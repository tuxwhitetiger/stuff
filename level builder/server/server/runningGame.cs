using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace server
{
    public class runningGame
    {
        int hostID;
        String discription;
        int maxplayers;
        int currentplayers = 0;
        List<User> users;

        Server server;

        Map gameMap;
        string[] action;


        public runningGame(User host,String discription,int maxplayers,Server server) {
            users = new List<User>();
            users.Add(host);
            hostID = host.getServerNumber();
            this.discription = discription;
            this.maxplayers = maxplayers;
            this.server = server;
        }

        public String getCharictorsPositions(){
            StringBuilder sb = new StringBuilder();
            int i = 0;
            foreach (User u in users) {
                i++;
                sb.Append(u.getCurrentCharictorPosition());
                if (i < users.Count) {
                    sb.Append(":");
                }
            }


            return sb.ToString();
        }

        public void addplayer() {
            currentplayers++;
        }

        public int getHostID()
        {
            return hostID;
        }

        public string getDiscription()
        {
            return discription;
        }

        public int getCurrentPlayers()
        {
            return currentplayers;
        }

        public int getMaxPlayers()
        {
            return maxplayers;
        }

        public bool isInHere(int ID)
        {
            foreach (User u in users) {
                if (u.getServerNumber() == ID) {
                    return true;
                }
            }
            return false;
        }

        public void uploadMap(string mapName, int mapsize, int[,] map, List<Event> events,string[] action)
        {
            this.action = action;
            gameMap = new Map(mapName, mapsize, map,events,int.Parse(action[1]));
        }

        public Map getMap()
        {
            return gameMap;
        }

        internal void addUser(User u2)
        {
            users.Add(u2);
            

        }

        public void setCharictorsPosition(int userID, Vector2 position)
        {
            foreach (User u in users)
            {
                if (u.getServerNumber() == userID)
                {
                    u.getCurrentCharictor().setPosition(position);
                }
            }
        }

        internal string getEvent(int userID3)
        {
            string[] userdata = {};
            foreach (User u in users) {
                if (u.getServerNumber() == userID3)
                {
                    String s = u.getCurrentCharictorPosition();
                    userdata = s.Split(';');
                    break;
                }
            }
            return gameMap.getEventData(int.Parse(userdata[1]), int.Parse(userdata[2]));
        }

        internal void removeplayer(int ThisUser)
        {
            foreach (User u in users)
            {
                if (u.getServerNumber() == ThisUser)
                {
                    users.Remove(u);
                    break;
                }
            }
        }

        internal bool update()
        {
            if (gameMap != null)
            {
                gameMap.Update();
            }
            if (users.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        internal void updateEvent(int x, int y, int ID, int HP,int fightMember)
        {
            gameMap.UpdateEvent(x, y, ID, HP,fightMember);
        }

        internal String fetchupdateEvent(int X3, int Y3)
        {
            return gameMap.fetchupdateEvent(X3,Y3);
        }
        internal int fetchcurrentfighter(int x, int y) {
            return gameMap.fetchCurrentFighter(x, y);
        }

        internal int joinEvent(int X3, int Y3,int connectioNumber)
        {
            foreach (User u in users){
                if(u.getServerNumber() == connectioNumber){
                    return gameMap.joinEvent(X3, Y3, u.getCurrentCharictor());
                }
            }
            return 0;
        }
    }
}
