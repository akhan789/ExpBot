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
                case "MainJob":
                case "SubJob":
                case "MainJobLevel":
                case "SubJobLevel":
                case "Name":
                case "HP":
                case "HPP":
                case "MP":
                case "MPP":
                case "TP":
                case "PlayerStatus":
                case "SpentJobPoints":
                case "X":
                case "Y":
                case "Z":
                case "StatusEffects":
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
            Stopwatch lockOnTimeoutWatch = new Stopwatch();
            lockOnTimeoutWatch.Start();
            while (target.HPP > 1 && !target.LockedOn)
            {
                api.ThirdParty.SendString("/lockon <t>");
                Thread.Sleep(500);
                if (lockOnTimeoutWatch.ElapsedMilliseconds >= TimeSpan.FromSeconds(5).TotalMilliseconds)
                {
                    SetTarget(0);
                    break;
                }
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
                    entity.Distance <= 25 &&
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
                    if (entity.Name.StartsWith("Chest"))
                    {
                        Console.WriteLine("Chest: TargetID:" + Convert.ToInt32(entity.TargetID));
                        Console.WriteLine("Chest: ActionTimer1:" + entity.ActionTimer1);
                        Console.WriteLine("Chest: ActionTimer2:" + entity.ActionTimer2);
                        for (int i = 0; x < entity.Animations.Length; i++)
                        {
                            Console.WriteLine("Chest: Animations[" + i + "]:" + entity.Animations[i]);
                        }
                        Console.WriteLine("Chest: Body:" + entity.Body);
                        Console.WriteLine("Chest: ClaimID:" + entity.ClaimID);
                        Console.WriteLine("Chest: CostumeID:" + entity.CostumeID);
                        Console.WriteLine("Chest: Distance:" + entity.Distance);
                        Console.WriteLine("Chest: Face:" + entity.Face);
                        Console.WriteLine("Chest: Feet:" + entity.Feet);
                        Console.WriteLine("Chest: FishingTimer:" + entity.FishingTimer);
                        Console.WriteLine("Chest: H:" + entity.H);
                        Console.WriteLine("Chest: Hands:" + entity.Hands);
                        Console.WriteLine("Chest: Head:" + entity.Head);
                        Console.WriteLine("Chest: HealthPercent:" + entity.HealthPercent);
                        Console.WriteLine("Chest: Legs:" + entity.Legs);
                        Console.WriteLine("Chest: Main:" + entity.Main);
                        Console.WriteLine("Chest: ManaPercent:" + entity.ManaPercent);
                        Console.WriteLine("Chest: ModelSize:" + entity.ModelSize);
                        Console.WriteLine("Chest: Name:" + entity.Name);
                        Console.WriteLine("Chest: PetIndex:" + entity.PetIndex);
                        Console.WriteLine("Chest: PetOwnerID:" + entity.PetOwnerID);
                        Console.WriteLine("Chest: Race:" + entity.Race);
                        Console.WriteLine("Chest: Ranged:" + entity.Ranged);
                        Console.WriteLine("Chest: Render0000:" + entity.Render0000);
                        Console.WriteLine("Chest: Render0001:" + entity.Render0001);
                        Console.WriteLine("Chest: Render0002:" + entity.Render0002);
                        Console.WriteLine("Chest: Render0003:" + entity.Render0003);
                        Console.WriteLine("Chest: Render0004:" + entity.Render0004);
                        Console.WriteLine("Chest: ServerID:" + entity.ServerID);
                        Console.WriteLine("Chest: SpawnFlags:" + entity.SpawnFlags);
                        Console.WriteLine("Chest: Speed:" + entity.Speed);
                        Console.WriteLine("Chest: SpeedAnimation:" + entity.SpeedAnimation);
                        Console.WriteLine("Chest: Status:" + entity.Status);
                        Console.WriteLine("Chest: Sub:" + entity.Sub);
                        Console.WriteLine("Chest: TargetingIndex:" + entity.TargetingIndex);
                        Console.WriteLine("Chest: Type:" + entity.Type);
                        Console.WriteLine("Chest: WarpPointer:" + entity.WarpPointer);
                        Console.WriteLine("Chest: X:" + entity.X);
                        Console.WriteLine("Chest: Y:" + entity.Y);
                        Console.WriteLine("Chest: Z:" + entity.Z);
                        Console.WriteLine("\n");
                    }
                    else if (entity.Name.StartsWith("Coffer"))
                    {
                        Console.WriteLine("Coffer: " + Convert.ToInt32(entity.TargetID));
                        Console.WriteLine("Coffer: ActionTimer1:" + entity.ActionTimer1);
                        Console.WriteLine("Coffer: ActionTimer2:" + entity.ActionTimer2);
                        for (int i = 0; x < entity.Animations.Length; i++)
                        {
                            Console.WriteLine("Coffer: Animations[" + i + "]:" + entity.Animations[i]);
                        }
                        Console.WriteLine("Coffer: Body:" + entity.Body);
                        Console.WriteLine("Coffer: ClaimID:" + entity.ClaimID);
                        Console.WriteLine("Coffer: CostumeID:" + entity.CostumeID);
                        Console.WriteLine("Coffer: Distance:" + entity.Distance);
                        Console.WriteLine("Coffer: Face:" + entity.Face);
                        Console.WriteLine("Coffer: Feet:" + entity.Feet);
                        Console.WriteLine("Coffer: FishingTimer:" + entity.FishingTimer);
                        Console.WriteLine("Coffer: H:" + entity.H);
                        Console.WriteLine("Coffer: Hands:" + entity.Hands);
                        Console.WriteLine("Coffer: Head:" + entity.Head);
                        Console.WriteLine("Coffer: HealthPercent:" + entity.HealthPercent);
                        Console.WriteLine("Coffer: Legs:" + entity.Legs);
                        Console.WriteLine("Coffer: Main:" + entity.Main);
                        Console.WriteLine("Coffer: ManaPercent:" + entity.ManaPercent);
                        Console.WriteLine("Coffer: ModelSize:" + entity.ModelSize);
                        Console.WriteLine("Coffer: Name:" + entity.Name);
                        Console.WriteLine("Coffer: PetIndex:" + entity.PetIndex);
                        Console.WriteLine("Coffer: PetOwnerID:" + entity.PetOwnerID);
                        Console.WriteLine("Coffer: Race:" + entity.Race);
                        Console.WriteLine("Coffer: Ranged:" + entity.Ranged);
                        Console.WriteLine("Coffer: Render0000:" + entity.Render0000);
                        Console.WriteLine("Coffer: Render0001:" + entity.Render0001);
                        Console.WriteLine("Coffer: Render0002:" + entity.Render0002);
                        Console.WriteLine("Coffer: Render0003:" + entity.Render0003);
                        Console.WriteLine("Coffer: Render0004:" + entity.Render0004);
                        Console.WriteLine("Coffer: ServerID:" + entity.ServerID);
                        Console.WriteLine("Coffer: SpawnFlags:" + entity.SpawnFlags);
                        Console.WriteLine("Coffer: Speed:" + entity.Speed);
                        Console.WriteLine("Coffer: SpeedAnimation:" + entity.SpeedAnimation);
                        Console.WriteLine("Coffer: Status:" + entity.Status);
                        Console.WriteLine("Coffer: Sub:" + entity.Sub);
                        Console.WriteLine("Coffer: TargetingIndex:" + entity.TargetingIndex);
                        Console.WriteLine("Coffer: Type:" + entity.Type);
                        Console.WriteLine("Coffer: WarpPointer:" + entity.WarpPointer);
                        Console.WriteLine("Coffer: X:" + entity.X);
                        Console.WriteLine("Coffer: Y:" + entity.Y);
                        Console.WriteLine("Coffer: Z:" + entity.Z);
                        Console.WriteLine("\n");
                    }
                }
            }
            return targets;
        }
        public int GetClosestTargetIdByNames(IList<string> names, float maxDistance)
        {
            if (names == null || names.Count == 0)
            {
                return -1;
            }

            XiEntity closestTargetEntity = null;
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
                            if (entity.HealthPercent != 0 && entity.Distance <= maxDistance)
                            {
                                if (searchID > entity.Distance &&
                                    entity.ClaimID == 0 &&
                                    entity.HealthPercent != 0)
                                {
                                    if (closestTargetEntity == null)
                                    {
                                        closestTargetEntity = entity;
                                    }
                                    else if (closestTargetEntity.Distance > entity.Distance)
                                    {
                                        closestTargetEntity = entity;
                                    }
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
                if (chatEntry != null && chatEntry.Text.Contains(Name + "'s casting is interrupted.") || spellTimeoutWatch.ElapsedMilliseconds >= TimeSpan.FromSeconds(castTime).TotalMilliseconds)
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
        public void PullWithRanged()
        {
            Thread.Sleep(1000);
            api.ThirdParty.SendString("/ra <t>");
        }
        public int GetTPAbilityRecast(TPAbilityId tpAbilityId)
        {
            IAbility ability = api.Resources.GetAbility((uint)tpAbilityId);
            if (ability != null)
            {
                return GetAbilityRecast(ability.TimerID);
            }
            return 0;
        }
        public int GetAbilityRecast(ushort timerId)
        {
            IList<int> timerIds = api.Recast.GetAbilityIds();
            for (int x = 0; x < timerIds.Count; x++)
            {
                if (timerIds[x] == timerId)
                {
                    return api.Recast.GetAbilityRecast(x);
                }
            }
            return 0;
        }
        public void PerformJobAbility(uint jobAbilityId, string target)
        {
            IAbility ability = api.Resources.GetAbility(jobAbilityId);
            if (ability != null &&
                HasAbility(jobAbilityId) &&
                GetAbilityRecast(ability.TimerID) == 0)
            {
                api.ThirdParty.SendString("/ja \"" + ability.Name[0] + "\" " + target);
                // TODO: Animation Delay - Configurable?
                Thread.Sleep(2500);
            }
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
        public IList<TPAbilityId> GetWeaponSkills()
        {
            IList<TPAbilityId> weaponSkills = new List<TPAbilityId>();
            foreach (TPAbilityId id in Enum.GetValues(typeof(TPAbilityId)).Cast<TPAbilityId>().ToList())
            {
                if (HasWeaponSkill(id))
                {
                    weaponSkills.Add(id);
                }
            }
            return weaponSkills;
        }
        public IList<BlackMagicSpellId> GetBlackMagicSpells()
        {
            IList<BlackMagicSpellId> blackMagicSpells = new List<BlackMagicSpellId>();
            foreach (BlackMagicSpellId id in Enum.GetValues(typeof(BlackMagicSpellId)).Cast<BlackMagicSpellId>().ToList())
            {
                if (CanCastSpell((uint)id))
                {
                    blackMagicSpells.Add(id);
                }
            }
            return blackMagicSpells;
        }
        public int CountStatusEffect(short id)
        {
            int statusEffectOccurs = 0;
            foreach (short buff in api.Player.Buffs)
            {
                if (buff == id)
                {
                    statusEffectOccurs++;
                }
            }
            return statusEffectOccurs;
        }
        public bool HasStatusEffect(short id)
        {
            return CountStatusEffect(id) > 0;
        }
        public void EquipItem(SlotId slotId, ItemId itemId)
        {
            IItem item = GetItem(itemId);
            if (item?.Name[0].Length > 0)
            {
                api.ThirdParty.SendString("/equip " + Enum.GetName(typeof(SlotId), slotId) + " \"" + item.Name[0] + "\"");
            }
            Thread.Sleep(2500);
        }
        public IItem GetItem(ItemId id)
        {
            return api.Resources.GetItem((uint)id);
        }
        public IItem GetItem(uint id)
        {
            return api.Resources.GetItem(id);
        }
        public bool UseItem(ItemId id, string target)
        {
            IItem item = api.Resources.GetItem((uint)id);
            if (MainJobLevel >= item.Level)
            {
                Stopwatch castDelay = new Stopwatch();
                castDelay.Start();
                while (true)
                {
                    Thread.Sleep(250);
                    if (castDelay.ElapsedMilliseconds >= TimeSpan.FromSeconds(item.CastDelay).TotalMilliseconds)
                    {
                        break;
                    }
                }
                api.ThirdParty.SendString("/item \"" + item.Name[0] + "\" " + target);
                int castTime = item.CastTime;
                Stopwatch itemTimeoutWatch = new Stopwatch();
                itemTimeoutWatch.Start();
                while (true)
                {
                    Thread.Sleep(250);
                    if (itemTimeoutWatch.ElapsedMilliseconds >= TimeSpan.FromSeconds(castTime).TotalMilliseconds)
                    {
                        break;
                    }
                }
                return true;
            }
            return false;
        }
        public bool IsEquippedItem(SlotId slotId, ItemId itemId)
        {
            return GetEquippedItem(slotId).Id == (int)itemId;
        }
        public InventoryItem GetEquippedItem(SlotId slotId)
        {
            return api.Inventory.GetEquippedItem((int)slotId);
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
        public bool CanCastSpell(uint id)
        {
            if (HasSpell(id))
            {
                ISpell spell = api.Resources.GetSpell(id);
                if (spell != null)
                {
                    if (GetSpellRecastRemaining((int)id) > 0)
                    {
                        return false;
                    }

                    short levelRequired;
                    if ((levelRequired = spell.LevelRequired[MainJob]) != -1 && MainJobLevel >= levelRequired)
                    {
                        return true;
                    }
                    else if ((levelRequired = spell.LevelRequired[SubJob]) != -1 && SubJobLevel >= levelRequired)
                    {
                        return true;
                    }
                    else if ((levelRequired = spell.LevelRequired[MainJob]) != -1 && MainJobLevel == 99 && SpentJobPoints >= levelRequired)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool HasWhiteMagicSpell(WhiteMagicSpellId id)
        {
            return HasSpell((uint)id);
        }
        public bool HasBlackMagicSpell(BlackMagicSpellId id)
        {
            return HasSpell((uint)id);
        }
        public bool HasSongSpell(SongSpellId id)
        {
            return HasSpell((uint)id);
        }
        public bool HasNinjutsuSpell(NinjutsuSpellId id)
        {
            return HasSpell((uint)id);
        }
        public bool HasSummmoningSpell(SummmoningSpellId id)
        {
            return HasSpell((uint)id);
        }
        public bool HasBlueMagicSpell(BlueMagicSpellId id)
        {
            return HasSpell((uint)id);
        }
        public bool HasGeomancySpell(GeomancySpellId id)
        {
            return HasSpell((uint)id);
        }
        public bool HasTrustSpell(TrustSpellId id)
        {
            return HasSpell((uint)id);
        }
        public bool HasTPAbility(TPAbilityId id)
        {
            return HasAbility((uint)id);
        }
        public bool HasWeaponSkill(TPAbilityId id)
        {
            IAbility ability = api.Resources.GetAbility((uint)id);
            return ability.TimerID == 900 && api.Player.HasWeaponSkill(ability.ID);
        }
        public bool HasJobAbility(JobAbilityId id)
        {
            return HasAbility((uint)id);
        }
        public bool HasPetAbility(PetAbilityId id)
        {
            return HasAbility((uint)id);
        }
        public bool HasAbility(uint id)
        {
            return api.Player.HasAbility(id);
        }
        public bool HasSpell(uint id)
        {
            return api.Player.HasSpell(id);
        }
        public bool IsDead()
        {
            return PlayerStatus == (uint)Status.Dead || PlayerStatus == (uint)Status.Dying;
        }
        public uint Id
        {
            get => api.Party.GetPartyMember(0).ID;
            set => SetPlayer("Id", value);
        }
        public int ServerId
        {
            get => api.Player.ServerId;
            set => SetPlayer("ServerId", value);
        }
        public byte MainJob
        {
            get => api.Player.MainJob;
            set => SetPlayer("MainJob", value);
        }
        public byte SubJob
        {
            get => api.Player.SubJob;
            set => SetPlayer("SubJob", value);
        }
        public byte MainJobLevel
        {
            get => api.Player.MainJobLevel;
            set => SetPlayer("MainJobLevel", value);
        }
        public byte SubJobLevel
        {
            get => api.Player.SubJobLevel;
            set => SetPlayer("SubJobLevel", value);
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
        public ushort SpentJobPoints
        {
            get => api.Player.GetJobPoints(MainJob).SpentJobPoints;
            set => SetPlayer("SpentJobPoints", value);
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
        public short[] StatusEffects
        {
            get => api.Player.Buffs;
            set => SetPlayer("StatusEffects");
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
        public byte PetHPP
        {
            get => api.Player.Pet.HealthPercent;
            set => SetPlayer("PetHPP");
        }
        private void PlayerMonitor()
        {
            uint id = 0;
            int serverId = 0;
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
            ushort spentJobPoints = 0;
            float x = 0.0f;
            float y = 0.0f;
            float z = 0.0f;
            float h = 0.0f;
            short[] statusEffects = new short[] { };
            bool moving = false;
            bool pulling = false;
            bool casting = false;
            byte petHPP = 0;
            while (true)
            {
                if (id != Id)
                {
                    id = Id;
                    OnPropertyChanged("Id");
                }
                if (serverId != ServerId)
                {
                    serverId = ServerId;
                    OnPropertyChanged("ServerId");
                }
                if (job != MainJob)
                {
                    job = MainJob;
                    OnPropertyChanged("MainJob");
                }
                if (subJob != SubJob)
                {
                    subJob = SubJob;
                    OnPropertyChanged("SubJob");
                }
                if (name != null && !name.Equals(Name))
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
                if (spentJobPoints != SpentJobPoints)
                {
                    spentJobPoints = SpentJobPoints;
                    OnPropertyChanged("SpentJobPoints");
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
                if (petHPP != PetHPP)
                {
                    petHPP = PetHPP;
                    OnPropertyChanged("PetHPP");
                }
                if (!Enumerable.SequenceEqual(statusEffects, StatusEffects))
                {
                    statusEffects = StatusEffects;
                    OnPropertyChanged("StatusEffects");
                }
                Thread.Sleep(100);
            }
        }
    }
}
