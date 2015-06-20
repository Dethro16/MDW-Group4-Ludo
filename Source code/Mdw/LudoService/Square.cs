using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LudoService
{
    public class Square
    {
        //Fields
        string name;
        Color color;
        int position = 0;
        bool isBase;
        bool isEnd;
        bool isToken;

        Token token;

        List<Token> tokens;

        //Properties
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

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

        public bool IsToken
        {
            get { return isToken; }
            set { isToken = value; }
        }

        public Color Color
        {
            get { return color; }
            set { color = value; }
        }

        public List<Token> Tokens
        {
            get { return tokens; }
            set { tokens = value; }
        }

        public Token Token
        {
            get { return token; }
            set { token = value; }
        }

        //Constructor
        public Square(int position, Color color, bool isBase, bool isEnd)
        {
            this.Name = name;
            this.Position = position;
            this.Color = color;
            this.IsBase = isBase;
            this.IsEnd = isEnd;
            this.Tokens = new List<Token>();
        }

        //this.squares.Add(new Square(Color.White, i, false, false));

        //Methods

        public void RemoveToken(Token token)
        {
            IsToken = false;
        }

    }
}
