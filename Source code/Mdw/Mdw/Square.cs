﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Mdw
{
    class Square
    {
        //Fields
        Color color;
        int position = 0;
        bool isBase;
        bool isEnd;
        bool isEmpty;

        List<Token> tokens;

        //Properties
        public int Position
        {
            get { return position; }
            set { position = value; }
        }

        public bool IsBase
        {
            get { return isBase; }
            set { isBase = value; }
        }

        public bool IsEnd
        {
            get { return isEnd; }
            set { isEnd = value; }
        }

        public bool IsEmpty
        {
            get { return isEmpty; }
            set { isEmpty = value; }
        }

        public Color Color
        {
            get { return color; }
            set { color = value; }
        }

        public List<Token> Tokens
        {
            get { return tokens; }
        }

        //Constructor
        public Square(int position, Color color, bool isBase, bool isEnd)
        {
            this.position = position;
            this.color = color;
            this.isBase = isBase;
            this.isEnd = isEnd;
        }

        //Methods

        public void AddToken(Token token)
        {
            isEmpty = false;
        }

        public void RemoveToken(Token token)
        {
        }


    }
}
