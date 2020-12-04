using ExpBot.Model;
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
            ExpScript.running = false;
            model.Unload();
        }
        public bool StartStopBot()
        {
            if (Initialised)
            {
                ExpScript script;
                if (!ExpScript.running && (script = new ExpScript(model.Player, model.Target, model.Party)) != null)
                {
                    ExpScript.running = true;
                    Thread botThread = new Thread(new ThreadStart(script.Run));
                    botThread.IsBackground = true;
                    botThread.Start();
                    return ExpScript.running;
                }
                else
                {
                    model.Unload();
                    return ExpScript.running = false;
                }
            }
            else
            {
                return ExpScript.running = false;
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
    }
}