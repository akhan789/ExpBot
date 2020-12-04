using EliteMMO.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using static EliteMMO.API.EliteAPI;

namespace ExpBot.Model.EliteAPIWrappers
{
    public class PlayerWrapper : APIConstants
    {
        private static EliteAPI api;
        private TargetWrapper target;

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
        public void SendAttack()
        {
            api.ThirdParty.SendString("/attack");
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
        public void FaceTarget()
        {
            if (target?.Id == 0)
            {
                return;
            }
            byte angle = (byte)(Math.Atan((Target.Z - Z) / (Target.X - X)) * -(128.0f / Math.PI));
            if (X > Target.X)
            {
                angle += 128;
            }
            double radian = (((float)angle) / 255) * 2 * Math.PI;
            SetPlayer("H", (float)radian);
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
            Thread.Sleep(TimeSpan.FromSeconds(spell.CastTime));
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
        public TargetWrapper Target
        {
            get => target;
            set
            {
                target = value;
                SetPlayer("Target", value);
            }
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
