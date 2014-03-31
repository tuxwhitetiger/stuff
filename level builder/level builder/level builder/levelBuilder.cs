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
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace level_builder
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class levelBuilder : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        
        Map map;
        TileSet tileSet;

        Texture2D background;
        Texture2D eventCreateBackground;
        Texture2D tile;
        KeyboardState ks;
        MouseState ms;

        KeyboardState lks;
        MouseState lms;

        //event creater
        int serlectedfield=0;
        GameKeyboard gk = new GameKeyboard();
        SpriteFont font;
        public int serlectedEvent =0;

        public levelBuilder()
        {
            
            graphics = new GraphicsDeviceManager(this);
            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferHeight = 720;
            graphics.PreferredBackBufferWidth = 1280;
            Content.RootDirectory = "Content";
            this.IsMouseVisible = true;
            
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
            map = new Map(this);
            tileSet = new TileSet();
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
            tile = Content.Load<Texture2D>("blank-tile");
            tileSet.loadtile(Content.Load<Texture2D>("blank-tile"));
            background = Content.Load<Texture2D>("blank-build-page");
            eventCreateBackground = Content.Load<Texture2D>("event-create-page");
            map.load(Content.Load<SpriteFont>("logInText"));
            font = Content.Load<SpriteFont>("logInText");

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            ks = Keyboard.GetState();
            ms = Mouse.GetState();

            if (map.newevent)
            {
                //mouse listener
                if (ms.LeftButton == ButtonState.Pressed) { 
                    //done button
                    if((ms.X>536)&&(ms.X<629)&&(ms.Y>654)&&(ms.Y<704)){
                        map.newevent = false;
                    }else
                    //add charictor
                    if ((ms.X > 65) && (ms.X < 237) && (ms.Y > 654) && (ms.Y < 704))
                    {
                        map.events[serlectedEvent].addCarictor("default", 0, 0, 0);
                    }else
                    //serlect name
                    if ((ms.X > 448) && (ms.X < 749) && (ms.Y > 196) && (ms.Y < 234))
                    {
                        serlectedfield=1;
                    }else
                    //serlect HP
                    if ((ms.X > 449) && (ms.X < 749) && (ms.Y > 304) && (ms.Y < 343))
                    {
                        serlectedfield=2;
                    }else
                    //serlect attcktpye
                    if ((ms.X > 451) && (ms.X < 749) && (ms.Y >424 ) && (ms.Y < 461))
                    {
                        serlectedfield=3;
                    }else
                    //serlectedfield attack power
                    if ((ms.X > 449) && (ms.X < 750) && (ms.Y > 540) && (ms.Y < 578))
                    {
                        serlectedfield=4;
                    }else
                    //serlect conversation
                    if ((ms.X > 873) && (ms.X < 1239) && (ms.Y > 578) && (ms.Y <617 ))
                    {
                        serlectedfield = 5;
                    }else{
                        serlectedfield = 0;
                    }
                }
                //keyboard listner
                //cheak that charictors !=0
                String s = gk.getKeysPressd();
                
                if(serlectedfield!=0){
                    if (s.Equals("back"))
                    {
                        Event e = map.events[serlectedEvent];
                        charictor c = e.getCharictor();
                        if (serlectedfield == 1)
                        {
                            c.backName();
                        }
                        if (serlectedfield == 2)
                        {
                            c.backHP();
                        }
                        if (serlectedfield == 3)
                        {
                            c.backAttackType();
                        }
                        if (serlectedfield == 4)
                        {
                            c.backAttackPower();
                        }
                        if (serlectedfield == 5)
                        {
                            c.backConvo();
                        }
                    }else if (s.Equals("enter"))
                    {
                        Event e = map.events[serlectedEvent];
                        charictor c = e.getCharictor();
                        if (serlectedfield == 5)
                        {
                            c.dumpToConvo();
                            e.addTalk(s);
                        }
                    }
                    else if (s.Equals("tab"))
                    {
                    }
                    else if (s.Equals("null"))
                    {
                    }
                    else 
                    {
                        Event e = map.events[serlectedEvent];
                        charictor c = e.getCharictor();
                        if(serlectedfield==1){
                            c.appendName(s);
                        }
                        if(serlectedfield==2){
                            c.appendHP(s);
                        }
                        if(serlectedfield==3){
                            c.appendAttackType(s);
                        }
                        if(serlectedfield==4){
                            c.appendAttackPower(s);   
                        }
                        if(serlectedfield==5){
                            c.addConvo(s);
                        }
                    }
                }

                if (gk.getUp())
                {
                    map.events[serlectedEvent].charictorSelectUp();
                }
                if (gk.getDown())
                {
                    map.events[serlectedEvent].charictorSelectDown();
                }



            }
            else
            {
                if ((ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Down)))
                {
                    if (map.getyShift() < map.mapsize - 36)
                    {
                        map.yShiftincrees(1);
                    }
                }
                if ((ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Up)))
                {
                    if (map.getyShift() > 0)
                    {
                        map.yShiftincrees(-1);
                    }
                }
                if ((ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Left)))
                {
                    if (map.getxShift() > 0)
                    {
                        map.xShiftincrees(-1);
                    }
                }
                if ((ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Right)))
                {
                    if (map.getxShift() < map.mapsize - 55)
                    {
                        map.xShiftincrees(1);
                    }
                }

                if ((ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.LeftControl)) && (ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.S)))
                {
                    Console.Out.WriteLine("save me ");
                    saveMap();
                }

                if ((ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.RightControl)) && (ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.L)))
                {
                    Console.Out.WriteLine("load me ");
                    loadMap();
                }


                if ((ms.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed))
                {
                    click(ms.X);
                }
                if ((ms.RightButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed))
                {
                    int x = ms.X/20;
                    int y = ms.Y/20;

                    foreach (Event e  in map.events){
                        if((e.getPosition().X==x)&&(e.getPosition().Y ==y)){
                            //open up the event at this location
                            map.newevent = true;
                            serlectedEvent = map.events.IndexOf(e);
                        }
                    }
                }
            }
            lks = ks;
            lms = ms;
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
            if (map.newevent)
            {
                spriteBatch.Draw(eventCreateBackground, Vector2.Zero, Color.White);
                map.events.Last().Draw(spriteBatch);

            }
            else
            {
                spriteBatch.Draw(background, Vector2.Zero, Color.White);
                map.Draw(gameTime, spriteBatch, tile);
                tileSet.Draw(gameTime, spriteBatch);
            }
            spriteBatch.End();
            
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        private void click(int x) { 
            //if x is < 1100 then map area elce controll pannel
            if (x < 1100)
            {

                map.click(tileSet.GetselectedTileSet());
            }
            else {
                tileSet.click();
            }
        }
        public void saveMap() {

            var directory = "maps/";
            var fileName = "alone in the dark";
            var extention = ".map";

            System.IO.File.WriteAllText(directory+fileName+extention, map.mapToServerData());
        }

        public void loadMap() {
            var directory = "maps/";
            var fileName = "alone in the dark";
            var extention = ".map";

            StringBuilder sb = new StringBuilder();
            using (StreamReader sr = new StreamReader(directory + fileName + extention))
            {
                String line;
                while ((line = sr.ReadLine()) != null)
                {
                    sb.AppendLine(line);
                }
            }
            map= new Map(sb.ToString(),font,this);

        }

    }
}
