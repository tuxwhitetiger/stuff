using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace game
{
    public class Item
    {
        public ItemType type;

        public String name;
        public String discription;

        public  int strengthTotal;
        public int intelligenceTotal;
        public int dexterityTotal;
        public int healthTotal;
        public int manaTotal;
        public int armorTotal;
        public int dodgeTotal;
        public int damageReductionTotal;
        public int meleeDamageTotal;
        public int spellDamageTotal;

        public int slot;

        public int equiped;

        public int ID;
        public int DBID;

        public Item(ItemType type,String name,String discription,int strengthTotal,int intelligenceTotal,int dexterityTotal,int healthTotal,int manaTotal,int armorTotal,int dodgeTotal, int damageReductionTotal, int meleeDamageTotal, int spellDamageTotal,int ID,int slot)
        { 
            this.strengthTotal=strengthTotal;
            this.intelligenceTotal = intelligenceTotal;
            this.dexterityTotal = dexterityTotal;
            this.healthTotal = healthTotal;
            this.manaTotal = manaTotal;
            this.armorTotal = armorTotal;
            this.dodgeTotal = dodgeTotal;
            this.damageReductionTotal = damageReductionTotal;
            this.meleeDamageTotal = meleeDamageTotal;
            this.spellDamageTotal = spellDamageTotal;
            this.type = type;
            this.name = name;
            this.discription = discription;
            this.ID = ID;
            this.slot = slot;
        }

        public void load(int DBID, int equiped)
        {
            this.DBID = DBID;
            this.equiped = equiped;
        }

    }

    public enum ItemType { 
        none,

        platehead,
        platecheast,
        platehands,
        platelegs,
        platefeet,

        leatherhead,
        leathercheast,
        leatherhands,
        leatherlegs,
        leatherfeet,

        clothhead,
        clothcheast,
        clothhands,
        clothlegs,
        clothfeet,

        sword,
        axe,
        dagger,
        staff,

        bow,
        potion
    }
}
