using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace game
{
    class TalentNode
    {
        String name;
        String effectDetail;
        Vector2 position;
        bool availble = false;
        bool got = false;
        int HP;
        int strength;
        int interlect;
        int dexterity;
        int armor;
        int damage;
        int mana;
        List<TalentNode> dependants = new List<TalentNode>();
        public TalentEffect effect;
        public int Level;
        public int maxLevel;

        public TalentNode(String name, String effectDetail, Vector2 position, bool availble, List<TalentNode> dependants, bool got, int HP, int strength, int interlect, int dexterity, int armor, int damage, int mana, TalentEffect effect, int maxlevel)
        {
            this.position = position;
            this.mana = mana;
            this.damage = damage;
            this.armor = armor;
            this.dexterity = dexterity;
            this.interlect = interlect;
            this.strength = strength;
            this.HP = HP;
            this.availble = availble;
            this.dependants = dependants;
            setGot(got);
            this.effect = effect;
            this.name = name;
            this.effectDetail = effectDetail;
            this.maxLevel = maxlevel;
        }
        public TalentNode(String name, String effectDetail, Vector2 position, int HP, int strength, int interlect, int dexterity, int armor, int damage, int mana, TalentEffect effect, int maxlevel)
        {
            this.position = position;
            this.mana = mana;
            this.damage = damage;
            this.armor = armor;
            this.dexterity = dexterity;
            this.interlect = interlect;
            this.strength = strength;
            this.HP = HP;
            this.effect = effect;
            this.name = name;
            this.effectDetail = effectDetail;
            this.maxLevel = maxlevel;
        }
        public TalentNode(String node)
        {

        }
        public void setlevel(int i) {
            Level = i;
        }
        public void addDependant(TalentNode node) {
            dependants.Add(node);
        }
        public void draw(SpriteBatch sp){
            
        }

        internal int getHP()
        {
            return HP;
        }

        internal int getstrength()
        {
            return strength;
        }

        internal int getInterlect()
        {
            return interlect;
        }

        internal int getdexterity()
        {
            return dexterity;
        }

        internal int getArmor()
        {
            return armor;
        }

        internal int getDamage()
        {
            return damage;
        }

        internal int getmana()
        {
            return mana;
        }

        internal bool getGot() {
            return got;
        }
        internal void setGot(bool got) {
            this.got = got;
        }
    }
}
