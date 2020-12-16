﻿using EliteMMO.API;
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
using System.Windows.Forms;
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

        private bool running;
        private bool aggroed = false;
        private bool trizekRingReady = true;
        private bool echadRingReady = true;
        private bool keepWithinMeleeRange = true;
        private bool restMP = true;
        private bool useWeaponSkill = true;
        private bool summonTrusts = true;
        private bool useCapPointEquipment = false;
        private bool useExpPointEquipment = false;
        private bool useAutoHeal;
        private bool pullWithSpell;
        private IList<string> targetNames = new List<string>();
        private IList<string> trustNames = new List<string>();
        private BlackMagicSpellId pullBlackMagicSpellId;
        private int restMPP = -1;
        private TPAbilityId weaponSkillId = TPAbilityId.RESERVED1;
        private int weaponSkillTP = 1000;
        private double meleeRange = 2.0d;
        private double pullDistance = 18.0d;
        private float pullSearchRadius = 50.0f;
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
        ~ExpScript()
        {
            Running = false;
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

            // Start the aggro monitor thread.
            Thread aggroMonitorThread = new Thread(new ThreadStart(AggroMonitor))
            {
                IsBackground = true
            };
            aggroMonitorThread.Start();

            // Actual Bot
            try
            {
                while (Running)
                {
                    switch (player.PlayerStatus)
                    {
                        case (uint)Status.Resting:
                            player.Heal(); // Stand back up.
                            break;
                        case (uint)Status.Idle:
                            if (IsRunningAndNotAggroed())
                            {
                                if (!player.Pulling)
                                {
                                    player.SetTarget(0);
                                    RunToLocation(idleLocation, IdleRadius);
                                    SummonTrustsIfNecessary(trusts);
                                    RestMPIfNecessary(RestMPP);
                                    UseCapPointExpPointEquipmentIfNecessary();
                                    CastGEOSpellsIfNecessary();
                                    HealHPIfNecessary();
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
                                else
                                {
                                    if (target.HPP <= 0)
                                    {
                                        player.Pulling = false;
                                        continue;
                                    }
                                    if (player.HasStatusEffect((short)APIConstants.StatusEffect.Gravity))
                                    {
                                        continue;
                                    }
                                    if (PullWithSpell)
                                    {
                                        if (player.HasStatusEffect((short)APIConstants.StatusEffect.Silence))
                                        {
                                            continue;
                                        }
                                    }
                                    player.FaceTarget(target.X, target.Z);
                                    if (!target.LockedOn)
                                    {
                                        player.LockOn(target);
                                    }
                                    player.Moving = MoveWithinPullDistance(target.Distance, PullDistance);
                                    if (IsRunningAndNotAggroed() && !player.Moving)
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
                                        if (PullWithSpell)
                                        {
                                            if (player.HasStatusEffect((short)APIConstants.StatusEffect.Silence))
                                            {
                                                continue;
                                            }
                                            while (IsRunningAndNotAggroed() && !player.CastSpell((uint)PullBlackMagicSpellId, "<t>"))
                                            {
                                                Thread.Sleep(100);
                                                if (target.Distance > PullDistance || target.HPP <= 0)
                                                {
                                                    pullFailed = true;
                                                    break;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            player.PullWithRanged();
                                        }
                                        if (pullFailed)
                                        {
                                            continue;
                                        }
                                        if (DistanceToLocation(idleLocation) > IdleRadius && target.LockedOn)
                                        {
                                            player.UnLockOn(target);
                                        }
                                        RunToLocation(idleLocation, IdleRadius);
                                        player.Attack(target);
                                        player.Pulling = false;
                                    }
                                }
                            }
                            else
                            {
                                RunToLocation(idleLocation, IdleRadius);
                                uint targetId;
                                if (Running && (targetId = player.GetAggroedTargetId()) > 0)
                                {
                                    player.SetTarget((int)targetId);
                                    if (target.HPP > 1)
                                    {
                                        player.Attack(target);
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
                                    player.Moving = MoveWithinDistance(target.Distance, MeleeRange);
                                    if (!player.Moving)
                                    {
                                        CastGEOSpellsIfNecessary();
                                        HealHPIfNecessary();
                                        if (target.Distance > MeleeRange + 0.5d)
                                        {
                                            continue;
                                        }
                                        else
                                        {
                                            UseWeaponSkillIfNecessary(WeaponSkillTP, WeaponSkillId);
                                        }
                                    }
                                }
                                else
                                {
                                    CastGEOSpellsIfNecessary();
                                    HealHPIfNecessary();
                                    UseWeaponSkillIfNecessary(WeaponSkillTP, WeaponSkillId);
                                }
                            }
                            break;
                        case (uint)Status.Dead:
                        case (uint)Status.Dying:
                            Console.WriteLine("Player status: Dead");
                            player.DeathWarp();
                            Running = false; // Kill the bot, we're done.
                            break;
                        default:
                            Console.WriteLine("Undocumented Player Status: " + player.PlayerStatus);
                            break;
                    }
                    Thread.Sleep(250);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception thrown, stopping bot: " + e.Message);
            }
            finally
            {
                Running = false;
                aggroMonitorThread.Join();
            }
            Console.WriteLine("Exp Bot has stopped running");
        }
        private bool IsRunningAndNotAggroed()
        {
            return Running && !aggroed;
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
                    while (Running && !player.IsDead() && DistanceToLocation(location) > distanceRadius)
                    {
                        if (stuckWatch.ElapsedMilliseconds > 1000)
                        {
                            // Try again every second until we get to the actual location.
                            player.Stop();
                            RunToLocation(location, distanceRadius);
                            return;
                        }
                        Thread.Sleep(100);
                    }
                    player.Stop();
                }
            }
        }
        private bool MoveWithinPullDistance(double targetDistance, double distance)
        {
            if (IsRunningAndNotAggroed())
            {
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
        private bool MoveWithinDistance(double targetDistance, double distance)
        {
            if (Running)
            {
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
        private void RestMPIfNecessary(int restMPP)
        {
            if (IsRunningAndNotAggroed() && RestMP)
            {
                if (restMPP <= 0)
                {
                    return;
                }
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
        private void UseCapPointExpPointEquipmentIfNecessary()
        {
            if (IsRunningAndNotAggroed() && (UseCapPointEquipment || UseExpPointEquipment))
            {
                ItemId currentRing1ItemId = (ItemId)player.GetEquippedItem(SlotId.Ring1).Id;
                if (UseCapPointEquipment && trizekRingReady)
                {
                    if (!((player.IsEquippedItem(SlotId.Ring1, ItemId.TrizekRing) ||
                        player.IsEquippedItem(SlotId.Ring2, ItemId.TrizekRing))))
                    {
                        player.EquipItem(SlotId.Ring1, ItemId.TrizekRing);
                    }
                    if (trizekRingReady && !player.HasStatusEffect((short)APIConstants.StatusEffect.Commitment))
                    {
                        bool itemUsed = player.UseItem(ItemId.TrizekRing, "<me>");
                        if (itemUsed)
                        {
                            Thread trizekRingReadyMonitor = new Thread(delegate () { TrizekRingReadyMonitor(); })
                            {
                                IsBackground = true
                            };
                            trizekRingReadyMonitor.Start();
                        }
                    }
                    player.EquipItem(SlotId.Ring1, currentRing1ItemId);
                }
                else if (UseExpPointEquipment && echadRingReady)
                {
                    if (!((player.IsEquippedItem(SlotId.Ring1, ItemId.EchadRing) ||
                        player.IsEquippedItem(SlotId.Ring2, ItemId.EchadRing))))
                    {
                        player.EquipItem(SlotId.Ring1, ItemId.EchadRing);
                    }
                    if (!player.HasStatusEffect((short)APIConstants.StatusEffect.Dedication) ||
                        (party.IsPartyMemberPresent("Kupofried") &&
                        player.CountStatusEffect((short)APIConstants.StatusEffect.Dedication) == 1))
                    {
                        bool itemUsed = player.UseItem(ItemId.EchadRing, "<me>");
                        if (itemUsed)
                        {
                            Thread echadRingReadyMonitor = new Thread(delegate () { EchadRingReadyMonitor(); })
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
        private void CastGEOSpellsIfNecessary()
        {
            if (Running)
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
        }
        private void HealHPIfNecessary()
        {
            if (!UseAutoHeal)
            {
                return;
            }

            if (Running)
            {
                int partyMember = 0;
                foreach (PartyMember member in party.PartyMembers)
                {
                    if (!Running || player.PlayerStatus == (uint)Status.Idle && aggroed)
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
            const int CureIIIHealHP = 80;
            const int CureIVHealHP = 50;
            const int CureVHealHP = 30;
            if (member.CurrentHPP <= CureVHealHP)
            {
                if (player.CanCastSpell((uint)WhiteMagicSpellId.CureV))
                {
                    player.CastSpell((uint)WhiteMagicSpellId.CureV, "<p" + memberIndex + ">");
                }
                else if (player.MainJob == (byte)Job.Dancer && player.MainJobLevel >= 70 && player.TP >= 500)
                {
                    if (player.HasTPAbility(TPAbilityId.CuringWaltzIV))
                    {
                        player.PerformJobAbility((uint)TPAbilityId.CuringWaltzIV, "<p" + memberIndex + ">");
                    }
                }
                else if (player.SubJob == (byte)Job.Dancer && player.SubJobLevel >= 45 && player.TP >= 500)
                {
                    if (player.HasTPAbility(TPAbilityId.CuringWaltzIII))
                    {
                        player.PerformJobAbility((uint)TPAbilityId.CuringWaltzIII, "<p" + memberIndex + ">");
                    }
                }
            }
            else if (member.CurrentHPP <= CureIVHealHP)
            {
                if (player.CanCastSpell((uint)WhiteMagicSpellId.CureIV))
                {
                    player.CastSpell((uint)WhiteMagicSpellId.CureIV, "<p" + memberIndex + ">");
                }
                else if (player.MainJob == (byte)Job.Dancer && player.MainJobLevel >= 45 && player.TP >= 350)
                {
                    if (player.HasTPAbility(TPAbilityId.CuringWaltzIII))
                    {
                        player.PerformJobAbility((uint)TPAbilityId.CuringWaltzIII, "<p" + memberIndex + ">");
                    }
                }
                else if (player.SubJob == (byte)Job.Dancer && player.SubJobLevel >= 45 && player.TP >= 350)
                {
                    if (player.HasTPAbility(TPAbilityId.CuringWaltzIII))
                    {
                        player.PerformJobAbility((uint)TPAbilityId.CuringWaltzIII, "<p" + memberIndex + ">");
                    }
                }
            }
            else if (member.CurrentHPP <= CureIIIHealHP)
            {
                if (player.CanCastSpell((uint)WhiteMagicSpellId.CureIII))
                {
                    player.CastSpell((uint)WhiteMagicSpellId.CureIII, "<p" + memberIndex + ">");
                }
                else if (player.MainJob == (byte)Job.Dancer && player.MainJobLevel >= 30 && player.TP >= 200)
                {
                    if (player.HasTPAbility(TPAbilityId.CuringWaltzII))
                    {
                        player.PerformJobAbility((uint)TPAbilityId.CuringWaltzII, "<p" + memberIndex + ">");
                    }
                }
                else if (player.SubJob == (byte)Job.Dancer && player.SubJobLevel >= 30 && player.TP >= 200)
                {
                    if (player.HasTPAbility(TPAbilityId.CuringWaltzII))
                    {
                        player.PerformJobAbility((uint)TPAbilityId.CuringWaltzII, "<p" + memberIndex + ">");
                    }
                }
            }
        }
        private void SummonTrustsIfNecessary(IList<TrustSpellId> trusts)
        {
            if (Running && SummonTrusts)
            {
                if (trusts?.Count <= 0)
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
        }
        private void AggroMonitor()
        {
            while (Running)
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
        private void TrizekRingReadyMonitor()
        {
            trizekRingReady = false;
            Stopwatch readyStopWatch = new Stopwatch();
            readyStopWatch.Start();
            while (Running)
            {
                if (readyStopWatch.ElapsedMilliseconds >= TimeSpan.FromSeconds(player.GetItem(ItemId.TrizekRing).RecastDelay).TotalMilliseconds)
                {
                    trizekRingReady = true;
                    return;
                }
                Thread.Sleep(100);
            }
        }
        private void EchadRingReadyMonitor()
        {
            echadRingReady = false;
            Stopwatch readyStopWatch = new Stopwatch();
            readyStopWatch.Start();
            while (Running)
            {
                if (readyStopWatch.ElapsedMilliseconds >= TimeSpan.FromSeconds(player.GetItem(ItemId.EchadRing).RecastDelay).TotalMilliseconds)
                {
                    echadRingReady = true;
                    return;
                }
                Thread.Sleep(100);
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