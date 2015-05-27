﻿using System;
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
            foreach (Player p in players)
            {
                for (int i = 0; i < 4; i++)
                {
                    Token t = new Token(tokens.Count, p.Color);
                    tokens.Add(t);
                }
            }
        }
        public void PutTokenInPlay(Token token, Square square)
        {
            if (token.AtBase == true)
            {
                if (square.IsEmpty == true)
                {
                    square.AddToken(token);
                }
                else
                {
                    foreach (Token t in square.Tokens)
                    {
                        if (t.Color != token.Color)
                        {
                            t.AtBase = true;
                        }
                    }
                }
                
            }
        }
    }
}
