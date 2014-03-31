using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace game
{
    class CarictorEditScreen
    {
        Texture2D background;
        Texture2D archer;
        Texture2D barbarian;
        Texture2D rouge;
        Texture2D wizard;

        Vector2 tree1pos;
        Vector2 tree2pos;
        Vector2 tree3pos;

        Vector2 textPosition = new Vector2(400, 530);

        Rectangle doneButton = new Rectangle(380, 600, 180, 55);
        Rectangle tree1box;
        Rectangle tree2box;
        Rectangle tree3box;
        
        Texture2D[] tree1;//5x6
        Texture2D[] tree2;
        Texture2D[] tree3;

        Game game;

        SpriteFont font;

        String bottomText= "Aviliable points:";

        MouseState lastMouseState = Mouse.GetState();

        public CarictorEditScreen(Game game) {
            this.game = game; 
            
            tree1pos = new Vector2(55, 100);
            tree2pos = new Vector2(55 + 55 + 330, 100);
            tree3pos = new Vector2(55 + 55 + 55 + 330 + 330, 100);

            tree1box = new Rectangle((int)tree1pos.X, (int)tree1pos.Y, 330, 395);
            tree2box = new Rectangle((int)tree2pos.X, (int)tree2pos.Y, 330, 395);
            tree3box = new Rectangle((int)tree3pos.X, (int)tree3pos.Y, 330, 395);
        }

        internal void load(Texture2D background,SpriteFont font,Texture2D archer,Texture2D barbarian,Texture2D rouge,Texture2D wizard,Texture2D[] tree1,Texture2D[] tree2,Texture2D[] tree3) {
            this.background = background;
            this.font = font;
            this.archer = archer;
            this.barbarian = barbarian;
            this.rouge = rouge;
            this.wizard = wizard;
            this.tree1 = tree1;
            this.tree2 = tree2;
            this.tree3 = tree3;
        }

        internal string update(){
            MouseState mouseState = Mouse.GetState();

            if (mouseState.LeftButton == ButtonState.Released && lastMouseState.LeftButton == ButtonState.Pressed) {
                Rectangle mouseBox = new Rectangle(mouseState.X, mouseState.Y, 1, 1);
                if (mouseBox.Intersects(doneButton))
                {
                    lastMouseState = mouseState;
                    return "done";
                }
                if (game.getCurrentCharictor().getAviliblePoints() > 0) {
                    Charictor player = game.getCurrentCharictor();
                    taltentTree trees = player.getTalentTrees();
                    if(mouseBox.Intersects(tree1box)){
                        TalentNode[,] strength = trees.getStrengthTree();
                        //strength
                        Action work = delegate
                        {
                            for (int j = strength.GetLength(1) - 1; j >= 0; j--)
                            {
                                for (int i = 0; i <= strength.GetLength(0) - 1; i++)
                                {
                                    if (strength[i, j] != null)
                                    {
                                        if (new Rectangle(55 + (i * 66), 100 + (j * 66), 66, 66).Intersects(mouseBox))
                                        {
                                            if (strength[i, j].Level < strength[i, j].maxLevel)
                                            {
                                                strength[i, j].Level++;
                                                player.setAviliblePoints(-1);
                                                game.updatePlayerTreeOnServer(1, i, j, strength[i, j].Level);
                                                return;
                                            }
                                        }
                                    }
                                }
                            }
                        };
                        work();
                    }
                    if(mouseBox.Intersects(tree2box)){
                        TalentNode[,] interlect = trees.getinterlectTree();
                        //interlect
                        Action work = delegate
                        {
                            for (int j = interlect.GetLength(1) - 1; j >= 0; j--)
                            {
                                for (int i = 0; i <= interlect.GetLength(0) - 1; i++)
                                {
                                    if (interlect[i, j] != null)
                                    {
                                        if (new Rectangle(55 + 330 + 55 + (i * 66), 100 + (j * 66), 66, 66).Intersects(mouseBox))
                                        {
                                            if (interlect[i, j].Level < interlect[i, j].maxLevel)
                                            {
                                                interlect[i, j].Level++;
                                                player.setAviliblePoints(-1);
                                                game.updatePlayerTreeOnServer(2, i, j, interlect[i, j].Level);
                                                return;
                                            }
                                        }
                                    }
                                }
                            }
                        };
                        work();
                    }
                    if (mouseBox.Intersects(tree3box))
                    {
                        TalentNode[,] dexterity = trees.getdexterityTree();
                        //dexterity
                        Action work = delegate
                        {
                            for (int j = dexterity.GetLength(1) - 1; j >= 0; j--)
                            {
                                for (int i = 0; i <= dexterity.GetLength(0) - 1; i++)
                                {
                                    if (dexterity[i, j] != null)
                                    {
                                        if (new Rectangle(55 + 330 + 55 + 330 + 55 + (i * 66), 100 + (j * 66), 66, 66).Intersects(mouseBox))
                                        {
                                            if (dexterity[i, j].Level < dexterity[i, j].maxLevel)
                                            {
                                                dexterity[i, j].Level++;
                                                player.setAviliblePoints(-1);
                                                game.updatePlayerTreeOnServer(3, i, j, dexterity[i, j].Level);
                                                return;
                                            }
                                        }
                                    }
                                }
                            }
                        };
                        work();
                    }
                }
            }

            lastMouseState = mouseState;
            return "null";
        }
        internal void Draw(SpriteBatch sp)
        {
            sp.Draw(background,Vector2.Zero,Color.White);
            

            Charictor player = game.getCurrentCharictor();
            taltentTree trees = player.getTalentTrees();
            sp.DrawString(font, bottomText+trees.getAviliablepoints(), textPosition, Color.White);
            TalentNode[,] strength = trees.getStrengthTree();
            TalentNode[,] dexterity = trees.getdexterityTree();
            TalentNode[,] interlect = trees.getinterlectTree();
            int count = 0;
            //strength
            for (int j = strength.GetLength(1)-1; j >=0; j--)
            {
                for (int i = 0; i <= strength.GetLength(0)-1; i++)
                {
                    if (strength[i, j] != null)
                    {
                        if (strength[i, j].Level>0)
                        {
                            sp.Draw(tree1[count], new Vector2(55 + (i * 66), 100 + (j * 66)), Color.White);
                            count++;
                        }
                        else
                        {
                            sp.Draw(tree1[count], new Vector2(55 + (i * 66), 100 + (j * 66)), Color.DarkGray);
                            count++;
                        }
                    }
                }
            }
            count = 0;

            //int 
            for (int j = interlect.GetLength(1) - 1; j >= 0; j--)
            {
                for (int i = 0; i <= interlect.GetLength(0) - 1; i++)
                {
                    if (interlect[i, j] != null)
                    {
                        if (interlect[i, j].Level > 0)
                        {
                            sp.Draw(tree2[count], new Vector2(55 + 330 + 55 + (i * 66), 100 + (j * 66)), Color.White);
                            count++;
                        }
                        else
                        {
                            sp.Draw(tree2[count], new Vector2(55 + 330 + 55 + (i * 66), 100 + (j * 66)), Color.Gray);
                            count++;
                        }
                    }
                }
            }

            count = 0;
            //dex
            for (int j = dexterity.GetLength(1) - 1; j >= 0; j--)
            {
                for (int i = 0; i <= dexterity.GetLength(0) - 1; i++)
                {
                    if (dexterity[i, j] != null)
                    {
                        if (dexterity[i, j].Level > 0)
                        {
                            sp.Draw(tree3[count], new Vector2(55 + 330 + 55 + 330 + 55 + (i * 66), 100 + (j * 66)), Color.White);
                            count++;
                        }
                        else
                        {
                            sp.Draw(tree3[count], new Vector2(55 + 330 + 55 + 330 + 55 + (i * 66), 100 + (j * 66)), Color.Gray);
                            count++;
                        }
                    }
                }
            }

            



        }

        
    }
}
