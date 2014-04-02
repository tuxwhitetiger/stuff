using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace game
{
    public class EventScreen
    {
        int Type = 1;
        //1:cut sceen
        //2:fight

        Texture2D background;
        Texture2D badguy;

        bool donetalking = false;
        public bool eventLoaded = false;

        bool yourturn = false;

        int moveSerlector = 0;
        int personSerlector = 0;

        SpriteFont font;

        Game game;

        List<Charictor> left = new List<Charictor>();
        List<EventCharictor> right = new List<EventCharictor>();
        Charictor player;
        EventTalkBox talking = new EventTalkBox();

        //left line maths

        Vector2 topleft = new Vector2(0, 0);
        Vector2 bottomleft = new Vector2(600, 400);
        double angleleft;
        List<Vector2> leftpoints = new List<Vector2>();

        //right line maths

        Vector2 topright = new Vector2(600, 0);
        Vector2 bottomright = new Vector2(1200, 400);
        double angleright;
        List<Vector2> rightpoints = new List<Vector2>();


        public EventScreen(Game game)
        {
            distributeCharictorsAlongLines();
            this.game = game;
        }
        public void Load(Texture2D background,Texture2D badguy, SpriteFont font)
        {
            this.background = background;
            this.font = font;
            this.badguy = badguy;
        }


        public String Update() {

            if (donetalking)
            {
                //***************FIGHT*****************\\
                List<EventCharictor> toRemove = new List<EventCharictor>();
                foreach (EventCharictor enamy in right)
                {
                    if (!enamy.alive)
                    {
                        toRemove.Add(enamy);
                    }
                }
                foreach (EventCharictor enamy in toRemove)
                {
                    right.Remove(enamy);
                    player.addXP(enamy.getXP());
                    if (personSerlector > 0)
                    {
                        personSerlector--;
                    }
                    if (right.Count == 0)
                    {
                        clear();
                        return "done";
                    }
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Left))
                {
                    if (personSerlector > 0)
                    {
                        personSerlector--;
                    }
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Right))
                {
                    if (personSerlector < right.Count - 1)
                    {
                        personSerlector++;
                    }
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Up))
                {
                    if (moveSerlector > 0)
                    {
                        moveSerlector--;
                    }
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Down))
                {
                    if (moveSerlector < player.moves.Count)
                    {
                        moveSerlector++;
                    }
                }
                if (currentFightmember == fightMemberNumber)
                {

                    if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                    {
                        if (right.Count > 0)
                        {
                            int i = right[personSerlector].getHp();
                            player.UseMove(moveSerlector, right[personSerlector]);
                            int j = right[personSerlector].getHp();
                            game.updateServerFight(right[personSerlector].getID(), i - j, fightMemberNumber);
                            currentFightmember++;
                            //send message to suerver
                        }
                    }
                }
            }
            else
            {
                string s = talking.Update();
                if (s.Equals("donetalking"))
                {
                    donetalking = true;
                }
            }
            
            return "null";
        }

        

        public void Draw(SpriteBatch sp) {

            sp.Draw(background, Vector2.Zero, Color.White);

            for (int i = 0; i < left.Count; i++)
            {
                sp.Draw(left[i].getSpriteSheet(), leftpoints[i], Color.White);
                
            }
            for (int i = 0; i < right.Count; i++)
            {
                sp.Draw(right[i].getSpriteSheet(), rightpoints[i], Color.White);
                if (i == personSerlector)
                {
                    sp.DrawString(font, "v", new Vector2(rightpoints[i].X + (right[i].getSpriteSheet().Width / 2), rightpoints[i].Y-10), Color.Black);
                    sp.DrawString(font, right[i].getHp().ToString(), new Vector2(rightpoints[i].X + (right[i].getSpriteSheet().Width / 2), rightpoints[i].Y), Color.Black);
                }
                else {
                    sp.DrawString(font, right[i].getHp().ToString(), new Vector2(rightpoints[i].X + (right[i].getSpriteSheet().Width / 2), rightpoints[i].Y), Color.Black);
                }
            }
            if (!donetalking)
            {
                talking.Draw(sp, font);
            }
            //fight move that are availible
            bool leftrightColom = true;
            int xpos=975;
            int ypos =621;
            for (int i = 0; i < player.moves.Count; i++) {
                if (i == moveSerlector)
                {
                    sp.DrawString(font, ">", new Vector2(xpos - 4, ypos), Color.Black);
                }

                if (leftrightColom)//left
                {
                    sp.DrawString(font, player.moves[i].ToString(), new Vector2(xpos, ypos), Color.Black);
                    xpos += 158;
                }
                else {//right
                    sp.DrawString(font, player.moves[i].ToString(), new Vector2(xpos, ypos), Color.Black);
                    ypos += 18;
                    xpos -= 158;
                }

                
                leftrightColom = !leftrightColom;
            }
        }


        public void addCharictor(Charictor c)
        {
            left.Add(c);
            distributeCharictorsAlongLines();
        }

        public void addPlayer(Charictor player) {
            this.player = player;
        }
        private void distributeCharictorsAlongLines(){
            leftpoints.Clear();
            rightpoints.Clear();
            int leftdeltax = ((int)bottomleft.X - (int)topleft.X);
            int leftdeltay = ((int)bottomleft.Y - (int)topleft.Y);

            angleleft = Math.Atan2(leftdeltay, leftdeltax);

            double lengthleft = Math.Sqrt((Math.Pow(leftdeltax, 2) + Math.Pow(leftdeltay, 2)));

            double deltalenghtleft = lengthleft / left.Count;
            double currentlength = 0;
            while (currentlength < lengthleft)
            {
                currentlength += deltalenghtleft;
                leftpoints.Add(new Vector2((int)((topleft.X + currentlength) * Math.Cos(angleleft)), (int)((topleft.Y + currentlength) * Math.Sin(angleleft))));
            }



            int rightdeltax = ((int)bottomright.X - (int)topright.X);
            int rightdeltay = ((int)bottomright.Y - (int)topright.Y);

            angleright = Math.Atan2(rightdeltay, rightdeltax);

            double lengthright = Math.Sqrt((Math.Pow(rightdeltax, 2) + Math.Pow(rightdeltay, 2)));

            double deltalenghtright = lengthright / right.Count;
            double currentlengthright = 0;
            while (currentlengthright < lengthright)
            {
                currentlengthright += deltalenghtright;
                rightpoints.Add(new Vector2((int)((topright.X + currentlengthright) * Math.Cos(angleright)), (int)((topright.Y + currentlengthright) * Math.Sin(angleright))));
            }
            right.Reverse();
        }

        public void clear() {
            right.Clear();
            left.Clear();
            rightpoints.Clear();
            leftpoints.Clear();
            talking.Clear();
        }

        internal void LoadData(string responce)
        {
            String[] EventData = responce.Split(';');
            int x = int.Parse(EventData[0]);
            int y = int.Parse(EventData[1]);


            String[] Charictors = EventData[2].Split('$');
            for (int j = 0; j < Charictors.Length - 1; j++)
            {
                //c.getName()+","+c.getHP()+","+c.getAttackType()+","+c.getAttackPower()+","
                String[] charictor = Charictors[j].Split(',');
                String name = charictor[0];
                int HP = int.Parse(charictor[1]);
                int AttackType = int.Parse(charictor[2]);
                int AttackPower = int.Parse(charictor[3]);
                EventCharictor c = new EventCharictor(name, HP, AttackType, AttackPower, badguy, j);
                String[] convo = charictor[4].Split('.');
                for (int k = 0; k < convo.Length; k++)
                {
                    String talk = convo[k];
                    c.directlyAddTalk(talk);
                }
                right.Add(c);
                distributeCharictorsAlongLines();
            }
            int shortestconvo = int.MaxValue;

            foreach (EventCharictor c in right)
            {
                if (c.getTalkLength() < shortestconvo)
                {
                    shortestconvo = c.getTalkLength();
                }
            }

            for (int i = 0; i < shortestconvo; i++)
            {
                for (int j = 0; j < right.Count; j++)
                {

                    String s = right[j].getTalkLength(i);
                    if ((s.Equals("")) || (s.Equals("-^-")))
                    {

                    }
                    else
                    {
                        talking.directlyAddTalk(right[j].getName() + ":" + s);
                    }
                }
            }

            eventLoaded = true;
        }
        
        internal void UpdateData(string responce)
        {
            String[] Charictors = responce.Split('$');
            for (int j = 0; j < Charictors.Length - 1; j++)
            {
                String[] charictor = Charictors[j].Split(',');
                String name = charictor[0];
                int HP = int.Parse(charictor[1]);
                right[j].setHP(HP);
            }
        }

        public int fightMemberNumber { get; set; }

        public int currentFightmember { get; set; }
    }
}
