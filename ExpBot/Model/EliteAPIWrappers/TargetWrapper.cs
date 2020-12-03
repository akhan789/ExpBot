using EliteMMO.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExpBot.Model.EliteAPIWrappers
{
    public class TargetWrapper : APIConstants
    {
        private static EliteAPI api;
        public TargetWrapper(EliteAPI api)
        {
            TargetWrapper.api = api;
        }
        public void SetTarget(string propertyName, params object[] properties)
        {
            switch (propertyName)
            {
                case "TargetId":
                case "TargetName":
                case "TargetHPP":
                default:
                    break;
            }
        }
        public uint TargetId
        {
            get => api.Target.GetTargetInfo().TargetId;
            set => SetTarget("TargetId", value);
        }
        public string TargetName
        {
            get => api.Target.GetTargetInfo().TargetName;
            set => SetTarget("TargetName", value);
        }
        public int TargetHPP
        {
            get => api.Target.GetTargetInfo().TargetHealthPercent;
            set => SetTarget("TargetHP", value);
        }
    }
}
