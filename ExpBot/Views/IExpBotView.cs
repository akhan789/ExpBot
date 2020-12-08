using ExpBot.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExpBot.Views
{
    public interface IExpBotView
    {
        void UpdatePOLProcessList();
        void UpdatePlayerDetails();
        void UpdateTargetDetails();
        void UpdatePartyDetails();
    }
}
