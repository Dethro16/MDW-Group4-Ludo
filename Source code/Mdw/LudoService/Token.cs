using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LudoService
{
   public class Token
    {
        //Fields
        Color color;
        int index;
        bool atBase;
        bool atEnd;
        Square place;
        List<Square> path;


        //Properties
        public int Index
        {
            get { return index; }
            set { index = value; }
        }

        public bool AtBase
        {
            get { return atBase; }
            set { atBase = value; }
        }

        public bool AtEnd
        {
            get { return atEnd; }
            set { atEnd = value; }
        }

        public Color Color
        {
            get { return color; }
            set { color = value; }
        }

        public Square Place
        {
            get { return place; }
            set { place = value; }
        }

        public List<Square> Path
        {
            get { return path; }
            set { path = value; }
        }

        //Constructor
        public Token(Color color)
        {
            Color = color;
            this.Index = 0;
            AtBase = true;
            AtEnd = false;
        }

        //Methods
    }
}
