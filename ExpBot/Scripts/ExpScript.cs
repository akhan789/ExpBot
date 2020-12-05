using EliteMMO.API;
using ExpBot.Model.EliteAPIWrappers;
using System;
using System.Collections;
using System.Collections.Generic;
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
                TrustSpellId.ApururuUC,
                TrustSpellId.ShantottoII,
                TrustSpellId.Kupofried,
                TrustSpellId.Selhteus
            };
            const int CureIIIHealHP = 80;
            const int CureIVHealHP = 50;
            const int CureVHealHP = 30;
            const int WeaponSkillTP = 1000;
            const TPAbilityId WeaponSkillId = TPAbilityId.Realmrazer;
            const double MeleeRange = 3.0d;
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
            while (ExpScript.running)
            {
                player.StopMovingBackward();
                player.StopMovingForward();
                switch (player.PlayerStatus)
                {
                    case (uint)Status.Resting:
                        player.Heal(); // Stand back up.
                        goto case (uint)Status.Idle;
                    case (uint)Status.Idle:
                        if (IsRunningAndNotAggroed())
                        {
                            //player.SetTarget(0);
                            // equip exp/cap point enhancing gear.
                            HealHPIfNecessary(CureIIIHealHP, CureIVHealHP, CureVHealHP);
                            SummonTrustsIfNecessary(trusts);
                            // check hp, heal if necessary.
                            // find target to attack.
                            // run to target
                            // attack target
                            // goto case incombat? or just wait 2000
                        }
                        else
                        {
                            uint targetId;
                            if ((targetId = player.GetAggroedTargetId().TargetID) > 0)
                            {
                                player.SetTarget((int)targetId);
                                player.FaceTarget(target);
                                player.Attack(target);
                            }
                        }
                        break;
                    case (uint)Status.InCombat:
                        if (target.HPP > 1)
                        {
                            player.FaceTarget(target);
                            isMoving = MoveWithinMeleeRange(MeleeRange);
                            if (!isMoving)
                            {
                                HealHPIfNecessary(CureIIIHealHP, CureIVHealHP, CureVHealHP);
                                UseWeaponSkillIfNecessary(WeaponSkillTP, WeaponSkillId);
                            }
                        }
                        break;
                    case (uint)Status.Dead:
                        player.DeathWarp();
                        ExpScript.running = false; // Kill the bot, we're done.
                        break;
                    default:
                        Console.WriteLine("Undocumented Player Status: " + player.PlayerStatus);
                        break;
                }

                Thread.Sleep(500);
                //ExpScript.running = false;

                //bool targetSet = player.Target.SetTarget(player.GetClosestTargetIdByName(MonsterName));
                //if (targetSet)
                //{
                //    Console.WriteLine(targetSet);
                //}
                //Thread.Sleep(2000);
                //ExpScript.running = false;
                //player.SendAttack();
                //Console.WriteLine("Player status: " + player.PlayerStatus.ToString());
                //Console.WriteLine("Target Id: " + target.Id);
                //Console.WriteLine("Target name: " + target.Name);
                //Console.WriteLine("Target HPP: " + target.HPP);
                //Console.WriteLine("Has ability Realmrazer: " + player.HasTPAbility(APIConstants.TPAbilityId.Realmrazer));
                //Console.WriteLine("Has ability Combo: " + player.HasTPAbility(APIConstants.TPAbilityId.Combo));
                //Console.WriteLine("Has ability Drain Samba: " + player.HasTPAbility(APIConstants.TPAbilityId.DrainSamba));
                //Console.WriteLine("Has ability Convert: " + player.HasJobAbility(APIConstants.JobAbilityId.Convert));
                //foreach (PartyMember member in party.AllianceMembers)
                //{
                //    Console.WriteLine("Party Member.Name: " + member.Name);
                //    Console.WriteLine("Party Member.HP: " + member.CurrentHP);
                //    Console.WriteLine("Party Member.Active: " + member.Active);
                //}

                //Console.WriteLine("Container contains: "  + player.HasItemInItems(ItemId.MendiEarring));
                //foreach (short buffId in player.GetBuffs())
                //{
                //    Console.WriteLine("Buff Id: " + buffId);
                //}

                //int x = 1;
                //IList<ISpell> allSpells = player.GetAllSpell();
                //List<ISpell> spells = new List<ISpell>();
                //foreach (ISpell spell in allSpells)
                //{
                //    if (spell?.MagicType == 8)
                //    {
                //        string name = spell.Name[0];
                //        if (name.Length == 0 || name == ".")
                //        {
                //            Console.WriteLine("RESERVED" + x.ToString() + " = " + spell.Index + ",");
                //            x++;
                //        }
                //        else
                //        {
                //            Console.WriteLine(spell.Name[0] + " = " + spell.Index + ",");
                //        }
                //        spells.Add(spell);
                //    }
                //}
                //spells.Sort((a, b) => a.Index.CompareTo(b.Index));
                //Thread.Sleep(2000);
                //ExpScript.running = false;

                //List<IItem> sortedItems = new List<IItem>();
                //for (uint i = 0; i <= 50000; i++) 
                //{
                //    IItem item = player.Item(i);
                //    if (item != null)
                //    {
                //        sortedItems.Add(item);
                //    }
                //}
                //sortedItems.Sort((a, b) => a.ItemID.CompareTo(b.ItemID));

                //int x = 1;
                //foreach (IItem item in sortedItems)
                //{
                //    string name = item.Name[0];
                //    if (name.Length == 0 || name == ".")
                //    {
                //        //Console.WriteLine("RESERVED" + x.ToString() + " = " + item.ItemID + ",");
                //        x++;
                //    }
                //    else
                //    {
                //        Console.WriteLine(name + " = " + item.ItemID + ",");
                //    }
                //    //Console.WriteLine("Ability ID: " + ability.ID);
                //    //Console.WriteLine("Ability Name0: " + ability.Name[0]);
                //    //Console.WriteLine("Ability Name1: " + ability.Name[1]);
                //    //Console.WriteLine("Ability Name2: " + ability.Name[2]);
                //    //Console.WriteLine("Ability Description: " + ability.Description);
                //    //Console.WriteLine("Ability MP: " + ability.MP);
                //    //Console.WriteLine("Ability TP: " + ability.TP);
                //    //Console.WriteLine("Ability Range: " + ability.Range);
                //    //Console.WriteLine("Ability MonsterLevel: " + ability.MonsterLevel);
                //    //Console.WriteLine("Ability TimerID: " + ability.TimerID);
                //    //Console.WriteLine("Ability ValidTargets: " + ability.ValidTargets);
                //    //Console.WriteLine("Ability Type: " + ability.Type);
                //    //Console.WriteLine("Ability Element: " + ability.Element);
                //    //Console.WriteLine(ability.ToString());
                //}
            }
            Console.WriteLine("Exp Bot has stopped running");
        }
        private bool IsRunningAndNotAggroed()
        {
            return ExpScript.running && !aggroed;
        }
        private bool MoveWithinMeleeRange(double meleeRange)
        {
            if (target.Distance >= meleeRange + 0.5d && target.Distance <= meleeRange - 0.5d)
            {
                // Within melee range.
                player.StopMovingBackward();
                player.StopMovingForward();
                return false;
            }
            else if (target.Distance > meleeRange + 0.5d)
            {
                player.StopMovingBackward();
                player.MoveForward();
                return true;
            }
            else if (target.Distance < meleeRange - 0.5d)
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
                            player.CastSpell((uint)trust, "<me>");
                            if (party.PartyMembers.Count == 6)
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }
        private void AggroMonitor()
        {
            while (ExpScript.running)
            {
                if (player.GetAggroedTargetId()?.TargetID > 0)
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