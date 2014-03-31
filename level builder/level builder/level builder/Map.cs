using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Runtime.Serialization;

namespace level_builder
{
    public class Map
    {
        String name= "map1";
        int[,] map;
        public int mapsize = 60;
        int yShift = 0;
        int xShift = 0;
        public List<Event> events = new List<Event>();

        SpriteFont font;

        public bool newevent = false;

        levelBuilder lb;


        public Map(levelBuilder lb)
        {
            this.lb = lb;
            map = new int[mapsize, mapsize];
        }
        
        public Map(string mapdata, SpriteFont font, levelBuilder lb)
        {
            this.font = font;
            this.lb = lb;
            String[] action = mapdata.Split(':');
            String mapName = action[1];
            int mapsize = int.Parse(action[2]);
            int[,] map = new int[mapsize, mapsize];

            String[] rows = action[3].Split(';');

            for (int i = 0; i < mapsize; i++)
            {
                String[] colloms = rows[i].Split(',');
                for (int j = 0; j < mapsize; j++)
                {
                    map[i, j] = int.Parse(colloms[j]);
                }
            }

            //load in events
            String[] Events = action[4].Split('*');

            for (int i=0; i<Events.Length-1; i++){
                String[] EventData = Events[i].Split(';');
                int x = int.Parse(EventData[0]);
                int y = int.Parse(EventData[1]);

                Event e = new Event(x,y,font);
                events.Add(e);
                String[] Charictors = EventData[2].Split('$');
                for (int j=0; j<Charictors.Length-1;j++){
                //c.getName()+","+c.getHP()+","+c.getAttackType()+","+c.getAttackPower()+","
                    String[] charictor = Charictors[j].Split(',');
                    String name = charictor[0];
                    int HP = int.Parse(charictor[1]);
                    int AttackType = int.Parse(charictor[2]);
                    int AttackPower = int.Parse(charictor[3]);

                    e.addCarictor(name,HP,AttackType,AttackPower);
                    charictor c = e.getCharictor();

                    String[] convo = charictor[4].Split('.');
                    for (int k = 0; k < convo.Length; k++) {
                        String talk = convo[k];
                        c.directlyAddTalk(talk);
                    }
                }
            }
 
            this.name = mapName;
            this.mapsize = mapsize;
            this.map = map;
        }


        public void Update(GameTime gameTime)
        {
             
        }
        public void click(int tiletype) {
            MouseState ms = Mouse.GetState();
            int positionX = (ms.X / 20) + xShift;
            int positionY = (ms.Y / 20) + yShift;
            if (positionX > 0 && positionY > 0)
            {
                if ((tiletype == 4) || (tiletype == 2))
                {
                    bool doseExistAllready = false;
                    foreach (Event e in events)
                    {
                        if ((e.getPosition().X == positionX) && (e.getPosition().Y == positionY))
                        {
                            doseExistAllready = true;
                        }
                    }
                    if (doseExistAllready)
                    {

                    }
                    else
                    {
                        newevent = true;
                        events.Add(new Event(positionX, positionY, font));
                        lb.serlectedEvent = events.Count - 1;
                    }
                }
                else {
                    Event toRemove=null;
                    foreach (Event e in events)
                    {
                        if ((e.getPosition().X == positionX) && (e.getPosition().Y == positionY))
                        {
                            toRemove=e;
                        }
                    }
                    if (events != null) {
                        events.Remove(toRemove);
                    }

                }
                map[positionX, positionY] = tiletype;
            }
        }


        public void Draw(GameTime gameTime, SpriteBatch sp, Texture2D tile)
        {
            //1100 max width 720 max hight
            //use start point as image off sset/scroll bars
            for (int i = (0 + xShift); i < (55 + xShift); i++)
            {
                for (int j = (0 + yShift); j < (36 + yShift); j++)
                {
                    switch (map[i, j])
                    {

                        case 0: { sp.Draw(tile, new Vector2((i - xShift) * 20, (j - yShift) * 20), Color.White); } break;
                        case 1: { sp.Draw(tile, new Vector2((i - xShift) * 20, (j - yShift) * 20), Color.Gray); } break;
                        case 2: { sp.Draw(tile, new Vector2((i - xShift) * 20, (j - yShift) * 20), Color.Red); } break;
                        case 3: { sp.Draw(tile, new Vector2((i - xShift) * 20, (j - yShift) * 20), Color.Blue); } break;
                        case 4: { sp.Draw(tile, new Vector2((i - xShift) * 20, (j - yShift) * 20), Color.Orange); } break;
                        case 5: { sp.Draw(tile, new Vector2((i - xShift) * 20, (j - yShift) * 20), Color.Purple); } break;
                        case 6: { sp.Draw(tile, new Vector2((i - xShift) * 20, (j - yShift) * 20), Color.Green); } break;
                        default: break;
                    }
                }
            }
        }




        public void yShiftincrees(int p)
        {
            yShift += p;
        }
        public void xShiftincrees(int p)
        {
            xShift += p;
        }

        public int getyShift()
        {
            return yShift;
        }
        public int getxShift()
        {
            return xShift;
        }

        
        public String mapToServerData() {

            //uploadmap:serverID:name:mapsize:map[]
            //map[]= cell,cell,cell,cell;cell,cell,cell,cell;cell,cell,cell,cell;...
            StringBuilder sb = new StringBuilder();
            sb.Append("uploadmap" +":" + name + ":" + mapsize+":");
            for (int i = 0; i < map.GetLength(0); i++) {
                for (int j = 0; j < map.GetLength(1); j++) {
                    sb.Append(map[i,j]+",");
                }
                sb.Append(";");
            }
            sb.Append(":");
            foreach (Event e in events) {
                int x = (int)e.getPosition().X;
                int y = (int)e.getPosition().Y;
                sb.Append(x+";"+y+";");
                foreach (charictor c in e.getCharictors()) {
                    sb.Append(c.getName()+","+c.getHP()+","+c.getAttackType()+","+c.getAttackPower()+",");
                    foreach (String s in c.getconvo()) {
                        sb.Append(s);
                        //all ready has a . seporator probably should change
                    }
                    if(c.Equals(e.getCharictors().Last())){
                    }else{
                    sb.Append("$");
                    }
                }
                sb.Append("*");
            }
            sb.Append(":");
            return sb.ToString();
        }


        internal void load(SpriteFont Font)
        {
            this.font = Font;
        }
    }
}
