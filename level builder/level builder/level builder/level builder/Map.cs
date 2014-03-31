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
    [Serializable]
    public class Map : ISerializable
    {
        String name= "map1";
        int[,] map;
        public int mapsize = 255;
        int yShift = 0;
        int xShift = 0;

        public Map()
        {
            map = new int[mapsize, mapsize];
        }
        public Map(SerializationInfo info, StreamingContext context)
        {
            name = (String)info.GetValue("name", typeof(String));
            map = (int[,])info.GetValue("map", typeof(int[,]));
            yShift = (int)info.GetValue("yShift", typeof(int));
            xShift = (int)info.GetValue("xShift", typeof(int));
            mapsize = (int)info.GetValue("mapsize", typeof(int));

        }

        public Map(string mapdata)
        {
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

            // TODO: Complete member initialization
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

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("name", name);
            info.AddValue("map", map);
            info.AddValue("yShift", yShift);
            info.AddValue("xShift", xShift);
            info.AddValue("mapsize", mapsize); 
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
            return sb.ToString();
        }

    }
}
