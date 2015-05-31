using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Mdw
{
    class Player
    {
        //Fields
        string name;
        Color color;
        bool hasWon;

        //Properties
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Color Color
        {
            get { return color; }
            set { color = value; }
        }

        public bool HasWon
        {
            get { return hasWon; }
            set { hasWon = value; }
        }

        //Constructor

        public Player(string name, Color color)
        {
            Name = name;
            Color = color;
            HasWon = false;
        }

        //Method

    }
}
