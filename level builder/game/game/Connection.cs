using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.IO;
using System.Collections;

namespace game
{
    class Connection
    {
        static TcpClient tcpclnt;
        Game game;

        ArrayList actionList;
        Thread t; 
        public int usernumber = 0;


        public void Connect(String url, Game game)
        {
            actionList = new ArrayList();
            this.game = game;
            tcpclnt = new TcpClient();
            tcpclnt.Connect(url, 2055);
            t = new Thread(new ThreadStart(Service));
            t.Start();
        }

        public void Service()
        {
            Stream s = tcpclnt.GetStream();
            StreamReader sr = new StreamReader(s);
            StreamWriter sw = new StreamWriter(s);
            sw.AutoFlush = true; // enable automatic flushing
            usernumber = int.Parse(sr.ReadLine());
            game.isConnected = true;




            while (true)
            {
                try
                {
                    while (true)
                    {
                        //actionList[0] != null
                        if (actionList.Count>0)
                        {
                            String action = (String)actionList[0];
                            if ((action != null)&&(!action.Equals("")))
                            {
                                String[] sendAction = action.Split(':');
                                String responce = null;
                                switch (sendAction[0])
                                {

                                    case "logIn":
                                        //logIn:username:passsword:connection number
                                        sw.WriteLine(action);
                                        action = null;
                                        actionList.RemoveAt(0);
                                        responce = sr.ReadLine();
                                        if (responce.Equals("yes"))
                                        {
                                            game.logInsucsesss(true, "sucsessfull login");
                                        }
                                        else
                                        {
                                            game.logInsucsesss(false, responce);
                                        }
                                        break;

                                    case "createNewAccount":
                                        //createNewAccount:username:password
                                        sw.WriteLine(action);
                                        action = null;
                                        actionList.RemoveAt(0);
                                        responce = sr.ReadLine();
                                        if (responce == null)
                                        {
                                            responce = "there was an error try again";
                                        }
                                        game.logInScreenMessage(responce);
                                        break;

                                    case "charCreate":
                                        sw.WriteLine(action);
                                        action = null;
                                        actionList.RemoveAt(0);
                                        responce = sr.ReadLine();
                                        break;

                                    case "charfetch":
                                        //charfetch:usernumber
                                        sw.WriteLine(action);
                                        action = null;
                                        actionList.RemoveAt(0);
                                        responce = sr.ReadLine();
                                        if (responce == null)
                                        {
                                            responce = "null";
                                        }
                                        game.charLoadIn(responce);
                                        break;

                                    case "chat":
                                        sw.WriteLine(action);
                                        action = null;
                                        actionList.RemoveAt(0);
                                        break;
                                    case "chatfetch":
                                        sw.WriteLine(action);
                                        action = null;
                                        actionList.RemoveAt(0);
                                        responce = sr.ReadLine();
                                        if (responce == null) { }
                                        else
                                        {
                                            String[] messages = responce.Split(':');
                                            foreach (String message in messages)
                                            {
                                                game.updateChat(message);
                                            }
                                        }
                                        break;
                                    case "joinChat":
                                        sw.WriteLine(action);
                                        action = null;
                                        actionList.RemoveAt(0);
                                        responce = sr.ReadLine();
                                        break;
                                    case "joinGame":
                                        sw.WriteLine(action);
                                        action = null;
                                        actionList.RemoveAt(0);
                                        responce = sr.ReadLine();
                                        break;
                                    case "getLobbyGames":
                                        sw.WriteLine(action);
                                        action = null;
                                        actionList.RemoveAt(0);
                                        responce = sr.ReadLine();
                                        game.lobbygames(responce);
                                        break;
                                    case "newGame":
                                        sw.WriteLine(action);
                                        action = null;
                                        actionList.RemoveAt(0);
                                        responce = sr.ReadLine();
                                        break;
                                    case "uploadmap":
                                        bool lastMessage = false;
                                        String mapMessage = "";
                                        StringBuilder messageBulider = new StringBuilder();

                                        while (!lastMessage)
                                        {
                                            mapMessage = (String)actionList[0];
                                            sw.WriteLine(mapMessage);
                                            actionList.RemoveAt(0);

                                            String[] endingi = mapMessage.Split(new char[] { '[', ']' });
                                            for (int i = 0; i < endingi.Length; i++)
                                            {
                                                lastMessage = endingi[i].Equals("end");
                                                if (lastMessage)
                                                {
                                                    break;
                                                }
                                            }
                                        }
                                        break;

                                    case "getMap":
                                        sw.WriteLine(action);
                                        action = null;
                                        actionList.RemoveAt(0);
                                        bool gotmap = false;
                                        StringBuilder mapBuilder = new StringBuilder();
                                        while (!gotmap)
                                        {
                                            String message = sr.ReadLine();
                                            mapBuilder.Append(message);
                                            bool lastMapMessage = false;
                                            while (!lastMapMessage)
                                            {
                                                message = sr.ReadLine();
                                                mapBuilder.Append(message);
                                                String[] endingi = message.Split(new char[] { '[', ']' });
                                                for (int i = 0; i < endingi.Length; i++)
                                                {
                                                    lastMapMessage = endingi[i].Equals("end");
                                                    if (lastMapMessage)
                                                    {
                                                        gotmap = true;
                                                        break;
                                                    }
                                                }
                                            }
                                        }
                                        Map map = new Map(mapBuilder.ToString());
                                        game.gotMapFromServer(map);
                                        break;

                                    case "getServerCharictorPositions":
                                        sw.WriteLine(action);
                                        action = null;
                                        actionList.RemoveAt(0);
                                        responce = sr.ReadLine();
                                        game.updateOtherCharictorsFromServer(responce);
                                        break;

                                    case "updateServerCharictorPositions":
                                        sw.WriteLine(action);
                                        action = null;
                                        actionList.RemoveAt(0);
                                        responce = sr.ReadLine();
                                        break;
                                    case "getEvent":
                                        sw.WriteLine(action);
                                        action = null;
                                        actionList.RemoveAt(0);
                                        responce = sr.ReadLine();
                                        game.loadEvent(responce);
                                        break;

                                    case "updateAvilibleTalentPoints":
                                        sw.WriteLine(action);
                                        action = null;
                                        actionList.RemoveAt(0);
                                        responce = sr.ReadLine();
                                        break;

                                    case "updateCharictorsAddTalent":
                                        sw.WriteLine(action);
                                        action = null;
                                        actionList.RemoveAt(0);
                                        responce = sr.ReadLine();
                                        break;

                                    case "updateCharictoraddXp":
                                        sw.WriteLine(action);
                                        action = null;
                                        actionList.RemoveAt(0);
                                        responce = sr.ReadLine();
                                        break;

                                    case "updateCharictorLevel":
                                        sw.WriteLine(action);
                                        action = null;
                                        actionList.RemoveAt(0);
                                        responce = sr.ReadLine();
                                        break;
                                    case "pickupItem":
                                        sw.WriteLine(action);
                                        action = null;
                                        actionList.RemoveAt(0);
                                        responce = sr.ReadLine();
                                        break;

                                    case "equipItem":
                                        sw.WriteLine(action);
                                        action = null;
                                        actionList.RemoveAt(0);
                                        responce = sr.ReadLine();
                                        break;
                                        
                                    default:
                                        action = null;
                                        actionList.RemoveAt(0);
                                        break;
                                }
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.Out.WriteLine(e.Message);
                    Console.Out.WriteLine(e.StackTrace);
                }
            }
            
        }

        public void Action(string action)
        {
            String temp = action;
            String cheak = action+":[end]";
            //action list empty couses crash
                if (actionList.Count < 2 || !actionList.Contains(cheak))
            { 
                int maxMessageLength = 1500;
                //modify action to take into account over filling 
                // just substring every 7800 chars and then go onto next one if there is more elce put [end] on it
                if (temp.Length > maxMessageLength)
                {
                    int rem = temp.Length;
                    int count=0;
                    while (rem > maxMessageLength)
                    {
                        String temp2 = temp.Substring(maxMessageLength * count, maxMessageLength);
                        actionList.Add(temp2);
                        rem -= maxMessageLength;
                        count++;
                    }
                    String temp3 = temp.Substring(maxMessageLength * count, action.Length - (maxMessageLength * count));
                    temp3 += ":[end]";
                    actionList.Add(temp3);
                }
                else
                {
                    temp += ":[end]";
                    actionList.Add(temp);
                }
            }
        }

        public void kill()
        {
            t.Abort();
        }
    }
}
