﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace Mdw
{
    public delegate void ReceiveMessage(string sender, string message);
    public delegate void GotNames(object sender, List<string> names);

    class ChatClient : ChatServiceReference.ISendChatServiceCallback
    {
        public event ReceiveMessage ReceiveMsg;
        public event GotNames NewNames;

        InstanceContext context = null;

        ChatServiceReference.SendChatServiceClient chatClient = null;

        public void Start(ChatClient client, string name)
        {
            context = new InstanceContext(client);
            chatClient = new ChatServiceReference.SendChatServiceClient(context);
            chatClient.Start(name);
        }

        public void SendMessage(string msg, string sender, string receiver)
        {
            chatClient.SendMessage(msg, sender, receiver);
        }

        public void Stop(string name)
        {
            chatClient.Stop(name);
        }

        void ChatServiceReference.ISendChatServiceCallback.ReceiveMessage(string msg, string receiver)
        {
            if (ReceiveMsg != null)
            {
                ReceiveMsg(receiver, msg);
            }
        }

        public void SendNames(string[] names)
        {
            if (NewNames != null)
            {
                NewNames(this, names.ToList());
            }
        }

    }
}