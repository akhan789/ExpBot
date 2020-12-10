﻿using ExpBot.Model;
using ExpBot.Scripts;
using ExpBot.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace ExpBot.ViewModel
{
    public class ExpBotDefaultPresenter : IExpBotPresenter
    {
        private IExpBotView view;
        private IExpBotModel model;
        private Thread botThread;
        public bool initialised;
        public ExpBotDefaultPresenter(IExpBotView view, IExpBotModel model)
        {
            this.view = view;
            this.model = model;
        }
        public void OnLoad()
        {
            Thread polProcessMonitorThread = new Thread(POLProcessMonitor);
            polProcessMonitorThread.IsBackground = true;
            polProcessMonitorThread.Start();
        }
        public void Close()
        {
            model.Unload();
            view.CloseView();
        }
        public bool StartStopBot()
        {
            IScript script = model.Script;
            if (Initialised)
            {
                if (script == null || !script.Running)
                {
                    script = model.Script = new ExpScript(model.Player, model.Target, model.Party);
                    script.Running = true;
                    ((IExpScript)script).TargetNames = model.SelectedTargetList;
                    ((IExpScript)script).TrustNames = model.SelectedTrustList;

                    botThread = new Thread(new ThreadStart(script.Run));
                    botThread.IsBackground = true;
                    botThread.Start();
                    return script.Running;
                }
                else
                {
                    script.Running = false;
                    if (botThread != null)
                    {
                        botThread.Interrupt();
                        botThread.Join();
                    }
                    return script.Running;
                }
            }
            else
            {
                if (script != null || botThread != null)
                {
                    if (script != null)
                    {
                        script.Running = false;
                        model.Script = null;
                    }
                    if (botThread != null)
                    {
                        botThread.Interrupt();
                        botThread.Join();
                    }
                }
                return false;
            }
        }
        public void Initialise(Process process)
        {
            try
            {
                if (model.CurrentPOLProcess?.Id != process.Id)
                {
                    model.CurrentPOLProcess = process;
                    Initialised = true;
                    model.Player.PropertyChanged += Player_PropertyChanged;
                    model.Target.PropertyChanged += Target_PropertyChanged;
                    model.Party.PropertyChanged += Party_PropertyChanged;
                    view.UpdateTargetList();
                    view.UpdateTrustList();
                }
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
                Initialised = false;
            }
        }

        public void POLProcessMonitor()
        {
            int initialPOLProcessCount = 0;
            while (true)
            {
                IList<Process> currentPOLProcesses;
                if ((currentPOLProcesses = model.POLProcesses)?.Count != initialPOLProcessCount)
                {
                    initialPOLProcessCount = currentPOLProcesses.Count;
                    view.UpdatePOLProcessList();
                }
                Thread.Sleep(5000);
            }
        }
        public bool Initialised
        {
            get => initialised;
            set
            {
                initialised = value;
            }
        }
        private void Player_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            view.UpdatePlayerDetails();
        }
        private void Target_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            view.UpdateTargetDetails();
        }
        private void Party_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            view.UpdatePartyDetails();
        }
        public void AddTarget(string name)
        {
            IList<string> targets;
            if ((targets = model.SelectedTargetList) == null)
            {
                targets = model.SelectedTargetList = new List<string>();
            }
            if (!targets.Contains(name))
            {
                targets.Add(name);
                model.SelectedTargetList = targets;
                view.UpdateSelectedTargets();
            }
        }
        public void RemoveTarget(string name)
        {
            IList<string> targets;
            if ((targets = model.SelectedTargetList) == null)
            {
                targets = model.SelectedTargetList = new List<string>();
            }
            if (targets.Contains(name))
            {
                targets.Remove(name);
                model.SelectedTargetList = targets;
                view.UpdateSelectedTargets();
            }
        }
        public void SetTrusts(IList<string> trustsList)
        {
            model.SelectedTrustList = trustsList;
        }
    }
}