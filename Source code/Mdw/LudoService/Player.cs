using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LudoService
{
    class Player
    {
        //Fields
        string name;
        Color color;
        bool hasWon;
        bool loggedIn = false;
        List<Player> players = new List<Player>();

        Player player;
        List<Color> AllColors = new List<Color>{
            Color.Red,Color.Blue, Color.Green, Color.Yellow};

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

        public List<Player> Players
        {
            get { return players; }
            set { players = value; }
        }


        //Constructor

        public Player(string name, Color color)
        {
            Name = name;
            Color = color;
            HasWon = false;
            LoggedIn = true;
        }

        public void CreatePlayer(string playerName, Color color)
        {
            if (AllColors.Exists(x => x.Equals(color)))
            {
                player = new Player(playerName, color);
                AllColors.Remove(color);
                players.Add(player);
            }

            else
            {
                int index = rnd.Next(0, AllColors.Count);
                player = new Player(playerName, AllColors.ElementAt(index));
                players.Add(player);
                AllColors.Remove(AllColors.ElementAt(index));
            }

        }

        //Method

    }
}
