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
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System.Runtime.Serialization.Formatters.Binary;

namespace level_builder
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        
        Map map;
        TileSet tileSet;

        Texture2D background;
        Texture2D tile;
        KeyboardState ks;
        MouseState ms;

        KeyboardState lks;
        MouseState lms;

        public Game1()
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
            map = new Map();
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

            if ((ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Down)) ) {
                if (map.getyShift() < map.mapsize - 36)
                {
                    map.yShiftincrees(1);
                }
            }
            if ((ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Up)) ) {
                if (map.getyShift() > 0)
                {
                    map.yShiftincrees(-1);
                }
            }
            if ((ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Left)) ) {
                if (map.getxShift() > 0)
                {
                    map.xShiftincrees(-1);
                }
            }
            if ((ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Right))) {
                if (map.getxShift() < map.mapsize - 55)
                {
                    map.xShiftincrees(1); 
                }
            }

            if((ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.LeftControl)) && (ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.S))){
                Console.Out.WriteLine("save me ");
                saveMap();
            }

            if ((ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.RightControl)) && (ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.L)))
            {
                Console.Out.WriteLine("load me ");
                loadMap();
            }


            if ((ms.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed)) {
                click(ms.X);  
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
            spriteBatch.Draw(background, Vector2.Zero, Color.White);
            map.Draw(gameTime, spriteBatch, tile);
            tileSet.Draw(gameTime, spriteBatch);
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

            FileInfo fi = new FileInfo(directory);
            if (!fi.Directory.Exists)
            {
                System.IO.Directory.CreateDirectory(fi.DirectoryName);
            } 

            Stream stream = File.Open(directory+fileName+extention, FileMode.Create);
            BinaryFormatter bformatter = new BinaryFormatter();

            Console.WriteLine("Writing map data");
            bformatter.Serialize(stream, map);
            stream.Close();
            Console.WriteLine("Complete ");
        }

        public void loadMap() {

            var directory = "maps/";
            var fileName = "alone in the dark";
            var extention = ".map";


            //Open the file written above and read values from it.
            Stream stream = File.Open(directory + fileName + extention, FileMode.Open);
            BinaryFormatter bformatter = new BinaryFormatter();

            Console.WriteLine("Reading map data");
            map = (Map)bformatter.Deserialize(stream);
            stream.Close();
            Console.WriteLine("Complete");
        
        }




    }
}
