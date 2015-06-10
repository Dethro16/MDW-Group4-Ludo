using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Drawing;

namespace LudoService
{

    public class MessageEventArgs : EventArgs
    {
        public string userName;
        public int diceNumber;
        
    }
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession, ConcurrencyMode = ConcurrencyMode.Reentrant)]
    public class CLudo : ILudo
    {
<<<<<<< HEAD
        Player player = new Player("", Color.Red);
        //List<Player> players = new List<Player>();
        //Player player;
        //List<Color> AllColors = new List<Color>();
        

=======
>>>>>>> origin/master
        public static event MessageEventHandler messageEvent;
        public delegate void MessageEventHandler(object sender, MessageEventArgs e);
        
        ILudoCallback clientCallBack;

        MessageEventHandler messageHandler = null;

        Random rnd;
        public int diceNumber;

        public CLudo()
        {
            rnd = new Random();
            
        }

        public int GetDiceRoll()
        {
            return diceNumber;
        }

        public void Roll(string userName)
        {
            MessageEventArgs e = new MessageEventArgs();
            diceNumber = rnd.Next(1, 7);
            e.userName = userName;
            e.diceNumber = diceNumber;
            messageEvent(this, e);
        }

        public void CreatePlayer(string playerName, Color color)
        {

            player.CreatePlayer(playerName, color);
            //if (AllColors.Exists(x => x.Equals(color)))
            //{
            //    player = new Player(playerName, color);
            //    AllColors.Remove(color);
            //    players.Add(player);
            //}

            //else
            //{
            //    int index = rnd.Next(0, AllColors.Count);
            //    player = new Player(playerName, AllColors.ElementAt(index));
            //    players.Add(player);
            //    AllColors.Remove(AllColors.ElementAt(index));
            //}

        }

        public string GetPlayer(Color color)
        {
            foreach (Player item in player.Players)
            {
                if (item.Color == color)
                {
                    return item.Name;
                }
            }

            //foreach (var item in players)
            //{
            //    if (item.Color == color)
            //    {
            //        return item.Name;
            //    }
            //}
            return "Jean";
        }

        public void StartGame()
        {
            //if (players.Count < 2)
            //{
            //    //Can't start game yet
            //}
            //else
            //{
            //    //Start game now
            //}
        }

        public void Subscribe()
        {
            clientCallBack = OperationContext.Current.GetCallbackChannel<ILudoCallback>();
            messageHandler = new MessageEventHandler(MessageHandler);
            messageEvent += messageHandler;
        }

        public void Unsubscribe()
        {
            messageEvent -= messageHandler;
        }

        public void MessageHandler(object sender, MessageEventArgs e)
        {
            clientCallBack.showDiceRoll(e.userName, e.diceNumber);
        }
    }
}
