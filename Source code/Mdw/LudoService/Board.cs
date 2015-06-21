using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LudoService
{
    class Board
    {
        //Fields
        private List<Square> squares = new List<Square>(92);
        private List<Token> tokens = new List<Token>();


        //Properties
        public List<Square> Squares
        {
            get { return squares; }
            set { squares = value; }
        }

        public List<Token> Tokens
        {
            get { return tokens; }
            set { tokens = value; }
        }


        //Constructor
        public Board()
        {
            this.InitializeBoard();

            //this.CreateToken(players);

        }

        //Methods
        public void MoveToken(Token token, Square square)
        {

        }

        public void InitializeBoard()
        {
            for (int i = 0; i < 92; i++)
            {
                this.squares.Add(new Square(i, Color.White, false, false));
                this.Squares[i].Name = "field" + (i + 1).ToString();
            }

            this.Squares[52].Name = "startRed";
            this.Squares[53].Name = "startGreen";
            this.Squares[54].Name = "startYellow";
            this.Squares[55].Name = "startBlue";

            //Home squares
            for (int i = 56; i <= 60; i++)
            {
                this.Squares[i].Name = "homeYellow" + (i - 55).ToString();
                this.Squares[i].Color = Color.Yellow;
            }

            for (int i = 61; i <= 65; i++)
            {
                this.Squares[i].Name = "homeGreen" + (i - 60).ToString();
                this.Squares[i].Color = Color.Green;
            }

            for (int i = 66; i <= 70; i++)
            {
                this.Squares[i].Name = "homeBlue" + (i - 65).ToString();
                this.Squares[i].Color = Color.Blue;
            }

            for (int i = 71; i <= 75; i++)
            {
                this.Squares[i].Name = "homeRed" + (i - 70).ToString();
                this.Squares[i].Color = Color.Red;
            }

            for (int i = 76; i <= 79; i++)
            {
                this.Squares[i].Name = "goalYellow" + (i - 75).ToString();
                this.Squares[i].Color = Color.Yellow;
                this.Squares[i].IsEnd = true;
            }

            for (int i = 80; i <= 83; i++)
            {
                this.Squares[i].Name = "goalGreen" + (i - 79).ToString();
                this.Squares[i].Color = Color.Green;
                this.Squares[i].IsEnd = true;
            }

            for (int i = 84; i <= 87; i++)
            {
                this.Squares[i].Name = "goalBlue" + (i - 83).ToString();
                this.Squares[i].Color = Color.Blue;
                this.Squares[i].IsEnd = true;
            }

            for (int i = 88; i <= 91; i++)
            {
                this.Squares[i].Name = "goalRed" + (i - 87).ToString();
                this.Squares[i].Color = Color.Red;
                this.Squares[i].IsEnd = true;
            }

        }

        public void CreateToken(List<Player> players)
        {
            foreach (Player p in players)
            {
                for (int i = 0; i < 4; i++)
                {
                    Token t = new Token(p.Color);
                    tokens.Add(t);
                }
            }
        }

        public List<Square> GetPath(Color color)
        {
            List<Square> tmp = new List<Square>();

            switch (color.ToString())
            {
                case "Color [Red]":
                    tmp.Add(Squares[52]);
                    for (int i = 0; i <= 12; i++)
                    {
                        tmp.Add(Squares[i]);
                    }
                    tmp.Add(Squares[53]);
                    for (int i = 13; i <= 25; i++)
                    {
                        tmp.Add(Squares[i]);
                    }
                    tmp.Add(Squares[54]);
                    for (int i = 26; i <= 38; i++)
                    {
                        tmp.Add(Squares[i]);
                    }
                    tmp.Add(Squares[55]);
                    for (int i = 39; i <= 51; i++)
                    {
                        tmp.Add(Squares[i]);
                    }

                    for (int i = 71; i <= 75; i++)
                    {
                        tmp.Add(Squares[i]);
                    }
                    return tmp;
                case "Color [Blue]":
                    tmp.Add(Squares[55]);
                    for (int i = 39; i <= 51; i++)
                    {
                        tmp.Add(Squares[i]);
                    }
                    tmp.Add(Squares[52]);
                    for (int i = 0; i <= 12; i++)
                    {
                        tmp.Add(Squares[i]);
                    }
                    tmp.Add(Squares[53]);
                    for (int i = 13; i <= 25; i++)
                    {
                        tmp.Add(Squares[i]);
                    }
                    tmp.Add(Squares[54]);
                    for (int i = 26; i <= 38; i++)
                    {
                        tmp.Add(Squares[i]);
                    }

                    for (int i = 66; i <= 70; i++)
                    {
                        tmp.Add(Squares[i]);
                    }
                    return tmp;
                case "Color [Yellow]":
                    tmp.Add(Squares[54]);
                    for (int i = 26; i <= 38; i++)
                    {
                        tmp.Add(Squares[i]);
                    }
                    tmp.Add(Squares[55]);
                    for (int i = 39; i <= 51; i++)
                    {
                        tmp.Add(Squares[i]);
                    }
                    tmp.Add(Squares[52]);
                    for (int i = 0; i <= 12; i++)
                    {
                        tmp.Add(Squares[i]);
                    }
                    tmp.Add(Squares[53]);
                    for (int i = 13; i <= 25; i++)
                    {
                        tmp.Add(Squares[i]);
                    }

                    for (int i = 76; i <= 79; i++)
                    {
                        tmp.Add(Squares[i]);
                    }
                    return tmp;
                case "Color [Green]":
                    tmp.Add(Squares[53]);
                    for (int i = 13; i <= 25; i++)
                    {
                        tmp.Add(Squares[i]);
                    }
                    tmp.Add(Squares[54]);
                    for (int i = 26; i <= 38; i++)
                    {
                        tmp.Add(Squares[i]);
                    }
                    tmp.Add(Squares[55]);
                    for (int i = 39; i <= 51; i++)
                    {
                        tmp.Add(Squares[i]);
                    }
                    tmp.Add(Squares[52]);
                    for (int i = 0; i <= 12; i++)
                    {
                        tmp.Add(Squares[i]);
                    }

                    for (int i = 61; i <= 65; i++)
                    {
                        tmp.Add(Squares[i]);
                    }

                    return tmp;

                default: return null;
            }
        }

    }
}
