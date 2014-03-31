using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace game
{
    class taltentTree
    {
        TalentNode[,] strength = new TalentNode[5,6];
        TalentNode[,] interlect = new TalentNode[5,6];
        TalentNode[,] dexterity = new TalentNode[5,6];


        Charictor player;

        int totalHP=0;
        int totalstrength=0;
        int totalinterlect=0;
        int totaldexterity=0;
        int totalarmor=0;
        int totalmeleedamage=0;
        int totalspelldamage=0;
        int totalmana=0;
        int totaldodge=0;
        int totaldamageReduction=0;

        public taltentTree(Charictor player)
        {
            this.player = player;
            loadNodes();
            populateTree(player.getTalents());
            recalculate();
        }
        internal void recalculate()
        {
            player.clearTalentGainedEffectsAndMoves();
            for (int i = 0; i < strength.GetLength(0); i++)
            {
                for (int j = 0; j < strength.GetLength(1); j++)
                {
                    if (strength[i, j] != null)
                    {
                        if (strength[i, j].getGot())
                        {
                            totalHP += strength[i, j].getHP();
                            totalstrength += strength[i, j].getstrength();
                            totalinterlect += strength[i, j].getInterlect();
                            totaldexterity += strength[i, j].getdexterity();
                            totalarmor += strength[i, j].getArmor();
                            totalmeleedamage += strength[i, j].getDamage();
                            totalmana += strength[i, j].getmana();
                            for (int k = 0; k < strength[i, j].Level; k++) {
                                player.addeffect(strength[i, j].effect);
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < interlect.GetLength(0); i++)
            {
                for (int j = 0; j < interlect.GetLength(1); j++)
                {
                    if (interlect[i, j] != null)
                    {
                        if (interlect[i, j].getGot())
                        {
                            totalHP += interlect[i, j].getHP();
                            totalstrength += interlect[i, j].getstrength();
                            totalinterlect += interlect[i, j].getInterlect();
                            totaldexterity += interlect[i, j].getdexterity();
                            totalarmor += interlect[i, j].getArmor();
                            totalspelldamage += interlect[i, j].getDamage();
                            totalmana += interlect[i, j].getmana();
                            for (int k = 0; k < interlect[i, j].Level; k++)
                            {
                                player.addeffect(interlect[i, j].effect);
                            }
                        }
                        
                    }
                }
            }

            for (int i = 0; i < dexterity.GetLength(0); i++)
            {
                for (int j = 0; j < dexterity.GetLength(1); j++)
                {
                    if (dexterity[i, j] != null)
                    {
                        if (dexterity[i, j].getGot())
                        {
                            totalHP += dexterity[i, j].getHP();
                            totalstrength += dexterity[i, j].getstrength();
                            totalinterlect += dexterity[i, j].getInterlect();
                            totaldexterity += dexterity[i, j].getdexterity();
                            totalarmor += dexterity[i, j].getArmor();
                            totalmeleedamage += dexterity[i, j].getDamage();
                            totalmana += dexterity[i, j].getmana();
                            for (int k = 0; k < dexterity[i, j].Level; k++)
                            {
                                player.addeffect(dexterity[i, j].effect);
                            }
                        }
                    }
                }
            }

        }
        private void loadNodes()
        { 
            
            //strength
            strength[0, 5] = new TalentNode("i can carry it", "increeses you bag space by 5 slots", new Vector2(3, 30), 0, 0, 0, 0, 0, 0, 0, TalentEffect.bag_space_plus_5, 5);
            strength[3, 5] = new TalentNode("hard man", "beef your self up wimp +1 strength", new Vector2(6, 30), 0, 1, 0, 0, 0, 0, 0, TalentEffect.none, 5);

            strength[1, 4] = new TalentNode("TO ARMS!!", "pointy end towards the bad guy ok +1 damage", new Vector2(4, 29), 0, 0, 0, 0, 0, 1, 0, TalentEffect.none, 1);
            strength[1, 4].addDependant(strength[3, 5]);
            strength[3, 4] = new TalentNode("blood rage", "strength now affect you melee dame EVEN MORE", new Vector2(6, 29), 0, 0, 0, 0, 0, 0, 0, TalentEffect.bloodRage, 1);
            strength[3, 4].addDependant(strength[3, 5]);
            strength[4, 4] = new TalentNode("stone skin", "rock hard abs turn to rock some antural armor", new Vector2(7, 29), 0, 0, 0, 0, 0, 0, 0, TalentEffect.stoneSkin, 1);
            strength[4, 4].addDependant(strength[3, 5]);

            strength[1, 3] = new TalentNode("got a spare hand", "learn to dual weild", new Vector2(4, 28), 0, 0, 0, 0, 0, 0, 0, TalentEffect.dualWeild, 1);
            strength[1, 3].addDependant(strength[1, 4]);
            strength[3, 3] = new TalentNode("go for the head", "no more head no more thret", new Vector2(6, 28), 0, 0, 0, 0, 0, 0, 0, TalentEffect.critChance_plus_5, 3);
            strength[3, 3].addDependant(strength[3, 4]);
            strength[4, 3] = new TalentNode("Taunt", "come up with a witty clear insult that causes the enamy to try and take you down fist", new Vector2(7, 28), 0, 0, 0, 0, 0, 0, 0, TalentEffect.taunt, 1);
            strength[4, 3].addDependant(strength[4, 4]);

            strength[1, 2] = new TalentNode("stronger then i look", "learn to dual weild two handed weaponds bring the PAIN", new Vector2(4, 27), 0, 0, 0, 0, 0, 0, 0, TalentEffect.dualWeild2, 1);
            strength[1, 2].addDependant(strength[1, 3]);
            strength[1, 2].addDependant(strength[3, 4]);
            strength[2, 2] = new TalentNode("battle cry", "cry out to rally the troop give +5 attack to all group members", new Vector2(5, 27), 0, 0, 0, 0, 0, 0, 0, TalentEffect.battleCry1, 1);
            strength[3, 2] = new TalentNode("decapitate", "remove the head even if it dosn't come off it got to hurt", new Vector2(6, 27), 0, 0, 0, 0, 0, 0, 0, TalentEffect.decapitate, 1);
            strength[3, 2].addDependant(strength[3, 3]);
            strength[4, 2] = new TalentNode("thunder punch", "boom boom pow bring it bitch", new Vector2(7, 27), 0, 0, 0, 0, 0, 0, 0, TalentEffect.thunderPuntch, 1);
            strength[4, 2].addDependant(strength[4, 3]);


            strength[2, 1] = new TalentNode("battle shought", "shout to rally the troop give +10 attack and 5%damage reduction to all group members", new Vector2(5, 26), 0, 0, 0, 0, 0, 0, 0, TalentEffect.battleCry2, 1);
            strength[2, 1].addDependant(strength[2,2]);
            strength[3, 1] = new TalentNode("take down", "take him down", new Vector2(6, 26), 0, 0, 0, 0, 0, 0, 0, TalentEffect.takedown, 1);
            strength[3, 1].addDependant(strength[3, 2]);
            strength[4, 1] = new TalentNode("bring it bitch", "battle cry,battle shought and battle roar now couse taunt", new Vector2(7, 26), 0, 0, 0, 0, 0, 0, 0, TalentEffect.taunt2, 1);
            strength[4, 1].addDependant(strength[4, 2]);

            strength[2, 0] = new TalentNode("battle roar", "shout to rally the troop give +15 attack,10% crit and 10%damage reduction to all group members", new Vector2(5, 25), 0, 0, 0, 0, 0, 0, 0, TalentEffect.battleCry3, 1);
            strength[2, 0].addDependant(strength[2, 1]);
            strength[4, 0] = new TalentNode("tis but a scratch", "when HP reaces 0 keep figting for 3 turns, if healed to full health then contine as normal", new Vector2(7, 26), 0, 0, 0, 0, 0, 0, 0, TalentEffect.tisButAScratch, 1);
            strength[4, 0].addDependant(strength[4, 1]);

            //interlect


            interlect[2, 4] = new TalentNode("spell book", "reading up is were to start", new Vector2(2, 4), 0, 0, 2, 0, 0, 0, 0, TalentEffect.none, 5);

            interlect[2, 3] = new TalentNode("wizard training", "your a wizard harry", new Vector2(2, 3), 0, 0, 5, 0, 0, 0, 0, TalentEffect.none, 2);
            interlect[2, 3].addDependant(interlect[2, 4]);

            interlect[1, 2] = new TalentNode("cristle magic", "lean to use shiny rocks", new Vector2(1, 2), 0, 0, 2, 0, 0, 0, 0, TalentEffect.none, 1);
            interlect[1, 2].addDependant(interlect[2, 3]);

            interlect[2, 2] = new TalentNode("mand magic", "no card shuffling, only shoot stuff from you hands like lightning and fire and stuff", new Vector2(2, 2), 0, 0, 0, 0, 0, 0, 0, TalentEffect.none, 1);
            interlect[2, 2].addDependant(interlect[2, 3]);

            interlect[3, 2] = new TalentNode("Deamon magic", "making a deal with the devil isn't that bad right?", new Vector2(3, 2), 0, 0, 0, 0, 0, 0, 0, TalentEffect.none, 1);
            interlect[3, 2].addDependant(interlect[2, 3]);

            interlect[0, 1] = new TalentNode("mana shiled", "a shild made of pure thought cool eh", new Vector2(0, 1), 0, 0, 0, 0, 0, 0, 0, TalentEffect.mana_shild, 1);
            interlect[0, 1].addDependant(interlect[1, 2]);

            interlect[1, 1] = new TalentNode("mana cristle", "can be used to regen mana with out wasting a turn", new Vector2(1, 1), 0, 0, 0, 0, 0, 0, 0, TalentEffect.mana_cristle, 1);
            interlect[1, 1].addDependant(interlect[1, 2]);

            interlect[2, 1] = new TalentNode("fireblast", "shoots flames from your hands pritty bad bass", new Vector2(2, 1), 0, 0, 0, 0, 0, 0, 0, TalentEffect.fireblast, 1);
            interlect[2, 1].addDependant(interlect[2, 2]);

            interlect[3, 1] = new TalentNode("circle of fire", "can be used to burn an enamy or keep you warm at night", new Vector2(2, 4), 0, 0, 0, 0, 0, 0, 0, TalentEffect.circle_of_fire, 1);
            interlect[3, 1].addDependant(interlect[3, 2]);

            interlect[4, 1] = new TalentNode("sole rip", "remove some ones sole and eat it to gain HP and mana", new Vector2(4, 1), 0, 0, 0, 0, 0, 0, 0, TalentEffect.sole_rip, 1);
            interlect[4, 1].addDependant(interlect[3, 2]);

            interlect[2, 0] = new TalentNode("icefire", "white hot frozen ice flamy. mad skils", new Vector2(2, 0), 0, 0, 0, 0, 0, 0, 0, TalentEffect.icefire, 1);
            interlect[2, 0].addDependant(interlect[1, 1]);
            interlect[2, 0].addDependant(interlect[2, 1]);
            interlect[2, 0].addDependant(interlect[3, 1]);


            //dexterity

            dexterity[2, 4] = new TalentNode("quick step", "master of agility and dexterity are light on there feet", new Vector2(2, 4), 0, 0, 0, 2, 0, 0, 0, TalentEffect.none, 5);

            dexterity[0, 3] = new TalentNode("arrow construction", "make your own arrows harder,better,faster stronger then shop bought ones", new Vector2(0, 3), 0, 0, 0, 0, 0, 0, 0, TalentEffect.none, 1);
            dexterity[0, 3].addDependant(dexterity[2, 4]);

            dexterity[2, 3] = new TalentNode("poisen", "", new Vector2(1, 3), 0, 0, 0, 0, 0, 0, 0, TalentEffect.poisen, 3);
            dexterity[2, 3].addDependant(dexterity[2, 4]);

            dexterity[4, 3] = new TalentNode("speed stabs", "lighting fast attack to stab them in the belly", new Vector2(4, 3), 0, 0, 0, 0, 0, 0, 0, TalentEffect.speed_stabs, 1);
            dexterity[4, 3].addDependant(dexterity[2, 4]);

            dexterity[0, 2] = new TalentNode("dead shot", "perfectly balanced never misses it's mark", new Vector2(0, 2), 0, 0, 0, 0, 0, 0, 0, TalentEffect.dead_shot, 1);
            dexterity[0, 2].addDependant(dexterity[0,3]);

            dexterity[2, 2] = new TalentNode("animal within", "brings out your iner-animal your survivle instinct", new Vector2(2, 2), 0, 0, 0, 0, 0, 0, 0, TalentEffect.animal_within, 1);
            dexterity[2, 2].addDependant(dexterity[2, 3]);

            dexterity[4, 2] = new TalentNode("to the shadows", "fade into the darkness to lay in wait for the right time to strike", new Vector2(4, 2), 0, 0, 0, 0, 0, 0, 0, TalentEffect.to_the_shadows, 1);
            dexterity[4, 2].addDependant(dexterity[4, 3]);

            dexterity[0, 1] = new TalentNode("fork shot", "well they are forked arn't they", new Vector2(0, 1), 0, 0, 0, 0, 0, 0, 0, TalentEffect.forkShot, 1);
            dexterity[0, 1].addDependant(dexterity[0, 2]);

            dexterity[2, 1] = new TalentNode("target", "target one guy", new Vector2(2, 1), 0, 0, 0, 0, 0, 0, 0, TalentEffect.target, 1);
            dexterity[2, 1].addDependant(dexterity[2, 1]);

            dexterity[4, 1] = new TalentNode("ninga furry", "go a little crazy with speed and skill do incradible damage in the blink of an eye", new Vector2(4, 1), 0, 0, 0, 0, 0, 0, 0, TalentEffect.ninga_furry, 1);
            dexterity[4, 1].addDependant(dexterity[4, 2]);

            dexterity[0, 0] = new TalentNode("explosive shot", "bang and the birt is gone", new Vector2(0, 0), 0, 0, 0, 0, 0, 0, 0, TalentEffect.explosive_shot, 1);
            dexterity[0, 0].addDependant(dexterity[0, 1]);
        }

        private void populateTree(String s) {
            // treenumber:x:y:level;treenumber:x:y:level;treenumber:x:y:level;treenumber:x:y:level;treenumber:x:y:level;treenumber:x:y:level;
            String[] charictor = s.Split(new string[] { "char:" }, StringSplitOptions.None);


            String[] nodes = s.Split(new string[] { "tree;" }, StringSplitOptions.None);

            foreach (String node in nodes) {
                String[] data = node.Split(';');
                if (data.Length > 5)
                {
                    switch (int.Parse(data[2]))
                    {
                        case 1:
                            strength[int.Parse(data[3]),int.Parse(data[4])].Level = int.Parse(data[5]);
                            strength[int.Parse(data[3]), int.Parse(data[4])].setGot(true);
                            break;
                        case 2:
                            interlect[int.Parse(data[3]), int.Parse(data[4])].Level = int.Parse(data[5]);
                            interlect[int.Parse(data[3]), int.Parse(data[4])].setGot(true);
                            break;
                        case 3:
                            dexterity[int.Parse(data[3]), int.Parse(data[4])].Level = int.Parse(data[5]);
                            dexterity[int.Parse(data[3]), int.Parse(data[4])].setGot(true);
                            break;
                    }
                }
            }
        
        }

        internal TalentNode[,] getStrengthTree()
        {
            return strength;
        }

        internal TalentNode[,] getdexterityTree()
        {
            return dexterity;
        }

        internal TalentNode[,] getinterlectTree()
        {
            return interlect;
        }

        internal int getAviliablepoints()
        {
            return player.getAviliblePoints();
        }

        internal void setStrengthTree(TalentNode[,] strength)
        {
            this.strength = strength;
        }

        internal void setdexterityTree(TalentNode[,] dexterity)
        {
            this.dexterity = dexterity;
        }

        internal void setinterlectTree(TalentNode[,] interlect)
        {
            this.interlect = interlect;
        }

        internal int getTreeStrengthBomus()
        {
            return totalstrength;
        }
        internal int getTreeintelligenceBonus()
        {
            return totalinterlect;
        }
        internal int getTreedexterityBonus()
        {
            return totaldexterity;
        }
        internal int getTreehealthBonus()
        {
            return totalHP;
        }
        internal int getTreemanaBonus()
        {
            return totalmana;
        }
        internal int getTreearmorBonus()
        {
            return totalarmor;
        }
        internal int getTreedodgeBonus()
        {
            return totaldodge;
        }
        internal int getTreedamageReductionBonus()
        {
            return totaldamageReduction;
        }
        internal int getTreemeleeDamageBonus()
        {
            return totalmeleedamage;
        }
        internal int getTreespellDamageBonus()
        {
            return totalspelldamage;
        }

    }
}
