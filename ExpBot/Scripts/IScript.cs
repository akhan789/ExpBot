using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ExpBot.Scripts
{
    public interface IScript
    {
        event PropertyChangedEventHandler PropertyChanged;
        void Run();
        bool Running { get; set; }
    }
}
