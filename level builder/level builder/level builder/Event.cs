using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace level_builder
{
    public class Event
    {
        List<charictor> charictors = new List<charictor>();

        public int serlectedChatictor = 0;
        int ID = 0;
        int X = 0;
        int Y = 0;

        SpriteFont font;

        public Event(int x, int y, SpriteFont font){
            this.X = x;
            this.Y = y;
            this.font = font;
        }

        public void addCarictor(String name, int HP, int attckType, int attackPower)
        {
            charictor c = new charictor(ID,name, HP, attckType, attackPower);
            charictors.Add(c);
            ID++;
        }
        public void addTalk(String talk) {

            foreach (charictor c in charictors) {
                if (c.getID() == serlectedChatictor)
                {
                    //c.addConvo(talk);
                }
                else {
                    c.addConvo("-^-");
                    c.dumpToConvo();
                }

            }
        }
        public List<charictor> getCharictors() {
            return charictors;
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, "add all charictors before doing the conversation", Vector2.Zero, Color.White);
            StringBuilder sb = new StringBuilder();
            for(int i=0; i<charictors.Count;i++){ 
                if(i==serlectedChatictor){
                    sb.Append(">" + charictors[i].getName() + "<\n");
                }else{
                    sb.Append(charictors[i].getName() + "\n");
                }
            }
            spriteBatch.DrawString(font, sb.ToString(), new Vector2(55, 165), Color.White);
            if(charictors.Count>0){
                charictor c =charictors[serlectedChatictor];
                spriteBatch.DrawString(font, c.getName(), new Vector2(458, 205), Color.White);
                spriteBatch.DrawString(font, c.getHP(), new Vector2(458, 314), Color.White);
                spriteBatch.DrawString(font, c.getAttackType(), new Vector2(458, 430), Color.White);
                spriteBatch.DrawString(font, c.getAttackPower(), new Vector2(458, 549), Color.White); 
            }
            //draw convo
            if (charictors.Count > 0)
            {
                charictor c = charictors[serlectedChatictor];
                spriteBatch.DrawString(font, c.DrawConvo(), new Vector2(876, 153), Color.White);
                spriteBatch.DrawString(font, c.DrawCurrentConvoMessage(), new Vector2(876,585), Color.White);
            }

        }

        internal Vector2 getPosition()
        {
            return new Vector2(X, Y);
        }
        public charictor getCharictor() {
            return charictors[serlectedChatictor];
        }

        internal void charictorSelectUp()
        {
            if (serlectedChatictor > 0) {
                serlectedChatictor--;
            }
        }

        internal void charictorSelectDown()
        {
            if (serlectedChatictor < charictors.Count - 1) {
                serlectedChatictor++;
            }
        }
    }
}
