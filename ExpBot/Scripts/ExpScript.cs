using EliteMMO.API;
using ExpBot.Model.EliteAPIWrappers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using static EliteMMO.API.EliteAPI;
using static ExpBot.Model.EliteAPIWrappers.APIConstants;

namespace ExpBot.Scripts
{
    public class ExpScript : IExpScript, INotifyPropertyChanged
    {
        // Use this Regex any time we need to compare an in-game thing vs an Enum name
        // e.g. Apururu vs Apururu (UC); or Mecisto. Mantle vs MecistoMantle.
        private const string EnumMatchingRegex = "[^a-zA-Z0-9]";
        private readonly PlayerWrapper player;
        private readonly TargetWrapper target;
        private readonly PartyWrapper party;

        private static Thread trizekRingReadyMonitor;
        private static Thread echadRingReadyMonitor;

        private volatile bool running;
        private volatile bool trizekRingReady = true;
        private volatile bool echadRingReady = true;
        private bool chaseTarget = true;
        private bool keepWithinMeleeRange = true;
        private bool restMP = true;
        private bool useWeaponSkill = true;
        private bool summonTrusts = true;
        private bool useCapPointEquipment = false;
        private bool useExpPointEquipment = false;
        private bool useAutoHeal;
        private bool pullWithSpell;
        private bool pullWithProvoke;
        private IList<string> targetNames = new List<string>();
        private IList<string> trustNames = new List<string>();
        private BlackMagicSpellId pullBlackMagicSpellId;
        private int restMPP = -1;
        private TPAbilityId weaponSkillId = TPAbilityId.RESERVED1;
        private int weaponSkillTP = 1000;
        private double meleeRange = 2.0d;
        private double pullDistance = 18.0d;
        private float pullSearchRadius = 50.0f;
        private float pullDelay = 4.0f;
        private float idleRadius = 1.0f;

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public ExpScript(PlayerWrapper player, TargetWrapper target, PartyWrapper party)
        {
            this.player = player;
            this.target = target;
            this.party = party;
        }
        public void Run()
        {
            IList<TrustSpellId> trusts = new List<TrustSpellId>();
            if (TrustNames?.Count > 0)
            {
                foreach (string name in TrustNames)
                {
                    Enum.TryParse(Regex.Replace(name, EnumMatchingRegex, ""), out TrustSpellId trustSpell);
                    trusts.Add(trustSpell);
                }
            }
            Location idleLocation = new Location(player.X, player.Y, player.Z);
            String skillchainLogText = null;
            Stopwatch skillchainTimer = new Stopwatch();
            Stopwatch magicBurstTimer = new Stopwatch();
            //Stopwatch nmCampWatch = new Stopwatch();
            //nmCampWatch.Start();
            //Console.WriteLine(DateTime.Now + ": Bot Started");
            // Actual Bot
            try
            {
                while (Running)
                {
                    //if (nmCampWatch.ElapsedMilliseconds >= TimeSpan.FromHours(5).TotalMilliseconds)
                    //{
                    //    Console.WriteLine(DateTime.Now + ": Bot Stopping");
                    //    break;
                    //}
                    //player.CastSpell((uint)WhiteMagicSpellId.Dia, "<t>");
                    //player.CastSpell((uint)BlueMagicSpellId.Bludgeon, "<t>");
                    switch (player.PlayerStatus)
                    {
                        case (uint)Status.Resting:
                            player.Heal(); // Stand back up.
                            break;
                        case (uint)Status.Idle:
                            player.StopMovingBackward();
                            player.StopMovingForward();
                            if (skillchainTimer.IsRunning)
                            {
                                skillchainTimer.Reset();
                            }
                            if (magicBurstTimer.IsRunning)
                            {
                                magicBurstTimer.Reset();
                                skillchainLogText = null;
                            }
                            if (IsRunningAndNotDeadOrAggroed())
                            {
                                if (!player.Pulling)
                                {
                                    player.SetTarget(0);
                                    player.Moving = false;
                                    RunToLocation(idleLocation, IdleRadius);
                                    SummonTrustsIfNecessary(trusts);
                                    RestMPIfNecessary();
                                    UseCapPointExpPointEquipmentIfNecessary();
                                    BuffIfNecessary();
                                    HealHPIfNecessary();
                                    RemoveStatusEffectsIfNecessary();
                                    if (party.GetAggroedTargetId() > 0)
                                    {
                                        continue;
                                    }
                                    else
                                    {
                                        int targetId;
                                        if ((targetId = player.GetClosestTargetIdByNames(TargetNames, PullSearchRadius)) > 0)
                                        {
                                            player.SetTarget(targetId);
                                            player.Pulling = true;
                                        }
                                        else
                                        {
                                            player.Pulling = false;
                                        }
                                    }
                                }
                                else
                                {
                                    if (target.Id == 0 || target.HPP <= 0)
                                    {
                                        player.Pulling = false;
                                        continue;
                                    }
                                    if (player.HasStatusEffect((short)APIConstants.StatusEffect.Gravity))
                                    {
                                        player.Pulling = false;
                                        continue;
                                    }
                                    if (PullWithSpell)
                                    {
                                        if (player.HasStatusEffect((short)APIConstants.StatusEffect.Silence))
                                        {
                                            player.Pulling = false;
                                            continue;
                                        }
                                    }
                                    player.FaceTarget(target.X, target.Z);
                                    if (!target.LockedOn)
                                    {
                                        player.LockOn(target);
                                    }
                                    player.Moving = MoveWithinPullDistance(target.Distance, PullDistance, true);
                                    if (IsRunningAndNotDeadOrAggroed() && !player.Moving)
                                    {
                                        if (target.HPP <= 1)
                                        {
                                            int targetId;
                                            if ((targetId = player.GetClosestTargetIdByNames(TargetNames, PullSearchRadius)) > 0)
                                            {
                                                player.SetTarget(targetId);
                                                continue;
                                            }
                                        }
                                        bool pullFailed = false;
                                        Stopwatch pullTimeoutWatch = new Stopwatch();
                                        if (PullWithSpell)
                                        {
                                            if (player.HasStatusEffect((short)APIConstants.StatusEffect.Silence))
                                            {
                                                player.Pulling = false;
                                                continue;
                                            }
                                            player.CastSpell((uint)PullBlackMagicSpellId, "<t>");
                                            pullTimeoutWatch.Start();
                                            while (IsRunningAndNotDeadOrAggroed() && target.TargetStatus != (uint)Status.InCombat)
                                            {
                                                Thread.Sleep(100);

                                                if (player.GetChatLog().Contains("Unable to see the"))
                                                {
                                                    player.Pulling = false;
                                                    pullFailed = true;
                                                    break;
                                                }
                                                if (target.Distance > PullDistance || target.HPP <= 0 ||
                                                    pullTimeoutWatch.ElapsedMilliseconds >= TimeSpan.FromSeconds(6).TotalMilliseconds)
                                                {
                                                    pullFailed = true;
                                                    break;
                                                }
                                            }
                                        }
                                        else if (PullWithProvoke)
                                        {
                                            player.PerformJobAbility((uint)JobAbilityId.Provoke, "<t>");
                                            pullTimeoutWatch.Start();
                                            while (IsRunningAndNotDeadOrAggroed() && target.TargetStatus != (uint)Status.InCombat)
                                            {
                                                Thread.Sleep(100);

                                                if (player.GetChatLog().Contains("Unable to see the"))
                                                {
                                                    player.Pulling = false;
                                                    pullFailed = true;
                                                    break;
                                                }
                                                if (target.Distance > PullDistance || target.HPP <= 0 ||
                                                    pullTimeoutWatch.ElapsedMilliseconds >= TimeSpan.FromSeconds(6).TotalMilliseconds)
                                                {
                                                    pullFailed = true;
                                                    break;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            player.PullWithRanged();
                                            pullTimeoutWatch.Start();
                                            while (IsRunningAndNotDeadOrAggroed() && target.TargetStatus != (uint)Status.InCombat)
                                            {
                                                Thread.Sleep(100);

                                                if (player.GetChatLog().Contains("Unable to see the"))
                                                {
                                                    player.Pulling = false;
                                                    pullFailed = true;
                                                    break;
                                                }
                                                if ((target.Distance > PullDistance || target.HPP <= 0) ||
                                                    pullTimeoutWatch.ElapsedMilliseconds >= TimeSpan.FromSeconds(6).TotalMilliseconds)
                                                {
                                                    pullFailed = true;
                                                    break;
                                                }
                                            }
                                        }
                                        if (party.GetAggroedTargetId() > 0 || pullFailed)
                                        {
                                            if (!ChaseTarget && pullFailed)
                                            {
                                                // If the pull failed because the mob went out of range, don't
                                                // chase after it. Run back and retarget.
                                                player.Pulling = false;
                                            }
                                            continue;
                                        }
                                        if (DistanceToLocation(idleLocation) > IdleRadius && target.LockedOn)
                                        {
                                            if (!player.UnLockOn(target))
                                            {
                                                continue;
                                            }
                                        }
                                        RunToLocation(idleLocation, IdleRadius);
                                        player.Attack(target);
                                        player.Pulling = false;
                                        Thread.Sleep(Convert.ToInt32(TimeSpan.FromSeconds(pullDelay).TotalMilliseconds));
                                    }
                                }
                            }
                            else
                            {
                                player.Moving = false;
                                player.Pulling = false;
                                if (DistanceToLocation(idleLocation) > IdleRadius && target.LockedOn)
                                {
                                    if (!player.UnLockOn(target))
                                    {
                                        continue;
                                    }
                                }
                                RunToLocation(idleLocation, IdleRadius);
                                if (target.Id > 0 && target.HPP > 1)
                                {
                                    player.Attack(target);
                                }
                                else
                                {
                                    int aggroedTargetId;
                                    if (IsRunningAndNotDead() && (aggroedTargetId = (int)party.GetAggroedTargetId()) > 0)
                                    {
                                        player.SetTarget((int)aggroedTargetId);
                                        if (target.HPP > 1)
                                        {
                                            player.Attack(target);
                                        }
                                    }
                                }
                            }
                            break;
                        case (uint)Status.InCombat:
                            if (target.HPP > 1)
                            {
                                player.FaceTarget(target.X, target.Z);
                                if (KeepWithinMeleeRange)
                                {
                                    player.Moving = MoveWithinDistance(target.Distance, MeleeRange, true);
                                    if (!player.Moving)
                                    {
                                        bool magicBurstSuccessful = false;
                                        if (!magicBurstTimer.IsRunning &&
                                            (skillchainLogText = player.GetChatLog()).Contains("Skillchain:"))
                                        {
                                            magicBurstTimer.Start();
                                            Console.WriteLine("Magic Burst timer starting");
                                        }
                                        if (magicBurstTimer.IsRunning)
                                        {
                                            Console.WriteLine("Performing magic burst for log: " + skillchainLogText);
                                            magicBurstSuccessful = PerformMagicBurstIfAvailable(skillchainLogText);
                                            if (!magicBurstSuccessful ||
                                            magicBurstTimer.ElapsedMilliseconds >= TimeSpan.FromSeconds(10).TotalMilliseconds)
                                            {
                                                magicBurstTimer.Reset();
                                                skillchainLogText = null;
                                                Console.WriteLine("Magic Burst timer stopped");
                                            }
                                        }
                                        BuffIfNecessary();
                                        HealHPIfNecessary();
                                        RemoveStatusEffectsIfNecessary();
                                        if (target.Distance > MeleeRange + 0.5d)
                                        {
                                            continue;
                                        }
                                        else
                                        {
                                            if (skillchainTimer.IsRunning)
                                            {
                                                long elapsedSeconds = skillchainTimer.ElapsedMilliseconds;
                                                if (elapsedSeconds >= TimeSpan.FromSeconds(5).TotalMilliseconds)
                                                {
                                                    Console.WriteLine("Stopping Skillchain Timer");
                                                    skillchainTimer.Reset();
                                                }
                                                else if (elapsedSeconds >= TimeSpan.FromSeconds(2).TotalMilliseconds)
                                                {
                                                    Console.WriteLine("Ending Darkness Skillchain - Performing Sinker Drill");
                                                    player.CastSpell((uint)BlueMagicSpellId.SinkerDrill, "<t>");
                                                    skillchainTimer.Reset();
                                                }
                                            }
                                            else if (!skillchainTimer.IsRunning &&
                                                player.MainJob == (byte)Job.BlueMage &&
                                                player.TP >= WeaponSkillTP)
                                            {
                                                if (player.CanCastSpell((uint)BlueMagicSpellId.SinkerDrill) &&
                                                    player.PerformJobAbility((uint)JobAbilityId.ChainAffinity, "<me>"))
                                                {
                                                    Console.WriteLine("Starting Darkness Skillchain - Performing Chant Du Cygne");
                                                    UseWeaponSkillIfNecessary(WeaponSkillTP, WeaponSkillId);
                                                    skillchainTimer.Start();
                                                }
                                                else
                                                {
                                                    UseWeaponSkillIfNecessary(WeaponSkillTP, WeaponSkillId);
                                                }
                                            }
                                            else
                                            {
                                                UseWeaponSkillIfNecessary(WeaponSkillTP, WeaponSkillId);
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    bool magicBurstSuccessful = false;
                                    if (!magicBurstTimer.IsRunning &&
                                        (skillchainLogText = player.GetChatLog()).Contains("Skillchain:"))
                                    {
                                        magicBurstTimer.Start();
                                        Console.WriteLine("Magic Burst timer starting");
                                    }
                                    if (magicBurstTimer.IsRunning)
                                    {
                                        Console.WriteLine("Performing magic burst for log: " + skillchainLogText);
                                        magicBurstSuccessful = PerformMagicBurstIfAvailable(skillchainLogText);
                                        if (!magicBurstSuccessful ||
                                        magicBurstTimer.ElapsedMilliseconds >= TimeSpan.FromSeconds(10).TotalMilliseconds)
                                        {
                                            magicBurstTimer.Reset();
                                            skillchainLogText = null;
                                            Console.WriteLine("Magic Burst timer stopped");
                                        }
                                    }
                                    BuffIfNecessary();
                                    HealHPIfNecessary();
                                    RemoveStatusEffectsIfNecessary();
                                    if (skillchainTimer.IsRunning)
                                    {
                                        long elapsedSeconds = skillchainTimer.ElapsedMilliseconds;
                                        if (elapsedSeconds >= TimeSpan.FromSeconds(5).TotalMilliseconds)
                                        {
                                            Console.WriteLine("Stopping Skillchain Timer");
                                            skillchainTimer.Reset();
                                        }
                                        else if (elapsedSeconds >= TimeSpan.FromSeconds(2).TotalMilliseconds)
                                        {
                                            Console.WriteLine("Ending Darkness Skillchain - Performing Sinker Drill");
                                            player.CastSpell((uint)BlueMagicSpellId.SinkerDrill, "<t>");
                                            skillchainTimer.Reset();
                                        }
                                    }
                                    if (player.MainJob == (byte)Job.BlueMage &&
                                        player.TP >= WeaponSkillTP)
                                    {
                                        if (player.CanCastSpell((uint)BlueMagicSpellId.SinkerDrill) &&
                                            player.PerformJobAbility((uint)JobAbilityId.ChainAffinity, "<me>"))
                                        {
                                            Console.WriteLine("Starting Darkness Skillchain - Performing Chant Du Cygne");
                                            UseWeaponSkillIfNecessary(WeaponSkillTP, WeaponSkillId);
                                            skillchainTimer.Start();
                                        }
                                        else
                                        {
                                            UseWeaponSkillIfNecessary(WeaponSkillTP, WeaponSkillId);
                                        }
                                    }
                                    else
                                    {
                                        UseWeaponSkillIfNecessary(WeaponSkillTP, WeaponSkillId);
                                    }
                                }
                            }
                            break;
                        case (uint)Status.Dead:
                        case (uint)Status.Dying:
                            if (skillchainTimer.IsRunning)
                            {
                                skillchainTimer.Reset();
                            }
                            if (magicBurstTimer.IsRunning)
                            {
                                magicBurstTimer.Reset();
                                skillchainLogText = null;
                            }
                            Console.WriteLine(DateTime.Now + ": Player status: Dead");
                            player.DeathWarp();
                            Running = false; // Kill the bot, we're done.
                            break;
                        default:
                            Console.WriteLine("Undocumented Player Status: " + player.PlayerStatus);
                            break;
                    }
                    Thread.Sleep(750);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception thrown, stopping bot: " + e.Message);
            }
            finally
            {
                player.Stop();
                player.StopMovingBackward();
                player.StopMovingForward();
                if (trizekRingReadyMonitor != null &&
                    !trizekRingReadyMonitor.Join(2000))
                {
                    trizekRingReadyMonitor.Interrupt();
                    if (!trizekRingReadyMonitor.Join(2000))
                    {
                        trizekRingReadyMonitor.Abort();
                    }
                }
                if (echadRingReadyMonitor != null &&
                    !echadRingReadyMonitor.Join(2000))
                {
                    echadRingReadyMonitor.Interrupt();
                    if (!echadRingReadyMonitor.Join(2000))
                    {
                        echadRingReadyMonitor.Abort();
                    }
                }
                Running = false;
            }
            Console.WriteLine("Exp Bot has stopped running");
        }
        private bool IsRunningAndNotDeadOrAggroed()
        {
            return IsRunningAndNotDead() && !(party.GetAggroedTargetId() > 0);
        }
        private bool IsRunningAndNotDead()
        {
            return Running && !player.IsDead();
        }
        private double DistanceToLocation(Location location)
        {
            return Math.Truncate(Math.Sqrt(Math.Pow((location.X - player.X), 2.0d) + Math.Pow((location.Z - player.Z), 2.0d) + Math.Pow((location.Y - player.Y), 2.0d)));
        }
        private void RunToLocation(Location location, float distanceRadius)
        {
            if (Running)
            {
                if (DistanceToLocation(location) > distanceRadius)
                {
                    player.Move(location.X, location.Y, location.Z);
                    Stopwatch stuckWatch = new Stopwatch();
                    stuckWatch.Start();
                    while (IsRunningAndNotDead() && DistanceToLocation(location) > distanceRadius)
                    {
                        if (stuckWatch.ElapsedMilliseconds > 5000)
                        {
                            // Try again every second until we get to the actual location.
                            player.Stop();
                            if (target.LockedOn)
                            {
                                player.UnLockOn(target);
                            }
                            RunToLocation(location, distanceRadius);
                            return;
                        }
                        Thread.Sleep(100);
                    }
                    player.Stop();
                }
            }
        }
        private bool MoveWithinPullDistance(double targetDistance, double distance, bool checkLockOn)
        {
            if (IsRunningAndNotDeadOrAggroed())
            {
                if (checkLockOn && target.LockedOn == false)
                {
                    return false;
                }

                if (targetDistance <= distance)
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
            else
            {
                return false;
            }
        }
        private bool MoveWithinDistance(double targetDistance, double distance, bool checkLockOn)
        {
            if (Running)
            {
                if (checkLockOn && target.LockedOn == false)
                {
                    return false;
                }

                if ((distance + 0.5d) >= targetDistance && (distance - 0.5d) <= targetDistance)
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
            else
            {
                return false;
            }
        }
        private void UseWeaponSkillIfNecessary(int weaponSkillTP, TPAbilityId weaponSkillId)
        {
            if (Running && UseWeaponSkill)
            {
                if (weaponSkillTP <= 0 || weaponSkillId == TPAbilityId.RESERVED1)
                {
                    return;
                }
                if (player.PlayerStatus == (uint)Status.InCombat &&
                    player.TP >= weaponSkillTP &&
                    player.HasWeaponSkill(weaponSkillId))
                {
                    player.PerformWeaponSkill(weaponSkillId, "<t>");
                }
            }
        }
        private bool PerformMagicBurstIfAvailable(string skillchainLogText)
        {
            if (skillchainLogText == null || skillchainLogText.Length == 0)
            {
                return false;
            }
            else
            {
                if (skillchainLogText.Contains("Light") ||
                    skillchainLogText.Contains("Fusion") ||
                    skillchainLogText.Contains("Liquefaction"))
                {
                    if (player.CanCastSpell((uint)BlackMagicSpellId.FireII))
                    {
                        return player.CastSpell((uint)BlackMagicSpellId.FireII, "<t>");
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (skillchainLogText.Contains("Darkness") ||
                    skillchainLogText.Contains("Distortion") ||
                    skillchainLogText.Contains("Induration"))
                {
                    if (player.CanCastSpell((uint)BlackMagicSpellId.FireII))
                    {
                        return player.CastSpell((uint)BlackMagicSpellId.BlizzardII, "<t>");
                    }
                    else if (player.MainJob == (byte)Job.BlueMage)
                    {

                        if (player.PerformJobAbility((uint)JobAbilityId.BurstAffinity, "<me>"))
                        {
                            return player.CanCastSpell((uint)BlueMagicSpellId.IceBreak) &&
                                player.CastSpell((uint)BlueMagicSpellId.IceBreak, "<t>");
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (skillchainLogText.Contains("Fragmentation") ||
                    skillchainLogText.Contains("Impaction"))
                {
                    if (player.CanCastSpell((uint)BlackMagicSpellId.FireII))
                    {
                        return player.CastSpell((uint)BlackMagicSpellId.ThunderII, "<t>");
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (skillchainLogText.Contains("Gravitation") ||
                    skillchainLogText.Contains("Scission"))
                {
                    if (player.CanCastSpell((uint)BlackMagicSpellId.FireII))
                    {
                        return player.CastSpell((uint)BlackMagicSpellId.StoneII, "<t>");
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (skillchainLogText.Contains("Reverberation"))
                {
                    if (player.CanCastSpell((uint)BlackMagicSpellId.FireII))
                    {
                        return player.CastSpell((uint)BlackMagicSpellId.WaterII, "<t>");
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (skillchainLogText.Contains("Detonation"))
                {
                    if (player.CanCastSpell((uint)BlackMagicSpellId.FireII))
                    {
                        return player.CastSpell((uint)BlackMagicSpellId.AeroII, "<t>");
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }
        private void RestMPIfNecessary()
        {
            if (!IsRunningAndNotDeadOrAggroed() || RestMPP <= 0)
            {
                return;
            }
            if (player.MPP <= RestMPP)
            {
                if (target.Id != 0)
                {
                    player.SetTarget(0);
                }
                uint initialMP = player.MP;
                player.Heal();
                Stopwatch restartRestMPPTimeout = new Stopwatch();
                restartRestMPPTimeout.Start();
                Stopwatch restMPPTimeout = new Stopwatch();
                restMPPTimeout.Start();
                while (IsRunningAndNotDeadOrAggroed() && player.MPP < 100)
                {
                    // If it's been 25 seconds, and the MP is still the same as it was
                    // when we started resting. The Rest failed. Try again.
                    if (restMPPTimeout.ElapsedMilliseconds >= TimeSpan.FromSeconds(25.0).TotalMilliseconds &&
                        player.MP <= initialMP)
                    {
                        RestMPIfNecessary();
                        return;
                    }
                    // 5 min timeout. Something gone wrong if it's still resting after 5mins.
                    if (restMPPTimeout.ElapsedMilliseconds >= TimeSpan.FromSeconds(300.0).TotalMilliseconds)
                    {
                        break;
                    }
                    Thread.Sleep(100);
                }
                player.Heal(); // Get back up.
            }
        }
        private void UseCapPointExpPointEquipmentIfNecessary()
        {
            if (!IsRunningAndNotDeadOrAggroed())
            {
                return;
            }
            if ((UseCapPointEquipment || UseExpPointEquipment))
            {
                ItemId currentRing1ItemId = (ItemId)player.GetEquippedItem(SlotId.Ring1).Id;
                if (UseCapPointEquipment && trizekRingReady)
                {
                    if (trizekRingReady && !player.HasStatusEffect((short)APIConstants.StatusEffect.Commitment))
                    {
                        if (!((player.IsEquippedItem(SlotId.Ring1, ItemId.TrizekRing) ||
                            player.IsEquippedItem(SlotId.Ring2, ItemId.TrizekRing))))
                        {
                            player.EquipItem(SlotId.Ring1, ItemId.TrizekRing);
                        }
                        bool itemUsed = player.UseItem(ItemId.TrizekRing, "<me>");
                        if (itemUsed)
                        {
                            if (trizekRingReadyMonitor != null)
                            {
                                trizekRingReadyMonitor.Interrupt();
                                if (!trizekRingReadyMonitor.Join(2000))
                                {
                                    trizekRingReadyMonitor.Abort();
                                }
                                trizekRingReadyMonitor = null;
                            }
                            trizekRingReadyMonitor = new Thread(delegate () { TrizekRingReadyMonitor(); })
                            {
                                IsBackground = true
                            };
                            trizekRingReadyMonitor.Start();
                        }
                    }
                    player.EquipItem(SlotId.Ring1, currentRing1ItemId);
                }
                if (UseExpPointEquipment && echadRingReady)
                {
                    if (!player.HasStatusEffect((short)APIConstants.StatusEffect.Dedication) ||
                        (party.IsPartyMemberPresent("Kupofried") &&
                        player.CountStatusEffect((short)APIConstants.StatusEffect.Dedication) == 1))
                    {
                        if (!((player.IsEquippedItem(SlotId.Ring1, ItemId.EchadRing) ||
                            player.IsEquippedItem(SlotId.Ring2, ItemId.EchadRing))))
                        {
                            player.EquipItem(SlotId.Ring1, ItemId.EchadRing);
                        }
                        bool itemUsed = player.UseItem(ItemId.EchadRing, "<me>");
                        if (itemUsed)
                        {
                            if (echadRingReadyMonitor != null)
                            {
                                echadRingReadyMonitor.Interrupt();
                                if (!echadRingReadyMonitor.Join(2000))
                                {
                                    echadRingReadyMonitor.Abort();
                                }
                                echadRingReadyMonitor = null;
                            }
                            echadRingReadyMonitor = new Thread(delegate () { EchadRingReadyMonitor(); })
                            {
                                IsBackground = true
                            };
                            echadRingReadyMonitor.Start();
                        }
                        player.EquipItem(SlotId.Ring1, currentRing1ItemId);
                    }
                }
            }
        }
        private void BuffIfNecessary()
        {
            if (IsRunningAndNotDeadOrAggroed() || (Running && player.PlayerStatus == (uint)Status.InCombat))
            {
                if (player.MainJob == (byte)Job.Geomancer ||
                    player.SubJob == (byte)Job.Geomancer)
                {
                    if ((!player.HasStatusEffect((short)APIConstants.StatusEffect.AccuracyBoost) ||
                        player.PetHPP == 0) &&
                        player.CanCastSpell((uint)GeomancySpellId.GeoPrecision))
                    {
                        player.CastSpell((uint)GeomancySpellId.GeoPrecision, "<me>");
                    }
                    if (!player.HasStatusEffect((short)APIConstants.StatusEffect.ColureActive) &&
                        player.CanCastSpell((uint)GeomancySpellId.IndiPrecision))
                    {
                        player.CastSpell((uint)GeomancySpellId.IndiPrecision, "<me>");
                    }
                }
                if (player.MainJob == (byte)Job.RedMage && player.MainJobLevel >= 99)
                {
                    if (!player.HasStatusEffect((short)APIConstants.StatusEffect.Composure))
                    {
                        player.PerformJobAbility((uint)JobAbilityId.Composure, "<me>");
                    }
                    if (!player.HasStatusEffect((short)APIConstants.StatusEffect.Refresh) &&
                        player.CanCastSpell((uint)WhiteMagicSpellId.RefreshIII))
                    {
                        player.CastSpell((uint)WhiteMagicSpellId.RefreshIII, "<me>");
                    }
                    if (!player.HasStatusEffect((short)APIConstants.StatusEffect.Regen) &&
                        player.CanCastSpell((uint)WhiteMagicSpellId.RegenII))
                    {
                        player.CastSpell((uint)WhiteMagicSpellId.RegenII, "<me>");
                    }
                    if (!player.HasStatusEffect((short)APIConstants.StatusEffect.Haste) &&
                        player.CanCastSpell((uint)WhiteMagicSpellId.HasteII))
                    {
                        player.CastSpell((uint)WhiteMagicSpellId.HasteII, "<me>");
                    }
                    if (!player.HasStatusEffect((short)APIConstants.StatusEffect.Enthunder) &&
                        player.CanCastSpell((uint)WhiteMagicSpellId.Enthunder))
                    {
                        player.CastSpell((uint)WhiteMagicSpellId.Enthunder, "<me>");
                    }
                    if (!player.HasStatusEffect((short)APIConstants.StatusEffect.Temper) &&
                        player.CanCastSpell((uint)WhiteMagicSpellId.TemperII))
                    {
                        player.CastSpell((uint)WhiteMagicSpellId.TemperII, "<me>");
                    }
                    if (!player.HasStatusEffect((short)APIConstants.StatusEffect.GainMND) &&
                        player.CanCastSpell((uint)WhiteMagicSpellId.GainMND))
                    {
                        player.CastSpell((uint)WhiteMagicSpellId.GainMND, "<me>");
                    }
                    if (!player.HasStatusEffect((short)APIConstants.StatusEffect.IceSpikes) &&
                        player.CanCastSpell((uint)BlackMagicSpellId.IceSpikes))
                    {
                        player.CastSpell((uint)BlackMagicSpellId.IceSpikes, "<me>");
                    }
                    if (!player.HasStatusEffect((short)APIConstants.StatusEffect.Stoneskin) &&
                        player.CanCastSpell((uint)WhiteMagicSpellId.Stoneskin))
                    {
                        player.CastSpell((uint)WhiteMagicSpellId.Stoneskin, "<me>");
                    }
                    if (!player.HasStatusEffect((short)APIConstants.StatusEffect.Blink) &&
                        player.CanCastSpell((uint)WhiteMagicSpellId.Blink))
                    {
                        player.CastSpell((uint)WhiteMagicSpellId.Blink, "<me>");
                    }
                    if (!player.HasStatusEffect((short)APIConstants.StatusEffect.Phalanx) &&
                        player.CanCastSpell((uint)WhiteMagicSpellId.Phalanx))
                    {
                        player.CastSpell((uint)WhiteMagicSpellId.Phalanx, "<me>");
                    }
                    if (!player.HasStatusEffect((short)APIConstants.StatusEffect.Aquaveil) &&
                        player.CanCastSpell((uint)WhiteMagicSpellId.Aquaveil))
                    {
                        player.CastSpell((uint)WhiteMagicSpellId.Aquaveil, "<me>");
                    }
                    if (!player.HasStatusEffect((short)APIConstants.StatusEffect.Barfire) &&
                        player.CanCastSpell((uint)WhiteMagicSpellId.Barfire))
                    {
                        player.CastSpell((uint)WhiteMagicSpellId.Barfire, "<me>");
                    }
                    if (!player.HasStatusEffect((short)APIConstants.StatusEffect.Barparalyze) &&
                        player.CanCastSpell((uint)WhiteMagicSpellId.Barparalyze))
                    {
                        player.CastSpell((uint)WhiteMagicSpellId.Barparalyze, "<me>");
                    }
                }
                if (((player.MainJob == (byte)Job.Dancer &&
                    player.MainJobLevel >= 45) ||
                    (player.SubJob == (byte)Job.Dancer &&
                    player.SubJobLevel >= 45)) &&
                    player.TP >= 350)
                {
                    if (!player.HasStatusEffect((short)APIConstants.StatusEffect.HasteSamba))
                    {
                        player.PerformJobAbility((uint)TPAbilityId.HasteSamba, "<me>");
                    }
                }
            }
        }
        private void RemoveStatusEffectsIfNecessary()
        {
            if (IsRunningAndNotDeadOrAggroed() || (player.PlayerStatus == (uint)Status.InCombat))
            {
                if (((player.MainJob == (byte)Job.Dancer &&
                    player.MainJobLevel >= 35) ||
                    (player.SubJob == (byte)Job.Dancer &&
                    player.SubJobLevel >= 35)) &&
                    player.TP >= 200)
                {
                    if (player.HasStatusEffect((short)APIConstants.StatusEffect.Silence) ||
                        player.HasStatusEffect((short)APIConstants.StatusEffect.Poison) ||
                        player.HasStatusEffect((short)APIConstants.StatusEffect.Gravity) ||
                        player.HasStatusEffect((short)APIConstants.StatusEffect.Blind) ||
                        player.HasStatusEffect((short)APIConstants.StatusEffect.Plague))
                    {
                        player.PerformJobAbility((uint)TPAbilityId.HealingWaltz, "<me>");
                    }
                }
            }
        }
        private void HealHPIfNecessary()
        {
            if (!UseAutoHeal)
            {
                return;
            }

            if (IsRunningAndNotDeadOrAggroed() || (Running && player.PlayerStatus == (uint)Status.InCombat))
            {
                int partyMember = 0;
                foreach (PartyMember member in party.PartyMembers)
                {
                    if (!Running || player.PlayerStatus == (uint)Status.Idle && party.GetAggroedTargetId() > 0)
                    {
                        break;
                    }
                    try
                    {
                        HealMember(member, partyMember);
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
        }
        private void HealMember(PartyMember member, int memberIndex)
        {
            const int CureIIIHealHPP = 80;
            const int CureIVHealHPP = 50;
            const int CureVHealHPP = 30;
            if (member.CurrentHPP <= CureVHealHPP)
            {
                if (player.CanCastSpell((uint)WhiteMagicSpellId.CureV))
                {
                    Console.WriteLine(DateTime.Now + ": Member HPP: " + member.CurrentHPP + " Casting spell Cure 5");
                    player.CastSpell((uint)WhiteMagicSpellId.CureV, "<p" + memberIndex + ">");
                }
                else if (player.MainJob == (byte)Job.Dancer &&
                    player.MainJobLevel >= 70 &&
                    player.TP >= 650)
                {
                    player.PerformJobAbility((uint)TPAbilityId.CuringWaltzIV, "<p" + memberIndex + ">");
                }
                else if (player.SubJob == (byte)Job.Dancer &&
                    player.SubJobLevel >= 45 &&
                    player.TP >= 500)
                {
                    player.PerformJobAbility((uint)TPAbilityId.CuringWaltzIII, "<p" + memberIndex + ">");
                }
            }
            if (member.CurrentHPP <= CureIVHealHPP)
            {
                if (player.CanCastSpell((uint)WhiteMagicSpellId.CureIV))
                {
                    Console.WriteLine(DateTime.Now + ": Member HPP: " + member.CurrentHPP + " Casting spell Cure 4");
                    player.CastSpell((uint)WhiteMagicSpellId.CureIV, "<p" + memberIndex + ">");
                }
                else if (player.MainJob == (byte)Job.Dancer &&
                    player.MainJobLevel >= 45 &&
                    player.TP >= 500)
                {
                    player.PerformJobAbility((uint)TPAbilityId.CuringWaltzIII, "<p" + memberIndex + ">");
                }
                else if (player.SubJob == (byte)Job.Dancer &&
                    player.SubJobLevel >= 45 &&
                    player.TP >= 500)
                {
                    player.PerformJobAbility((uint)TPAbilityId.CuringWaltzIII, "<p" + memberIndex + ">");
                }
            }
            if (member.CurrentHPP <= CureIIIHealHPP)
            {
                if (player.CanCastSpell((uint)WhiteMagicSpellId.CureIII))
                {
                    Console.WriteLine(DateTime.Now + ": Member HPP: " + member.CurrentHPP + " Casting spell Cure 3");
                    player.CastSpell((uint)WhiteMagicSpellId.CureIII, "<p" + memberIndex + ">");
                }
                else if (player.MainJob == (byte)Job.Dancer &&
                    player.MainJobLevel >= 30 &&
                    player.TP >= 350)
                {
                    player.PerformJobAbility((uint)TPAbilityId.CuringWaltzII, "<p" + memberIndex + ">");
                }
                else if (player.SubJob == (byte)Job.Dancer &&
                    player.SubJobLevel >= 30 &&
                    player.TP >= 350)
                {
                    player.PerformJobAbility((uint)TPAbilityId.CuringWaltzII, "<p" + memberIndex + ">");
                }
            }
        }
        private void SummonTrustsIfNecessary(IList<TrustSpellId> trusts)
        {
            if(!SummonTrusts)
            {
                return;
            }
            if (!IsRunningAndNotDeadOrAggroed())
            {
                return;
            }

            if (trusts?.Count <= 0 || party.PartyMembers?.Count == 6)
            {
                return;
            }

            IList<PartyMember> partyMembers;
            while (IsRunningAndNotDeadOrAggroed() && (partyMembers = party.PartyMembers)?.Count != 6)
            {
                Console.WriteLine(DateTime.Now + ": Summoning Trusts");
                foreach (TrustSpellId trust in trusts)
                {
                    if (IsRunningAndNotDeadOrAggroed())
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
                            if (player.PlayerStatus != (uint)Status.InCombat && player.GetSpellRecastRemaining((int)trust) != 0)
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
                    else
                    {
                        Console.WriteLine(DateTime.Now + ": Aggro detected while attempting to summon trusts");
                        return;
                    }
                }
            }
        }
        private void TrizekRingReadyMonitor()
        {
            trizekRingReady = false;
            Stopwatch readyStopWatch = new Stopwatch();
            readyStopWatch.Start();
            while (Running)
            {
                try
                {
                    if (readyStopWatch.ElapsedMilliseconds >= TimeSpan.FromSeconds(player.GetItem(ItemId.TrizekRing).RecastDelay).TotalMilliseconds)
                    {
                        trizekRingReady = true;
                        return;
                    }
                    Thread.Sleep(100);
                }
                catch (ThreadInterruptedException)
                {
                    break;
                }
            }
        }
        private void EchadRingReadyMonitor()
        {
            echadRingReady = false;
            Stopwatch readyStopWatch = new Stopwatch();
            readyStopWatch.Start();
            while (Running)
            {
                try
                {
                    if (readyStopWatch.ElapsedMilliseconds >= TimeSpan.FromSeconds(player.GetItem(ItemId.EchadRing).RecastDelay).TotalMilliseconds)
                    {
                        echadRingReady = true;
                        return;
                    }
                    Thread.Sleep(100);
                }
                catch (ThreadInterruptedException)
                {
                    break;
                }
            }
        }
        public bool Running
        {
            get => running;
            set
            {
                running = value;
                OnPropertyChanged("Running");
            }
        }
        public bool ChaseTarget
        {
            get => chaseTarget;
            set => chaseTarget = value;
        }
        public bool KeepWithinMeleeRange
        {
            get => keepWithinMeleeRange;
            set => keepWithinMeleeRange = value;
        }
        public bool RestMP
        {
            get => restMP;
            set => restMP = value;
        }
        public bool UseWeaponSkill
        {
            get => useWeaponSkill;
            set => useWeaponSkill = value;
        }
        public bool SummonTrusts
        {
            get => summonTrusts;
            set => summonTrusts = value;
        }
        public bool UseCapPointEquipment
        {
            get => useCapPointEquipment;
            set => useCapPointEquipment = value;
        }
        public bool UseExpPointEquipment
        {
            get => useExpPointEquipment;
            set => useExpPointEquipment = value;
        }
        public bool UseAutoHeal
        {
            get => useAutoHeal;
            set => useAutoHeal = value;
        }
        public bool PullWithSpell
        {
            get => pullWithSpell;
            set => pullWithSpell = value;
        }
        public bool PullWithProvoke
        {
            get => pullWithProvoke;
            set => pullWithProvoke = value;
        }
        public IList<string> TargetNames
        {
            get => targetNames;
            set => targetNames = value;
        }
        public IList<string> TrustNames
        {
            get => trustNames;
            set => trustNames = value;
        }
        public BlackMagicSpellId PullBlackMagicSpellId
        {
            get => pullBlackMagicSpellId;
            set => pullBlackMagicSpellId = value;
        }
        public int RestMPP
        {
            get => restMPP;
            set => restMPP = value;
        }
        public TPAbilityId WeaponSkillId
        {
            get => weaponSkillId;
            set => weaponSkillId = value;
        }
        public int WeaponSkillTP
        {
            get => weaponSkillTP;
            set => weaponSkillTP = value;
        }
        public double MeleeRange
        {
            get => meleeRange;
            set => meleeRange = value;
        }
        public double PullDistance
        {
            get => pullDistance;
            set => pullDistance = value;
        }
        public float PullSearchRadius
        {
            get => pullSearchRadius;
            set => pullSearchRadius = value;
        }
        public float PullDelay
        {
            get => pullDelay;
            set => pullDelay = value;
        }
        public float IdleRadius
        {
            get => idleRadius;
            set => idleRadius = value;
        }

        private class Location
        {
            private float x;
            private float y;
            private float z;
            public Location(float locationX, float locationY, float locationZ)
            {
                X = locationX;
                Y = locationY;
                Z = locationZ;
            }
            public float X
            {
                get => x;
                set => x = value;
            }
            public float Y
            {
                get => y;
                set => y = value;
            }
            public float Z
            {
                get => z;
                set => z = value;
            }
        }
    }
}