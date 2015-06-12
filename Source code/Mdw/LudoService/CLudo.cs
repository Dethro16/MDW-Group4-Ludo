﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Drawing;

namespace LudoService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class CLudo : ILudo
    {
        DatabaseHelper db = new DatabaseHelper();

        public List<Player> players = new List<Player>();

        public List<Color> AllColors = new List<Color>{
            Color.Red,Color.Blue, Color.Green, Color.Yellow};


        ILudoCallback clientCallBack;

        Random rnd;
        public int diceNumber;

        public CLudo()
        {
            rnd = new Random();
        }

        public int GenerateRoll()
        {
            return rnd.Next(1, 7);
        }

        public void GetPlayerColor(string playername, Color color)
        {
            foreach (Player item in players)
            {
                if (item.PlayerName != playername)
                {
                    item.callback.OnPlayerLogin(playername, color);
                }
            }
        }

        public string GetPlayer(Color color)
        {
            foreach (Player item in players)
            {
                if (item.Color == color)
                {
                    return item.PlayerName;
                }
            }
            return "Empty";
        }

        public string RollToClient(string playername)
        {
            diceNumber = GenerateRoll();
            string s = "[" + DateTime.Now.ToString("HH:MM") + "] ~~~ <" + playername + "> rolled a " + diceNumber.ToString() + "!!! ~~~";
            return s;
        }

        public void Roll(string playername)
        {
            foreach (Player item in players)
            {
                if (item.PlayerName != playername)
                {
                    item.callback.OnRollCallback(playername, diceNumber);
                }
            }
        }


        public int NumberToClient()
        {
            return diceNumber;
        }

        public void CreatePlayers(string userName, Color color)
        {
            if (AllColors.Exists(x => x.Equals(color)))
            {
                Player player = new Player(userName, color);
                if (players.Count < 1)
                {
                    player.First = true;
                }
                player.ID = players.Count + 1;
                player.callback = OperationContext.Current.GetCallbackChannel<ILudoCallback>();
                AllColors.Remove(color);
                players.Add(player);
            }

            else
            {
                int index = rnd.Next(0, AllColors.Count);
                Player player = new Player(userName, AllColors.ElementAt(index));
                player.callback = OperationContext.Current.GetCallbackChannel<ILudoCallback>();
                players.Add(player);
                AllColors.Remove(AllColors.ElementAt(index));
            }
        }


        public void Chat(string playername, string message)
        {
            foreach (Player item in players)
            {
                if (item.PlayerName != playername)
                {
                    item.callback.OnChatCallback(playername, message);
                }
            }
        }

        public string ChatToClient(string playername, string message)
        {
            if (message != "")
            {
                string temp = "["+DateTime.Now.ToString("HH:MM") + "] <" + playername + ">: " + message;
                return temp;
            }
            else return null;
        }

        public void Subscribe()
        {
            clientCallBack = OperationContext.Current.GetCallbackChannel<ILudoCallback>();
        }

    }
}
