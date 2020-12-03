using EliteMMO.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public IItem Item(uint itemId)
        {
            return api.Resources.GetItem(itemId);
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
        public uint Status
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
        public uint TargetId
        {
            get => api.Player.TargetID;
            set => SetPlayer("TargetId", value);
        }
    }
}
