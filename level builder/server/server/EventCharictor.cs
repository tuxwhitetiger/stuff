using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace server
{
    public class EventCharictor
    {
        private string name;
        private int HP;
        private int AttackType;
        private int AttackPower;
        List<String> conversation = new List<string>();

        public EventCharictor(string name, int HP, int AttackType, int AttackPower)
        {
            this.name = name;
            this.HP = HP;
            this.AttackType = AttackType;
            this.AttackPower = AttackPower;
        }

        internal void directlyAddTalk(string talk)
        {
            conversation.Add(talk);
        }

        internal String getData()
        {
            StringBuilder sb = new StringBuilder(); 
            sb.Append(name + "," + HP + "," + AttackType + "," + AttackPower + ",");
            foreach (String s in conversation) {
                sb.Append(s+".");
            }


            return sb.ToString();
        }
    }
}
