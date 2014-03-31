using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace server
{
    public class Event
    { 
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
    }
}
