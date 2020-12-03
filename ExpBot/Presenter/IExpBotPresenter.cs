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
        bool StartStopBot();
        void Initialise(Process process);
        bool Initialised { get; set; }
    }
}
