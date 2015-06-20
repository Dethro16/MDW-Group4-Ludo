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
        int id;
        bool atBase;
        bool atEnd;


        //Properties
        public int Id
        {
            get { return id; }
            set { id = value; }
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

        //Constructor
        public Token(int id, Color color)
        {
            Id = id;
            Color = color;
            AtBase = true;
            AtEnd = false;

        }

        //Methods
    }
}
