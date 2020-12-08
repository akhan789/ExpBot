using EliteMMO.API;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;

namespace ExpBot.Model.EliteAPIWrappers
{
    public class TargetWrapper : APIConstants, INotifyPropertyChanged
    {
        private static EliteAPI api;
        public TargetWrapper(EliteAPI api)
        {
            TargetWrapper.api = api;

            Thread targetMonitorThread = new Thread(TargetMonitor);
            targetMonitorThread.IsBackground = true;
            targetMonitorThread.Start();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void SetTarget(string propertyName, params object[] properties)
        {
            switch (propertyName)
            {
                case "TargetStatus":
                case "Id":
                case "TargetId":
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
        private void TargetMonitor()
        {
            uint targetStatus = TargetStatus;
            uint id = Id;
            string name = Name;
            int hpp = HPP;
            bool lockedOn = LockedOn;
            double distance = Distance;
            float x = X;
            float y = Y;
            float z = Z;
            float h = H;
            while (true)
            {
                if (targetStatus != TargetStatus)
                {
                    targetStatus = TargetStatus;
                    OnPropertyChanged("TargetStatus");
                }
                if (id != Id)
                {
                    id = Id;
                    OnPropertyChanged("Id");
                }
                if (name != Name)
                {
                    name = Name;
                    OnPropertyChanged("Name");
                }
                if (hpp != HPP)
                {
                    hpp = HPP;
                    OnPropertyChanged("HPP");
                }
                if (lockedOn != LockedOn)
                {
                    lockedOn = LockedOn;
                    OnPropertyChanged("LockedOn");
                }
                if (distance != Distance)
                {
                    distance = Distance;
                    OnPropertyChanged("Distance");
                }
                if (x != X)
                {
                    x = X;
                    OnPropertyChanged("X");
                }
                if (y != Y)
                {
                    y = Y;
                    OnPropertyChanged("Y");
                }
                if (z != Z)
                {
                    z = Z;
                    OnPropertyChanged("Z");
                }
                if (h != H)
                {
                    h = H;
                    OnPropertyChanged("H");
                }
                Thread.Sleep(100);
            }
        }
    }
}
