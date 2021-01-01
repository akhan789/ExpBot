using ExpBot.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ExpBot.ViewModel
{
    public interface IExpBotPresenter
    {
        void OnLoad();
        void Close();
        bool StartBot();
        bool StopBot();
        void Initialise(Process process);
        bool Initialised { get; set; }
        void AddTarget(string name);
        void RemoveTarget(string name);
    }
}