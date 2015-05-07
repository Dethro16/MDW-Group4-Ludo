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
            
        }

        public void CreateToken(List<Player> players)
        {

        }

    }
}
