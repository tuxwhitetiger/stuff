using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace game
{
    class EventTalkBox
    {
        List<String> conversation = new List<String>();
        int conversationPosition=0;
        KeyboardState lastState = Keyboard.GetState();

        public EventTalkBox() {
//String[] conversation 
            //this.conversation = conversation;
                //new String[]{"NPC1:hi there how are you","NPC2:i am very well thank you","NPC1: do you want to go on a quest for me","NPC2: shure why not could be a giggle!","NPC1: not realy you will probably die on the way","NPC2: COOL!!","NPC1:you not the bright are you","NPC2:mummy says i have other skills"};
        }
        public String Update() {
            if ((Keyboard.GetState().IsKeyDown(Keys.Space))&&(lastState.IsKeyUp(Keys.Space))) {
                if (conversationPosition < conversation.Count - 1)
                {
                    conversationPosition++;
                }
                else {
                    return "donetalking";
                }
            }
            lastState = Keyboard.GetState();
            return "null";
        }
        public void Draw(SpriteBatch sp, SpriteFont font) {
            if (conversation.Count <= 0)
            {
            }
            else
            {
                sp.DrawString(font, conversation[conversationPosition], new Vector2(10, 630), Color.White);
            }
            sp.DrawString(font, "press space ...", new Vector2(10, 700), Color.White);
        }
        public void loadConversation(String conversation) {
            String[] conversationData = conversation.Split(',');
            foreach (String s in conversationData) {
                this.conversation.Add(s);
            }
        }
        public void Clear() { 
           conversationPosition = 0; 
        }

        internal void directlyAddTalk(string p)
        {
            conversation.Add(p);
        }
    }
}
