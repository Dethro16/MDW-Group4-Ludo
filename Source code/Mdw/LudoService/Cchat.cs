using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace LudoService
{
    public delegate void ListOfNames(List<string> names, object sender);

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class CChat : ISendChatService
    {
        Dictionary<string, IReceiveChatService> names = new Dictionary<string, IReceiveChatService>();

        IReceiveChatService callback = null;

        public static event ListOfNames ChatListOfNames;

        public CChat() { }

        public void Close()
        {
            callback = null;
            names.Clear();
        }

        public void Start(string Name)
        {
            try
            {
                if (!names.ContainsKey(Name))
                {
                    callback = OperationContext.Current.GetCallbackChannel<IReceiveChatService>();
                    AddUser(Name, callback);
                    SendNamesToAll();
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void Stop(string Name)
        {
            try
            {
                if (names.ContainsKey(Name))
                {
                    names.Remove(Name);
                    SendNamesToAll();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void AddUser(string name, IReceiveChatService callback)
        {
            names.Add(name, callback);
            if (ChatListOfNames != null)
            {
                ChatListOfNames(names.Keys.ToList(), this);
            }

        }

        void SendNamesToAll()
        {
            foreach (KeyValuePair<string, IReceiveChatService> item in names)
            {
                IReceiveChatService proxy = item.Value;
                proxy.SendNames(names.Keys.ToList());
            }
            if (ChatListOfNames != null)
            {
                ChatListOfNames(names.Keys.ToList(), this);
            }
        }

        void ISendChatService.SendMessage(string msg, string sender, string receiver)
        {
            if (names.ContainsKey(receiver))
            {
                callback = names[receiver];
                callback.ReceiveMessage(msg, sender);
            }
        }

    }
}