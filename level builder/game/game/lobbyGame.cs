using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace game
{
    class lobbyGame
    {
        int hostID;
        String Discription;
        int currentplayers;
        int maxplayers;

        public lobbyGame(int hostID,String Discription,int currentplayers, int maxplayers) {
            this.hostID = hostID;
            this.Discription = Discription;
            this.currentplayers = currentplayers;
            this.maxplayers = maxplayers;
        }
        public int getHostID(){
            return hostID;
        }
        public String getDiscription(){
            return Discription;
        }
        public String getpopulation() {
            return currentplayers.ToString() + "/" + maxplayers.ToString();
        }
    }
}
