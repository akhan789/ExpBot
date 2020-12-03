using EliteMMO.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static EliteMMO.API.EliteAPI;

namespace ExpBot.Model.EliteAPIWrappers
{
    public class PartyWrapper
    {
        private static EliteAPI api;
        public PartyWrapper(EliteAPI api)
        {
            PartyWrapper.api = api;
        }
        public void SetParty(string propertyName, params object[] properties)
        {
            switch (propertyName)
            {
                case "PartyMembers":
                case "PartyMember":
                default:
                    break;
            }
        }
        public List<PartyMember> PartyMembers
        {
            get => api.Party.GetPartyMembers();
            set => SetParty("PartyMembers", value);
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
    }
}
