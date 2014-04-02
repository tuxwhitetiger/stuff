using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Runtime.Serialization;

namespace server
{
    public class Map 
    {
        String name= "map1";
        int[,] map;
        public int mapsize = 255;
        List<Event> events;
        int yShift = 0;
        int xShift = 0;
        int hostID = 0;

        public Map(string mapName, int mapsize, int[,] map,List<Event> events,int ID)
        {
            this.name = mapName;
            this.mapsize = mapsize;
            this.map = map;
            this.events = events;
            hostID = ID;
        }
        
        public void Update()
        {
            foreach (Event e in events) {
                e.update();
            }
        }
        public void click(int tiletype) {
            MouseState ms = Mouse.GetState();
            int positionX = (ms.X / 20) + xShift;
            int positionY = (ms.Y / 20) + yShift;
            if (positionX > 0 && positionY > 0)
            {
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
            sb.Append("uploadmap" + ":" + name + ":" + mapsize+":");
            for (int i = 0; i < map.GetLength(0); i++) {
                for (int j = 0; j < map.GetLength(1); j++) {
                    sb.Append(map[i,j]+",");
                }
                sb.Append(";");
            }
            return sb.ToString();
        }
        public string getEventData(int x, int y) {
            foreach (Event e in events) {
                if (e.getposition() == new Vector2(x, y)) {
                    return x.ToString()+";"+y.ToString()+";"+e.getData();
                }
            }
            return "null";
        }


        internal void UpdateEvent(int x, int y, int ID, int HP, int fightmember)
        {
            foreach (Event e in events) {
                if (e.getposition().X == x && e.getposition().Y == y) {
                    e.updateCharictor(fightmember,ID, HP);
                }
            }
        }

        internal String fetchupdateEvent(int x, int y)
        {
            foreach (Event e in events)
            {
                if (e.getposition().X == x && e.getposition().Y == y)
                {
                    return e.getData();
                }
            }
            return "null";
        }
        internal int fetchCurrentFighter(int x,int y){
            foreach (Event e in events)
            {
                if (e.getposition().X == x && e.getposition().Y == y)
                {
                    return e.getCurrentFighter();
                }
            }
            return 0;
        }

        internal int joinEvent(int X3, int Y3,Charictor player)
        {
            foreach (Event e in events)
            {
                if (e.getposition().X == X3 && e.getposition().Y == Y3)
                {
                    return e.addPlayer(player);
                }
            }
            return 0;
        }
    }
}
