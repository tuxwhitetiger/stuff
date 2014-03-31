using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace game
{
    class LobbyScreen
    {
        List<lobbyGame> games;

        Vector2 gamsesListv = new Vector2(48,48);
        Rectangle JoinGame = new Rectangle(825, 605, 250, 85);

        Texture2D background;

        SpriteFont font;

        String text = "lobby";

        MouseState lastState = Mouse.GetState();

        int serlectedGame = 0;

        public LobbyScreen() {

            games = new List<lobbyGame>();
        }

        public String update() {

            MouseState Mstate = Mouse.GetState();

            if (games.Count > 0) {
                StringBuilder sb = new StringBuilder();
                foreach (lobbyGame g in games) {

                    if (games[serlectedGame] == g)
                    {
                        sb.Append(">> ");
                        sb.Append("host:" + g.getHostID() + "-");
                        String s = g.getDiscription();
                        if (s.Length > 30)
                        {
                            sb.Append(g.getDiscription().Substring(0, 30) + "-");
                        }
                        else {
                            sb.Append(g.getDiscription() + "-");
                        }
                        
                        sb.Append(g.getpopulation());
                        sb.Append(" <<");
                        sb.Append("\n");
                    }
                    else
                    {
                        sb.Append("host:" + g.getHostID() + "-");
                        String s = g.getDiscription();
                        if (s.Length > 30)
                        {
                            sb.Append(g.getDiscription().Substring(0, 30) + "-");
                        }
                        else
                        {
                            sb.Append(g.getDiscription() + "-");
                        }
                        sb.Append(g.getpopulation());
                        sb.Append("\n");
                    }
                }
                text = sb.ToString();
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Enter) || (new Rectangle(Mstate.X, Mstate.Y,1,1).Intersects(JoinGame) && Mstate.LeftButton == ButtonState.Released && lastState.LeftButton == ButtonState.Pressed))
            {
                return "join:" + games[serlectedGame].getHostID() + ":" + games[serlectedGame].getDiscription();
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                if (serlectedGame > 0)
                {
                    serlectedGame--;
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                if (serlectedGame < games.Count-1)
                {
                    serlectedGame++;
                }
            }
            lastState = Mstate;
            return "null";
        }

        public void Draw(SpriteBatch sp) {
            sp.Draw(background, Vector2.Zero, Color.White);
            sp.DrawString(font, text, gamsesListv, Color.White);
        }

        public void Load(Texture2D background, SpriteFont font)
        {
            this.background = background;
            this.font = font;
        }


        public void getGames(String gamesList) {

            games.Clear();
            if (!gamesList.Equals("null"))
            {
                String[] ListOfGames = gamesList.Split(':');
                foreach (String game in ListOfGames)
                {
                    String[] gameData = game.Split(';');
                    if (gameData.Length >1)
                    {
                        lobbyGame g = new lobbyGame(
                            int.Parse(gameData[0]),
                            gameData[1],
                            int.Parse(gameData[2]),
                            int.Parse(gameData[3])
                            );
                        games.Add(g);
                    }
                }
            }
        }



    }
}
