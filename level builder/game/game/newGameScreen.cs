using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.Xna.Framework.Input;

namespace game
{
    class NewGameScreen
    {
        //where map serlection takes place before the chat room and game is made on the server 
        //this is the stepp that has been missing this happens after the lobby but before the wait room
        MapStore maps;
        String[] mapList;
        String toDrawMapList;
        String discription ="";

        Rectangle createGame = new Rectangle(825,605,250,85);


        SpriteFont font;
        Vector2 mapListposition = new Vector2(48, 48);
        Vector2 discriptionposition = new Vector2(45, 460);
        Texture2D background;
        int selectedMap = 0;

        GameKeyboard keyboard;


        public NewGameScreen() {
            maps = new MapStore();
            keyboard = new GameKeyboard();
            mapList = maps.getMapList();
            StringBuilder sb = new StringBuilder();
            foreach(String map in mapList){
                sb.Append(map + "\n");
            }
            toDrawMapList = sb.ToString();
        }

        public void Load(Texture2D background,SpriteFont font) {
            this.background = background;
            this.font = font;
        }
        

        public String update() {

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < mapList.Length; i++) {
                if (selectedMap == i)
                {
                    sb.Append(">>" + mapList[i] + "<<" + "\n");
                }
                else {
                    sb.Append(mapList[i] + "\n");
                }
            }
            toDrawMapList = sb.ToString();
            String input = keyboard.getKeysPressd();

            MouseState mState = Mouse.GetState();

            if (mState.LeftButton == ButtonState.Pressed && new Rectangle(mState.X, mState.Y, 1, 1).Intersects(createGame))
            {
                return newGame();
            }

            if (input != "null") {
                if (input.Equals("enter"))
                {
                    return newGame();
                }
                else if (input.Equals("back"))
                {
                    if (discription.Length > 0)
                    {
                        discription = discription.Substring(0, discription.Length - 1);
                    }
                }
                else if (input.Equals("tab"))
                {

                }
                else
                {
                    discription += input;
                }
            }
            

            if (keyboard.getUp()) {
                if (selectedMap > 0) {
                    selectedMap--;
                }
            }
            if (keyboard.getDown()) {
                if (selectedMap < mapList.Length - 1) {
                    selectedMap++;
                }
            }
            return "null";
        }

        public void Draw(SpriteBatch sp) {
            sp.Draw(background, Vector2.Zero, Color.White);
            sp.DrawString(font, toDrawMapList, mapListposition, Color.White);
            sp.DrawString(font, discription, discriptionposition, Color.White);
        }

        public String newGame(){
            String s = "newGame:" + discription + ":5:";
            return s;
        }
        public Map getMap() {
            return maps.getMap(mapList[selectedMap]);
        }
    }
}
