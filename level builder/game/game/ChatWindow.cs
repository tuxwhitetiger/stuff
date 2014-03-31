using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace game
{
    class ChatWindow
    {
        Rectangle window;
        Rectangle typeBox;
        Vector2 positionOfText;
        Vector2 positionOfTyping;
        SpriteFont spriteFont;

        int offsetLines = 0;

        public bool istyping = true;

        List<String> Lines;
        String toDraw = "";

        StringBuilder buildingMessage;

        GameKeyboard keyboard;

        public ChatWindow(Rectangle window,Rectangle typeBox, SpriteFont spriteFont) {
            this.window = window;
            this.typeBox = typeBox;
            this.spriteFont = spriteFont;
            keyboard = new GameKeyboard();
            positionOfText = new Vector2(window.X, window.Y);
            positionOfTyping = new Vector2(typeBox.X, typeBox.Y);
            Lines = new List<String>();
            buildingMessage = new StringBuilder();
        }



        public String update() {

            String s = keyboard.getKeysPressd();
            String message = "null";
            if (istyping)
            {
                switch (s)
                {
                    case null: break;
                    case "null": break;
                    case "tab": break;
                    case "back":
                        if (buildingMessage.Length > 0)
                        {
                            buildingMessage.Remove(buildingMessage.Length - 1, 1);
                        }
                        break;
                    case "enter":
                        message = buildingMessage.ToString();
                        buildingMessage.Clear();
                        break;
                    default: buildingMessage.Append(s); break;
                }
            }
            return message;
        }

        public void Draw(SpriteBatch sp)
        {
            sp.DrawString(spriteFont, toDraw, positionOfText, Color.Black);
            sp.DrawString(spriteFont, buildingMessage.ToString(), positionOfTyping, Color.Black);
        }

        public void newMessage(String message)
        {

            if (message != null)
            {
                string[] words = message.Split(' ');
                StringBuilder sb = new StringBuilder();
                String line;
                float lineWidth = 0f;

                float spaceWidth = spriteFont.MeasureString(" ").X;

                foreach (string word in words)
                {
                    Vector2 size = spriteFont.MeasureString(word);

                    if (lineWidth + size.X < window.Width)
                    {
                        sb.Append(word + " ");
                        lineWidth += size.X + spaceWidth;
                    }
                    else
                    {
                        line = sb.ToString();
                        if (Lines.Last().Equals(line)) { }
                        else
                        {
                            Lines.Add(line);
                        }
                        sb.Clear();
                        sb.Append(word);
                        lineWidth = size.X + spaceWidth;
                    }
                }
                line = sb.ToString();
                if (Lines.Count == 0){
                    Lines.Add(line);
                }else if (Lines.Last().Equals(line)) {
                
                }else{
                    Lines.Add(line);
                }
                sb.Clear();


                float spaceHight = spriteFont.MeasureString(" ").Y;
                float lineCount = window.Height / spaceHight;

                sb = new StringBuilder();
                for (int i = 1; i < lineCount; i++)
                {
                    if (Lines.Count - i >= 0)
                    {
                        sb.AppendLine(Lines[Lines.Count - i]);
                    }
                }
                if (sb.ToString() == null)
                {
                    toDraw = "chat Box";
                }
                else
                {
                    toDraw = sb.ToString();
                }
            }
        }

    }
}
