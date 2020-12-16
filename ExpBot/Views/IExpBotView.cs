using ExpBot.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExpBot.Views
{
    public interface IExpBotView
    {
        void CloseView();
        void UpdatePOLProcessList();
        void UpdateTargetList();
        void UpdateSelectedTargets();
        void UpdateTrustList();
        void UpdatePlayerDetails();
        void UpdateTargetDetails();
        void UpdatePartyDetails();
        void UpdateScriptDetails();
    }
}
