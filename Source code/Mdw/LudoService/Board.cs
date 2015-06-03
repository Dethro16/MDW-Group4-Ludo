using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Mdw
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
            //Initializes ALL squares to be colorless firts
            for (int i = 0; i < 92; i++)
            {
                this.squares.Add(new Square(i, Color.White, false, false));
            }

            #region Starting Squares
            //Starting squares
            this.Squares[53].Color = Color.Red;
            this.Squares[54].Color = Color.Blue;
            this.Squares[55].Color = Color.Green;
            this.Squares[56].Color = Color.Yellow;
            #endregion

            #region Home Squares 
            //Home squares almost until the goal
            for (int i = 57; i <= 61; i++)
            {
                this.Squares[i].Color = Color.Red;
            }

            for (int i = 62; i <= 66; i++)
            {
                this.Squares[i].Color = Color.Blue;
            }

            for (int i = 67; i <= 71; i++)
            {
                this.Squares[i].Color = Color.Green;
            }

            for (int i = 72; i <= 77; i++)
            {
                this.Squares[i].Color = Color.Yellow;
            }
            #endregion

            #region Goal Squares
            for (int i = 77; i <= 80; i++)
            {
                this.Squares[i].Color = Color.Red;
                this.Squares[i].IsEnd = true;
            }

            for (int i = 81; i <= 84; i++)
            {
                this.Squares[i].Color = Color.Blue;
                this.Squares[i].IsEnd = true;
            }

            for (int i = 85; i <= 88; i++)
            {
                this.Squares[i].Color = Color.Green;
                this.Squares[i].IsEnd = true;
            }

            for (int i = 89; i <= 92; i++)
            {
                this.Squares[i].Color = Color.Yellow;
                this.Squares[i].IsEnd = true;
            }
            #endregion


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
