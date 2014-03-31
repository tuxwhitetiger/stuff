using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace game
{
    class WaitRoomScreen
    {
        Rectangle chatWindowArea = new Rectangle(35, 456, 760, 205);
        Rectangle chatbox = new Rectangle(35, 660, 760, 30);
        Rectangle players;
        Rectangle minimap;
        Rectangle discription= new Rectangle(910, 180, 300, 400);
        Rectangle leveButton;
        Rectangle StartButton = new Rectangle(827, 608, 246, 79);

        MouseState lastState = Mouse.GetState();

        Vector2 discriptionDraw = new Vector2(910, 180);

        String Discription = "";
        String DiscriptiontoDraw = "";

        Texture2D background;

        SpriteFont Font;

        ChatWindow chatWindow;

        int hostID = 1;
        public Map map;

        public WaitRoomScreen()
        {
        }

        public void Load(SpriteFont spriteFont, Texture2D background)
        {
            this.Font = spriteFont;
            this.background = background;
            chatWindow = new ChatWindow(chatWindowArea, chatbox, spriteFont);
        }
        
        public String update() {
            MouseState state = Mouse.GetState();

            if (new Rectangle(state.X, state.Y, 1, 1).Intersects(StartButton) && state.LeftButton == ButtonState.Released && lastState.LeftButton == ButtonState.Pressed)
            {
                return "startGame";
            }
            lastState = state;
            return chatWindow.update();
            
        }

        public void Draw(SpriteBatch sp) {
            sp.Draw(background, Vector2.Zero, Color.White);
            sp.DrawString(Font, DiscriptiontoDraw, discriptionDraw, Color.White);
            chatWindow.Draw(sp);
        
        }

        public void newmessage(String message) {
            chatWindow.newMessage(message);
        }


        public void joingame(int hostID,String Discription2)
        {
            this.hostID = hostID;
            Discription = Discription2;
            String[] words = Discription.Split(' ');
            StringBuilder sb = new StringBuilder();
            float lineWidth = 0f;
            float spaceWidth = Font.MeasureString(" ").X;
            foreach (string word in words)
            {
                Vector2 size = Font.MeasureString(word);
                if (lineWidth + size.X < discription.Width)
                {
                    sb.Append(word + " ");
                    lineWidth += size.X + spaceWidth;
                }
                else
                {
                    sb.Append("\n" + word + " ");
                    lineWidth = size.X + spaceWidth;
                }
            }
            DiscriptiontoDraw = sb.ToString();
            sb.Clear();

        }
    }
}
