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
    public class PartyWrapper : APIConstants, INotifyPropertyChanged
    {
        private static EliteAPI api;
        public PartyWrapper(EliteAPI api)
        {
            PartyWrapper.api = api;

            Thread partyMonitorThread = new Thread(PartyMonitor);
            partyMonitorThread.IsBackground = true;
            partyMonitorThread.Start();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void SetParty(string propertyName, params object[] properties)
        {
            switch (propertyName)
            {
                case "AllianceMembers":
                case "PartyMembers":
                case "PartyMember":
                default:
                    break;
            }
        }
        public IList<PartyMember> PartyMembers
        {
            get
            {
                IList<PartyMember> partyMembers = new List<PartyMember>();
                IList<PartyMember> allianceMembers = AllianceMembers;
                for (int i = 0; i < api.Party.GetAllianceInfo().Party0Count; i++)
                {
                    partyMembers.Add(allianceMembers[i]);
                }
                return partyMembers;
            }
            set => SetParty("PartyMembers", value);
        }
        public IList<PartyMember> AllianceMembers
        {
            get => api.Party.GetPartyMembers();
            set => SetParty("AllianceMembers", value);
        }
        /// <summary>
        /// Party Member 1 (Index 0) is the Player.
        /// </summary>
        public PartyMember PartyMember1
        {
            get => api.Party.GetPartyMember(0);
            set => SetParty("PartyMember", value);
        }
        public PartyMember PartyMember2
        {
            get => api.Party.GetPartyMember(1);
            set => SetParty("PartyMember", value);
        }
        public PartyMember PartyMember3
        {
            get => api.Party.GetPartyMember(2);
            set => SetParty("PartyMember", value);
        }
        public PartyMember PartyMember4
        {
            get => api.Party.GetPartyMember(3);
            set => SetParty("PartyMember", value);
        }
        public PartyMember PartyMember5
        {
            get => api.Party.GetPartyMember(4);
            set => SetParty("PartyMember", value);
        }
        public PartyMember PartyMember6
        {
            get => api.Party.GetPartyMember(5);
            set => SetParty("PartyMember", value);
        }
        public bool IsPartyMemberPresent(string partyMemberName)
        {
            foreach (PartyMember member in PartyMembers)
            {
                if (member.Name[0].Equals(partyMemberName))
                {
                    return true;
                }
            }
            return false;
        }
        private void PartyMonitor()
        {
            while (true)
            {
                Thread.Sleep(100);
            }
        }
    }
}
