using EliteMMO.API;
using ExpBot.Model.EliteAPIWrappers;
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
    public class ExpBotDefaultModel : IExpBotModel, INotifyPropertyChanged
    {
        private static EliteAPI api;
        private Process currentPOLProcess;
        private IList<Process> currentProcesses;
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
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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
        public IList<Process> CurrentProcesses
        {
            get => currentProcesses;
            set => currentProcesses = value;
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
        public PlayerWrapper Player
        {
            get => player;
            set
            {
                player = value;
                OnPropertyChanged("Player");
            }
        }
        public TargetWrapper Target
        {
            get => target;
            set
            {
                target = value;
                OnPropertyChanged("Target");
            }
        }
        public PartyWrapper Party
        {
            get => party;
            set
            {
                party = value;
                OnPropertyChanged("Party");
            }
        }
    }
}
