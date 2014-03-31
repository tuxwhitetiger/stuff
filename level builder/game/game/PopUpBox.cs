using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace game
{
    class PopUpBox :IDisposable
    {
        public event EventHandler Disposed;

        Rectangle window;
        String message;
        String DrawMessage;
        SpriteFont font;
        Texture2D blank;
        public bool draw = false;

        public PopUpBox(Rectangle window, String message, SpriteFont font, Texture2D blank)
        {
            this.window = window;
            this.message = message;
            wordWrap();
            this.DrawMessage += "/n click to contine";
            this.font = font;
            this.blank = blank;
        }
        public void SetMessage(String message) {
            this.message = message;
            wordWrap();
        }
        public void SetWindow(Rectangle window){
            wordWrap();
        }
        public void Update() {
            if (Mouse.GetState().LeftButton == ButtonState.Pressed) {
                Dispose();
            }
        }
        public void Draw(SpriteBatch sp) {
            if (draw)
            {
                sp.Draw(blank, window, Color.AliceBlue);
                sp.DrawString(font, DrawMessage, new Vector2(window.X, window.Y), Color.White);
            }
        }
        public void wordWrap()
        {
            string[] words = message.Split(' ');
            StringBuilder sb = new StringBuilder();
            String line;
            float lineWidth = 0f;

            float spaceWidth = font.MeasureString(" ").X;

            foreach (string word in words)
            {
                Vector2 size = font.MeasureString(word);

                if (lineWidth + size.X < window.Width)
                {
                    sb.Append(word + " ");
                    lineWidth += size.X + spaceWidth;
                }
                else
                {
                    line = sb.ToString();
                    sb.Clear();
                    DrawMessage += line + "\n";
                    sb.Append(word);
                    lineWidth = size.X + spaceWidth;
                }
            }
            line = sb.ToString();
            sb.Clear();
            DrawMessage += line;
        }
        public void Dispose()
        {
            if (this.Disposed != null)
                this.Disposed(this, EventArgs.Empty);
        }

    }
}
