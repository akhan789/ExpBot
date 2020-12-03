using ExpBot.Model.EliteAPIWrappers;
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
        PlayerWrapper Player { get; set; }
        TargetWrapper Target { get; set; }
        PartyWrapper Party { get; set; }
    }
}
