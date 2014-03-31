using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace server
{
    public class User
    {
        int userId;
        int DBID;
        public String userName;
        Charictor[] charictors = new Charictor[10];
        int serlectedCharictor = 0;

        public User(int userId, int DBID,String userName) {
            this.userId = userId;
            this.DBID = DBID;
            this.userName = userName;
        }

        public void LoadCharictors(String CharictorData) {
            int charcount = 0;
            String[] charictor = CharictorData.Split(new string[] { "char:" }, StringSplitOptions.None);
            foreach (string charictordata in charictor)
            {

                String[] chardata = charictordata.Split(':');
                if (chardata.Length >1)
                {
                    int charnumber = int.Parse(chardata[0]);
                    int charDB = int.Parse(chardata[1]);
                    int userID = int.Parse(chardata[2]);
                    String charname = chardata[3];
                    String chartype = chardata[4];
                    int talantpoints = int.Parse(chardata[5]);
                    int level = int.Parse(chardata[6]);
                    int experiance = int.Parse(chardata[7]);
                    charictors[charcount] = new Charictor(charnumber, charDB, userID, charname, chartype, level, experiance);
                    charcount++;
                }
            }
        }

        public int getDbNumber()
        {
            return DBID;
        }
        public int getServerNumber()
        {
            return userId;
        }

        public string getName()
        {
            return userName;
        }
        public void setSerlectedCharictor(int i)
        {
            serlectedCharictor = i;
        }
        public void setSerlectedCharictor(String charName)
        {
            int i=0;
            foreach(Charictor c in charictors){
                if(c.getName().Equals(charName)){
                    serlectedCharictor =i;
                    break;
                }
                i++;
            }
        }

        public String getCurrentCharictorPosition()
        {
            Charictor c = charictors[serlectedCharictor];
            if (c == null) {
                return  "deadbeat;0;0";
            }
            else
            {
                return c.getName() + ";" + c.getPosition().X.ToString() + ";" + c.getPosition().Y.ToString();
            }
        }

        public Charictor getCurrentCharictor()
        {
            return charictors[serlectedCharictor];
        }
    }
}
