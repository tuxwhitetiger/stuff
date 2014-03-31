using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace level_builder
{
    class TileSet
    {
        int selectedTileSet = 0;
        Texture2D tile;
        int[,] tiles;

        int tileSetWidth = 2;
        int tileSetHight = 4;


        public TileSet()
        {
            tiles = new int[tileSetWidth, tileSetHight];

            tiles[0, 0] = 0;
            tiles[0, 1] = 1;
            tiles[0, 2] = 2;
            tiles[0, 3] = 3;
            tiles[1, 0] = 4;
            tiles[1, 1] = 5;
            tiles[1, 2] = 6;


        }

        public void loadtile(Texture2D tex) {
            tile = tex;
        }
        public void click()
        {
            MouseState ms = Mouse.GetState();
            int positionX = (ms.X-1122)/20;
            int positionY = (ms.Y-150)/20;
                try
                {
                    selectedTileSet = tiles[positionX, positionY];
                }
                catch (IndexOutOfRangeException) { 
                
                }
            
            }

        public int GetselectedTileSet() {
            return selectedTileSet;
        }


        public void Draw(GameTime gameTime, SpriteBatch sp)
        {
            for (int i = 0; i < tileSetWidth; i++)
            {
                for (int j = 0; j < tileSetHight; j++)
                {
                    switch (tiles[i, j]) {

                        case 0: { sp.Draw(tile, new Vector2((i * 20) + 1122, (j * 20) + 150), Color.White); } break;
                        case 1: { sp.Draw(tile, new Vector2((i * 20) + 1122, (j * 20) + 150), Color.Gray); } break;
                        case 2: { sp.Draw(tile, new Vector2((i * 20) + 1122, (j * 20) + 150), Color.Red); } break;
                        case 3: { sp.Draw(tile, new Vector2((i * 20) + 1122, (j * 20) + 150), Color.Blue); } break;
                        case 4: { sp.Draw(tile, new Vector2((i * 20) + 1122, (j * 20) + 150), Color.Orange); } break;
                        case 5: { sp.Draw(tile, new Vector2((i * 20) + 1122, (j * 20) + 150), Color.Purple); } break;
                        case 6: { sp.Draw(tile, new Vector2((i * 20) + 1122, (j * 20) + 150), Color.Green); } break;
                        default:break;
                    }
                }
            }
        }



    }
}
