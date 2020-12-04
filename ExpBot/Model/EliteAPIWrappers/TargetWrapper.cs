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
                case "TargetStatus":
                case "Id":
                case "Name":
                case "HPP":
                case "LockedOn":
                case "Distance":
                case "X":
                case "Y":
                case "Z":
                case "H":
                default:
                    break;
            }
        }
        public bool SetTarget(int index)
        {
            return api.Target.SetTarget(index);
        }
        public uint TargetStatus
        {
            get => api.Entity.GetEntity(Convert.ToInt32(Id)).Status;
            set => SetTarget("TargetStatus", value);
        }
        public uint Id
        {
            get => api.Target.GetTargetInfo().TargetId;
            set => SetTarget("Id", value);
        }
        public string Name
        {
            get => api.Target.GetTargetInfo().TargetName;
            set => SetTarget("Name", value);
        }
        public int HPP
        {
            get => api.Target.GetTargetInfo().TargetHealthPercent;
            set => SetTarget("TargetHP", value);
        }
        public bool LockedOn
        {
            get => api.Target.GetTargetInfo().LockedOn;
            set => SetTarget("LockedOn", value);
        }
        public double Distance
        {
            get => Math.Truncate((10 * api.Entity.GetEntity((int)api.Target.GetTargetInfo().TargetIndex).Distance) / 10);
            set => SetTarget("Distance", value);
        }
        public float X
        {
            get => api.Entity.GetEntity((int)api.Target.GetTargetInfo().TargetIndex).X;
            set => SetTarget("X", value);
        }
        public float Y
        {
            get => api.Entity.GetEntity((int)api.Target.GetTargetInfo().TargetIndex).Y;
            set => SetTarget("Y", value);
        }
        public float Z
        {
            get => api.Entity.GetEntity((int)api.Target.GetTargetInfo().TargetIndex).Z;
            set => SetTarget("Z", value);
        }
        public float H
        {
            get => api.Entity.GetEntity((int)api.Target.GetTargetInfo().TargetIndex).H;
            set => SetTarget("H", value);
        }
    }
}
