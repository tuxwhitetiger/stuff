using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Collections;
using System.Text;

namespace server
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Server : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Connection connection;
        database DB;
        ArrayList users;
        List<ChatRoom> chatrooms;
        List<runningGame> games;

        int mapcount = 0;

        SpriteFont font;
        String toDraw="";

        String IP = "";

        public Server()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            users = new ArrayList();
            chatrooms = new List<ChatRoom>();
            games = new List<runningGame>();
            DB = new database();
           // DB.connect();
            connection = new Connection(this);
            connection.start();

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("logInText");
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void OnExiting(Object sender, EventArgs args)
        {
            base.OnExiting(sender, args);
            connection.kill();
            // Stop the threads
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            StringBuilder sb = new StringBuilder();
            sb.Append("IP:" + IP + "\n");
            sb.Append("current running games:" + games.Count + "\n");
            sb.Append("current users signed in:" + users.Count + "\n");
            sb.Append("current running catrooms:" + chatrooms.Count + "\n");
            sb.Append("current number of maps :" + mapcount + "\n");

            List<runningGame> runningGametoRemove = new List<runningGame>();
            List<ChatRoom> ChatRoomtoRemove = new List<ChatRoom>();
            foreach (runningGame game in games)
            {
                if (game.update())
                {

                }
                else {
                    runningGametoRemove.Add(game);
                }
            }
            foreach (ChatRoom chat in chatrooms)
            {
                if (chat.update())
                {

                }
                else {
                    ChatRoomtoRemove.Add(chat);
                }
            }
            foreach (runningGame game in runningGametoRemove)
            {
                games.Remove(game);
                mapcount--;
            }
            foreach (ChatRoom chat in ChatRoomtoRemove)
            {
                chatrooms.Remove(chat);
            }


            toDraw = sb.ToString();
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            spriteBatch.DrawString(font,toDraw,Vector2.Zero,Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }


        public String LogIn(String userName, String Password,String userID) {

            int userIDD = int.Parse(userID); 
            int userDBID = DB.userlogin(userName, Password);

            if (userDBID > 0)
            {
                User u = new User(userIDD, userDBID, userName);
                users.Add(u);
                return "yes";
            }
            else
            {
                return "logIn failed please try again";
            }
        }
        public string createNewAccount(string userName, string password)
        {
            if (password.Length > 5)
            {
                if (DB.doseUserExist(userName) > 0)
                {
                    return "account already exists";
                }
                else
                {
                    DB.createNewUser(userName, password);
                    return "account created";
                }
            }
            else {
                return "password to short";
            }
        }
        public string createNewCharictor(string charType, string charName,int userID)
        {
            
            if (userSearch(userID) != null) {
                DB.createNewcharacter(getDBIDFromServerID(userID).ToString(), charType, charName);
                return "charictor created";
            }
            return "error";
            
        }
        public String FetchCharictors(int userID) {
            int i = getDBIDFromServerID(userID);
            String s =DB.fetchcharacter(i);
            userSearch(userID).LoadCharictors(s);
            return s;
        }
        public User userSearch(int i)
        {
            foreach (object u in users)
            {
                User u2 = (User)u;
                int j = u2.getServerNumber();
                if (j == i)
                {
                    return u2;
                }
            }
            return null;
        }
        public int getDBIDFromServerID(int i)
        {
            foreach (object u in users)
            {
                User u2 = (User)u;
                int j = u2.getServerNumber();
                if (j == i)
                {
                    return u2.getDbNumber();
                }
            }
            return 0;
        }
        public void newChatRoom(int ID) {

            foreach (object u in users)
            {
                User u2 = (User)u;
                int j = u2.getServerNumber();
                if (j == ID)
                {
                    ChatRoom room = new ChatRoom(u2);
                    chatrooms.Add(room);
                }
            }
        }
        public ChatRoom findChatRoom(int ID)
        {
            foreach (ChatRoom cr in chatrooms)
            {

                if (cr.isInHere(ID))
                {
                    return cr;
                }
            }
            return null;
        }
        public runningGame findgame(int ID)
        {
            foreach (runningGame g in games)
            {
                if (g.isInHere(ID))
                {
                    return g;
                }
            }
            return null;
        }
        public string getLobbyGames()
        {
            StringBuilder sb = new StringBuilder();
            if (games.Count > 0)
            {
                foreach (runningGame g in games)
                {
                    
                    sb.Append(g.getHostID() + ";");
                    sb.Append(g.getDiscription() + ";");
                    sb.Append(g.getCurrentPlayers() + ";");
                    sb.Append(g.getMaxPlayers() + ";");
                    sb.Append(":");
                }
                return sb.ToString();
            }
            return "null";
        }
        public void newGame(int hostID, String Dicription, int max){
            User u = userSearch(hostID);
            runningGame g = new runningGame(u, Dicription, max,this);
            ChatRoom cr = new ChatRoom(u);
            chatrooms.Add(cr);
            games.Add(g);
        }
        public void uploadMap(int ID, string mapName, int mapsize, int[,] map,List<Event> events, string[] action)
        {
            findgame(ID).uploadMap(mapName, mapsize, map, events, action);
            mapcount++;
        }
        internal void cleanUser(int ThisUser)
        {
            foreach (runningGame game in games) {
                game.removeplayer(ThisUser);
            }
            foreach (ChatRoom chat in chatrooms) {
                chat.removeUser(ThisUser);
            }
            foreach (User user in users) {
                if (user.getServerNumber() == ThisUser)
                {
                    users.Remove(user);
                    break;
                }
            }
        }
        internal void setIP(string localIP)
        {
            IP = localIP;
        }
        internal void updateCharictorsTalentPoints(int charictorID, int talentpoints)
        {
            DB.updateCharictorsTalentPoints(charictorID, talentpoints);
        }
        internal void updateCharictorsAddTalent(int charictorID, int treenumber, int x, int y, int level)
        {
            DB.updateCharictorsAddTalent(charictorID, treenumber,x,y,level);
        }
        internal void updateCharictorXP(int charictorDBid2, int exp)
        {
            DB.updateCharictorXP(charictorDBid2,exp);
        }
        internal void updateCharictorLevel(int charictorDBid3, int level)
        {
            DB.updateCharictorLevel(charictorDBid3, level);
        }
        internal void equipItemFromInventory(int charictorID, int itemToArmorID, int itemToInventoryID)
        {
            DB.equipItemFromInventory(charictorID, itemToArmorID, itemToInventoryID);
        }
        internal void pickupitem(int charictorID, int itemToInventoryID)
        {
            DB.pickupitem(charictorID,itemToInventoryID);
        }
        internal void updateServerFight(int connectionID, int x, int y, int ID, int HP,int fighter) {
            findgame(connectionID).updateEvent(x, y, ID, HP,fighter);
        }
        internal string fetchServerFightUpdate(int conection1, int X3, int Y3)
        {
            return findgame(conection1).fetchupdateEvent(X3, Y3);
        }
        internal int fetchCurrentFighter(int conection1, int x, int y) {
            return findgame(conection1).fetchcurrentfighter(x, y);
        }
        internal int jointEvent(int conection3, int X3, int Y3)
        {
            return findgame(conection3).joinEvent(X3, Y3, conection3);
        }
    }
}
