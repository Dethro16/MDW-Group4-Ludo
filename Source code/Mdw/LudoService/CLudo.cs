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
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Reentrant)]
    public class CLudo : ILudo
    {
        DatabaseHelper db = new DatabaseHelper();
        public static event MessageEventHandler messageEvent;
        public delegate void MessageEventHandler(object sender, MessageEventArgs e);

        public List<Player> players = new List<Player>();

        List<Color> AllColors = new List<Color>{
            Color.Red,Color.Blue, Color.Green, Color.Yellow};
        
        
        ILudoCallback clientCallBack;
        Player player = new Player("", Color.Black);

        MessageEventHandler messageHandler = null;

        Random rnd;
        public int diceNumber;

        public CLudo()
        {
            rnd = new Random();
        }

        public string Register(string userName, string passWord, string confPassWord)
        {
            return db.Register(userName, passWord);
        }

        public string Login(string userName, string passWord, Color color)
        {
            string check = db.Login(userName, passWord);
            if (check.Contains("successfully"))
            {

                if (AllColors.Exists(x => x.Equals(color)))
                {
                    player = new Player(userName, color);
                    AllColors.Remove(color);
                    players.Add(player);
                    return check; 
                }

                else
                {
                    int index = rnd.Next(0, AllColors.Count);
                    player = new Player(userName, AllColors.ElementAt(index));
                    players.Add(player);
                    AllColors.Remove(AllColors.ElementAt(index));
                    return check; 
                }

            }
            else
            {
                return check;
            }
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

        public string GetColorPlayer(Color color)
        {
            foreach (Player item in players)
            {
                if (item.Color == color)
                {
                    return item.Name;
                }
            }

            return "No player";
        }

        //public void createPlayer(string name, Color color)
        //{
        //    Player player = new Player(name, color);
        //    players.Add(player);
        //    player.getColorPlayer(players, color);
        //}


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
