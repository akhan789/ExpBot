using ExpBot.Model.EliteAPIWrappers;
using ExpBot.Scripts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ExpBot.Model
{
    public interface IExpBotModel
    {
        IList<Process> POLProcesses { get; }
        Process CurrentPOLProcess { get; set; }
        void Unload();
        IScript Script { get; set; }
        IList<string> TargetList { get; }
        IList<string> SelectedTargetList { get; set; }
        IList<string> TrustList { get; }
        IList<string> SelectedTrustList { get; set; }
        PlayerWrapper Player { get; set; }
        TargetWrapper Target { get; set; }
        PartyWrapper Party { get; set; }
    }
}
