using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace game
{
    class RunningGame
    {
        Texture2D background;
        Texture2D blackTile;

        Texture2D XPBar;

        Vector2 xpBarPos = new Vector2(0, 560);


        Texture2D archerSpriteSheet;
        Texture2D barbarianSpriteSheet;
        Texture2D wizardSpriteSheet;
        Texture2D rougeSpriteSheet;

        SpriteFont font;

        ChatWindow chatbox;

        GraphicsDevice GD;

        Charictor player;

        List<Charictor> otherplayers = new List<Charictor>();

        Map map;

        Rectangle chatwindow = new Rectangle(300,600,400,100);
        Rectangle typeBox = new Rectangle(300,700,400,20);

        public bool wait = false;
        private Game game;

        public RunningGame(Game game,GraphicsDevice GD)
        {
            this.game = game;
            this.GD = GD;
        }

        public void load(Texture2D background, SpriteFont font, Texture2D blackTile, Texture2D archerSpriteSheet, Texture2D barbarianSpriteSheet, Texture2D wizardSpriteSheet, Texture2D rougeSpriteSheet)
        {
            this.background = background;
            this.blackTile = blackTile;
            this.font = font;

            this.archerSpriteSheet = archerSpriteSheet;
            this.barbarianSpriteSheet = barbarianSpriteSheet;
            this.wizardSpriteSheet = wizardSpriteSheet;
            this.rougeSpriteSheet = rougeSpriteSheet;
            
            chatbox = new ChatWindow(chatwindow, typeBox, font);
        }
        
        public void secondLoad(Map map, Charictor charictor) {
            this.map = map;
            player = charictor;
            switch (player.GetcharType()) {

                case charictorType.archer: player.load(archerSpriteSheet); break;
                case charictorType.barbarian: player.load(barbarianSpriteSheet); break;
                case charictorType.rouge: player.load(rougeSpriteSheet); break;
                case charictorType.wizard: player.load(wizardSpriteSheet); break;
            }
            mapXPBar();
        }
        
        public String update() {

            KeyboardState ks = Keyboard.GetState();
            if ((ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Z)))
            {
                addXp(100);
            }
            if ((ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Down)))
            {
                player.modifyYPosition(1);

                if ((!walkableBoundsBox()) || (!map.getTile((int)player.GetPosition().X, (int)player.GetPosition().Y).walkable))
                {
                    player.modifyYPosition(-1);
                }
                else
                {
                    scrollMap(1);
                }
                return "action";
            }
            if ((ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Up)))
            {
                player.modifyYPosition(-1);

                if ((!walkableBoundsBox()) || (!map.getTile((int)player.GetPosition().X, (int)player.GetPosition().Y).walkable))
                {
                    player.modifyYPosition(1);
                }
                else
                {
                    scrollMap(2);
                }
                return "action";
            }
            if ((ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Left)))
            {
                player.modifyXPosition(-1);

                if ((!walkableBoundsBox()) || (!map.getTile((int)player.GetPosition().X, (int)player.GetPosition().Y).walkable))
                {
                    player.modifyXPosition(1);
                }
                else
                {
                    scrollMap(4);
                }
                return "action";
            }

            if ((ks.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Right)))
            {
                player.modifyXPosition(1);
                if ((!walkableBoundsBox()) || (!map.getTile((int)player.GetPosition().X, (int)player.GetPosition().Y).walkable))
                {
                    player.modifyXPosition(-1);
                }
                else
                {
                    scrollMap(3);
                }
                return "action";
            }

            if (map.getTile((int)player.GetPosition().X, (int)player.GetPosition().Y).getType() == tileTypes.Talk) {
                map.getTile((int)player.GetPosition().X, (int)player.GetPosition().Y).setType(0);
                map.setTile((int)player.GetPosition().X, (int)player.GetPosition().Y,0);
                return "talk";
            }



            String s = chatbox.update();
            return s;
        }

        public void Draw(SpriteBatch sp){
            sp.Draw(background, Vector2.Zero, Color.White);
            sp.Draw(XPBar, xpBarPos, Color.White);
            map.Draw(sp,blackTile);
            Vector2 offset = new Vector2(map.getxShift(), map.getyShift());
            foreach (Charictor c in otherplayers) {
                sp.Draw(rougeSpriteSheet, c.GetDrawPosition()-offset*40, Color.Blue);
            }
            player.Draw(sp, offset);
            sp.DrawString(font, "Strength:" + player.getTotalStrength(), new Vector2(0, 575), Color.White);
            sp.DrawString(font, "interlect:" + player.getTotalInterlect(), new Vector2(0, 590), Color.White);
            sp.DrawString(font, "dexterity:" + player.getTotalDexterity(), new Vector2(0, 605), Color.White);
            sp.DrawString(font, "health:" + player.getTotalHealth(), new Vector2(0, 620), Color.White);
            sp.DrawString(font, "mana:" + player.getTotalMana(), new Vector2(0, 635), Color.White);
            sp.DrawString(font, "armor:" + player.getTotalArmor(), new Vector2(0, 650), Color.White);
            sp.DrawString(font, "melee damage:" + player.getTotalMeleeDamage(), new Vector2(720, 575), Color.White);
            sp.DrawString(font, "spell damage:" + player.getTotalSpellDamage(), new Vector2(720, 590), Color.White);
            sp.DrawString(font, "dodge change:" + player.getTotalDodge(), new Vector2(720, 605), Color.White);
            sp.DrawString(font, "damage reduction:" + player.getTotalDamageReduction(), new Vector2(720, 620), Color.White);
            sp.DrawString(font, "level:" + player.getLevel(), new Vector2(720, 635), Color.White);

            // 0-head 1-cheast 2-hands 3-legs 4-feet 5-leftwep 6-rightwep
            if (player.armor[0] != null)
            {
                sp.DrawString(font, player.armor[0].DBID.ToString(), new Vector2(1155, 36), Color.White);
            }
            if (player.armor[1] != null)
            {
                sp.DrawString(font, player.armor[1].DBID.ToString(), new Vector2(1155, 77), Color.White);
            }
            if (player.armor[3] != null)
            {
                sp.DrawString(font, player.armor[3].DBID.ToString(), new Vector2(1155,100), Color.White);
            }
            if (player.armor[4] != null)
            {
                sp.DrawString(font, player.armor[4].DBID.ToString(), new Vector2(1155,126), Color.White);
            }
            if (player.armor[2] != null)
            {
                sp.DrawString(font, player.armor[2].DBID.ToString(), new Vector2(1130,77), Color.White);
            }
            if (player.armor[6] != null)
            {
                sp.DrawString(font, player.armor[6].DBID.ToString(), new Vector2(1168,100), Color.White);
            }
            if (player.armor[5] != null)
            {
                sp.DrawString(font, player.armor[5].DBID.ToString(), new Vector2(1130,77), Color.White);
            }

            for (int i = 0; i < player.inventory.Count; i++) {
                if (player.inventory[i] != null) {
                    sp.DrawString(font, player.inventory[i].name.ToString(), new Vector2(1100, 300+(i*10)), Color.White);
                }
            }

            chatbox.Draw(sp);
        }

        public Vector2 getPlayerPosition() {
            return player.GetPosition();
        }
        public List<Charictor> getOtherPlayer(){
            return otherplayers;
        }
        public void setOtherPlayer(List<Charictor> c) {
            otherplayers.Clear();
            otherplayers = c;
        }
        internal void addOtherPlayer(Charictor c){
            c.load(archerSpriteSheet);
            otherplayers.Add(c);
            Console.Out.WriteLine("current other players:"+otherplayers.Count);
        }
        internal void updateotherplayer(int i,Vector2 v){
            otherplayers[i].setPosition(v);
        }
        internal void newMessage(string message){
            chatbox.newMessage(message);
        }
        internal String getPlayerName(){
            return player.GetName();
        }
        private bool walkableBoundsBox() {
            if ((player.GetPosition().X < 0)||(player.GetPosition().X >=map.mapsize)||(player.GetPosition().Y < 0) || (player.GetPosition().Y >= map.mapsize)) {
                return false;   
            }
            return true;
        }
        private void scrollMap(int direction) {
            Vector2 playerv = player.GetPosition();
            Vector2 offset = new Vector2(map.getxShift(), map.getyShift());

            Vector2 diference = playerv - offset;

            int limit = 5;
            int veiwScreenWidth = 27;
            int veiwScreenHight = 14;

            if (direction == 2)//up
            {
                if (map.getyShift() > 0)//is it posible to move in this direction
                {
                    if (diference.Y < limit)// is player in the move area
                    {
                        map.yShiftincrees(-1);
                    }
                }
            }
            if (direction == 1)//down
            {
                if (map.getyShift() < map.mapsize - veiwScreenHight)//is it posible to move in this direction
                {
                    if ((diference.Y >= veiwScreenHight - limit))// is player in the move area
                    {
                        map.yShiftincrees(1);
                    }
                }
            }
            if (direction == 4)//left
            {
                if (map.getxShift() > 0)//is it posible to move in this direction
                {
                    if (diference.X < limit)// is player in the move area
                    {
                        map.xShiftincrees(-1);
                    }
                }
            }
            if (direction == 3)//right
            {
                if (map.getxShift() <  map.mapsize - veiwScreenWidth)//is it posible to move in this direction
                {
                    if ((diference.X >= veiwScreenWidth - limit))// is player in the move area
                    {
                        map.xShiftincrees(1);
                    }
                }
            }

        }
        internal void addXp(int XP) {
            game.updateCharictorXpOnServer(XP);
            mapXPBar();
        }
        private void mapXPBar() {
            //recalculate grafic
            Color[] texdata = new Color[10800];
            Rectangle r = new Rectangle(0, 0, 1080, 10);
            int level = player.getLevel();
            int xpMax = game.levelsXP.fetchDing(level);
            int XPMin = game.levelsXP.fetchDing(level - 1);
            int currentXP = player.getCurrentXp();

            double drawMin = (currentXP - XPMin);
            double drawMax = (xpMax - XPMin);

            double persentage = drawMin / drawMax;

            int fillLine = (int) (persentage * 1080);

            for (int i = 0; i < 1080; i++)
            {

                if (i > fillLine)
                {
                    texdata[i] = Color.DarkGreen;
                    texdata[i + (1080 * 2)] = Color.DarkGreen;
                    texdata[i + (1080 * 3)] = Color.DarkGreen;
                    texdata[i + (1080 * 4)] = Color.DarkGreen;
                    texdata[i + (1080 * 5)] = Color.DarkGreen;
                    texdata[i + (1080 * 6)] = Color.DarkGreen;
                    texdata[i + (1080 * 7)] = Color.DarkGreen;
                    texdata[i + (1080 * 8)] = Color.DarkGreen;
                    texdata[i + (1080 * 9)] = Color.DarkGreen;
                }
                else
                {
                    texdata[i] = Color.Green;
                    texdata[i + (1080 * 2)] = Color.Green;
                    texdata[i + (1080 * 3)] = Color.Green;
                    texdata[i + (1080 * 4)] = Color.Green;
                    texdata[i + (1080 * 5)] = Color.Green;
                    texdata[i + (1080 * 6)] = Color.Green;
                    texdata[i + (1080 * 7)] = Color.Green;
                    texdata[i + (1080 * 8)] = Color.Green;
                    texdata[i + (1080 * 9)] = Color.Green;
                }
            }
            XPBar = new Texture2D(GD ,1080,10);
            XPBar.SetData<Color>(0, r, texdata, 0, 10800);
        
        }
    }
}
