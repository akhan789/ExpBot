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

namespace ExpBot.Model
{
    public class ExpBotDefaultModel : IExpBotModel
    {
        private static EliteAPI api;
        private Process currentPOLProcess;
        private IList<Process> currentProcesses;
        private IList<string> selectedTargetList;
        private IList<string> trustList;
        private IScript script;
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
        public IScript Script
        {
            get => script;
            set => script = value;
        }
        public IList<Process> CurrentProcesses
        {
            get => currentProcesses;
            set => currentProcesses = value;
        }
        public IList<string> TargetList
        {
            get => player.GetAllAvailableTargets();
        }
        public IList<string> SelectedTargetList
        {
            get => selectedTargetList;
            set => selectedTargetList = value;
        }
        public IList<string> TrustList
        {
            get => player.GetAllAvailableTrusts();
        }
        public IList<string> SelectedTrustList
        {
            get => trustList;
            set => trustList = value;
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
