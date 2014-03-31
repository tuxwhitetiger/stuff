using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace game
{
    class cariscotrSelectionScreen
    {
        Vector2 charictorMainShow = new Vector2(400, 150);
        Vector2 charictorMainShowName = new Vector2(400, 450);
        Vector2 char1Namev = new Vector2(1000, 50);
        Vector2 char2Namev = new Vector2(1000, 150);
        Vector2 char3Namev = new Vector2(1000, 250);
        Vector2 char4Namev = new Vector2(1000, 350);
        Vector2 char5Namev = new Vector2(1000, 450);
        Vector2 char6Namev = new Vector2(1000, 550);

        Rectangle goToLobbyButton = new Rectangle(465,550,200,100);

        Rectangle char1r = new Rectangle(1000, 50, 200, 100);
        Rectangle char2r = new Rectangle(1000, 150, 200, 100);
        Rectangle char3r = new Rectangle(1000, 250, 200, 100);
        Rectangle char4r = new Rectangle(1000, 350, 200, 100);
        Rectangle char5r = new Rectangle(1000, 450, 200, 100);
        Rectangle char6r = new Rectangle(1000, 550, 200, 100);

        Texture2D archer;
        Texture2D wizard;
        Texture2D rouge;
        Texture2D barbarian;
        Texture2D charictorMain;
        Texture2D background;

        SpriteFont font;

        String CharictorMainShowName = "";
        String char1Name = "create a charictor";
        String char2Name = "create a charictor";
        String char3Name = "create a charictor";
        String char4Name = "create a charictor";
        String char5Name = "create a charictor";
        String char6Name = "create a charictor";

        GameKeyboard keyboard;

        Game game;

        public cariscotrSelectionScreen(Game game) {
            keyboard = new GameKeyboard();
            this.game = game;
        
        }

        public void Load(Texture2D archer,Texture2D wizard,Texture2D rouge,Texture2D barbarian,Texture2D background, SpriteFont font) {
            this.archer = archer;
            this.wizard = wizard;
            this.rouge = rouge;
            this.barbarian = barbarian;
            this.background = background;
            this.font = font;

            charictorMain = archer;
        }

        public String update() {

            if (keyboard.getMouseleftClick()) { 
                Rectangle mouse = new Rectangle(Mouse.GetState().X,Mouse.GetState().Y,1,1);

                if (goToLobbyButton.Intersects(mouse))
                {
                    //go to lobby
                }
                else if (char1r.Intersects(mouse))
                {
                    //sellect char 1
                    if (!char1Name.Equals("create a charictor"))
                    {
                        game.SelectActiveChar(char1Name);
                    }
                    else { 
                        //create charictor
                    }

                }
                else if (char2r.Intersects(mouse))
                {
                    //sellect char 2
                    if (!char2Name.Equals("create a charictor"))
                    {
                        game.SelectActiveChar(char1Name);
                    }
                    else
                    {
                        //create charictor
                    }
                }
                else if (char3r.Intersects(mouse))
                {
                    //sellect char 3
                    if (!char3Name.Equals("create a charictor"))
                    {
                        game.SelectActiveChar(char1Name);
                    }
                    else
                    {
                        //create charictor
                    }
                }
                else if (char4r.Intersects(mouse))
                {
                    //sellect char 4
                    if (!char4Name.Equals("create a charictor"))
                    {
                        game.SelectActiveChar(char1Name);
                    }
                    else
                    {
                        //create charictor
                    }
                }
                else if (char5r.Intersects(mouse))
                {
                    //sellect char 5
                    if (!char5Name.Equals("create a charictor"))
                    {
                        game.SelectActiveChar(char1Name);
                    }
                    else
                    {
                        //create charictor
                    }
                }
                else if (char6r.Intersects(mouse))
                {
                    //sellect char 6
                    if (!char6Name.Equals("create a charictor"))
                    {
                        game.SelectActiveChar(char1Name);
                    }
                    else
                    {
                        //create charictor
                    }
                }
                
            }


            return "null";
        }

        public void draw(SpriteBatch sp){
            sp.Draw(background, Vector2.Zero, Color.White);
            sp.Draw(charictorMain, charictorMainShow, Color.White);

            sp.DrawString(font, char1Name, char1Namev, Color.White);
            sp.DrawString(font, char2Name, char2Namev, Color.White);
            sp.DrawString(font, char3Name, char3Namev, Color.White);
            sp.DrawString(font, char4Name, char4Namev, Color.White);
            sp.DrawString(font, char5Name, char5Namev, Color.White);
            sp.DrawString(font, char6Name, char6Namev, Color.White);
            sp.DrawString(font, CharictorMainShowName, charictorMainShowName, Color.White);
        }
    }
}
