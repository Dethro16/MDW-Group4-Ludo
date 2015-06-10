using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LudoService
{
   public class Player
    {
        //Fields
        string name;
        Color color;
        bool hasWon;
        bool loggedIn = false;


        List<Player> players = new List<Player>();
        

        //List<Player> players;
        

        Random rnd = new Random();


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

        public bool LoggedIn
        {
            get { return loggedIn; }
            set { loggedIn = value; }
        }


        //Constructor

        public Player(string name, Color color)
        {
            if (color == Color.Black)
            {

            }
            else
            {
                Name = name;
                Color = color;
                HasWon = false;
                LoggedIn = true;

            }
        }

        //Method

    }
}
