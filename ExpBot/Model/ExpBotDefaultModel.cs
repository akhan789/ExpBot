using EliteMMO.API;
using ExpBot.Model.EliteAPIWrappers;
using ExpBot.Scripts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static ExpBot.Model.EliteAPIWrappers.APIConstants;

namespace ExpBot.Model
{
    public class ExpBotDefaultModel : IExpBotModel
    {
        private static EliteAPI api;
        private Process currentPOLProcess;
        private IList<Process> currentProcesses;
        private IScript script;
        private bool keepWithinMeleeRange;
        private bool restMP;
        private bool useWeaponSkill;
        private bool summonTrusts;
        private bool returnToIdleLocation;
        private bool useCapPointEquipment;
        private bool useExpPointEquipment;
        private bool useAutoHeal;
        private bool pullWithSpell;
        private IList<string> selectedTargetList;
        private IList<string> trustList;
        private int restMPP;
        private TPAbilityId weaponSkillId;
        private BlackMagicSpellId pullBlackMagicSpellId;
        private int weaponSkillTP;
        private double meleeRange;
        private double pullDistance;
        private float pullSearchRadius;
        private float pullDelay;
        private float idleRadius;
        private PlayerWrapper player;
        private TargetWrapper target;
        private PartyWrapper party;
        public ExpBotDefaultModel()
        {
        }
        public IList<Process> POLProcesses
        {
            get => CurrentProcesses = Process.GetProcessesByName(Path.GetFileNameWithoutExtension("pol"));
        }
        public Process CurrentPOLProcess
        {
            get => currentPOLProcess;
            set
            {
                currentPOLProcess = value;
                InitializeApi();
            }
        }
        public void Unload()
        {
            api.ThirdParty.SendString("//lua unload ScriptedExtender");
        }
        protected void InitializeApi()
        {
            if (CurrentPOLProcess != null)
            {
                if (api == null)
                {
                    api = new EliteAPI(CurrentPOLProcess.Id);
                }
                else
                {
                    api.Reinitialize(CurrentPOLProcess.Id);
                }
                api.ThirdParty.SendString("//lua load ScriptedExtender");
                Player = new PlayerWrapper(api);
                Target = new TargetWrapper(api);
                Party = new PartyWrapper(api);
            }
            else
            {
                throw new Exception("POL Process not found when initialise called");
            }
        }
        public IList<Process> CurrentProcesses
        {
            get => currentProcesses;
            set => currentProcesses = value;
        }
        public IScript Script
        {
            get => script;
            set => script = value;
        }
        public IList<string> SelectedTargetList
        {
            get => selectedTargetList;
            set => selectedTargetList = value;
        }
        public IList<string> SelectedTrustList
        {
            get => trustList;
            set => trustList = value;
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
        public bool ReturnToIdleLocation
        {
            get => returnToIdleLocation;
            set => returnToIdleLocation = value;
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
        public BlackMagicSpellId PullBlackMagicSpellId
        {
            get => pullBlackMagicSpellId;
            set => pullBlackMagicSpellId = value;
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
        public PlayerWrapper Player
        {
            get => player;
            set
            {
                player = value;
            }
        }
        public TargetWrapper Target
        {
            get => target;
            set
            {
                target = value;
            }
        }
        public PartyWrapper Party
        {
            get => party;
            set
            {
                party = value;
            }
        }
    }
}
