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

namespace game
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Connection connection;
        MapStore mapStore;
        ItemStore itemStore;
        moveController movecontroller;
        internal levels levelsXP;

        Charictor[] charictors;
        int activeCharictorArrayId;

        LogInScreen logInScreen;
        CharacterCreationScreen characterCreationScreen;
        ChariscotrSelectionScreen chariscotrSelectionScreen;
        WaitRoomScreen waitRoomScreen;
        LobbyScreen lobbyScreen;
        NewGameScreen newGameScreen;
        RunningGame runningGame;
        EventScreen eventScreen;
        CarictorEditScreen characterEditScreen;


        bool isLogedIn = true;
        public bool isConnected = false;
        bool isCharacterCreate = false;
        bool isCharacterSelect = false;
        bool isWaitRoomScreen = false;
        bool isLobbyScreen = false;
        bool isNewGameScreen = false;
        bool isrunningGame = false;
        bool isEventScreen = false;
        bool isCharacterEditScreen=false;

        int timeLoopRunningGameUpdate = 0;


        String serverIP = "127.0.0.1";
        

        public Game()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 720;
            graphics.PreferredBackBufferWidth = 1280;
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
            connection = new Connection();
            logInScreen = new LogInScreen();
            characterCreationScreen = new CharacterCreationScreen();
            chariscotrSelectionScreen = new ChariscotrSelectionScreen(this);
            waitRoomScreen = new WaitRoomScreen();
            lobbyScreen = new LobbyScreen();
            this.IsMouseVisible = true;
            charictors = new Charictor[6];
            newGameScreen = new NewGameScreen();
            runningGame = new RunningGame(this,GraphicsDevice);
            eventScreen = new EventScreen(this);
            characterEditScreen = new CarictorEditScreen(this);
            levelsXP = new levels();
            itemStore = new ItemStore();
            movecontroller = new moveController();
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
            logInScreen.Load(Content.Load<SpriteFont>("logInText"), Content.Load<Texture2D>("logInScreen"));
            characterCreationScreen.Load(
                Content.Load<Texture2D>("archer"),
                Content.Load<Texture2D>("wizard"),
                Content.Load<Texture2D>("barbarian"),
                Content.Load<Texture2D>("rouge"),
                Content.Load<Texture2D>("charictorSelecter"),
                Content.Load<Texture2D>("charictorCreate"),
                Content.Load<SpriteFont>("logInText")
                );
            chariscotrSelectionScreen.Load(
                Content.Load<Texture2D>("archer"),
                Content.Load<Texture2D>("wizard"),
                Content.Load<Texture2D>("rouge"),
                Content.Load<Texture2D>("barbarian"),
                Content.Load<Texture2D>("charictorSelect"),
                Content.Load<Texture2D>("carictor-select-screen-edit-button"),
                Content.Load<SpriteFont>("logInText")

                );
            waitRoomScreen.Load(
                Content.Load<SpriteFont>("logInText"),
                Content.Load<Texture2D>("gameWaitRoomScreen")
                );
            lobbyScreen.Load(
                Content.Load<Texture2D>("lobbyScreen"),
                Content.Load<SpriteFont>("logInText")
                );
            newGameScreen.Load(
                Content.Load<Texture2D>("createGameScreen"),
                Content.Load<SpriteFont>("logInText")
                );
            List<Texture2D> tree1 = new List<Texture2D>();

            tree1.Add(Content.Load<Texture2D>("icons/tree1/i_can_cary_it"));
            tree1.Add(Content.Load<Texture2D>("icons/tree1/hard_man"));
            tree1.Add(Content.Load<Texture2D>("icons/tree1/to_arms_brothers"));
            tree1.Add(Content.Load<Texture2D>("icons/tree1/blood_rage"));
            tree1.Add(Content.Load<Texture2D>("icons/tree1/stone_skin"));
            tree1.Add(Content.Load<Texture2D>("icons/tree1/got_a_spare_hand"));
            tree1.Add(Content.Load<Texture2D>("icons/tree1/got_for_the_head"));
            tree1.Add(Content.Load<Texture2D>("icons/tree1/taunt"));
            tree1.Add(Content.Load<Texture2D>("icons/tree1/stronger_than_i_look"));
            tree1.Add(Content.Load<Texture2D>("icons/tree1/battle_cry"));
            tree1.Add(Content.Load<Texture2D>("icons/tree1/decapitate"));
            tree1.Add(Content.Load<Texture2D>("icons/tree1/thunder_puntch"));
            tree1.Add(Content.Load<Texture2D>("icons/tree1/battle_shout"));
            tree1.Add(Content.Load<Texture2D>("icons/tree1/takedown"));
            tree1.Add(Content.Load<Texture2D>("icons/tree1/taunt_2"));
            tree1.Add(Content.Load<Texture2D>("icons/tree1/battle_roar"));
            tree1.Add(Content.Load<Texture2D>("icons/tree1/tis_but_a_scratch"));
            List<Texture2D> tree2 = new List<Texture2D>();
            tree2.Add(Content.Load<Texture2D>("icons/tree2/spell_book"));
            tree2.Add(Content.Load<Texture2D>("icons/tree2/wizard_power"));
            tree2.Add(Content.Load<Texture2D>("icons/tree2/cristale_magic"));
            tree2.Add(Content.Load<Texture2D>("icons/tree2/magic_hand"));
            tree2.Add(Content.Load<Texture2D>("icons/tree2/deamon_magic"));
            tree2.Add(Content.Load<Texture2D>("icons/tree2/mana_shild"));
            tree2.Add(Content.Load<Texture2D>("icons/tree2/mana_cristal"));
            tree2.Add(Content.Load<Texture2D>("icons/tree2/fireblast"));
            tree2.Add(Content.Load<Texture2D>("icons/tree2/circle_of_fire"));
            tree2.Add(Content.Load<Texture2D>("icons/tree2/sole_rip"));
            tree2.Add(Content.Load<Texture2D>("icons/tree2/icefire"));
            List<Texture2D> tree3 = new List<Texture2D>();
            tree3.Add(Content.Load<Texture2D>("icons/tree3/quick_steap"));
            tree3.Add(Content.Load<Texture2D>("icons/tree3/arrow_construction"));
            tree3.Add(Content.Load<Texture2D>("icons/tree3/poisen"));
            tree3.Add(Content.Load<Texture2D>("icons/tree3/speed_stab"));
            tree3.Add(Content.Load<Texture2D>("icons/tree3/dead_shot"));
            tree3.Add(Content.Load<Texture2D>("icons/tree3/animal_within"));
            tree3.Add(Content.Load<Texture2D>("icons/tree3/to_the_shadows"));
            tree3.Add(Content.Load<Texture2D>("icons/tree3/fork_shot"));
            tree3.Add(Content.Load<Texture2D>("icons/tree3/target"));
            tree3.Add(Content.Load<Texture2D>("icons/tree3/ninga_furry"));
            tree3.Add(Content.Load<Texture2D>("icons/tree3/explosive_arrow"));

            characterEditScreen.load(
                Content.Load<Texture2D>("charictor-edit_Screen_background"),
                Content.Load<SpriteFont>("logInText"),
                Content.Load<Texture2D>("archer"),
                Content.Load<Texture2D>("wizard"),
                Content.Load<Texture2D>("rouge"),
                Content.Load<Texture2D>("barbarian"),
                tree1.ToArray(),
                tree2.ToArray(),
                tree3.ToArray()
                );


            runningGame.load(
                Content.Load<Texture2D>("runningGameBackground"),
                Content.Load<SpriteFont>("logInText"),
                Content.Load<Texture2D>("tile40-40"),
                Content.Load<Texture2D>("archerSpriteSheet"),
                Content.Load<Texture2D>("barbarianSpriteSheet"),
                Content.Load<Texture2D>("wizardSpriteSheet"),
                Content.Load<Texture2D>("rougeSpriteSheet")
                );
            eventScreen.Load(
                Content.Load<Texture2D>("eventScreen"),
                Content.Load<Texture2D>("badguy"),
                Content.Load<SpriteFont>("logInText")
                );

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

            //log in page and logic
            if (isLogedIn)
            {
                String s = logInScreen.update(gameTime);

                if (!s.Equals("null"))
                {
                    
                    
                    String[] logindata = s.Split(':');
                    if(logindata[0].Equals("logIn")){
                        if (!isConnected)
                        {
                            connection.Connect(serverIP, this);
                            while (!isConnected)
                            {
                                //ADD IN A WAIT TIME THEN BOOT OUT
                            }
                        }
                        connection.Action("logIn:" + logindata[1] + ":" + logindata[2]+":"+connection.usernumber);
                    }
                    else if (logindata[0].Equals("createNewAccount"))
                    {
                        if (!isConnected)
                        {
                            connection.Connect(serverIP, this);
                            while (!isConnected)
                            {
                                //ADD IN A WAIT TIME THEN BOOT OUT
                            }
                        }
                        connection.Action("createNewAccount:" + logindata[1] + ":" + logindata[2]);
                    }
                    else if (logindata[0].Equals("IP"))
                    {
                        serverIP = logindata[1];
                    }
                }
            }



            //charictor creation screen
            if (isCharacterCreate) {
                String s = characterCreationScreen.update();
                if(!s.Equals("null")){
                    connection.Action(s+":"+connection.usernumber);
                    isCharacterSelect = true;
                    connection.Action("charfetch:" + connection.usernumber + ":");
                    isCharacterCreate = false;
                }
            }
            //charictor Selection screen
            if (isCharacterSelect) {
                String s = chariscotrSelectionScreen.update();
                

                if (!s.Equals("null"))
                {
                    if (s.Equals("createGame"))
                    {
                        isCharacterSelect = false;
                        isNewGameScreen = true;
                    }
                    if (s.Equals("lobby"))
                    {
                        isCharacterSelect = false;
                        isLobbyScreen = true;
                        connection.Action("getLobbyGames:");
                    }
                    if (s.Equals("edit"))
                    {
                        isCharacterSelect = false;
                        isCharacterEditScreen = true;
                    }
                }
            }
            if (isCharacterEditScreen) {

                String s = characterEditScreen.update();
                if (!s.Equals("null"))
                {
                    if (s.Equals("done")) {
                        isCharacterSelect = true;
                        isCharacterEditScreen = false;
                    }
                }
            }
            if (isNewGameScreen) {
                String s = newGameScreen.update();
                if (!s.Equals("null"))
                {
                    connection.Action(s + connection.usernumber);
                    String[] Data = s.Split(':');
                    waitRoomScreen.joingame(connection.usernumber,Data[1]);
                    connection.Action(newGameScreen.getMap().mapToServerData(connection.usernumber));
                    int dwStartTime = System.Environment.TickCount;
                    while (true)
                    {
                        if (System.Environment.TickCount - dwStartTime > 3000) break; //1000 milliseconds 
                    }
                    isNewGameScreen = false;
                    isWaitRoomScreen = true;
                    waitRoomScreen.map = newGameScreen.getMap();
                }
            }

            if (isWaitRoomScreen) {
                String s = waitRoomScreen.update();
                if (!s.Equals("null"))
                {
                    if (s.Equals("startGame"))
                    {
                        isWaitRoomScreen = false;
                        isrunningGame = true;
                        if (waitRoomScreen.map != null)
                        {
                            runningGame.secondLoad(waitRoomScreen.map,charictors[activeCharictorArrayId]);
                        }
                    }
                    else
                    {
                        connection.Action("chat:" + s + ":" + connection.usernumber);
                    }
                }
                //put a time lock on here
                connection.Action("chatfetch:"+connection.usernumber);
            }

            if (isLobbyScreen) {
                String s =lobbyScreen.update();
                if (!s.Equals("null"))
                {
                    String[] Data = s.Split(':');
                    connection.Action("joinGame:" + Data[1] + ":" + connection.usernumber);
                    connection.Action("joinChat:" + Data[1] +":"+ connection.usernumber);
                    waitRoomScreen.joingame(int.Parse(Data[1]), Data[2]);
                    runningGame.wait = true;
                    connection.Action("getMap:"+connection.usernumber);
                    while (runningGame.wait) { 

                    }
                    isWaitRoomScreen = true;
                    isLobbyScreen = false;
                }
            }

            if (isrunningGame) {
                String s = runningGame.update();
                if (!s.Equals("null"))
                {
                    if (s.Equals("action"))
                    {
                        //do an action
                        connection.Action("updateServerCharictorPositions:" + connection.usernumber + ":"+runningGame.getPlayerPosition().X+":"+runningGame.getPlayerPosition().Y);
                    }
                    else if (s.Equals("talk"))
                    {
                        //do an action
                        isrunningGame = false;
                        eventScreen.eventLoaded = false;
                        connection.Action("getEvent:" + connection.usernumber);
                        jointEvent();
                        eventScreen.addPlayer(charictors[activeCharictorArrayId]);
                        while (!eventScreen.eventLoaded) { 
                        
                        }
                        isEventScreen = true;
                    }
                    else
                    {
                        connection.Action("chat:" + s + ":" + connection.usernumber);
                    }
                }

                if (gameTime.TotalGameTime.TotalMilliseconds >= timeLoopRunningGameUpdate)
                {
                    connection.Action("chatfetch:" + connection.usernumber);
                    connection.Action("getServerCharictorPositions:" + connection.usernumber);
                    timeLoopRunningGameUpdate = (int)gameTime.TotalGameTime.TotalMilliseconds + 1000;
                }

            }
            if (isEventScreen)
            {

                if (gameTime.TotalGameTime.TotalMilliseconds >= timeLoopRunningGameUpdate)
                {
                    fetchUpdate();
                    fetchCurrentFighter();
                    timeLoopRunningGameUpdate = (int)gameTime.TotalGameTime.TotalMilliseconds + 500;
                }
                

                String s = eventScreen.Update();

                if (s.Equals("done")) {
                    isEventScreen = false;
                    isrunningGame = true;
                }

            }
            if(Keyboard.GetState().IsKeyDown(Keys.PageUp)){
                isEventScreen = !isEventScreen;
            }
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

            spriteBatch.Begin();
            if (isLogedIn)
            {
                logInScreen.draw(spriteBatch);
            }
            if (isCharacterCreate)
            {
                characterCreationScreen.Draw(spriteBatch);
            }
            if (isCharacterSelect) {
                chariscotrSelectionScreen.draw(spriteBatch);
            }
            if (isNewGameScreen)
            {
                newGameScreen.Draw(spriteBatch);
            }
            if (isWaitRoomScreen) {
                waitRoomScreen.Draw(spriteBatch);
            }
            if (isLobbyScreen) {
                lobbyScreen.Draw(spriteBatch);
            }
            if (isrunningGame)
            {
                runningGame.Draw(spriteBatch);
            }
            if (isEventScreen)
            {
                eventScreen.Draw(spriteBatch);
            }
            if (isCharacterEditScreen)
            {
                characterEditScreen.Draw(spriteBatch);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }



        public void logInsucsesss(bool b, String errormessage)
        {
            if (b) {
                connection.Action("charfetch:" + connection.usernumber + ":");
                isCharacterSelect = true;
                isLogedIn = false;
            }
            logInScreen.setErrorMessage(errormessage);
        }
        public void logInScreenMessage(String errormessage)
        {
            logInScreen.setErrorMessage(errormessage);
        }
        public void charLoadIn(String data) {
            int charcount = 0;
            String[] charictor = data.Split(new string[] { "char:" }, StringSplitOptions.None);
            foreach (string charictordata in charictor) {
                
                String[] chardata = charictordata.Split(':');
                if (chardata.Length >1)
                {
                    int charnumber = int.Parse(chardata[0]);
                    int charDB = int.Parse(chardata[1]);
                    int userID = int.Parse(chardata[2]);
                    String charname = chardata[3];
                    String chartype = chardata[4];
                    int availableTalentPoints = int.Parse(chardata[5]);
                    int level = int.Parse(chardata[6]);
                    int experiance = int.Parse(chardata[7]);

                    Item[] armor = new Item[7];// 0-head 1-cheast 2-hands 3-legs 4-feet 5-leftwep 6-rightwep
                    List<Item> Items = new List<Item>();
                    String[] inventoryData = chardata[9].Split(new string[] { "Item;" }, StringSplitOptions.None);
                    if (inventoryData.Length > 1)
                    {
                        for (int i = 1; i < inventoryData.Length; i++)
                        {
                            String[] itemData = inventoryData[i].Split(new string[] { ";" }, StringSplitOptions.None);
                            int ItemDBID = int.Parse(itemData[0]);
                            int ItemID = int.Parse(itemData[1]);
                            int Equiped = int.Parse(itemData[3]);
                            Item item = itemStore.fetchItem(ItemID);
                            item.load(ItemDBID, Equiped);
                            if (Equiped == 1)
                            {
                                armor[item.slot] = item;
                            }
                            else
                            {
                                Items.Add(item);
                            }
                        }
                    }
                    charictors[charcount] = new Charictor(charnumber, charDB, userID, charname, chartype, chardata[8], availableTalentPoints, level, experiance, armor, Items);
                    charictors[charcount].sortMoveData(movecontroller);
                    charcount++;
                }
            }

        }
        public void SelectActiveChar(String name) {
            int i = 0;
            foreach (Charictor c in charictors) {
                if (c.GetName().Equals(name)) { 
                    activeCharictorArrayId = i;
                    break;
                }
                i++;
            }
        }
        public String[] getCharictorNames() {
            String[] names = new String[6];
            int i =0;
            foreach (Charictor c in charictors) {
                if (c == null)
                {
                    break;
                }
                names[i] = c.GetName();
                i++;
            }
            return names;
        }
        public void Createchar()
        {
            isCharacterSelect = false;
            isCharacterCreate = true;

            
        }
        public charictorType getCharictorType(string charName)
        {
            foreach (Charictor c in charictors)
            {
                if (c == null)
                {
                    break;
                }
                if(c.GetName().Equals(charName)){
                    return c.GetcharType();
                }
            }
            return charictorType.none;
        }
        public void updateChat(String message)
        {
            waitRoomScreen.newmessage(message);
            runningGame.newMessage(message);
        }
        public void joinchatroom(int roomID) {
            connection.Action("joinChat:" + roomID);
        }
        public void lobbygames(string responce)
        {
            lobbyScreen.getGames(responce);
        }
        public void gotMapFromServer(Map map)
        {
            runningGame.secondLoad(map, charictors[activeCharictorArrayId]);
            runningGame.wait = false;
        }
        public void updateOtherCharictorsFromServer(string charictors)
        {
            List<Charictor> oldData = runningGame.getOtherPlayer();
            bool found = false;
            String[] charictorsData = charictors.Split(':');
            foreach (String charictor in charictorsData) { 
                String[] charictorData = charictor.Split(';');
                String name = charictorData[0];
                int xCord = int.Parse(charictorData[1]);
                int yCord = int.Parse(charictorData[2]);
                int count = 0;
                foreach (Charictor c in oldData) { 
                    if(c.GetName().Equals(name)){
                        Vector2 v = new Vector2(xCord,yCord);
                        runningGame.updateotherplayer(count,v);
                        found = true;
                    }
                    count++;
                }
                if (!found) {
                    Charictor c = new Charictor(name, new Vector2(xCord, yCord));
                    runningGame.addOtherPlayer(c);
                }
                found = false;
            }
        }
        internal void loadEvent(string responce)
        {
            eventScreen.LoadData(responce);
            
            for(int i=0; i<runningGame.getOtherPlayer().Count;i++){
                eventScreen.addCharictor(runningGame.getOtherPlayer()[i]);
            }

            eventScreen.eventLoaded = true;
        }
        internal Charictor getCurrentCharictor()
        {
            return charictors[activeCharictorArrayId];
        }
        internal void updatePlayerTreeOnServer(int treeNumber, int x, int y, int nodeLevel)
        {
            String action = "updateAvilibleTalentPoints:" + charictors[activeCharictorArrayId].getCharictorDBID() + ":" + charictors[activeCharictorArrayId].getAviliblePoints() + ":";
            connection.Action(action);
            action = "updateCharictorsAddTalent:" + charictors[activeCharictorArrayId].getCharictorDBID() + ":" + treeNumber + ":" + x + ":" + y + ":" + nodeLevel + ":";
            connection.Action(action);
        }
        internal void updateCharictorXpOnServer(int XP)
        {
            charictors[activeCharictorArrayId].addXP(XP);
            String action = "updateCharictoraddXp:" + charictors[activeCharictorArrayId].getCharictorDBID() + ":" + charictors[activeCharictorArrayId].getXP() +":";
            connection.Action(action);

            int ding = levelsXP.fetchDing(charictors[activeCharictorArrayId].getLevel());
            int currentXP = charictors[activeCharictorArrayId].getXP();

            if (currentXP > ding) {
                charictors[activeCharictorArrayId].setAviliblePoints(1);
                action = "updateAvilibleTalentPoints:" + charictors[activeCharictorArrayId].getCharictorDBID() + ":" + charictors[activeCharictorArrayId].getAviliblePoints() + ":";
                connection.Action(action);
                charictors[activeCharictorArrayId].setLevel(1);
                action = "updateCharictorLevel:" + charictors[activeCharictorArrayId].getCharictorDBID() + ":" + charictors[activeCharictorArrayId].getLevel() + ":";
                connection.Action(action);

            }


        }
        internal void addItemInventory(int i) { 
            //add to charictor
            charictors[activeCharictorArrayId].addToInventory(itemStore.fetchItem(i));
            //add to server
            String action = "pickupItem:" + charictors[activeCharictorArrayId].getCharictorDBID() + ":" + i + ":";
            connection.Action(action);
        }
        internal void equipItemFromInventory(Item itemToArmor, Item itemToInventory)
        {


            int itemtoArmorDBID = itemToArmor.DBID;
            int itemtoInventoryDBID;
            if (itemToInventory != null)
            {
                itemtoInventoryDBID = itemToInventory.DBID;
            }
            else {
                itemtoInventoryDBID = -1;
            }

            //cheack if can be equiped
            // 0-head 1-cheast 2-hands 3-legs 4-feet

            charictors[activeCharictorArrayId].equipItem(itemToArmor, itemToInventory);
            String action = "equipItem:" + charictors[activeCharictorArrayId].getCharictorDBID() + ":" + itemtoArmorDBID + ":" + itemtoInventoryDBID + ":";
            connection.Action(action);

            /*
            switch (charictors[activeCharictorArrayId].GetcharType()) {
                case charictorType.archer:
                    switch (slot)
                    {
                        case 0:
                            if (item.type == ItemType.leatherhead) {
                                Item itemHold = charictors[activeCharictorArrayId].getArmor(slot);
                                charictors[activeCharictorArrayId].setArmor(item,slot);
                                charictors[activeCharictorArrayId].setInventory(itemHold, fromSlot);
                                String action = "equipItem:" + charictors[activeCharictorArrayId].getCharictorDBID() + ":" + item.ID + ":" + itemHold.ID + ":";
                                connection.Action(action);
                            }
                            break;
                        case 1:
                            if (item.type == ItemType.leathercheast) {
                                Item itemHold = charictors[activeCharictorArrayId].getArmor(slot);
                                charictors[activeCharictorArrayId].setArmor(item, slot);
                                charictors[activeCharictorArrayId].setInventory(itemHold, fromSlot);
                                String action = "equipItem:" + charictors[activeCharictorArrayId].getCharictorDBID() + ":" + item.ID + ":" + itemHold.ID + ":";
                                connection.Action(action);
                            }
                            break;
                        case 2:
                            if (item.type == ItemType.leatherhands) {
                                Item itemHold = charictors[activeCharictorArrayId].getArmor(slot);
                                charictors[activeCharictorArrayId].setArmor(item, slot);
                                charictors[activeCharictorArrayId].setInventory(itemHold, fromSlot);
                                String action = "equipItem:" + charictors[activeCharictorArrayId].getCharictorDBID() + ":" + item.ID + ":" + itemHold.ID + ":";
                                connection.Action(action);
                            }
                            break;
                        case 3:
                            if (item.type == ItemType.leatherlegs) {
                                Item itemHold = charictors[activeCharictorArrayId].getArmor(slot);
                                charictors[activeCharictorArrayId].setArmor(item, slot);
                                charictors[activeCharictorArrayId].setInventory(itemHold, fromSlot);
                                String action = "equipItem:" + charictors[activeCharictorArrayId].getCharictorDBID() + ":" + item.ID + ":" + itemHold.ID + ":";
                                connection.Action(action);
                            }
                            break;
                        case 4:
                            if (item.type == ItemType.leatherfeet) {
                                Item itemHold = charictors[activeCharictorArrayId].getArmor(slot);
                                charictors[activeCharictorArrayId].setArmor(item, slot);
                                charictors[activeCharictorArrayId].setInventory(itemHold, fromSlot);
                                String action = "equipItem:" + charictors[activeCharictorArrayId].getCharictorDBID() + ":" + item.ID + ":" + itemHold.ID + ":";
                                connection.Action(action);
                            }
                            break;
                    }
                    break;
                case charictorType.barbarian:
                    switch (slot)
                    {
                        case 0:
                            if (item.type == ItemType.platehead) {
                                Item itemHold = charictors[activeCharictorArrayId].getArmor(slot);
                                charictors[activeCharictorArrayId].setArmor(item, slot);
                                charictors[activeCharictorArrayId].setInventory(itemHold, fromSlot);
                                String action = "equipItem:" + charictors[activeCharictorArrayId].getCharictorDBID() + ":" + item.ID + ":" + itemHold.ID + ":";
                                connection.Action(action);
                            }
                            break;
                        case 1:
                            if (item.type == ItemType.platecheast) {
                                Item itemHold = charictors[activeCharictorArrayId].getArmor(slot);
                                charictors[activeCharictorArrayId].setArmor(item, slot);
                                charictors[activeCharictorArrayId].setInventory(itemHold, fromSlot);
                                String action = "equipItem:" + charictors[activeCharictorArrayId].getCharictorDBID() + ":" + item.ID + ":" + itemHold.ID + ":";
                                connection.Action(action);
                            }
                            break;
                        case 2:
                            if (item.type == ItemType.platehands) {
                                Item itemHold = charictors[activeCharictorArrayId].getArmor(slot);
                                charictors[activeCharictorArrayId].setArmor(item, slot);
                                charictors[activeCharictorArrayId].setInventory(itemHold, fromSlot); 
                                String action = "equipItem:" + charictors[activeCharictorArrayId].getCharictorDBID() + ":" + item.ID + ":" + itemHold.ID + ":";
                                connection.Action(action);
                            }
                            break;
                        case 3:
                            if (item.type == ItemType.platelegs) {
                                Item itemHold = charictors[activeCharictorArrayId].getArmor(slot);
                                charictors[activeCharictorArrayId].setArmor(item, slot);
                                charictors[activeCharictorArrayId].setInventory(itemHold, fromSlot);
                                String action = "equipItem:" + charictors[activeCharictorArrayId].getCharictorDBID() + ":" + item.ID + ":" + itemHold.ID + ":";
                                connection.Action(action);
                            }
                            break;
                        case 4:
                            if (item.type == ItemType.platefeet) {
                                Item itemHold = charictors[activeCharictorArrayId].getArmor(slot);
                                charictors[activeCharictorArrayId].setArmor(item, slot);
                                charictors[activeCharictorArrayId].setInventory(itemHold, fromSlot);
                                String action = "equipItem:" + charictors[activeCharictorArrayId].getCharictorDBID() + ":" + item.ID + ":" + itemHold.ID + ":";
                                connection.Action(action);
                            }
                            break;
                    }
                    break;
                case charictorType.rouge:
                    switch (slot)
                    {
                        case 0:
                            if (item.type == ItemType.leatherhead) {
                                Item itemHold = charictors[activeCharictorArrayId].getArmor(slot);
                                charictors[activeCharictorArrayId].setArmor(item, slot);
                                charictors[activeCharictorArrayId].setInventory(itemHold, fromSlot);
                                String action = "equipItem:" + charictors[activeCharictorArrayId].getCharictorDBID() + ":" + item.ID + ":" + itemHold.ID + ":";
                                connection.Action(action);
                            }
                            break;
                        case 1:
                            if (item.type == ItemType.leathercheast) {
                                Item itemHold = charictors[activeCharictorArrayId].getArmor(slot);
                                charictors[activeCharictorArrayId].setArmor(item, slot);
                                charictors[activeCharictorArrayId].setInventory(itemHold, fromSlot);
                                String action = "equipItem:" + charictors[activeCharictorArrayId].getCharictorDBID() + ":" + item.ID + ":" + itemHold.ID + ":";
                                connection.Action(action);
                            }
                            break;
                        case 2:
                            if (item.type == ItemType.leatherhands) {
                                Item itemHold = charictors[activeCharictorArrayId].getArmor(slot);
                                charictors[activeCharictorArrayId].setArmor(item, slot);
                                charictors[activeCharictorArrayId].setInventory(itemHold, fromSlot);
                                String action = "equipItem:" + charictors[activeCharictorArrayId].getCharictorDBID() + ":" + item.ID + ":" + itemHold.ID + ":";
                                connection.Action(action);
                            }
                            break;
                        case 3:
                            if (item.type == ItemType.leatherlegs) {
                                Item itemHold = charictors[activeCharictorArrayId].getArmor(slot);
                                charictors[activeCharictorArrayId].setArmor(item, slot);
                                charictors[activeCharictorArrayId].setInventory(itemHold, fromSlot);
                                String action = "equipItem:" + charictors[activeCharictorArrayId].getCharictorDBID() + ":" + item.ID + ":" + itemHold.ID + ":";
                                connection.Action(action);
                            }
                            break;
                        case 4:
                            if (item.type == ItemType.leatherfeet) {
                                Item itemHold = charictors[activeCharictorArrayId].getArmor(slot);
                                charictors[activeCharictorArrayId].setArmor(item, slot);
                                charictors[activeCharictorArrayId].setInventory(itemHold, fromSlot);
                                String action = "equipItem:" + charictors[activeCharictorArrayId].getCharictorDBID() + ":" + item.ID + ":" + itemHold.ID + ":";
                                connection.Action(action);
                            }
                            break;
                    }
                    break;
                case charictorType.wizard:
                    switch (slot)
                    {
                        case 0:
                            if (item.type == ItemType.clothhead) {
                                Item itemHold = charictors[activeCharictorArrayId].getArmor(slot);
                                charictors[activeCharictorArrayId].setArmor(item, slot);
                                charictors[activeCharictorArrayId].setInventory(itemHold, fromSlot);
                                String action = "equipItem:" + charictors[activeCharictorArrayId].getCharictorDBID() + ":" + item.ID + ":" + itemHold.ID + ":";
                                connection.Action(action);
                            }
                            break;
                        case 1:
                            if (item.type == ItemType.clothcheast) {
                                Item itemHold = charictors[activeCharictorArrayId].getArmor(slot);
                                charictors[activeCharictorArrayId].setArmor(item, slot);
                                charictors[activeCharictorArrayId].setInventory(itemHold, fromSlot);
                                String action = "equipItem:" + charictors[activeCharictorArrayId].getCharictorDBID() + ":" + item.ID + ":" + itemHold.ID + ":";
                                connection.Action(action);
                            }
                            break;
                        case 2:
                            if (item.type == ItemType.clothhands) {
                                Item itemHold = charictors[activeCharictorArrayId].getArmor(slot);
                                charictors[activeCharictorArrayId].setArmor(item, slot);
                                charictors[activeCharictorArrayId].setInventory(itemHold, fromSlot);
                                String action = "equipItem:" + charictors[activeCharictorArrayId].getCharictorDBID() + ":" + item.ID + ":" + itemHold.ID + ":";
                                connection.Action(action);
                            }
                            break;
                        case 3:
                            if (item.type == ItemType.clothlegs) {
                                Item itemHold = charictors[activeCharictorArrayId].getArmor(slot);
                                charictors[activeCharictorArrayId].setArmor(item, slot);
                                charictors[activeCharictorArrayId].setInventory(itemHold, fromSlot);
                                String action = "equipItem:" + charictors[activeCharictorArrayId].getCharictorDBID() + ":" + item.ID + ":" + itemHold.ID + ":";
                                connection.Action(action);
                            }
                            break;
                        case 4:
                            if (item.type == ItemType.clothfeet) {
                                Item itemHold = charictors[activeCharictorArrayId].getArmor(slot);
                                charictors[activeCharictorArrayId].setArmor(item, slot);
                                charictors[activeCharictorArrayId].setInventory(itemHold, fromSlot);
                                String action = "equipItem:" + charictors[activeCharictorArrayId].getCharictorDBID() + ":" + item.ID + ":" + itemHold.ID + ":";
                                connection.Action(action);
                            }
                            break;
                    }
                    break;
            }*/
            
        }





        internal void updateServerFight(int ID, int HP, int fightMemberNumber)
        {
            Vector2 eventposition = charictors[activeCharictorArrayId].GetPosition();
            String serverUpdate = "UpdtaeServerEvent:" + connection.usernumber + ":" + eventposition.X + ":" + eventposition.Y + ":" + ID + ":" + HP + ":" + fightMemberNumber + ":";
            connection.Action(serverUpdate);
        }
        internal void fetchUpdate()
        {
            Vector2 eventposition = charictors[activeCharictorArrayId].GetPosition();
            String serverUpdate = "fetchUpdtaeServerEvent:" + connection.usernumber + ":" + eventposition.X + ":" + eventposition.Y + ":";
            connection.Action(serverUpdate);
        }
        internal void updateEvent(string responce)
        {
            eventScreen.UpdateData(responce);
        }
        internal void jointEvent()
        {
            Vector2 eventposition = charictors[activeCharictorArrayId].GetPosition();
            String serverUpdate = "joinEvent:" + connection.usernumber + ":" + eventposition.X + ":" + eventposition.Y + ":";
            connection.Action(serverUpdate);
        }

        internal void fetchCurrentFighter()
        {
            Vector2 eventposition = charictors[activeCharictorArrayId].GetPosition();
            String serverUpdate = "fetchCurrentFighter:" + connection.usernumber + ":" + eventposition.X + ":" + eventposition.Y + ":";
            connection.Action(serverUpdate);
        }

        internal void jointEventresponce(string responce)
        {
            eventScreen.fightMemberNumber = int.Parse(responce);
        }

        internal void fetchCurrentFighteresponce(string responce)
        {
            eventScreen.currentFightmember = int.Parse(responce);
        }
    }
}
