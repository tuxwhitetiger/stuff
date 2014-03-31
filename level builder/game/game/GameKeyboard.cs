using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace game
{
    class GameKeyboard
    {
        KeyboardState state1 = Keyboard.GetState();
        KeyboardState state2 = Keyboard.GetState();

        MouseState Mstate1= Mouse.GetState();
        MouseState Mstate2= Mouse.GetState();

        public bool getMouseleftClick() {
            Mstate1 = Mouse.GetState();
            if((Mstate1.LeftButton ==ButtonState.Pressed)&&(Mstate2.LeftButton == ButtonState.Released)){
                Mstate2 = Mstate1;
                return true;
            }
            Mstate2 = Mstate1;
            return false;
        }

        public bool getLeft()
        {
            state1 = Keyboard.GetState();
            return Keyboard.GetState().IsKeyDown(Keys.Left);
        }
        public bool getRight()
        {
            state1 = Keyboard.GetState();
            return Keyboard.GetState().IsKeyDown(Keys.Right);
        }
        public bool getUp()
        {
            state1 = Keyboard.GetState();
            return Keyboard.GetState().IsKeyDown(Keys.Up);
        }
        public bool getDown()
        {
            state1 = Keyboard.GetState();
            return Keyboard.GetState().IsKeyDown(Keys.Down);
        }
        public bool getLeftUpDown()
        {
            state1 = Keyboard.GetState();
            bool b = Keyboard.GetState().IsKeyDown(Keys.Left)&& state2.IsKeyUp(Keys.Left);
            state2 = state1;
            return b;
        }
        public bool getRightUpDown()
        {
            state1 = Keyboard.GetState();
            bool b = Keyboard.GetState().IsKeyDown(Keys.Right) && state2.IsKeyUp(Keys.Right);
            state2 = state1;
            return b;
        }

        public String getKeysPressd() {



            state2 = state1;

            state1 = Keyboard.GetState();


            if ((state1.IsKeyDown(Keys.A))&&(state2.IsKeyUp(Keys.A)))
            {
                if (state1.IsKeyDown(Keys.LeftShift) || state1.IsKeyDown(Keys.RightShift))
                {
                    return "A";
                }
                else
                {
                    return "a";
                }
            }
            if ((state1.IsKeyDown(Keys.B))&&(state2.IsKeyUp(Keys.B)))
            {
                if (state1.IsKeyDown(Keys.LeftShift) || state1.IsKeyDown(Keys.RightShift))
                {
                    return "B";
                }
                else
                {
                    return "b";
                }
            }
            if ((state1.IsKeyDown(Keys.C))&&(state2.IsKeyUp(Keys.C)))
            {
                if (state1.IsKeyDown(Keys.LeftShift) || state1.IsKeyDown(Keys.RightShift))
                {
                    return "C";
                }
                else
                {
                    return "c";
                }
            }
            if ((state1.IsKeyDown(Keys.D))&&(state2.IsKeyUp(Keys.D)))
            {
                if (state1.IsKeyDown(Keys.LeftShift) || state1.IsKeyDown(Keys.RightShift))
                {
                    return "D";
                }
                else
                {
                    return "d";
                }
            }
            if ((state1.IsKeyDown(Keys.E))&&(state2.IsKeyUp(Keys.E)))
            {
                if (state1.IsKeyDown(Keys.LeftShift) || state1.IsKeyDown(Keys.RightShift))
                {
                    return "E";
                }
                else
                {
                    return "e";
                }
            }
            if ((state1.IsKeyDown(Keys.F))&&(state2.IsKeyUp(Keys.F)))
            {
                if (state1.IsKeyDown(Keys.LeftShift) || state1.IsKeyDown(Keys.RightShift))
                {
                    return "F";
                }
                else
                {
                    return "f";
                }
            }
            if ((state1.IsKeyDown(Keys.G))&&(state2.IsKeyUp(Keys.G)))
            {
                if (state1.IsKeyDown(Keys.LeftShift) || state1.IsKeyDown(Keys.RightShift))
                {
                    return "G";
                }
                else
                {
                    return "g";
                }
            }
            if ((state1.IsKeyDown(Keys.H))&&(state2.IsKeyUp(Keys.H)))
            {
                if (state1.IsKeyDown(Keys.LeftShift) || state1.IsKeyDown(Keys.RightShift))
                {
                    return "H";
                }
                else
                {
                    return "h";
                }
            }
            if ((state1.IsKeyDown(Keys.I))&&(state2.IsKeyUp(Keys.I)))
            {
                if (state1.IsKeyDown(Keys.LeftShift) || state1.IsKeyDown(Keys.RightShift))
                {
                    return "I";
                }
                else
                {
                    return "i";
                }
            }
            if ((state1.IsKeyDown(Keys.J))&&(state2.IsKeyUp(Keys.J)))
            {
                if (state1.IsKeyDown(Keys.LeftShift) || state1.IsKeyDown(Keys.RightShift))
                {
                    return "J";
                }
                else
                {
                    return "j";
                }
            } 
            if ((state1.IsKeyDown(Keys.K))&&(state2.IsKeyUp(Keys.K)))
            {
                if (state1.IsKeyDown(Keys.LeftShift) || state1.IsKeyDown(Keys.RightShift))
                {
                    return "K";
                }
                else
                {
                    return "k";
                }
            }
            if ((state1.IsKeyDown(Keys.L))&&(state2.IsKeyUp(Keys.L)))
            {
                if (state1.IsKeyDown(Keys.LeftShift) || state1.IsKeyDown(Keys.RightShift))
                {
                    return "L";
                }
                else
                {
                    return "l";
                }
            }
            if ((state1.IsKeyDown(Keys.M))&&(state2.IsKeyUp(Keys.M)))
            {
                if (state1.IsKeyDown(Keys.LeftShift) || state1.IsKeyDown(Keys.RightShift))
                {
                    return "M";
                }
                else
                {
                    return "m";
                }
            }
            if ((state1.IsKeyDown(Keys.N))&&(state2.IsKeyUp(Keys.N)))
            {
                if (state1.IsKeyDown(Keys.LeftShift) || state1.IsKeyDown(Keys.RightShift))
                {
                    return "N";
                }
                else
                {
                    return "n";
                }
            }
            if ((state1.IsKeyDown(Keys.O))&&(state2.IsKeyUp(Keys.O)))
            {
                if (state1.IsKeyDown(Keys.LeftShift) || state1.IsKeyDown(Keys.RightShift))
                {
                    return "O";
                }
                else
                {
                    return "o";
                }
            }
            if ((state1.IsKeyDown(Keys.P))&&(state2.IsKeyUp(Keys.P)))
            {
                if (state1.IsKeyDown(Keys.LeftShift) || state1.IsKeyDown(Keys.RightShift))
                {
                    return "P";
                }
                else
                {
                    return "p";
                }
            }
            if ((state1.IsKeyDown(Keys.Q))&&(state2.IsKeyUp(Keys.Q)))
            {
                if (state1.IsKeyDown(Keys.LeftShift) || state1.IsKeyDown(Keys.RightShift))
                {
                    return "Q";
                }
                else
                {
                    return "q";
                }
            }
            if ((state1.IsKeyDown(Keys.R))&&(state2.IsKeyUp(Keys.R)))
            {
                if (state1.IsKeyDown(Keys.LeftShift) || state1.IsKeyDown(Keys.RightShift))
                {
                    return "R";
                }
                else
                {
                    return "r";
                }
            }
            if ((state1.IsKeyDown(Keys.S))&&(state2.IsKeyUp(Keys.S)))
            {
                if (state1.IsKeyDown(Keys.LeftShift) || state1.IsKeyDown(Keys.RightShift))
                {
                    return "S";
                }
                else
                {
                    return "s";
                }
            }
            if ((state1.IsKeyDown(Keys.T))&&(state2.IsKeyUp(Keys.T)))
            {
                if (state1.IsKeyDown(Keys.LeftShift) || state1.IsKeyDown(Keys.RightShift))
                {
                    return "T";
                }
                else
                {
                    return "t";
                }
            }
            if ((state1.IsKeyDown(Keys.U))&&(state2.IsKeyUp(Keys.U)))
            {
                if (state1.IsKeyDown(Keys.LeftShift) || state1.IsKeyDown(Keys.RightShift))
                {
                    return "U";
                }
                else
                {
                    return "u";
                }
            }
            if ((state1.IsKeyDown(Keys.V))&&(state2.IsKeyUp(Keys.V)))
            {
                if (state1.IsKeyDown(Keys.LeftShift) || state1.IsKeyDown(Keys.RightShift))
                {
                    return "V";
                }
                else
                {
                    return "v";
                }
            }
            if ((state1.IsKeyDown(Keys.W))&&(state2.IsKeyUp(Keys.W)))
            {
                if (state1.IsKeyDown(Keys.LeftShift) || state1.IsKeyDown(Keys.RightShift))
                {
                    return "W";
                }
                else
                {
                    return "w";
                }
            }
            if ((state1.IsKeyDown(Keys.X))&&(state2.IsKeyUp(Keys.X)))
            {
                if (state1.IsKeyDown(Keys.LeftShift) || state1.IsKeyDown(Keys.RightShift))
                {
                    return "X";
                }
                else
                {
                    return "x";
                }
            }
            if ((state1.IsKeyDown(Keys.Y))&&(state2.IsKeyUp(Keys.Y)))
            {
                if (state1.IsKeyDown(Keys.LeftShift) || state1.IsKeyDown(Keys.RightShift))
                {
                    return "Y";
                }
                else
                {
                    return "y";
                }
            }
            if ((state1.IsKeyDown(Keys.Z)) && (state2.IsKeyUp(Keys.Z)))
            {
                if (state1.IsKeyDown(Keys.LeftShift) || state1.IsKeyDown(Keys.RightShift))
                {
                    return "Z";
                }
                else
                {
                    return "z";
                }
            }

            if (state1.IsKeyDown(Keys.D0) && state2.IsKeyUp(Keys.D0) || state1.IsKeyDown(Keys.NumPad0) && state2.IsKeyUp(Keys.NumPad0))
            {
                return "0";
            }
            if (state1.IsKeyDown(Keys.D1) && state2.IsKeyUp(Keys.D1) || state1.IsKeyDown(Keys.NumPad1) && state2.IsKeyUp(Keys.NumPad1))
            {
                return "1";
            }
            if (state1.IsKeyDown(Keys.D2) && state2.IsKeyUp(Keys.D2) || state1.IsKeyDown(Keys.NumPad2) && state2.IsKeyUp(Keys.NumPad2))
            {
                return "2";
            }
            if (state1.IsKeyDown(Keys.D3) && state2.IsKeyUp(Keys.D3) || state1.IsKeyDown(Keys.NumPad3) && state2.IsKeyUp(Keys.NumPad3))
            {
                return "3";
            }
            if (state1.IsKeyDown(Keys.D4) && state2.IsKeyUp(Keys.D4) || state1.IsKeyDown(Keys.NumPad4) && state2.IsKeyUp(Keys.NumPad4))
            {
                return "4";
            }
            if (state1.IsKeyDown(Keys.D5) && state2.IsKeyUp(Keys.D5) || state1.IsKeyDown(Keys.NumPad5) && state2.IsKeyUp(Keys.NumPad5))
            {
                return "5";
            }
            if (state1.IsKeyDown(Keys.D6) && state2.IsKeyUp(Keys.D6) || state1.IsKeyDown(Keys.NumPad6) && state2.IsKeyUp(Keys.NumPad6))
            {
                return "6";
            }
            if (state1.IsKeyDown(Keys.D7) && state2.IsKeyUp(Keys.D7) || state1.IsKeyDown(Keys.NumPad7) && state2.IsKeyUp(Keys.NumPad7))
            {
                return "7";
            }
            if (state1.IsKeyDown(Keys.D8) && state2.IsKeyUp(Keys.D8) || state1.IsKeyDown(Keys.NumPad8) && state2.IsKeyUp(Keys.NumPad8))
            {
                return "8";
            }
            if (state1.IsKeyDown(Keys.D9) && state2.IsKeyUp(Keys.D9) || state1.IsKeyDown(Keys.NumPad9) && state2.IsKeyUp(Keys.NumPad9))
            {
                return "9";
            }
            if (state1.IsKeyDown(Keys.OemPeriod) && state2.IsKeyUp(Keys.OemPeriod) || state1.IsKeyDown(Keys.Decimal) && state2.IsKeyUp(Keys.Decimal))
            {
                return ".";
            }



            if ((state1.IsKeyDown(Keys.Back)) && (state2.IsKeyUp(Keys.Back)))
            {
                return "back";
            } 
            if ((state1.IsKeyDown(Keys.Space)) && (state2.IsKeyUp(Keys.Space)))
            {
                return " ";
            }
            if ((state1.IsKeyDown(Keys.Tab))&&(state2.IsKeyUp(Keys.Tab)))
            {
                return "tab";
            }
            if ((state1.IsKeyDown(Keys.Enter))&&(state2.IsKeyUp(Keys.Enter)))
            {
                return "enter";
            }


            return "null";
        }


    }
}
