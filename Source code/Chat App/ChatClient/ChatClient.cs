using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;

namespace ChatClient
{
    [ServiceContract(CallbackContract = typeof(IChatService))]
    public interface IChatService
    {
        [OperationContract(IsOneWay = true)]
        void Login(string userName);
        [OperationContract(IsOneWay = true)]
        void SendMessage(string userName, string message);
    }

    //So that you can create a channel with the both interfaces IClientChannel and IChatService
    public interface IChatChannel : IChatService, IClientChannel
    {
    }

    public partial class ChatClient : Form, IChatService
    {
        //Delegates for event being used when a user joins or sends a message
        private delegate void UserJoin(string userName);

        //Added an s to the name as it causes ambiguity with the method SendMessage from IChatService
        private delegate void SendMessages(string userName, string message);

        private static event UserJoin JoinNew;
        private static event SendMessages MessageSent;

        //Will be changed for final app, just for testing purposes
        private string userName;

        //Declaring the interface to use methods later
        private IChatChannel channel;
        //For duplex communication
        private DuplexChannelFactory<IChatChannel> factory;



        public ChatClient()
        {
            InitializeComponent();
        }

        public ChatClient(string userName)
        {
            this.userName = userName;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tBUser.Text))
            {
                try
                {
                    //Events
                    JoinNew += new UserJoin(ChatClient_JoinNew);
                    //This because when someone logs in they need to be notified
                    //And this event is for the message sending
                    MessageSent += new SendMessages(ChatClient_MessageSent);

                    channel = null;

                    //set the username from the textbox
                    this.userName = tBUser.Text;

                    //Each instance gets created with a new username so we have to lock it so they can only log it once
                    //But ideally each user is unique so maybe add a method tocheck if username is unique, or use database
                    InstanceContext context = new InstanceContext(new ChatClient(tBUser.Text));

                    //each client creates a connection
                    factory = new DuplexChannelFactory<IChatChannel>(context, "ChatEndPoint");

                    channel = factory.CreateChannel();
                    channel.Open();
                    channel.Login(this.userName);

                    richTextBox1.AppendText("Welcome! Feel free to chat.\r\n");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            channel.SendMessage(this.userName, textBox2.Text);
        }



        //Event
        void ChatClient_MessageSent(string userName, string message)
        {
            //Checks first if the name is in the list if not adds it
            if (!lstUsers.Items.Contains(userName))
            {
                lstUsers.Items.Add(userName);
            }

            richTextBox1.AppendText("\r\n"+userName + " says: " + message);
        }

        //event
        void ChatClient_JoinNew(string userName)
        {
            richTextBox1.AppendText("\r\n" + userName + " joined at: [" + DateTime.Now.ToString() + "]");
            lstUsers.Items.Add(userName);

            if (!lstUsers.Items.Contains(userName))
            {
                lstUsers.Items.Add(userName);
            }
        }

        //Methods

        public void Login(string userName)
        {
            if (JoinNew != null)
            {
                JoinNew(userName);
            }
        }


        public void SendMessage(string userName, string message)
        {
            //If the message is not null, it will
            if (MessageSent != null)
            {
                MessageSent(userName, message);
                
            }
        }



    }
}