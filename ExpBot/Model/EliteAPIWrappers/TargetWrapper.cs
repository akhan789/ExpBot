using EliteMMO.API;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using static EliteMMO.API.EliteAPI;

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
                case "TargetIndex":
                case "EntryPointer":
                case "Id":
                case "Name":
                case "HPP":
                case "LockedOn":
                case "Distance":
                case "X":
                case "Y":
                case "Z":
                case "H":
                case "HasSubTarget":
                case "SubTargetIndex":
                case "SubTargetEntryPointer":
                case "SubTargetId":
                case "SubTargetName":
                case "SubTargetHPP":
                default:
                    break;
            }
        }
        public uint TargetStatus
        {
            get => api.Entity.GetEntity(Convert.ToInt32(TargetIndex)).Status;
            set => SetTarget("TargetStatus", value);
        }
        public uint TargetIndex
        {
            get => api.Target.GetTargetInfo().TargetIndex;
            set => SetTarget("TargetIndex", value);
        }
        public XiEntity Entity
        {
            get => api.Entity.GetEntity((int)api.Target.GetTargetInfo().TargetIndex);
            set => SetTarget("Entity", value);
        }
        public uint EntryPointer
        {
            get => api.Target.GetTargetInfo().TargetEntryPointer;
            set => SetTarget("EntryPointer", value);
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
        public bool HasSubTarget
        {
            get => api.Target.GetTargetInfo().HasSubTarget;
            set => SetTarget("HasSubTarget", value);
        }
        public uint SubTargetIndex
        {
            get => api.Target.GetTargetInfo().SubTargetIndex;
            set => SetTarget("SubTargetIndex", value);
        }
        public uint SubTargetEntryPointer
        {
            get => api.Target.GetTargetInfo().SubTargetEntryPointer;
            set => SetTarget("SubTargetEntryPointer", value);
        }
        public uint SubTargetId
        {
            get => api.Target.GetTargetInfo().SubTargetId;
            set => SetTarget("SubTargetId", value);
        }
        public string SubTargetName
        {
            get => api.Target.GetTargetInfo().SubTargetName;
            set => SetTarget("SubTargetName", value);
        }
        public int SubTargetHPP
        {
            get => api.Target.GetTargetInfo().SubTargetHealthPercent;
            set => SetTarget("SubTargetHealthPercent", value);
        }
        private void TargetMonitor()
        {
            uint targetStatus = 0;
            uint targetIndex = 0;
            uint entryPointer = 0;
            uint id = 0;
            string name = "";
            int hpp = 0;
            bool lockedOn = false;
            double distance = 0.0d;
            float x = 0.0f;
            float y = 0.0f;
            float z = 0.0f;
            float h = 0.0f;
            bool hasSubTarget = false;
            uint subTargetIndex = 0;
            uint subTargetEntryPointer = 0;
            uint subTargetId = 0;
            string subTargetName = "";
            int subTargetHPP = 0;
            while (true)
            {
                if (targetStatus != TargetStatus)
                {
                    targetStatus = TargetStatus;
                    OnPropertyChanged("TargetStatus");
                }
                if (targetIndex != TargetIndex)
                {
                    targetIndex = TargetIndex;
                    OnPropertyChanged("TargetIndex");
                }
                if (entryPointer != EntryPointer)
                {
                    entryPointer = EntryPointer;
                    OnPropertyChanged("EntryPointer");
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
                if (hasSubTarget != HasSubTarget)
                {
                    hasSubTarget = HasSubTarget;
                    OnPropertyChanged("HasSubTarget");
                }
                if (subTargetIndex != SubTargetIndex)
                {
                    subTargetIndex = SubTargetIndex;
                    OnPropertyChanged("SubTargetIndex");
                }
                if (subTargetEntryPointer != SubTargetEntryPointer)
                {
                    subTargetEntryPointer = SubTargetEntryPointer;
                    OnPropertyChanged("SubTargetEntryPointer");
                }
                if (subTargetId != SubTargetId)
                {
                    subTargetId = SubTargetId;
                    OnPropertyChanged("SubTargetId");
                }
                if (subTargetName != SubTargetName)
                {
                    subTargetName = SubTargetName;
                    OnPropertyChanged("SubTargetName");
                }
                if (subTargetHPP != SubTargetHPP)
                {
                    subTargetHPP = SubTargetHPP;
                    OnPropertyChanged("SubTargetHPP");
                }
                Thread.Sleep(100);
            }
        }
    }
}
