﻿using EliteMMO.API;
using System;
using System.Collections;
using System.Linq;
using System.Threading;
using static EliteMMO.API.EliteAPI;

namespace ExpBot.Model.EliteAPIWrappers
{
    public class PlayerWrapper : APIConstants
    {
        private static EliteAPI api;

        public PlayerWrapper(EliteAPI api)
        {
            PlayerWrapper.api = api;
        }
        public void SetPlayer(string propertyName, params object[] properties)
        {
            switch (propertyName)
            {
                case "Target":
                    break;
                case "H":
                    api.Entity.SetEntityHPosition(api.Entity.LocalPlayerIndex, (float)properties[0]);
                    break;
                case "Job":
                case "SubJob":
                case "Name":
                case "HP":
                case "HPP":
                case "MP":
                case "MPP":
                case "TP":
                case "PlayerStatus":
                case "X":
                case "Y":
                case "Z":
                default:
                    break;
            }
        }
        public void Attack(TargetWrapper target)
        {
            FaceTarget(target);
            while (!target.LockedOn)
            {
                api.ThirdParty.SendString("/lockon <t>");
                Thread.Sleep(100);
            }
            if (PlayerStatus != (uint)Status.InCombat)
            {
                api.ThirdParty.SendString("/attack");
            }
        }
        public short[] GetBuffs()
        {
            return api.Player.Buffs;
        }
        public bool HasBuff(short id)
        {
            // TODO:
            return false;
        }
        public void Heal()
        {
            api.ThirdParty.SendString("/heal");
            Thread.Sleep(2000);
        }
        public void MoveForward()
        {
            api.ThirdParty.KeyDown(Keys.NUMPAD8);
        }
        public void StopMovingForward()
        {
            api.ThirdParty.KeyUp(Keys.NUMPAD8);
        }
        public void MoveBackward()
        {
            api.ThirdParty.KeyDown(Keys.NUMPAD2);
        }
        public void StopMovingBackward()
        {
            api.ThirdParty.KeyUp(Keys.NUMPAD2);
        }
        public bool SetTarget(int id)
        {
            return api.Target.SetTarget(id);
        }
        public void FaceTarget(TargetWrapper target)
        {
            byte angle = (byte)(Math.Atan((target.Z - Z) / (target.X - X)) * -(128.0f / Math.PI));
            if (X > target.X)
            {
                angle += 128;
            }
            double radian = (((float)angle) / 255) * 2 * Math.PI;
            api.Entity.SetEntityHPosition(api.Entity.LocalPlayerIndex, (float)radian);
        }
        public XiEntity GetAggroedTargetId()
        {
            XiEntity entity = null;
            for (var x = 0; x < 2048; x++)
            {
                entity = api.Entity.GetEntity(x);
                if (entity.WarpPointer == 0 ||
                    entity.HealthPercent == 0 ||
                    entity.TargetID <= 0 ||
                    (!new BitArray(new int[] { entity.SpawnFlags }).Get(4)) ||
                    entity.ClaimID != 0)
                {
                    continue;
                }

                // Unfortunately it's not straight-forward to find out
                // if a monster is targetting the player.
                if (entity.HealthPercent != 0 &&
                    entity.Distance <= 5 &&
                    entity.Status == (uint)Status.InCombat)
                {
                    break;
                }
            }
            return entity;
        }
        //public XiEntity GetClosestTargetId()
        //{
        //    XiEntity closestTargetEntity = null;
        //    for (var x = 0; x < 2048; x++)
        //    {
        //        XiEntity entity = api.Entity.GetEntity(x);
        //        if (entity.WarpPointer == 0 ||
        //            entity.HealthPercent == 0 ||
        //            entity.TargetID <= 0 ||
        //            (!new BitArray(new int[] { entity.SpawnFlags }).Get(4)) ||
        //            entity.ClaimID != 0)
        //        {
        //            continue;
        //        }

        //        if (entity.HealthPercent != 0 && entity.Distance <= 100)
        //        {
        //            if (closestTargetEntity == null)
        //            {
        //                closestTargetEntity = entity;
        //            }
        //            else if (closestTargetEntity.Distance > entity.Distance)
        //            {
        //                closestTargetEntity = entity;
        //            }
        //        }
        //    }
        //    Console.WriteLine("Name: " + closestTargetEntity.Name);
        //    Console.WriteLine("Distance: " + closestTargetEntity.Distance);
        //    Console.WriteLine("Status: " + closestTargetEntity.Status);
        //    Console.WriteLine("TargetID: " + closestTargetEntity.TargetID);
        //    Console.WriteLine("ServerID: " + closestTargetEntity.ServerID);
        //    Console.WriteLine("ClaimID: " + closestTargetEntity.ClaimID);
        //    Console.WriteLine("Type: " + closestTargetEntity.Type);
        //    return closestTargetEntity;
        //}
        //public XiEntity GetClosestTargetId()
        //{
        //    XiEntity closestTargetId = null;
        //    for (var x = 0; x < 2048; x++)
        //    {
        //        XiEntity id = api.Entity.GetEntity(x);
        //        if (id.Name?.Length > 0 &&
        //            !id.Name.Equals(Name) &&
        //            id.HealthPercent > 0 &&
        //            id.Distance > 0 &&
        //            id.ServerID == Id)
        //        {
        //            if (closestTargetId == null)
        //            {
        //                closestTargetId = id;
        //            }
        //            else if (closestTargetId.Distance > id.Distance)
        //            {
        //                closestTargetId = id;
        //            }
        //        }
        //    }
        //    return closestTargetId;
        //}
        public int GetClosestTargetIdByName(string name)
        {
            XiEntity closestTargetId = null;
            for (var x = 0; x < 2048; x++)
            {
                XiEntity id = api.Entity.GetEntity(x);
                if (id.Name != null && id.Name.ToLower().Equals(name.ToLower()))
                {
                    if (closestTargetId == null)
                    {
                        closestTargetId = id;
                    }
                    else if (closestTargetId.Distance > id.Distance)
                    {
                        closestTargetId = id;
                    }
                }
            }
            return (int)closestTargetId.TargetID;
        }
        //public IList<ISpell> GetAllSpell()
        //{
        //    IList<ISpell> spells = new List<ISpell>();
        //    for (uint x = 0; x < 10000; x++)
        //    {
        //        spells.Add(api.Resources.GetSpell(x));
        //    }
        //    return spells;
        //}
        public int GetSpellRecastRemaining(int spellId)
        {
            return api.Recast.GetSpellRecast(spellId);
        }
        public void CastSpell(uint spellId, string target)
        {
            ISpell spell = api.Resources.GetSpell(spellId);
            api.ThirdParty.SendString("/ma \"" + spell.Name[0] + "\" " + target);
            while (GetSpellRecastRemaining((int)spellId) == 0)
            {
                Thread.Sleep(100);
            }
            // TODO: Animation Delay - Configurable?
            Thread.Sleep(2500);
        }
        public ISpell GetTrustSpell(TrustSpellId trustSpellId)
        {
            return api.Resources.GetSpell((uint)trustSpellId);
        }
        public void PerformJobAbility(uint jobAbilityId, string target)
        {
            IAbility ability = api.Resources.GetAbility(jobAbilityId);
            api.ThirdParty.SendString("/ja \"" + ability.Name[0] + "\" " + target);
        }
        public void PerformWeaponSkill(TPAbilityId weaponSkillId, string target)
        {
            IAbility weaponSkill = api.Resources.GetAbility((uint)weaponSkillId);
            api.ThirdParty.SendString("/ws \"" + weaponSkill.Name[0] + "\" " + target);
        }
        public bool HasItemInItems(ItemId id)
        {
            return HasItem(ContainerId.Items, id);
        }
        public bool HasItemInMogSafe(ItemId id)
        {
            return HasItem(ContainerId.MogSafe, id);
        }
        public bool HasItemInStorage(ItemId id)
        {
            return HasItem(ContainerId.Storage, id);
        }
        public bool HasItemInMogLocker(ItemId id)
        {
            return HasItem(ContainerId.MogLocker, id);
        }
        public bool HasItemInMogSatchel(ItemId id)
        {
            return HasItem(ContainerId.MogSatchel, id);
        }
        public bool HasItemInMogSack(ItemId id)
        {
            return HasItem(ContainerId.MogSafe, id);
        }
        public bool HasItemInMogCase(ItemId id)
        {
            return HasItem(ContainerId.MogCase, id);
        }
        public bool HasItemInMogWardrobe(ItemId id)
        {
            return HasItem(ContainerId.MogWardrobe, id);
        }
        public bool HasItemInMogSafe2(ItemId id)
        {
            return HasItem(ContainerId.MogSafe2, id);
        }
        public bool HasItemInMogWardrobe2(ItemId id)
        {
            return HasItem(ContainerId.MogWardrobe2, id);
        }
        public bool HasItem(ContainerId containerId, ItemId itemId)
        {
            return ItemQuantity(containerId, itemId) > 0;
        }
        public uint ItemQuantity(ContainerId containerId, ItemId itemId)
        {
            int currentItemCount = api.Inventory.GetContainerCount((int)containerId);
            for (int i = 0; i < currentItemCount; i++)
            {
                InventoryItem item = api.Inventory.GetContainerItem((int)containerId, i);
                if (item.Id == (int)itemId)
                {
                    return item.Count;
                }
            }
            return 0;
        }
        public bool HasWhiteMagicSpell(WhiteMagicSpellId id)
        {
            return api.Player.HasSpell((uint)id);
        }
        public bool HasBlackMagicSpell(BlackMagicSpellId id)
        {
            return api.Player.HasSpell((uint)id);
        }
        public bool HasSongSpell(SongSpellId id)
        {
            return api.Player.HasSpell((uint)id);
        }
        public bool HasNinjutsuSpell(NinjutsuSpellId id)
        {
            return api.Player.HasSpell((uint)id);
        }
        public bool HasSummmoningSpell(SummmoningSpellId id)
        {
            return api.Player.HasSpell((uint)id);
        }
        public bool HasBlueMagicSpell(BlueMagicSpellId id)
        {
            return api.Player.HasSpell((uint)id);
        }
        public bool HasGeomancySpell(GeomancySpellId id)
        {
            return api.Player.HasSpell((uint)id);
        }
        public bool HasTrustSpell(TrustSpellId id)
        {
            return api.Player.HasSpell((uint)id);
        }
        public bool HasTPAbility(TPAbilityId id)
        {
            return api.Player.HasAbility((uint)id);
        }
        public bool HasJobAbility(JobAbilityId id)
        {
            return api.Player.HasAbility((uint)id);
        }
        public bool HasPetAbility(PetAbilityId id)
        {
            return api.Player.HasAbility((uint)id);
        }
        public uint Id
        {
            get => api.Player.ServerID;
            set => SetPlayer("Id", value);
        }
        public int Job
        {
            get => api.Player.MainJob;
            set => SetPlayer("Job", value);
        }
        public int SubJob
        {
            get => api.Player.SubJob;
            set => SetPlayer("SubJob", value);
        }
        public string Name
        {
            get => api.Player.Name;
            set => SetPlayer("Name", value);
        }
        public uint HP
        {
            get => api.Player.HP;
            set => SetPlayer("HP", value);
        }
        public uint MaxHP
        {
            get => api.Player.HPMax;
            set => SetPlayer("MaxHP", value);
        }
        public uint HPP
        {
            get => api.Player.HPP;
            set => SetPlayer("HPP", value);
        }
        public uint MP
        {
            get => api.Player.MP;
            set => SetPlayer("MP", value);
        }
        public uint MaxMP
        {
            get => api.Player.MPMax;
            set => SetPlayer("MaxMP", value);
        }
        public uint MPP
        {
            get => api.Player.MPP;
            set => SetPlayer("MPP", value);
        }
        public uint TP
        {
            get => api.Player.TP;
            set => SetPlayer("TP", value);
        }
        public uint PlayerStatus
        {
            get => api.Entity.GetLocalPlayer().Status;
            set => SetPlayer("PlayerStatus", value);
        }
        public float X
        {
            get => api.Player.X;
            set => SetPlayer("X", value);
        }
        public float Y
        {
            get => api.Player.Y;
            set => SetPlayer("Y", value);
        }
        public float Z
        {
            get => api.Player.Z;
            set => SetPlayer("Z", value);
        }
        public float H
        {
            get => api.Player.H;
            set => SetPlayer("H", value);
        }
    }
}
