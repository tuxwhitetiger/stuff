using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace game
{
    class CharacterCreationScreen
    {
        Texture2D arecher;
        Texture2D wizard;
        Texture2D barberian;
        Texture2D rouge;
        Texture2D selecter;
        Texture2D background;

        SpriteFont font;

        GameKeyboard keybord;

        String charictorName = "";

        Rectangle selecterv = new Rectangle(200, 140, 180, 250);//slide 180
        Rectangle createCharictorButton = new Rectangle(520,545,165,35);
        Rectangle classPannel = new Rectangle(200, 140, 720, 250);
        Vector2 arecherv = new Vector2(200,140);
        Vector2 wizardv = new Vector2(380, 140);
        Vector2 barberianv = new Vector2(560, 140);
        Vector2 rougev = new Vector2(740, 140);
        Vector2 text = new Vector2(305, 466);

        int serlectorPos=0;

        public CharacterCreationScreen() {
            keybord = new GameKeyboard();
        }

        public void Load(Texture2D arecher, Texture2D wizard, Texture2D barberian, Texture2D rouge, Texture2D selecter, Texture2D background, SpriteFont font)
        {
            this.arecher = arecher;
            this.background = background;
            this.barberian = barberian;
            this.font = font;
            this.rouge = rouge;
            this.selecter = selecter;
            this.wizard = wizard;
        }


        public String update() {
            String s =keybord.getKeysPressd();

            switch (s) {
                case "null": 
                    //mouse cheak for colitionss
                    selector();
                    return mouse();
                    break;
                case "tab": break;
                case "enter": 
                    return create(); 
                    break;
                case "back":
                    if (charictorName.Length > 0)
                    {
                        charictorName = charictorName.Substring(0, charictorName.Length - 1);
                    }
                    break;
                default:
                    charictorName += s;
                    break;
            }
            return "null";
        }

        public void Draw(SpriteBatch sp) {

            sp.Draw(background, Vector2.Zero, Color.White);
            sp.Draw(selecter, selecterv, Color.White);
            sp.Draw(barberian, barberianv, Color.White);
            sp.Draw(arecher, arecherv, Color.White);
            sp.Draw(rouge, rougev, Color.White);
            sp.Draw(wizard, wizardv, Color.White);
            sp.DrawString(font, charictorName, text, Color.White);
        }


        private void Clear() {
            charictorName = "";
            selecterv = new Rectangle(200, 140, 180, 250);//slide 180
            serlectorPos = 0;
        }

        private String create() {

            String ans = "";
            ans += "charCreate:";
            switch (serlectorPos) {
                case 0: ans += "archer:"; break;
                case 1: ans += "wizard:"; break;
                case 2: ans += "barberian:"; break;
                case 3: ans += "rouge:"; break;
            }
            ans += charictorName;
            Clear();
            return ans;
        
        }

        private String mouse() {
            if (keybord.getMouseleftClick())
            {
                if (createCharictorButton.Intersects(new Rectangle(Mouse.GetState().X, Mouse.GetState().Y, 1, 1)))
                {
                    return create();
                }
            }

            return "null";
        }

        private void selector()
        {
            
            if (keybord.getMouseleftClick())
            {
                MouseState ms = Mouse.GetState();
                if (classPannel.Intersects(new Rectangle(ms.X, ms.Y, 1, 1)))
                {
                    int x = ms.X - classPannel.X;
                    int i = x / 180;

                    serlectorPos = i;
                    selecterv = new Rectangle(200, 140, 180, 250);//slide 180
                    selecterv.X += i * 180;
                }
            }

            if (keybord.getLeft() && serlectorPos > 0)
            {
                serlectorPos--;
                selecterv.X -= 180;
            }
            if (keybord.getRight() && serlectorPos < 3)
            {
                serlectorPos++;
                selecterv.X += 180;
            }
        }
    }
}
