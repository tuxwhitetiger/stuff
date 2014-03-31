using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace game
{
    public class EventCharictor
    {
        private string name;
        private int HP;
        private int AttackType;
        private int AttackPower;
        List<String> conversation = new List<string>();
        Texture2D spriteSheet;

        public EventCharictor(string name, int HP, int AttackType, int AttackPower,Texture2D spritesheet)
        {
            this.name = name;
            this.HP = HP;
            this.AttackType = AttackType;
            this.AttackPower = AttackPower;
            this.spriteSheet = spritesheet;
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
    }
}
