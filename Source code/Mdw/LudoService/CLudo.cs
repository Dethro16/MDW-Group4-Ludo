using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

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
        //public string GetData(int value)
        //{
        //    return string.Format("You entered: {0}", value);
        //}

        //public CompositeType GetDataUsingDataContract(CompositeType composite)
        //{
        //    if (composite == null)
        //    {
        //        throw new ArgumentNullException("composite");
        //    }
        //    if (composite.BoolValue)
        //    {
        //        composite.StringValue += "Suffix";
        //    }
        //    return composite;
        //}

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
