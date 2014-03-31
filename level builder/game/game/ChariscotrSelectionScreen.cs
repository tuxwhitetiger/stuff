using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace game
{
    class ChariscotrSelectionScreen
    {
        Vector2 charictorMainShow = new Vector2(400, 150);
        Vector2 charictorMainShowName = new Vector2(400, 450);
        Vector2 char1Namev = new Vector2(1020, 70);
        Vector2 char2Namev = new Vector2(1020, 170);
        Vector2 char3Namev = new Vector2(1020, 270);
        Vector2 char4Namev = new Vector2(1020, 370);
        Vector2 char5Namev = new Vector2(1020, 470);
        Vector2 char6Namev = new Vector2(1020, 570);

        Rectangle goToLobbyButton = new Rectangle(465, 550, 200, 100);
        Rectangle createGameButton = new Rectangle(160, 550, 230, 100);

        Rectangle char1r = new Rectangle(1000, 50, 200, 100);
        Rectangle char2r = new Rectangle(1000, 150, 200, 100);
        Rectangle char3r = new Rectangle(1000, 250, 200, 100);
        Rectangle char4r = new Rectangle(1000, 350, 200, 100);
        Rectangle char5r = new Rectangle(1000, 450, 200, 100);
        Rectangle char6r = new Rectangle(1000, 550, 200, 100);

        Rectangle char1editr = new Rectangle(1198, 50, 62, 100);
        Rectangle char2editr = new Rectangle(1198, 150, 62, 100);
        Rectangle char3editr = new Rectangle(1198, 250, 62, 100);
        Rectangle char4editr = new Rectangle(1198, 350, 62, 100);
        Rectangle char5editr = new Rectangle(1198, 450, 62, 100);
        Rectangle char6editr = new Rectangle(1198, 550, 62, 100);

        Texture2D archer;
        Texture2D wizard;
        Texture2D rouge;
        Texture2D barbarian;
        Texture2D background;
        Texture2D editButton;

        charictorType charictorMain;

        SpriteFont font;

        String CharictorMainShowName = "";
        String char1Name = "create a \n charictor";
        String char2Name = "create a \n charictor";
        String char3Name = "create a \n charictor";
        String char4Name = "create a \n charictor";
        String char5Name = "create a \n charictor";
        String char6Name = "create a \n charictor";

        GameKeyboard keyboard;

        Game game;
        

        public ChariscotrSelectionScreen(Game game) {
            keyboard = new GameKeyboard();
            this.game = game;
        
        }

        public void Load(Texture2D archer,Texture2D wizard,Texture2D rouge,Texture2D barbarian,Texture2D background,Texture2D editButton, SpriteFont font) {
            this.archer = archer;
            this.wizard = wizard;
            this.rouge = rouge;
            this.barbarian = barbarian;
            this.background = background;
            this.font = font;
            this.editButton = editButton;

            charictorMain = charictorType.none;
        }

        public String update() {

            String [] names = game.getCharictorNames();
            int namecount=0;
            foreach (String s in names) {
                if (namecount == 0)
                {
                    if (names[0] != null)
                    {
                        char1Name = names[0];
                    }
                }
                if (namecount == 1)
                {
                    if (names[1] != null)
                    {
                        char2Name = names[1];
                    }
                }
                if (namecount == 2)
                {
                    if (names[2] != null)
                    {
                        char3Name = names[2];
                    }
                }
                if (namecount == 3)
                {
                    if (names[3] != null)
                    {
                        char4Name = names[3];
                    }
                }
                if (namecount == 4)
                {
                    if (names[4] != null)
                    {
                        char5Name = names[4];
                    }
                }
                if (namecount == 5)
                {
                    if (names[5] != null)
                    {
                        char6Name = names[5];
                    }
                }
                namecount++;
            }


            if (keyboard.getMouseleftClick()) { 
                Rectangle mouse = new Rectangle(Mouse.GetState().X,Mouse.GetState().Y,1,1);
                if (createGameButton.Intersects(mouse))
                {
                    //go to lobby
                    return "createGame";
                }
                if (goToLobbyButton.Intersects(mouse))
                {
                    //go to lobby
                    return "lobby";
                }
                else if (char1r.Intersects(mouse))
                {
                    //sellect char 1
                    if (!char1Name.Equals("create a \n charictor"))
                    {
                        game.SelectActiveChar(char1Name);
                        setMainShowType(game.getCharictorType(char1Name));
                        CharictorMainShowName = char1Name;
                    }
                    else { 
                        //create charictor
                        game.Createchar();
                    }

                }
                else if (char2r.Intersects(mouse))
                {
                    //sellect char 2
                    if (!char2Name.Equals("create a \n charictor"))
                    {
                        game.SelectActiveChar(char2Name);
                        setMainShowType(game.getCharictorType(char2Name));
                        CharictorMainShowName = char2Name;
                    }
                    else
                    {
                        //create charictor
                        game.Createchar();
                    }
                }
                else if (char3r.Intersects(mouse))
                {
                    //sellect char 3
                    if (!char3Name.Equals("create a \n charictor"))
                    {
                        game.SelectActiveChar(char3Name);
                        setMainShowType(game.getCharictorType(char3Name));
                        CharictorMainShowName = char3Name;
                    }
                    else
                    {
                        //create charictor
                        game.Createchar();
                    }
                }
                else if (char4r.Intersects(mouse))
                {
                    //sellect char 4
                    if (!char4Name.Equals("create a \n charictor"))
                    {
                        game.SelectActiveChar(char4Name);
                        setMainShowType(game.getCharictorType(char4Name));
                        CharictorMainShowName = char4Name;
                    }
                    else
                    {
                        //create charictor
                        game.Createchar();
                    }
                }
                else if (char5r.Intersects(mouse))
                {
                    //sellect char 5
                    if (!char5Name.Equals("create a \n charictor"))
                    {
                        game.SelectActiveChar(char5Name);
                        setMainShowType(game.getCharictorType(char5Name));
                        CharictorMainShowName = char5Name;
                    }
                    else
                    {
                        //create charictor
                        game.Createchar();
                    }
                }
                else if (char6r.Intersects(mouse))
                {
                    //sellect char 6
                    if (!char6Name.Equals("create a \n charictor"))
                    {
                        game.SelectActiveChar(char6Name);
                        setMainShowType(game.getCharictorType(char6Name));
                        CharictorMainShowName = char6Name;
                    }
                    else
                    {
                        //create charictor
                        game.Createchar();
                    }
                }
                else if (char1editr.Intersects(mouse))
                {
                    //edit char 1
                    if (!char1Name.Equals("create a \n charictor"))
                    {
                        game.SelectActiveChar(char1Name);
                        return "edit";
                    }
                }
                else if (char2editr.Intersects(mouse))
                {
                    //edit char 2
                    if (!char2Name.Equals("create a \n charictor"))
                    {
                        game.SelectActiveChar(char2Name);
                        return "edit";
                    }
                }
                else if (char3editr.Intersects(mouse))
                {
                    //edit char 3
                    if (!char3Name.Equals("create a \n charictor"))
                    {
                        game.SelectActiveChar(char3Name);
                        return "edit";
                    }
                }
                else if (char4editr.Intersects(mouse))
                {
                    //edit char 4
                    if (!char4Name.Equals("create a \n charictor"))
                    {
                        game.SelectActiveChar(char4Name);
                        return "edit";
                    }
                }
                else if (char5editr.Intersects(mouse))
                {
                    //edit char 5
                    if (!char5Name.Equals("create a \n charictor"))
                    {
                        game.SelectActiveChar(char5Name);
                        return "edit";
                    }
                }
                else if (char6editr.Intersects(mouse))
                {
                    //edit char 6
                    if (!char6Name.Equals("create a \n charictor"))
                    {
                        game.SelectActiveChar(char6Name);
                        return "edit";
                    }
                }
                
            }


            return "null";
        }

        private void setMainShowType(charictorType type)
        {
            charictorMain = type;
        }

        public void draw(SpriteBatch sp){
            sp.Draw(background, Vector2.Zero, Color.White);
            switch (charictorMain) {
                case charictorType.archer:
                    sp.Draw(archer, charictorMainShow, Color.White);
                    break;
                case charictorType.barbarian:
                    sp.Draw(barbarian, charictorMainShow, Color.White);
                    break;
                case charictorType.rouge:
                    sp.Draw(rouge, charictorMainShow, Color.White); 
                    break;
                case charictorType.wizard:
                    sp.Draw(wizard, charictorMainShow, Color.White);
                    break;

            }
            

            sp.DrawString(font, char1Name, char1Namev, Color.White);
            if (!char1Name.Equals("create a \n charictor"))
            {
                sp.Draw(editButton, new Vector2(1198,50), Color.White);
            }
            sp.DrawString(font, char2Name, char2Namev, Color.White);
            if (!char2Name.Equals("create a \n charictor"))
            {
                sp.Draw(editButton, new Vector2(1198, 150), Color.White);
            }
            sp.DrawString(font, char3Name, char3Namev, Color.White);
            if (!char3Name.Equals("create a \n charictor"))
            {
                sp.Draw(editButton, new Vector2(1198, 250), Color.White);
            }
            sp.DrawString(font, char4Name, char4Namev, Color.White);
            if (!char4Name.Equals("create a \n charictor"))
            {
                sp.Draw(editButton, new Vector2(1198, 350), Color.White);
            }
            sp.DrawString(font, char5Name, char5Namev, Color.White);
            if (!char5Name.Equals("create a \n charictor"))
            {
                sp.Draw(editButton, new Vector2(1198, 450), Color.White);
            }
            sp.DrawString(font, char6Name, char6Namev, Color.White);
            if (!char6Name.Equals("create a \n charictor"))
            {
                sp.Draw(editButton, new Vector2(1198, 550), Color.White);
            }
            sp.DrawString(font, CharictorMainShowName, charictorMainShowName, Color.White);
        }
    }
}
