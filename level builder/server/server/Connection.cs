using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Configuration;
using Microsoft.Xna.Framework;
using System.Net;

namespace server
{
    class Connection
    {

        static TcpListener listener;
        const int LIMIT = 50; //5 concurrent clients

        Thread[] threads = new Thread[LIMIT];

        static int usernumber = 0;
        private Server server;

        public Connection()
        {
            
        }

        public Connection(Server server)
        {
            // TODO: Complete member initialization
            this.server = server;
            IPHostEntry host;
            host = Dns.GetHostEntry(Dns.GetHostName());
            StringBuilder sb = new StringBuilder();
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    sb.Append(ip.ToString() + ", ");
                }
            }
            server.setIP(sb.ToString());
        }

        public void start()
        {
            listener = new TcpListener(2055);
            listener.Start();
            

            for (int i = 0; i < LIMIT; i++)
            {
                Thread t = new Thread(new ThreadStart(Service));
                threads[i] = t;
                t.Start();
            }
        }

        public void Service()
        {
            while (true)
            {
                Socket soc = listener.AcceptSocket();
                try
                {
                    String message ="";
                    Stream s = new NetworkStream(soc);
                    StreamReader sr = new StreamReader(s);
                    StreamWriter sw = new StreamWriter(s);
                    sw.AutoFlush = true; // enable automatic flushing
                    usernumber++;
                    int ThisUser = usernumber;
                    sw.WriteLine(usernumber);
                    StringBuilder messageBulider = new StringBuilder();
                    while (true)
                    {
                        
                        
                        try{
                            message = sr.ReadLine();
                        }
                        catch {
                            server.cleanUser(ThisUser);
                            break;
                        }

                        messageBulider.Append(message);
                        String[] endingi = message.Split(new char[] { '[', ']' });
                        bool lastMessage = false;
                        for (int i = 0; i < endingi.Length; i++)
                        {
                            lastMessage = endingi[i].Equals("end");
                            if (lastMessage) {
                                break;
                            }
                        }
                        while (!lastMessage)
                        {
                            message = sr.ReadLine();
                            messageBulider.Append(message);
                            endingi = message.Split(new char[] { '[', ']' });
                            for (int i = 0; i < endingi.Length; i++)
                            {
                                lastMessage = endingi[i].Equals("end");
                                if (lastMessage)
                                {
                                    break;
                                }
                            }
                        }
                        String actionmessage = messageBulider.ToString();
                        messageBulider.Clear();
                        String[] action = actionmessage.Split(':');
                        String returnMessage = null;
                        switch (action[0]){
                            case "logIn":
                                returnMessage = server.LogIn(action[1], action[2],action[3]);
                                sw.WriteLine(returnMessage);
                                break;
                            case "createNewAccount":
                                returnMessage = server.createNewAccount(action[1], action[2]);
                                sw.WriteLine(returnMessage);
                                break;
                            case "charCreate":
                                returnMessage = server.createNewCharictor(action[1], action[2], int.Parse(action[3]));
                                sw.WriteLine(returnMessage);
                                break;
                            case "charfetch":
                                returnMessage = server.FetchCharictors(int.Parse(action[1]));
                                sw.WriteLine(returnMessage);
                                break;
                            case "chat":
                                String chatdata = action[1];
                                int FromID = int.Parse(action[2]);
                                User cu = server.userSearch(FromID);
                                ChatRoom cr = server.findChatRoom(FromID);
                                if (cr == null)
                                {
                                    server.newChatRoom(FromID);
                                    server.findChatRoom(FromID).newMessage(cu.getName() + "-" + chatdata);
                                }
                                else {
                                    cr.newMessage(cu.getName() + "-" + chatdata);
                                }
                                break;
                            case "chatfetch":
                                String chatReplay = server.findChatRoom(int.Parse(action[1])).getMessages();
                                sw.WriteLine(server.findChatRoom(int.Parse(action[1])).getMessages());
                                break;
                            case "joinChat":
                                ChatRoom chatroom = server.findChatRoom(int.Parse(action[1]));
                                User u = server.userSearch(int.Parse(action[2]));
                                chatroom.addUser(u);

                                sw.WriteLine("done");
                                break;
                            case "joinGame":
                                runningGame runninggame = server.findgame(int.Parse(action[1]));
                                User u2 = server.userSearch(int.Parse(action[2]));
                                runninggame.addUser(u2);
                                sw.WriteLine("done");
                                break;
                            case "getLobbyGames":
                                sw.WriteLine(server.getLobbyGames());
                                break;
                            case "newGame":
                                server.newGame(
                                    int.Parse(action[3]),
                                    action[1],
                                    int.Parse(action[2]));
                                sw.WriteLine("done");
                                break;
                            case "uploadmap":
                                //Console.Out.WriteLine(actionmessage);
                                int ID = int.Parse(action[1]);
                                String mapName = action[2];
                                int mapsize = int.Parse(action[3]);
                                int[,] map = new int[mapsize,mapsize];

                                String[] rows = action[4].Split(';');
                                for (int i = 0; i < mapsize; i++)
                                {
                                    String[] colloms = rows[i].Split(',');
                                    for (int j = 0; j < mapsize; j++)
                                    {
                                        map[i, j] = int.Parse(colloms[j]);
                                    }
                                }
                                //load in events
                                String[] Events = action[5].Split('*');

                                List<Event> events = new List<Event>();

                                for (int i = 0; i < Events.Length - 1; i++)
                                {
                                    String[] EventData = Events[i].Split(';');
                                    int x = int.Parse(EventData[0]);
                                    int y = int.Parse(EventData[1]);

                                    Event e = new Event(x, y);
                                    events.Add(e);
                                    String[] Charictors = EventData[2].Split('$');
                                    for (int j = 0; j < Charictors.Length - 1; j++)
                                    {
                                        //c.getName()+","+c.getHP()+","+c.getAttackType()+","+c.getAttackPower()+","
                                        String[] charictor = Charictors[j].Split(',');
                                        String name = charictor[0];
                                        int HP = int.Parse(charictor[1]);
                                        int AttackType = int.Parse(charictor[2]);
                                        int AttackPower = int.Parse(charictor[3]);

                                        EventCharictor c = new EventCharictor(name, HP, AttackType, AttackPower);
                                        
                                        
                                        String[] convo = charictor[4].Split('.');
                                        for (int k = 0; k < convo.Length; k++)
                                        {
                                            String talk = convo[k];
                                            c.directlyAddTalk(talk);
                                        }
                                        e.addCarictor(c);
                                    }
                                }

                                server.uploadMap(
                                    ID,
                                    mapName,
                                    mapsize,
                                    map,
                                    events,
                                    action
                                    );
                                //sw.WriteLine("done");
                                break;
                            case "getMap":
                                int userIDtogetgamemap = int.Parse(action[1]);
                                String temp = server.findgame(userIDtogetgamemap).getMap().mapToServerData();
                                int maxMessageLength = 2000;
                                //modify action to take into account over filling 
                                // just substring every 7800 chars and then go onto next one if there is more elce put [end] on it
                                if (temp.Length > maxMessageLength)
                                {
                                    int rem = temp.Length;
                                    int count = 0;
                                    while (rem > maxMessageLength)
                                    {
                                        String temp2 = temp.Substring(maxMessageLength * count, maxMessageLength);
                                        sw.WriteLine(temp2);
                                        rem -= maxMessageLength;
                                        count++;
                                    }
                                    String temp3 = temp.Substring(maxMessageLength * count, temp.Length - (maxMessageLength * count));
                                    temp3 += ":[end]";
                                    sw.WriteLine(temp3);
                                }
                                break;

                            case "getServerCharictorPositions":
                                int userID = int.Parse(action[1]);
                                sw.WriteLine(server.findgame(userID).getCharictorsPositions());
                                break;

                            case "updateServerCharictorPositions":
                                int userID2 = int.Parse(action[1]);
                                Vector2 v = new Vector2(int.Parse(action[2]),int.Parse(action[3]));
                                server.findgame(userID2).setCharictorsPosition(userID2,v);
                                sw.WriteLine("done");
                                break;

                            case "getEvent":
                                int userID3 = int.Parse(action[1]);
                                String s2 = server.findgame(userID3).getEvent(userID3);
                                sw.WriteLine(s2);
                                break;

                            case "updateAvilibleTalentPoints":
                                int charictorDBID=int.Parse(action[1]);
                                int availiblepoints=int.Parse(action[2]);
                                server.updateCharictorsTalentPoints(charictorDBID, availiblepoints);
                                sw.WriteLine("done");
                                break;

                            case "updateCharictorsAddTalent":
                                int charictorDBid=int.Parse(action[1]);
                                int treeNumber = int.Parse(action[2]);
                                int X = int.Parse(action[3]);
                                int Y = int.Parse(action[4]);
                                int nodelevel = int.Parse(action[5]);
                                server.updateCharictorsAddTalent(charictorDBid, treeNumber, X, Y, nodelevel);

                                sw.WriteLine("done");
                                break;

                            case "updateCharictoraddXp":
                                int charictorDBid2 = int.Parse(action[1]);
                                int exp = int.Parse(action[2]);
                                server.updateCharictorXP(charictorDBid2, exp);
                                sw.WriteLine("done");
                                break;

                            case "updateCharictorLevel":
                                int charictorDBid3 = int.Parse(action[1]);
                                int level = int.Parse(action[2]);
                                server.updateCharictorLevel(charictorDBid3, level);
                                sw.WriteLine("done");
                                break;

                            case "pickupItem":
                                int charictorDBid4 = int.Parse(action[1]);
                                int itemToIventory = int.Parse(action[2]);
                                server.pickupitem(charictorDBid4, itemToIventory);
                                sw.WriteLine("done");
                                break;

                            case "equipItem":
                                int charictorDBid5 = int.Parse(action[1]);
                                int itemToArmor = int.Parse(action[2]);
                                int itemToIventory2 = int.Parse(action[3]);
                                server.equipItemFromInventory(charictorDBid5, itemToArmor, itemToIventory2);
                                sw.WriteLine("done");
                                break;

                            default : break;
                        }
                        message = null;
                    }
                }
                catch (Exception e)
                {
                    Console.Out.WriteLine(e.StackTrace);
                    Console.Out.WriteLine(e.Message);
                    Console.Out.WriteLine(e.TargetSite);

                    Console.Out.WriteLine("connection crash");
                    Console.Out.WriteLine("Details:");
                    Console.Out.WriteLine("last messsage:" + "unknown");
                    Console.Out.WriteLine("user Number:" + "unknow");

                }
                soc.Close();
            }
        }


        public void kill()
        {
            foreach (Thread t in threads) {
                t.Abort();
            }
        }
    }
}
