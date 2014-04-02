using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace game
{
    public class EventCharictor
    {
        private int ID;
        private string name;
        private int HP;
        private int MAXHP;
        private int AttackType;
        private int AttackPower;
        private int XP = 100;
        public bool alive = true;
        List<String> conversation = new List<string>();
        Texture2D spriteSheet;

        public EventCharictor(string name, int HP, int AttackType, int AttackPower,Texture2D spritesheet,int id)
        {
            this.name = name;
            this.HP = HP;
            MAXHP = HP;
            this.AttackType = AttackType;
            this.AttackPower = AttackPower;
            this.spriteSheet = spritesheet;
            ID = id;
        }

        internal void directlyAddTalk(string talk)
        {
            conversation.Add(talk);
        }

        internal Texture2D getSpriteSheet()
        {
            return spriteSheet;
        }


        internal int getTalkLength()
        {
            return conversation.Count;
        }

        internal string getTalkLength(int i)
        {
            return conversation[i];
        }

        internal string getName()
        {
            return name;
        }

        internal void dealdamage(int p)
        {
            HP -= p;
            if (HP < 0) {
                alive = false;
            }
        }
        internal int getHpPersentage() {
            return (int)(((double)HP / (double)MAXHP)*100); 
        }

        internal int getHp()
        {
            return HP;
        }
        internal int getID()
        {
            return ID;
        }

        internal void setHP(int HP)
        {
            this.HP = HP;
        }

        internal int getXP()
        {
            return XP;
        }
    }
}
