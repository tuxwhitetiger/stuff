using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace game
{
    public class Charictor
    {
        private int charnumber;
        private int charDB;
        private int userID;
        private int availableTalentPoints;
        private int level;
        private int experiance;
        private string charname;
        string TalentTreeData;


        private int strengthTotal;
        private int intelligenceTotal;
        private int dexterityTotal;
        private int healthTotal;
        private int manaTotal;
        private int armorTotal;
        private int dodgeTotal;
        private int damageReductionTotal;
        private int meleeDamageTotal;
        private int spellDamageTotal;
        


        private charictorType chartype;

        Vector2 position = new Vector2(0, 0);
        Vector2 DrawPosition = new Vector2(0, 0);

        Texture2D charictorSpriteSheet;

        List<TalentEffect> effects = new List<TalentEffect>();

        public List<Move> moves = new List<Move>();
        List<object> movesdata = new List<object>();

        taltentTree talentTree;

        public Item[] armor = new Item[7];// 0-head 1-cheast 2-hands 3-legs 4-feet 5-leftwep 6-rightwep
        public List<Item> inventory = new List<Item>();

        public Charictor(int charnumber, int charDB, int userID, string charname, string chartype, string TalentTreeData, int availableTalentPoints, int level, int experiance, Item[] armor, List<Item> inventory)
        {
            this.charnumber = charnumber;
            this.charDB = charDB;
            this.userID = userID;
            this.charname = charname;
            switch (chartype) {
                case "archer": this.chartype = charictorType.archer; loadBaseMovesArcher(); break;
                case "barberian": this.chartype = charictorType.barbarian; loadBaseMovesBarbarian(); break;
                case "rouge": this.chartype = charictorType.rouge; loadBaseMovesRouge(); break;
                case "wizard": this.chartype = charictorType.wizard; loadBaseMovesWizard(); break;
            }
            this.availableTalentPoints = availableTalentPoints;
            this.level = level;
            this.experiance = experiance;
            this.TalentTreeData = TalentTreeData;
            this.armor = armor;
            this.inventory = inventory;
            talentTree = new taltentTree(this);
            calculateStats();
        }

        public Charictor(string name, Vector2 vector2)
        {
            this.charname = name;
            this.position = vector2;
        }
        public void load(Texture2D charictorSpriteSheet)
        {
            this.charictorSpriteSheet = charictorSpriteSheet;
        }

        public void Draw(SpriteBatch sp,Vector2 offset) {

            if (charictorSpriteSheet != null) {
                sp.Draw(charictorSpriteSheet, DrawPosition - offset*40 , Color.White);
            }
        }

        public String GetName() {
            return charname;
        }
        private void calculateStats() {
            int strengthBonus= talentTree.getTreeStrengthBomus();
            int intelligenceBonus=talentTree.getTreeintelligenceBonus();
            int dexterityBonus=talentTree.getTreedexterityBonus();
            int healthBonus=talentTree.getTreehealthBonus();
            int manaBonus=talentTree.getTreemanaBonus();
            int armorBonus=talentTree.getTreearmorBonus();
            int dodgeBonus=talentTree.getTreedodgeBonus();
            int damageReductionBonus=talentTree.getTreedamageReductionBonus();
            int meleeDamageBonus=talentTree.getTreemeleeDamageBonus();
            int spellDamageBonus=talentTree.getTreespellDamageBonus();

            switch (chartype) {
                case charictorType.archer:
                    strengthTotal = (int)(((10 + (2 * level)) + strengthBonus) * 0.5);
                    intelligenceTotal = (int)(((5 + (2 * level)) + intelligenceBonus) * 0.7);
                    dexterityTotal = (int)(((5 + (2 * level)) + dexterityBonus) * 0.3);
                    healthTotal = (int)((50 + (2 * level)) + (Math.Pow(strengthTotal, 1.7))) + healthBonus;
                    manaTotal = (int)(10 + (1.5 * level) + (Math.Pow(intelligenceTotal, 1.2))) + manaBonus;
                    armorTotal=(int)(armorBonus*1.3);
                    dodgeTotal = (int)((dexterityTotal / 4) / 100) + dodgeBonus;
                    damageReductionTotal = (int)((armorTotal / 10) / 100) + damageReductionBonus;
                    meleeDamageTotal=meleeDamageBonus+strengthTotal;
                    spellDamageTotal = spellDamageBonus + intelligenceTotal;
                    break;
                case charictorType.barbarian: 
                    strengthTotal = (int)(((10 + (2 * level)) + strengthBonus) * 0.5);
                    intelligenceTotal = (int)(((5 + (2 * level)) + intelligenceBonus) * 0.5);
                    dexterityTotal = (int)(((5 + (2 * level)) + dexterityBonus) * 0.15);
                    healthTotal = (int)((50 + (2 * level)) + (Math.Pow(strengthTotal, 1.5))) + healthBonus;
                    manaTotal = (int)(10 + (1.5 * level) + (intelligenceTotal)) + manaBonus;
                    armorTotal=(int)(armorBonus*1.5);
                    dodgeTotal = (int)((dexterityTotal / 4) / 100) + dodgeBonus;
                    damageReductionTotal = (int)((armorTotal / 10) / 100) + damageReductionBonus;
                    meleeDamageTotal=meleeDamageBonus+strengthTotal;
                    spellDamageTotal = spellDamageBonus + intelligenceTotal;
                    break;
                case charictorType.rouge: 
                    strengthTotal = (int)(((10 + (2 * level)) + strengthBonus) * 0.5);
                    intelligenceTotal = (int)(((5 + (2 * level)) + intelligenceBonus) * 0.7);
                    dexterityTotal = (int)(((5 + (2 * level)) + dexterityBonus) * 0.3);
                    healthTotal = (int)((50 + (2 * level)) + (Math.Pow(strengthTotal, 1.7))) + healthBonus;
                    manaTotal = (int)(10 + (1.5 * level) + (Math.Pow(intelligenceTotal, 1.2))) + manaBonus;
                    armorTotal=(int)(armorBonus*1.3);
                    dodgeTotal = (int)((dexterityTotal / 4) / 100) + dodgeBonus;
                    damageReductionTotal = (int)((armorTotal / 10) / 100) + damageReductionBonus;
                    meleeDamageTotal=meleeDamageBonus+strengthTotal;
                    spellDamageTotal = spellDamageBonus + intelligenceTotal;
                    break;
                case charictorType.wizard: 
                    strengthTotal = (int)(((10 + (2 * level)) + strengthBonus) * 0.2);
                    intelligenceTotal = (int)(((10 + (2 * level)) + intelligenceBonus));
                    dexterityTotal = (int)(((5 + (2 * level)) + dexterityBonus) * 0.07);
                    healthTotal = (int)((50 + (2 * level)) + (Math.Pow(strengthTotal, 1.9))) + healthBonus;
                    manaTotal = (int)(10 + (1.5 * level) + (Math.Pow(intelligenceTotal, 1.5))) + manaBonus;
                    armorTotal=(int)(armorBonus);
                    dodgeTotal = (int)((dexterityTotal / 4) / 100) + dodgeBonus;
                    damageReductionTotal = (int)((armorTotal / 10) / 100) + damageReductionBonus;
                    meleeDamageTotal = meleeDamageBonus + strengthTotal;
                    spellDamageTotal = spellDamageBonus + intelligenceTotal;
                    break;
            }
        }
        public charictorType GetcharType()
        {
            return chartype;
        }
        public Vector2 GetPosition()
        {
            return position;
        }
        public void setPosition(Vector2 position)
        {
            this.position = position;
            updateDrawPossition();
        }
        public void modifyXPosition(int delta)
        {
            position = new Vector2(position.X += delta,position.Y);
            updateDrawPossition();
        }
        public void modifyYPosition(int delta)
        {
            position = new Vector2(position.X, position.Y += delta);
            updateDrawPossition();
        }
        private void updateDrawPossition() {
            DrawPosition = new Vector2(position.X * 40, position.Y * 40);
        }
        public Vector2 GetDrawPosition()
        {
            return DrawPosition;
        }
        public Texture2D getSpriteSheet() {
            return charictorSpriteSheet;
        }
        internal string getTalents()
        {
            return TalentTreeData;
        }
        internal void clearTalentGainedEffectsAndMoves()
        {      
            effects.Clear();
        }
        internal void addeffect(TalentEffect effect)
        {
            if (effect != TalentEffect.none)
            { 
            effects.Add(effect);
            }
        }
        internal taltentTree getTalentTrees()
        {
            return talentTree;
        }
        internal int getAviliblePoints()
        {
            return availableTalentPoints;
        }
        internal void setAviliblePoints(int p)
        {
            availableTalentPoints += p;
        }
        internal int getCharictorDBID() {
            return charDB;
        }
        internal void addXP(int XP) {
            experiance += XP;
        }
        internal int getLevel()
        {
            return level;
        }
        internal int getXP()
        {
            return experiance;
        }
        internal void setLevel(int p)
        {
            level += 1;
            calculateStats();
        }
        internal int getCurrentXp()
        {
            return experiance;
        }
        internal int getTotalStrength()
        {
            return strengthTotal;
        }
        internal int getTotalInterlect()
        {
            return intelligenceTotal;
        }
        internal int getTotalDexterity()
        {
            return dexterityTotal;
        }
        internal int getTotalHealth()
        {
            return healthTotal;
        }
        internal int getTotalMana()
        {
            return manaTotal;
        }
        internal int getTotalArmor()
        {
            return armorTotal;
        }
        internal int getTotalMeleeDamage()
        {
            return meleeDamageTotal;
        }
        internal int getTotalSpellDamage()
        {
            return spellDamageTotal;
        }
        internal int getTotalDodge()
        {
            return dodgeTotal;
        }
        internal int getTotalDamageReduction()
        {
            return damageReductionTotal;
        }
        internal void addToInventory(Item item)
        {
            inventory.Add(item);
        }
        internal Item getArmor(int slot)
        {
            return armor[slot];
        }
        internal void setArmor(Item item, int slot)
        {
            armor[slot] = item;
        }
        internal void setInventory(Item itemHold, int fromSlot)
        {
            inventory[fromSlot] = itemHold;
        }
        internal Item getItemByDBID(int DBID)
        {
            for(int i =0;i<armor.Length;i++){
                if (armor[i] != null)
                {
                    if (armor[i].DBID == DBID)
                    {
                        return armor[i];
                    }
                }
            }
            foreach (Item i in inventory) {
                if (i != null)
                {
                    if (i.DBID == DBID)
                    {
                        return i;
                    }
                }
            }

            return null;
        }
        internal void equipItem(Item itemToArmor, Item itemToInventory)
        {

            if (armor[itemToArmor.slot] == null)
            {
                armor[itemToArmor.slot] = itemToArmor;
                for (int j = 0; j < inventory.Count; j++)
                {
                    if (inventory[j] != null)
                    {
                        if (inventory[j].DBID == itemToArmor.DBID)
                        {
                            inventory.Remove(inventory[j]);
                            return;
                        }
                    }
                }

            }
            else {
                for (int j = 0; j < inventory.Count; j++)
                {
                    if (inventory[j] != null)
                    {
                        if (inventory[j].DBID == itemToArmor.DBID)
                        {
                            armor[itemToArmor.slot] = itemToArmor;
                            inventory[j] = itemToInventory;
                            return;
                        }
                    }
                }
            }

        }
        internal void sortMoveData(moveController Controler){
            talentTree.recalculate();
            foreach (TalentEffect ef in effects)
            {
                switch (ef) {
                    case TalentEffect.bloodRage: moves.Add(Move.bloodRage); break;
                    case TalentEffect.stoneSkin: moves.Add(Move.stoneSkin); break;
                    case TalentEffect.battleCry1: moves.Add(Move.battleCry1); break;
                    case TalentEffect.battleCry2: moves.Add(Move.battleCry2); break;
                    case TalentEffect.battleCry3: moves.Add(Move.battleCry3); break;
                    case TalentEffect.decapitate: moves.Add(Move.decapitate); break;
                    case TalentEffect.taunt: moves.Add(Move.taunt); break;
                    case TalentEffect.taunt2: moves.Add(Move.taunt2); break;
                    case TalentEffect.thunderPuntch: moves.Add(Move.thunderPuntch); break;
                    case TalentEffect.takedown: moves.Add(Move.takedown); break;
                    case TalentEffect.tisButAScratch: moves.Add(Move.tisButAScratch); break;
                    case TalentEffect.mana_shild: moves.Add(Move.mana_shild); break;
                    case TalentEffect.fireblast: moves.Add(Move.fireblast); break;
                    case TalentEffect.circle_of_fire: moves.Add(Move.circle_of_fire); break;
                    case TalentEffect.sole_rip: moves.Add(Move.sole_rip); break;
                    case TalentEffect.icefire: moves.Add(Move.icefire); break;
                    case TalentEffect.poisen: moves.Add(Move.poisen); break;
                    case TalentEffect.speed_stabs: moves.Add(Move.speed_stabs); break;
                    case TalentEffect.dead_shot: moves.Add(Move.dead_shot); break;
                    case TalentEffect.animal_within: moves.Add(Move.animal_within); break;
                    case TalentEffect.to_the_shadows: moves.Add(Move.to_the_shadows); break;
                    case TalentEffect.forkShot: moves.Add(Move.forkShot); break;
                    case TalentEffect.target: moves.Add(Move.target); break;
                    case TalentEffect.ninga_furry: moves.Add(Move.ninga_furry); break;
                    case TalentEffect.explosive_shot: moves.Add(Move.explosive_shot); break;
                        
                }
            }
            movesdata.Clear();
            foreach (Move m in moves) {
                movesdata.Add(Controler.getMove(this, m));
            }
        }
        internal void addmove(Move m)
        {
            moves.Add(m);
        }
        private void loadBaseMovesArcher() {
            addmove(Move.shoot);
        }
        private void loadBaseMovesBarbarian() {
            addmove(Move.whack);
        }
        private void loadBaseMovesRouge() {
            addmove(Move.stab);
        }
        private void loadBaseMovesWizard() {
            addmove(Move.zap);
        }
        internal void UseMove(int move, EventCharictor eventCharictor)
        {
            moves.generalMove d = (moves.generalMove)movesdata[move];
            d.use(eventCharictor);
            
        }
    }
}