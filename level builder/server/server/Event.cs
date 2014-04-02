using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace server
{
    public class Event
    {
        int fightMember = 0;
        int currentfightMember = 1;
        List<Charictor> left = new List<Charictor>();
        List<EventCharictor> right = new List<EventCharictor>();
        private int x;
        private int y;

        public Event(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        internal void addCarictor(EventCharictor c)
        {
            right.Add(c);
            fightMember++;
            right.Last().fightmember = fightMember;
        }
        internal int addPlayer(Charictor c)
        {
            left.Add(c);
            fightMember++;
            left.Last().fightmember = fightMember;
            return fightMember;

        }

        internal Microsoft.Xna.Framework.Vector2 getposition()
        {
            return new Microsoft.Xna.Framework.Vector2(x, y);
        }

        internal string getData()
        {
            StringBuilder sb = new StringBuilder();
            foreach (EventCharictor ec in right) {
                sb.Append(ec.getData()+"$");
            }
            return sb.ToString();
        }

        internal void updateCharictor(int fighter,int ID, int HP)
        {
            if (fighter == currentfightMember)
            {
                right[ID].damage(HP);
                if (currentfightMember == fightMember)
                {
                    currentfightMember = 1;
                }
                else {
                    currentfightMember++;
                }
            }
        }
        internal int getCurrentFighter() {
            return currentfightMember;
        }

        internal void update()
        {

            foreach (EventCharictor e in right) {
                if (e.fightmember == currentfightMember) { 
                    //enamy fight

                    if (currentfightMember == fightMember)
                    {
                        currentfightMember = 1;
                    }
                    else
                    {
                        currentfightMember++;
                    }
                }
            }
        }
    }
}
