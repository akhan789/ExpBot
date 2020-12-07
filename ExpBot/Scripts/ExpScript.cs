using EliteMMO.API;
using ExpBot.Model.EliteAPIWrappers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using static EliteMMO.API.EliteAPI;
using static ExpBot.Model.EliteAPIWrappers.APIConstants;

namespace ExpBot.Scripts
{
    public class ExpScript
    {
        public static bool running;
        private bool aggroed = false;
        // Use this Regex any time we need to compare an in-game thing vs an Enum name
        // e.g. Apururu vs Apururu (UC); or Mecisto. Mantle vs MecistoMantle.
        private const string EnumMatchingRegex = "[^a-zA-Z0-9]";
        private readonly PlayerWrapper player;
        private readonly TargetWrapper target;
        private readonly PartyWrapper party;
        public ExpScript(PlayerWrapper player, TargetWrapper target, PartyWrapper party)
        {
            this.player = player;
            this.target = target;
            this.party = party;
        }
        ~ExpScript()
        {
            ExpScript.running = false;
        }
        public void Run()
        {
            // Parameters - TODO: Make these all configurable via UI.
            TrustSpellId[] trusts = {
                TrustSpellId.Gessho,
                //TrustSpellId.ApururuUC,
                TrustSpellId.Cherukiki,
                TrustSpellId.ShantottoII,
                TrustSpellId.Kupofried,
                TrustSpellId.Selhteus
            };
            const uint RestMPP = 20;
            const uint PullSpell = (uint)BlackMagicSpellId.Stone;
            const int CureIIIHealHP = 80;
            const int CureIVHealHP = 50;
            const int CureVHealHP = 30;
            const int WeaponSkillTP = 1000;
            const TPAbilityId WeaponSkillId = TPAbilityId.Realmrazer;
            const double MeleeRange = 3.0d;
            const double PullDistance = 18.0d;
            const float PullSearchRadius = 50.0f;
            const string MonsterName = "Sinewy Matamata";
            float initialPlayerX = player.X;
            float initialPlayerY = player.Y;
            float initialPlayerZ = player.Z;

            // Start the aggro monitor thread.
            Thread aggroMonitorThread = new Thread(new ThreadStart(AggroMonitor));
            aggroMonitorThread.IsBackground = true;
            aggroMonitorThread.Start();

            // Actual Bot
            bool isMoving = false;
            bool isPulling = false;
            try
            {
                while (ExpScript.running)
                {
                    player.StopMovingBackward();
                    player.StopMovingForward();
                    switch (player.PlayerStatus)
                    {
                        case (uint)Status.Resting:
                            //Console.WriteLine("Player status: Resting");
                            player.Heal(); // Stand back up.
                            break;
                        case (uint)Status.Idle:
                            //Console.WriteLine("Player status: Idle");
                            if (IsRunningAndNotAggroed())
                            {
                                if (!isPulling)
                                {
                                    player.SetTarget(0);
                                    if (DistanceToLocation(initialPlayerX, initialPlayerY, initialPlayerZ) > 3.0f)
                                    {
                                        RunToIdleLocation(initialPlayerX, initialPlayerY, initialPlayerZ);
                                    }
                                    RestMPIfNecessary(RestMPP);
                                    // equip exp/cap point enhancing gear.
                                    HealHPIfNecessary(CureIIIHealHP, CureIVHealHP, CureVHealHP);
                                    SummonTrustsIfNecessary(trusts);
                                    int targetId;
                                    if ((targetId = player.GetClosestTargetIdByName(MonsterName, PullSearchRadius)) > 0)
                                    {
                                        player.SetTarget(targetId);
                                        //Console.WriteLine("Player SetTarget: " + targetId);
                                        //Console.WriteLine("Player isPulling: " + isPulling);
                                        isPulling = true;
                                    }
                                    else
                                    {
                                        //Console.WriteLine("Player isPulling: " + isPulling);
                                        isPulling = false;
                                    }
                                }
                                else
                                {
                                    if(target.HPP <= 0)
                                    {
                                        isPulling = false;
                                        continue;
                                    }
                                    player.FaceTarget(target.X, target.Z);
                                    if (!target.LockedOn)
                                    {
                                        player.LockOn(target);
                                    }
                                    //Console.WriteLine("Player LockOn");
                                    isMoving = MoveWithinPullDistance(target.Distance, PullDistance);
                                    if (!isMoving)
                                    {
                                        //Console.WriteLine("Player not moving");
                                        if (target.HPP <= 1)
                                        {
                                            int targetId;
                                            if ((targetId = player.GetClosestTargetIdByName(MonsterName, PullSearchRadius)) > 0)
                                            {
                                                player.SetTarget(targetId);
                                                //Console.WriteLine("Player SetTarget: " + targetId);
                                                continue;
                                            }
                                        }
                                        while (IsRunningAndNotAggroed() && !player.CastSpell(PullSpell, "<t>"))
                                        {
                                            Thread.Sleep(100);
                                        }
                                        if (target.LockedOn)
                                        {
                                            player.UnLockOn(target);
                                        }
                                        //Console.WriteLine("Player Unlock");
                                        RunToIdleLocation(initialPlayerX, initialPlayerY, initialPlayerZ);
                                        player.Attack(target);
                                        //Console.WriteLine("Player Attacking");
                                        isPulling = false;
                                        //Console.WriteLine("Player isPulling: " + isPulling);
                                    }
                                }
                            }
                            else
                            {
                                if (DistanceToLocation(initialPlayerX, initialPlayerY, initialPlayerZ) > 3.0f)
                                {
                                    RunToIdleLocation(initialPlayerX, initialPlayerY, initialPlayerZ);
                                }
                                uint targetId;
                                if (ExpScript.running && (targetId = player.GetAggroedTargetId()) > 0)
                                {
                                    player.SetTarget((int)targetId);
                                    //Console.WriteLine("Player SetTarget: " + targetId);
                                    if (target.HPP > 1)
                                    {
                                        player.Attack(target);
                                    }
                                    //Console.WriteLine("Player Attacking aggro");
                                }
                            }
                            break;
                        case (uint)Status.InCombat:
                            //Console.WriteLine("Player status: InCombat");
                            if (target.HPP > 1)
                            {
                                player.FaceTarget(target.X, target.Z);
                                isMoving = MoveWithinDistance(target.Distance, MeleeRange);
                                if (!isMoving)
                                {
                                    HealHPIfNecessary(CureIIIHealHP, CureIVHealHP, CureVHealHP);
                                    UseWeaponSkillIfNecessary(WeaponSkillTP, WeaponSkillId);
                                }
                            }
                            break;
                        case (uint)Status.Dead:
                            Console.WriteLine("Player status: Dead");
                            player.DeathWarp();
                            ExpScript.running = false; // Kill the bot, we're done.
                            break;
                        default:
                            Console.WriteLine("Undocumented Player Status: " + player.PlayerStatus);
                            break;
                    }

                    Thread.Sleep(500);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception thrown, stopping bot: " + e.Message);
            }
            finally
            {
                ExpScript.running = false;
                aggroMonitorThread.Join();
            }
            Console.WriteLine("Exp Bot has stopped running");
        }

        private bool IsRunningAndNotAggroed()
        {
            return ExpScript.running && !aggroed;
        }
        private void RunToIdleLocation(float idleX, float idleY, float idleZ)
        {
            RunToLocation(idleX, idleY, idleZ, 3.0f);
        }
        private void RunToLocation(float locationX, float locationY, float locationZ, float distanceRadius)
        {
            if (DistanceToLocation(locationX, locationY, locationZ) > distanceRadius)
            {
                player.Move(locationX, locationY, locationZ);
                Stopwatch stuckWatch = new Stopwatch();
                stuckWatch.Start();
                while (ExpScript.running && DistanceToLocation(locationX, locationY, locationZ) > distanceRadius)
                {
                    if (stuckWatch.ElapsedMilliseconds > 1000)
                    {
                        // Try again every second until we get to the actual location.
                        player.Stop();
                        RunToLocation(locationX, locationY, locationZ, distanceRadius);
                        return;
                    }
                    Thread.Sleep(100);
                }
                player.Stop();
            }
        }
        private bool MoveWithinPullDistance(double targetDistance, double distance)
        {
            if (targetDistance <= distance)
            {
                // Within distance.
                player.StopMovingBackward();
                player.StopMovingForward();
                Thread.Sleep(500); // Cast/JA delay after stopping movement.
                return false;
            }
            else if (targetDistance > distance + 0.5d)
            {
                player.StopMovingBackward();
                player.MoveForward();
                return true;
            }
            else if (targetDistance < distance - 0.5d)
            {
                player.StopMovingForward();
                player.MoveBackward();
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool MoveWithinDistance(double targetDistance, double distance)
        {
            if (targetDistance >= distance + 0.5d && targetDistance <= distance - 0.5d)
            {
                // Within distance.
                player.StopMovingBackward();
                player.StopMovingForward();
                return false;
            }
            else if (targetDistance > distance + 0.5d)
            {
                player.StopMovingBackward();
                player.MoveForward();
                return true;
            }
            else if (targetDistance < distance - 0.5d)
            {
                player.StopMovingForward();
                player.MoveBackward();
                return true;
            }
            else
            {
                return false;
            }
        }
        private void UseWeaponSkillIfNecessary(int weaponSkillTP, TPAbilityId weaponSkillId)
        {
            if (player.PlayerStatus == (uint)Status.InCombat &&
                player.TP >= weaponSkillTP &&
                player.HasTPAbility(weaponSkillId))
            {
                player.PerformWeaponSkill(weaponSkillId, "<t>");
            }
        }
        private void RestMPIfNecessary(uint restMPP)
        {
            if (IsRunningAndNotAggroed())
            {
                if (player.MPP <= restMPP)
                {
                    if (target.Id != 0)
                    {
                        player.SetTarget(0);
                    }
                    player.Heal();
                    while (IsRunningAndNotAggroed() && player.MPP < 100)
                    {
                        Thread.Sleep(100);
                    }
                }
            }
        }
        private void HealHPIfNecessary(int cureIIIHP, int cureIVHP, int cureVHP)
        {
            int partyMember = 0;
            foreach (PartyMember member in party.PartyMembers)
            {
                if (!ExpScript.running || player.PlayerStatus == (uint)Status.Idle && aggroed)
                {
                    break;
                }
                try
                {
                    if (member.CurrentHPP <= cureVHP && player.HasWhiteMagicSpell(WhiteMagicSpellId.CureV))
                    {
                        player.CastSpell((uint)WhiteMagicSpellId.CureV, "<p" + partyMember + ">");
                    }
                    else if (member.CurrentHPP <= cureIVHP && player.HasWhiteMagicSpell(WhiteMagicSpellId.CureIV))
                    {
                        player.CastSpell((uint)WhiteMagicSpellId.CureIV, "<p" + partyMember + ">");
                    }
                    else if (member.CurrentHPP <= cureIIIHP && player.HasWhiteMagicSpell(WhiteMagicSpellId.CureIII))
                    {
                        player.CastSpell((uint)WhiteMagicSpellId.CureIII, "<p" + partyMember + ">");
                    }
                }
                catch (Exception e)
                {
                    if (e.Message.Equals("Not enough MP"))
                    {
                        break;
                    }
                    else
                    {
                        throw e;
                    }
                }
                partyMember++;
            }
        }
        private void SummonTrustsIfNecessary(TrustSpellId[] trusts)
        {
            if (trusts?.Length <= 0)
            {
                return;
            }

            IList<PartyMember> partyMembers;
            while (IsRunningAndNotAggroed() && (partyMembers = party.PartyMembers)?.Count != 6)
            {
                foreach (TrustSpellId trust in trusts)
                {
                    bool alreadySummoned = false;
                    foreach (PartyMember member in partyMembers)
                    {
                        string memberName = Regex.Replace(member.Name, EnumMatchingRegex, "");
                        if (memberName.Equals(Regex.Replace(trust.ToString(), @"(UC?)", "")))
                        {
                            alreadySummoned = true;
                            break;
                        }
                    }
                    if (!alreadySummoned)
                    {
                        if (IsRunningAndNotAggroed() && player.PlayerStatus != (uint)Status.InCombat && player.GetSpellRecastRemaining((int)trust) != 0)
                        {
                            Thread.Sleep(100);
                        }
                        else
                        {
                            if (player.HasTrustSpell(trust))
                            {
                                player.CastSpell((uint)trust, "<me>");
                            }
                            else
                            {
                                throw new Exception("Trust not found: " + trust.ToString());
                            }

                            if (party.PartyMembers.Count == 6)
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }
        private double DistanceToLocation(float locationX, float locationY, float locationZ)
        {
            return Math.Truncate(Math.Sqrt(Math.Pow((locationX - player.X), 2.0d) + Math.Pow((locationZ - player.Z), 2.0d) + Math.Pow((locationY - player.Y), 2.0d)));
        }
        private void AggroMonitor()
        {
            while (ExpScript.running)
            {
                if (player.GetAggroedTargetId() > 0)
                {
                    aggroed = true;
                }
                else
                {
                    aggroed = false;
                }
                Thread.Sleep(100);
            }
        }
    }
}