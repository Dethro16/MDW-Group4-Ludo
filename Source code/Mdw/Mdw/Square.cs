using System;
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

        //Constructor
        public Square(int position, Color color, bool isBase, bool isEnd)
        {

        }

        //Methods

        public void AddToken(Token token)
        {

        }

        public void RemoveToken(Token token)
        {

        }


    }
}
