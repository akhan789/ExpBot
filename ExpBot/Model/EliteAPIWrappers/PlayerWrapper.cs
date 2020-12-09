using EliteMMO.API;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using static EliteMMO.API.EliteAPI;

namespace ExpBot.Model.EliteAPIWrappers
{
    public class PlayerWrapper : APIConstants, INotifyPropertyChanged
    {
        private static EliteAPI api;
        private bool moving;
        private bool pulling;
        private bool casting;
        public PlayerWrapper(EliteAPI api)
        {
            PlayerWrapper.api = api;

            Thread playerMonitorThread = new Thread(PlayerMonitor);
            playerMonitorThread.IsBackground = true;
            playerMonitorThread.Start();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void SetPlayer(string propertyName, params object[] properties)
        {
            switch (propertyName)
            {
                case "H":
                    api.Entity.SetEntityHPosition(api.Entity.LocalPlayerIndex, (float)properties[0]);
                    OnPropertyChanged("H");
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
                case "Moving":
                case "Pulling":
                case "Casting":
                default:
                    break;
            }
        }

        //public string GetChatLog()
        //{
        //    ChatEntry chatEntry = api.Chat.GetNextChatLine();
        //    if (chatEntry != null)
        //    {
        //        Console.WriteLine("Timestamp: " + chatEntry.Timestamp);
        //        Console.WriteLine("ChatColor: " + chatEntry.ChatColor);
        //        Console.WriteLine("ChatType: " + chatEntry.ChatType);
        //        Console.WriteLine("Index1: " + chatEntry.Index1);
        //        Console.WriteLine("Index2: " + chatEntry.Index2);
        //        Console.WriteLine("Length: " + chatEntry.Length);
        //        Console.WriteLine("RawLine: " + chatEntry.RawLine);
        //        Console.WriteLine("RawText: " + chatEntry.RawText);
        //        Console.WriteLine("         Text: " + chatEntry.Text);
        //        return chatEntry.Text;
        //    }
        //    else
        //    {
        //        return "";
        //    }
        //}
        public void Attack(TargetWrapper target)
        {
            FaceTarget(target.X, target.Z);
            if (!target.LockedOn)
            {
                LockOn(target);
            }
            if (PlayerStatus != (uint)Status.InCombat)
            {
                api.ThirdParty.SendString("/attack");
            }
            Thread.Sleep(2500);
        }
        public void LockOn(TargetWrapper target)
        {
            while (target.HPP > 1 && !target.LockedOn)
            {
                api.ThirdParty.SendString("/lockon <t>");
                Thread.Sleep(500);
            }
        }
        public void UnLockOn(TargetWrapper target)
        {
            while (target.LockedOn)
            {
                api.ThirdParty.SendString("/lockon <t>");
                Thread.Sleep(500);
            }
        }
        public void Heal()
        {
            api.ThirdParty.SendString("/heal");
            Thread.Sleep(2000);
        }
        public void DeathWarp()
        {
            Thread.Sleep(TimeSpan.FromSeconds(1.0));
            api.ThirdParty.KeyPress(Keys.NUMPADENTER);
            Thread.Sleep(TimeSpan.FromSeconds(0.5));
            api.ThirdParty.KeyPress(Keys.RIGHT);
            Thread.Sleep(TimeSpan.FromSeconds(0.5));
            api.ThirdParty.KeyPress(Keys.NUMPADENTER);
        }
        public bool SetTarget(int id)
        {
            return api.Target.SetTarget(id);
        }
        public void FaceTarget(float targetX, float targetZ)
        {
            byte angle = (byte)(Math.Atan((targetZ - Z) / (targetX - X)) * -(128.0f / Math.PI));
            if (X > targetX)
            {
                angle += 128;
            }
            double radian = (((float)angle) / 255) * 2 * Math.PI;
            api.Entity.SetEntityHPosition(api.Entity.LocalPlayerIndex, (float)radian);
        }
        public uint GetAggroedTargetId()
        {
            XiEntity entity = null;
            for (int x = 0; x < 2048; x++)
            {
                entity = api.Entity.GetEntity(x);
                if (entity.WarpPointer == 0 ||
                    entity.HealthPercent == 0 ||
                    entity.TargetID <= 0 ||
                    (!new BitArray(new int[] { entity.SpawnFlags }).Get(4)) ||
                    entity.ClaimID != 0)
                {
                    entity = null;
                    continue;
                }

                // Unfortunately it's not straight-forward to find out
                // if a monster is targetting the player.
                if (entity.HealthPercent != 0 &&
                    entity.Distance <= 7.5 &&
                    entity.Status == (uint)Status.InCombat)
                {
                    break;
                }
            }
            if (entity != null)
            {
                return entity.TargetID;
            }
            else
            {
                return 0;
            }
        }
        public IList<string> GetAllAvailableTargets()
        {
            IList<string> targets = new List<string>();
            for (int x = 0; x < 2048; x++)
            {
                XiEntity entity = api.Entity.GetEntity(x);
                if ((!new BitArray(new int[] { entity.SpawnFlags }).Get(4)))
                {
                    continue;
                }

                if (entity.Name?.Length > 0)
                {
                    if (!targets.Contains(entity.Name))
                    {
                        targets.Add(entity.Name);
                    }
                }
            }
            return targets;
        }
        public int GetClosestTargetIdByNames(IList<string> names, float maxDistance)
        {
            float searchID = 999;
            int targetId = -1;
            for (int x = 0; x < 2048; x++)
            {
                XiEntity entity = api.Entity.GetEntity(x);
                if (entity.WarpPointer == 0 ||
                    entity.HealthPercent == 0 ||
                    entity.TargetID <= 0 ||
                    (!new BitArray(new int[] { entity.SpawnFlags }).Get(4)) ||
                    entity.ClaimID != 0)
                {
                    continue;
                }

                if (entity.Name != null)
                {
                    foreach (string name in names)
                    {
                        if (entity.Name.ToLower().Equals(name.ToLower()))
                        {
                            if (entity.HealthPercent != 0 &&
                                entity.Distance <= maxDistance)
                            {
                                if (searchID > entity.Distance &&
                                    entity.ClaimID == 0 &&
                                    entity.HealthPercent != 0)
                                {
                                    searchID = entity.Distance;
                                    targetId = Convert.ToInt32(entity.TargetID);
                                }
                            }
                        }
                    }
                }
            }
            return targetId;
        }
        public IList<string> GetAllAvailableTrusts()
        {
            IList<string> trustList = new List<string>();
            foreach (TrustSpellId trust in Enum.GetValues(typeof(TrustSpellId)))
            {
                if (HasTrustSpell(trust))
                {
                    ISpell spell = api.Resources.GetSpell((uint)trust);
                    trustList.Add(spell.Name[0]);
                }
            }
            ((List<string>)trustList).Sort();
            return trustList;
        }
        public int GetSpellRecastRemaining(int spellId)
        {
            return api.Recast.GetSpellRecast(spellId);
        }
        public bool CastSpell(uint spellId, string target)
        {
            ISpell spell = api.Resources.GetSpell(spellId);
            if (spell.MPCost > MP)
            {
                throw new Exception("Not enough MP");
            }
            Casting = true;
            Thread.Sleep(1000);
            api.ThirdParty.SendString("/ma \"" + spell.Name[0] + "\" " + target);
            int castTime = spell.CastTime;
            Stopwatch spellTimeoutWatch = new Stopwatch();
            spellTimeoutWatch.Start();
            while (GetSpellRecastRemaining((int)spellId) <= 0)
            {
                Thread.Sleep(250);
                ChatEntry chatEntry = api.Chat.GetNextChatLine();
                if (chatEntry != null && chatEntry.Text.Equals(Name + "'s casting is interrupted.") || spellTimeoutWatch.ElapsedMilliseconds >= TimeSpan.FromSeconds(castTime).TotalMilliseconds)
                {
                    Casting = false;
                    return false;
                }
            }
            // TODO: Animation Delay - Configurable?
            Thread.Sleep(2600);
            Casting = false;
            return true;
        }
        public void PerformJobAbility(uint jobAbilityId, string target)
        {
            IAbility ability = api.Resources.GetAbility(jobAbilityId);
            api.ThirdParty.SendString("/ja \"" + ability.Name[0] + "\" " + target);
            // TODO: Animation Delay - Configurable?
            Thread.Sleep(2500);
        }
        public void PerformWeaponSkill(TPAbilityId weaponSkillId, string target)
        {
            IAbility weaponSkill = api.Resources.GetAbility((uint)weaponSkillId);
            api.ThirdParty.SendString("/ws \"" + weaponSkill.Name[0] + "\" " + target);
            // TODO: Animation Delay - Configurable?
            Thread.Sleep(2500);
        }
        public void Move(float locationX, float locationY, float locationZ)
        {
            api.AutoFollow.SetAutoFollowCoords(locationX - X, locationY - Y, locationZ - Z);
            api.AutoFollow.IsAutoFollowing = true;
            Thread.Sleep(100);
        }
        public void Stop()
        {
            api.AutoFollow.IsAutoFollowing = false;
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
        public bool HasStatusEffect(short id)
        {
            foreach (short buff in GetBuffs())
            {
                if (buff == id)
                {
                    return true;
                }
            }
            return false;
        }
        public short[] GetBuffs()
        {
            return api.Player.Buffs;
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
        // TODO: Mog Wardrobe 3
        // TODO: Mog Wardrobe 4
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
        public bool Moving
        {
            get => moving;
            set => moving = value;
        }
        public bool Pulling
        {
            get => pulling;
            set => pulling = value;
        }
        public bool Casting
        {
            get => casting;
            set => casting = value;
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

        private void PlayerMonitor()
        {
            uint id = 0;
            int job = 0;
            int subJob = 0;
            string name = "";
            uint hp = 0;
            uint hpp = 0;
            uint maxHP = 0;
            uint mp = 0;
            uint mpp = 0;
            uint maxMP = 0;
            uint tp = 0;
            uint playerStatus = 0;
            float x = 0.0f;
            float y = 0.0f;
            float z = 0.0f;
            float h = 0.0f;
            bool moving = false;
            bool pulling = false;
            bool casting = false;
            while (true)
            {
                if (id != Id)
                {
                    id = Id;
                    OnPropertyChanged("Id");
                }
                if (job != Job)
                {
                    job = Job;
                    OnPropertyChanged("Job");
                }
                if (subJob != SubJob)
                {
                    subJob = SubJob;
                    OnPropertyChanged("SubJob");
                }
                if (!name.Equals(Name))
                {
                    name = Name;
                    OnPropertyChanged("Name");
                }
                if (hp != HP)
                {
                    hp = HP;
                    OnPropertyChanged("HP");
                }
                if (hpp != HPP)
                {
                    hpp = HPP;
                    OnPropertyChanged("HPP");
                }
                if (maxHP != MaxHP)
                {
                    maxHP = MaxHP;
                    OnPropertyChanged("MaxHP");
                }
                if (mp != MP)
                {
                    mp = MP;
                    OnPropertyChanged("MP");
                }
                if (mpp != MPP)
                {
                    mpp = MPP;
                    OnPropertyChanged("MPP");
                }
                if (maxMP != MaxMP)
                {
                    maxMP = MaxMP;
                    OnPropertyChanged("MaxMP");
                }
                if (tp != TP)
                {
                    tp = TP;
                    OnPropertyChanged("TP");
                }
                if (playerStatus != PlayerStatus)
                {
                    playerStatus = PlayerStatus;
                    OnPropertyChanged("PlayerStatus");
                }
                if (x != X)
                {
                    x = X;
                    OnPropertyChanged("X");
                }
                if (y != Y)
                {
                    y = Y;
                    OnPropertyChanged("Y");
                }
                if (z != Z)
                {
                    z = Z;
                    OnPropertyChanged("Z");
                }
                if (h != H)
                {
                    h = H;
                    OnPropertyChanged("H");
                }
                if (moving != Moving)
                {
                    moving = Moving;
                    OnPropertyChanged("Moving");
                }
                if (pulling != Pulling)
                {
                    pulling = Pulling;
                    OnPropertyChanged("Pulling");
                }
                if (casting != Casting)
                {
                    casting = Casting;
                    OnPropertyChanged("Casting");
                }
                Thread.Sleep(100);
            }
        }
    }
}
