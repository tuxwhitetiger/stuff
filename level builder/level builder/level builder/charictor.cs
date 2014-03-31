using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace level_builder
{
    public class charictor
    {
        String Name="";

        int ID = 0;
        int Hp=0;
        int AttackType=0;
        int AttackPower=0;

        conversation convo = new conversation();

        StringBuilder convoMessage = new StringBuilder();

        String detailsToDraw = "";

        public charictor(int ID,String name,int HP,int attckType,int attackPower) {

            this.ID = ID;
            this.Name = name;
            this.Hp = HP;
            this.AttackType = attckType;
            this.AttackPower = attackPower;
        }
        public String getName() {
            return Name;
        }
        public void addConvo(String talk) {
            convoMessage.Append(talk);
        }
        public void dumpToConvo() {
            convo.addTalk(convoMessage.ToString()+".");
            convoMessage.Clear();
        }
        public int getID() {
            return ID;
        }


        internal String getHP()
        {
            return Hp.ToString();
        }

        internal String getAttackType()
        {
            return AttackType.ToString();
        }

        internal String getAttackPower()
        {
            return AttackPower.ToString();
        }

        internal void appendName(string s)
        {
            Name += s;
        }

        internal void appendHP(string s)
        {
            try
            {
                Hp = int.Parse(Hp.ToString() + s);
            }
            catch (Exception ex) { }
        }

        internal void appendAttackType(string s)
        {
            try
            {
                AttackType = int.Parse(AttackType.ToString() + s);
            }
            catch (Exception ex) { }
        }

        internal void appendAttackPower(string s)
        {
            try
            {
                AttackPower = int.Parse(AttackPower.ToString() + s);
            }
            catch (Exception ex) { }
        }

        internal void backName()
        {
            if (Name.Length > 0)
            {
                Name = Name.Substring(0, Name.Length - 1);
            }
        }

        internal void backHP()
        {
            if (Hp.ToString().Length > 0)
            {
                if (Hp.ToString().Length == 1)
                {
                    Hp = 0;
                }
                else
                {
                    Hp = int.Parse(Hp.ToString().Substring(0, Hp.ToString().Length - 1));
                }
            }
        }

        internal void backAttackType()
        {
            if (AttackType.ToString().Length > 0)
            {
                if (AttackType.ToString().Length == 1)
                {
                    AttackType = 0;
                }
                else
                {
                    AttackType = int.Parse(AttackType.ToString().Substring(0, AttackType.ToString().Length - 1));
                }
            }
        }

        internal void backAttackPower()
        {
            if (AttackPower.ToString().Length > 0)
            {
                if (AttackPower.ToString().Length == 1)
                {
                    AttackPower = 0;
                }
                else
                {
                    AttackPower = int.Parse(AttackPower.ToString().Substring(0, AttackPower.ToString().Length - 1));
                }
            }
        }

        internal void backConvo()
        {
            convoMessage.Remove(convoMessage.Length - 1, 1);
        }

        internal String DrawConvo()
        {
            StringBuilder sb = new StringBuilder();

            foreach (string s in convo.getList())
            {
                sb.Append(s + "\n");
            }
            return sb.ToString();
        }
        internal String DrawCurrentConvoMessage()
        {
            return convoMessage.ToString();
        }

        internal IEnumerable<string> getconvo()
        {
            return convo.getList();
        }

        internal void directlyAddTalk(string talk)
        {
            convo.addTalk(talk);
        }
    }
}
