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
        public Board(List<Player> players)
        {
            this.InitializeBoard();

            this.CreateToken(players);


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
            }

            for (int i = 76; i <= 79; i++)
            {
                this.Squares[i].Color = Color.Yellow;
                this.Squares[i].IsBase = true;
            }

            for (int i = 80; i <= 83; i++)
            {
                this.Squares[i].Color = Color.Green;
                this.Squares[i].IsBase = true;
            }

            for (int i = 84; i <= 87; i++)
            {
                this.Squares[i].Color = Color.Blue;
                this.Squares[i].IsBase = true;
            }

            for (int i = 88; i <= 91; i++)
            {
                this.Squares[i].Color = Color.Red;
                this.Squares[i].IsBase = true;
            }

            this.Squares[57].Color = Color.Yellow;
            this.Squares[57].IsEnd = true;

            this.Squares[63].Color = Color.Green;
            this.Squares[63].IsEnd = true;

            this.Squares[69].Color = Color.Blue;
            this.Squares[69].IsEnd = true;

            this.Squares[75].Color = Color.Red;
            this.Squares[75].IsEnd = true;

            this.Squares[3].Color = Color.Yellow;

            this.Squares[16].Color = Color.Green;

            this.Squares[29].Color = Color.Blue;

            this.Squares[42].Color = Color.Red;

            //Home squares
            for (int i = 52; i <= 56; i++)
            {
                this.Squares[i].Color = Color.Yellow;
            }

            for (int i = 58; i <= 62; i++)
            {
                this.Squares[i].Color = Color.Green;
            }

            for (int i = 64; i <= 68; i++)
            {
                this.Squares[i].Color = Color.Blue;
            }

            for (int i = 70; i <= 74; i++)
            {
                this.Squares[i].Color = Color.Red;
            }

        }

        public void CreateToken(List<Player> players)
        {
            foreach (Player p in players)
            {
                for (int i = 0; i < 4; i++)
                {
                    Token t = new Token(tokens.Count, p.Color);
                    tokens.Add(t);
                }
            }
        }

    }
}
