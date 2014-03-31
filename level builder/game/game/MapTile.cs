using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace game
{
    public class MapTile
    {
        tileTypes Type = tileTypes.empty;
        public bool walkable = true;

        public void Update() {

            switch (Type) {
                case tileTypes.empty: break;
                case tileTypes.wall: break;
                case tileTypes.Talk: break;
            }
        }
        public tileTypes getType()
        {
            return Type;
        }

        public void setType(int typenumber)
        {
            switch (typenumber)
            {
                case 0: Type = tileTypes.empty; break;
                case 1: Type = tileTypes.wall; walkable = false; break;
                case 2: Type = tileTypes.Talk; break;
            }
        }
    }



    public enum tileTypes { 
        empty,
        wall,
        Talk,
    }
}
