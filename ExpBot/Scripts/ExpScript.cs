using EliteMMO.API;
using ExpBot.Model.EliteAPIWrappers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using static EliteMMO.API.EliteAPI;

namespace ExpBot.Scripts
{
    public class ExpScript
    {
        public static bool running;
        private PlayerWrapper player;
        private TargetWrapper target;
        private PartyWrapper party;
        public ExpScript(PlayerWrapper player, TargetWrapper target, PartyWrapper party)
        {
            this.player = player;
            this.target = target;
            this.party = party;
        }
        ~ExpScript()
        {
            ExpScript.running = false;
        }
        public void Run()
        {
            while (ExpScript.running)
            {
                //Console.WriteLine("Player status: " + player.Status.ToString());
                //Console.WriteLine("Target Id: " + target.TargetId);
                //Console.WriteLine("Target name: " + target.TargetName);
                //Console.WriteLine("Target HPP: " + target.TargetHPP);
                //Console.WriteLine("Has ability Realmrazer: " + player.HasTPAbility(APIConstants.TPAbilityId.Realmrazer));
                //Console.WriteLine("Has ability Combo: " + player.HasTPAbility(APIConstants.TPAbilityId.Combo));
                //Console.WriteLine("Has ability Drain Samba: " + player.HasTPAbility(APIConstants.TPAbilityId.DrainSamba));
                //Console.WriteLine("Has ability Convert: " + player.HasJobAbility(APIConstants.JobAbilityId.Convert));
                //foreach(PartyMember member in party.PartyMembers) {
                //    Console.WriteLine("Party Member.Name: " + member.Name);
                //    Console.WriteLine("Party Member.HP: " + member.CurrentHP);
                //    Console.WriteLine("Party Member.Active: " + member.Active);
                //}
                List<IItem> sortedItems = new List<IItem>();
                for (uint i = 0; i <= 50000; i++)
                {
                    IItem item = player.Item(i);
                    if (item != null)
                    {
                        sortedItems.Add(item);
                    }
                }
                sortedItems.Sort((a, b) => a.ItemID.CompareTo(b.ItemID));

                int x = 1;
                foreach (IItem item in sortedItems)
                {
                    string name = item.Name[0];
                    if (name.Length == 0 || name == ".")
                    {
                        //Console.WriteLine("RESERVED" + x.ToString() + " = " + item.ItemID + ",");
                        x++;
                    }
                    else
                    {
                        Console.WriteLine(name + " = " + item.ItemID + ",");
                    }
                    //    //Console.WriteLine("Ability ID: " + ability.ID);
                    //    //Console.WriteLine("Ability Name0: " + ability.Name[0]);
                    //    //Console.WriteLine("Ability Name1: " + ability.Name[1]);
                    //    //Console.WriteLine("Ability Name2: " + ability.Name[2]);
                    //    //Console.WriteLine("Ability Description: " + ability.Description);
                    //    //Console.WriteLine("Ability MP: " + ability.MP);
                    //    //Console.WriteLine("Ability TP: " + ability.TP);
                    //    //Console.WriteLine("Ability Range: " + ability.Range);
                    //    //Console.WriteLine("Ability MonsterLevel: " + ability.MonsterLevel);
                    //    //Console.WriteLine("Ability TimerID: " + ability.TimerID);
                    //    //Console.WriteLine("Ability ValidTargets: " + ability.ValidTargets);
                    //    //Console.WriteLine("Ability Type: " + ability.Type);
                    //    //Console.WriteLine("Ability Element: " + ability.Element);
                    //    //Console.WriteLine(ability.ToString());
                }
                Thread.Sleep(2000);
                ExpScript.running = false;
            }
        }
    }
}