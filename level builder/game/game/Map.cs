using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Runtime.Serialization;

namespace game
{
    public class Map
    {
        String name= "map1";
        int[,] map;
        MapTile[,] logicMap;
        public int mapsize = 255;
        int yShift = 0;
        int xShift = 0;
        String mapToServer="";

        public Map(string mapdata)
        {
            mapToServer = mapdata;
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
            mapToLogicMap();
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

        public void Draw(SpriteBatch sp, Texture2D tile)
        {
            //1100 max width 720 max hight
            //use start point as image off sset/scroll bars
            for (int i = (0 + xShift); i < (27 + xShift); i++)
            {
                for (int j = (0 + yShift); j < (14 + yShift); j++)
                {
                    switch (map[i, j])
                    {
                        case 0: { sp.Draw(tile, new Vector2((i - xShift) * 40, (j - yShift) * 40), Color.White); } break;
                        case 1: { sp.Draw(tile, new Vector2((i - xShift) * 40, (j - yShift) * 40), Color.Gray); } break;
                        case 2: { sp.Draw(tile, new Vector2((i - xShift) * 40, (j - yShift) * 40), Color.Red); } break;
                        case 3: { sp.Draw(tile, new Vector2((i - xShift) * 40, (j - yShift) * 40), Color.Blue); } break;
                        case 4: { sp.Draw(tile, new Vector2((i - xShift) * 40, (j - yShift) * 40), Color.Orange); } break;
                        case 5: { sp.Draw(tile, new Vector2((i - xShift) * 40, (j - yShift) * 40), Color.Purple); } break;
                        case 6: { sp.Draw(tile, new Vector2((i - xShift) * 40, (j - yShift) * 40), Color.Green); } break;
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

        public String mapToServerData(int ServerID) {
            String[] maptosend = mapToServer.Split(':');

            StringBuilder sb = new StringBuilder();

            sb.Append(maptosend[0]);
            sb.Append(":"+ServerID + ":");
            for (int i = 1; i < maptosend.Length; i++) {
                sb.Append(maptosend[i] + ":");
            }

            return sb.ToString();
        }

        private void mapToLogicMap() {
            logicMap = new MapTile[mapsize,mapsize];
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    MapTile m = new MapTile();
                    m.setType(map[i, j]);
                    logicMap[i, j] = m;
                }
            }
        }

        public MapTile getTile(int x, int y) {
            return logicMap[x, y];
        }

        public void setTile(int x, int y, int type)
        {
            map[x, y] = type;
        }
    }
}
