using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace server
{
    public class Charictor
    {
        Vector2 position = new Vector2(0,0);
        String name;
        private int charnumber;
        private int charDB;
        private int userID;
        private int experiance;
        private int level;
        private string chartype;
        public int fightmember;

        public Charictor(){

        }

        public Charictor(int charnumber, int charDB, int userID, string charname, string chartype,int experiance,int level)
        {
            this.charnumber = charnumber;
            this.charDB = charDB;
            this.userID = userID;
            this.name = charname;
            this.chartype = chartype;
            this.experiance = experiance;
            this.level = level;
        }

        public Vector2 getPosition() {
            return position;
        }
        public void setPosition(Vector2 position) {
            this.position = position;
        }
        public String getName()
        {
            return name;
        }
        public void setName(String name)
        {
            this.name = name;
        }

    }
}
