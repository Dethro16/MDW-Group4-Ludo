using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Drawing;

namespace LudoService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class CLudo : ILudo
    {
        DatabaseHelper db = new DatabaseHelper();

        int turn = 1;
        Color eat = Color.Black;

        public List<Player> players = new List<Player>();
        public List<Color> AllColors = new List<Color>{
            Color.Red,Color.Blue, Color.Green, Color.Yellow};


        Board board = new Board();


        ILudoCallback clientCallBack;

        Random rnd;
        public int diceNumber;

        public CLudo()
        {
            rnd = new Random();
        }

        public int GenerateRoll()
        {
            return rnd.Next(1, 7);
        }

        public void GetPlayerColor(string playername, Color color)
        {
            foreach (Player item in players)
            {
                if (item.PlayerName != playername)
                {
                    item.callback.OnPlayerLogin(playername, color);
                }
            }
        }

        public string GetPlayer(Color color)
        {
            foreach (Player item in players)
            {
                if (item.Color == color)
                {
                    return item.PlayerName;
                }
            }
            return "Empty";
        }

        public string RollToClient(string playername)
        {
            diceNumber = GenerateRoll();

            if (diceNumber == 6)
            {
                foreach (Player item in players)
                {
                    if (item.PlayerName == playername)
                    {
                        item.RolledSix = true;
                    }
                }
            }

            string s = "[" + DateTime.Now.ToString("HH:MM") + "] ~~~ <" + playername + "> rolled a " + diceNumber.ToString() + "!!! ~~~";
            return s;
        }

        public void Roll(string playername)
        {
            foreach (Player item in players)
            {
                if (item.PlayerName != playername)
                {
                    item.callback.OnRollCallback(playername, diceNumber);
                }
            }
        }


        public int NumberToClient()
        {
            return diceNumber;
        }

        public void CreatePlayers(string userName, Color color)
        {
            if (AllColors.Exists(x => x.Equals(color)))
            {
                Player player = new Player(userName, color);

                if (players.Count < 1)
                {
                    player.First = true;
                }

                player.ID = players.Count + 1;
                player.callback = OperationContext.Current.GetCallbackChannel<ILudoCallback>();
                AllColors.Remove(color);
                players.Add(player);
            }

            else
            {
                int index = rnd.Next(0, AllColors.Count);
                Player player = new Player(userName, AllColors.ElementAt(index));
                player.callback = OperationContext.Current.GetCallbackChannel<ILudoCallback>();
                players.Add(player);
                AllColors.Remove(AllColors.ElementAt(index));
            }
        }


        public void Chat(string playername, string message)
        {
            foreach (Player item in players)
            {
                if (item.PlayerName != playername)
                {
                    item.callback.OnChatCallback(playername, message);
                }
            }
        }

        public string ChatToClient(string playername, string message)
        {
            if (message != "")
            {
                string temp = "[" + DateTime.Now.ToString("HH:MM") + "] <" + playername + ">: " + message;
                return temp;
            }
            else return null;
        }

        public void Subscribe()
        {
            clientCallBack = OperationContext.Current.GetCallbackChannel<ILudoCallback>();
        }

        public void StartGame()
        {
            foreach (Player p in players)
            {
                if (p.ID == turn)
                {
                    p.callback.OnPlayerTurn();
                }
            }
        }

        public bool Check(string playerName)
        {
            foreach (Player p in players)
            {
                if (playerName == p.PlayerName)
                {
                    if (p.ID == turn)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void NextTurn()
        {
            if (turn == players.Count)
            {
                turn = 0;
            }

            turn++;
            foreach (Player p in players)
            {
                if (p.ID == turn)
                {
                    p.callback.OnPlayerTurn();
                }
            }
        }

        public string PutTokenInPlay(Color color, bool remove)
        {
            foreach (Player player in players)
            {
                if (player.Color == color)
                {
                    List<Square> path = board.GetPath(color);

                    Token tk = new Token(color);
                    tk.Path = path;
                    if (tk.Path[tk.Index].Token != null)
                    {
                        if (tk.Path[tk.Index].Token.Color != color)
                        {
                            eat = tk.Path[tk.Index].Token.Color;

                            foreach (Player pl in players)
                            {
                                if (pl.Color == color)
                                {
                                    pl.BaseTokens.Add(tk.Path[tk.Index].Token);
                                    
                                    tk.Path[tk.Index].Token = null;
                                }
                            }

                        }
                        else
                        {
                            eat = Color.Black;
                            return "error";
                        }
                    }
                    tk.Place = tk.Path[tk.Index];
                    path[0].Token = tk;

                    if (remove)
                    {
                        player.FieldTokens.Add(tk);
                        player.BaseTokens.RemoveAt(0);
                    }

                    switch (color.ToString())
                    {
                        case "Color [Red]":
                            return "startRed";
                        case "Color [Blue]":
                            return "startBlue";
                        case "Color [Green]":
                            return "startGreen";
                        case "Color [Yellow]":
                            return "startYellow";
                    }
                }
            }
            return "";
        }

        public void PlaceToken(string playername, string tokenname, Color color, string destination)
        {
            foreach (Player item in players)
            {
                if (item.PlayerName != playername)
                {
                    item.callback.OnPlaceToken(tokenname, color, destination);
                }
            }
        }

        public string MoveToken(string field, Color color)
        {
            eat = Color.Black;
            foreach (Square sq in board.GetPath(color))
            {
                if (sq.Name == field)
                {
                    int before = sq.Token.Index;
                    int check = sq.Token.Index + diceNumber;
                    if (sq.Token.Path[check].Token != null)
                    {
                        if (sq.Token.Path[check].Token.Color != color)
                        {
                            eat = sq.Token.Path[check].Token.Color;

                            foreach (Player pl in players)
                            {
                                if (pl.Color == color)
                                {
                                    pl.BaseTokens.Add(sq.Token.Path[check].Token);
                                    sq.Token.Path[check].Token = null;
                                }
                            }

                        }
                        else
                        {
                            eat = Color.Black;
                            return field;
                        }
                    }

                    foreach (Player p in players)
                    {
                        if (p.Color == color)
                        {
                            if (check > 60)
                            {
                                sq.Token.Index = p.TokenIn + 61;
                                p.TokenIn++;
                            }
                            else
                            {
                                sq.Token.Index = check;
                            }
                        }
                    }
                    sq.Token.Place = sq.Token.Path[sq.Token.Index];
                    sq.Token.Path[sq.Token.Index].Token = sq.Token;
                    string s = sq.Token.Path[sq.Token.Index].Name;
                    sq.Token.Path[before].Token = null;
                    return s;

                }
            }
            return field;
        }

        public void MoveToClient(string playername, string tokenname, Color color, string destination)
        {
            foreach (Player item in players)
            {
                if (item.PlayerName != playername)
                {
                    item.callback.OnMoveToken(tokenname, color, destination);
                }
            }
        }

        public void EatToClient(string playername, Color color)
        {
            foreach (Player item in players)
            {
                if (item.PlayerName != playername)
                {
                    item.callback.OnTokenEat(playername, color);
                }
            }
        }

        public Color GetReadyToEat()
        {
            return eat;
        }
    }
}
