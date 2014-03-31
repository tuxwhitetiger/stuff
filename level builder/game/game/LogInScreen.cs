using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace game
{
    class LogInScreen
    {

        Texture2D background;
        SpriteFont font;

        Vector2 userNameV = new Vector2(457, 230);
        Vector2 passwordV = new Vector2(457, 272);
        Vector2 errorMessageV = new Vector2(460, 400);
        Vector2 ipAddressV = new Vector2(364, 610);

        Rectangle createNewAccount = new Rectangle(455, 326, 110, 50);

        String IPAddress = "127.0.0.1";

        String errorMessage = "";
        String userName = "";
        String password = "";
        String hiddenPassword = "";

        GameKeyboard GameKeyboard;
        MouseState lastState = Mouse.GetState();

        int blinkerTimer = 0;
        int userpassword = 0;

        bool blinker = true;

        public LogInScreen()
        {
            GameKeyboard = new GameKeyboard();
            
        }

        public void Load(SpriteFont font,Texture2D background)
        {
            this.font = font;
            this.background = background;
        }

        public String update(GameTime gameTime)
        {

            blinkerTimer += gameTime.ElapsedGameTime.Milliseconds;
            if (blinkerTimer > 750) {
                blinkerTimer = 0;
                blinker = !blinker;
            }
            String s = GameKeyboard.getKeysPressd();
            MouseState mState = Mouse.GetState();

            if (mState.LeftButton == ButtonState.Released && lastState.LeftButton == ButtonState.Pressed)
            {
                if (createNewAccount.Intersects(new Rectangle(Mouse.GetState().X, Mouse.GetState().Y, 1, 1)))
                {
                    String logIn = userName + ":" + password;
                    lastState = mState;
                    return "createNewAccount:" + logIn;
                    /*
                     * 
                     * allso addd login butten
                     * 
                     * button highlighting
                     * 
                     * 
                     */
                }
            }
            lastState = mState;
            if (s.Equals("null"))
            {
                return "null";
            }
            else if (s.Equals("tab"))
            {
                userpassword++;
                if (userpassword == 3) {
                    userpassword = 0;
                }
            }
            else if (s.Equals("enter"))
            {
                switch (userpassword) {
                    case 0:
                        return "logIn:" + userName + ":" + password;
                        break;//username
                    case 1:
                        return "logIn:" + userName + ":" + password;
                        break;//password
                    case 2:
                        return "logIn:" + userName + ":" + password;
                        break;//ip
                }
            }
            else if (s.Equals("back"))
            {
                switch (userpassword)
                {
                    case 0:
                        if (userName.Length > 0)
                        {
                            userName = userName.Substring(0, userName.Length - 1);
                        }
                        break;//username
                    case 1:
                        if (password.Length > 0)
                    {
                        password = password.Substring(0, password.Length - 1);
                    }
                    if (hiddenPassword.Length > 0)
                    {
                        hiddenPassword = hiddenPassword.Substring(0, hiddenPassword.Length - 1);
                    }
                        break;//password
                    case 2:
                        if (IPAddress.Length > 0)
                        {
                            IPAddress = IPAddress.Substring(0, IPAddress.Length - 1);
                        }
                        break;//ip
                }
            }
            else {
                switch (userpassword)
                {
                    case 0:
                        userName += s;
                        break;//username
                    case 1:
                        password += s;
                    hiddenPassword += "*";
                        break;//password
                    case 2:
                        IPAddress += s;
                        return "IP:" + IPAddress;
                        break;//ip
                }
            }
            return "null";
        }

        public void draw(SpriteBatch sp) {

            sp.Draw(background, Vector2.Zero, Color.White);
            switch (userpassword)
            {
                case 0:
                    if (blinker) {
                        sp.DrawString(font, userName +"|", userNameV, Color.Black);
                    } else {
                        sp.DrawString(font, userName, userNameV, Color.Black);
                    }
                    
                    sp.DrawString(font, hiddenPassword, passwordV, Color.Black);
                    sp.DrawString(font, errorMessage, errorMessageV, Color.Red);
                    sp.DrawString(font, IPAddress, ipAddressV, Color.Black);
                    break;//username
                case 1:
                    sp.DrawString(font, userName, userNameV, Color.Black);
                    if (blinker)
                    {
                        sp.DrawString(font, hiddenPassword+"|", passwordV, Color.Black);
                    }
                    else {
                        sp.DrawString(font, hiddenPassword, passwordV, Color.Black);
                    }
                    sp.DrawString(font, errorMessage, errorMessageV, Color.Red);
                    sp.DrawString(font, IPAddress, ipAddressV, Color.Black);
                    break;//password
                case 2:
                    sp.DrawString(font, userName, userNameV, Color.Black);
                    sp.DrawString(font, hiddenPassword, passwordV, Color.Black);
                    sp.DrawString(font, errorMessage, errorMessageV, Color.Red);
                    if (blinker) {
                        sp.DrawString(font, IPAddress+"|", ipAddressV, Color.Black);
                    } else {
                        sp.DrawString(font, IPAddress, ipAddressV, Color.Black);
                    }
                    
                    break;//ip
            }

            
        }

        public void setErrorMessage(String errormessage) {
            errorMessage = errormessage;
        }


    }
}
