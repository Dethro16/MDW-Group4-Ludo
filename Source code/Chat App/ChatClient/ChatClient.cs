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
        private delegate void UserJoined(string userName);
        private delegate void UserSendMessage(string userName, string message);

        private static event UserJoined NewJoin;
        private static event UserSendMessage MessageSent;

        private string userName;
        private IChatChannel channel;
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
            if (!string.IsNullOrEmpty(tBUser.Text.Trim()))
            {
                try
                {
                    //Events
                    NewJoin += new UserJoined(ChatClient_NewJoin);
                    //This because when someone logs in they need to be notified
                    MessageSent += new UserSendMessage(ChatClient_MessageSent);

                    channel = null;

                    this.userName = tBUser.Text;

                    InstanceContext context = new InstanceContext(new ChatClient(tBUser.Text));

                    factory = new DuplexChannelFactory<IChatChannel>(context, "ChatEndPoint");

                    channel = factory.CreateChannel();
                    channel.Open();
                    channel.Login(this.userName);

                    richTextBox1.AppendText("Yay chat application!\r\n");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }


        //Event
        void ChatClient_MessageSent(string userName, string message)
        {
            //Checks first if the name is in the list if not adds it
            if (!lstUsers.Items.Contains(userName))
            {
                lstUsers.Items.Add(userName);
            }

            richTextBox1.AppendText("\r\n");
            richTextBox1.AppendText(userName + " says: " + message);
        }

        //event
        void ChatClient_NewJoin(string userName)
        {
            richTextBox1.AppendText("\r\n");
            richTextBox1.AppendText(userName + " joined at: [" + DateTime.Now.ToString() + "]");
            lstUsers.Items.Add(userName);

            if (!lstUsers.Items.Contains(userName))
            {
                lstUsers.Items.Add(userName);
            }
        }

        public void Login(string userName)
        {
            if (NewJoin != null)
            {
                NewJoin(userName);
            }
        }

        public void SendMessage(string userName, string message)
        {
            if (MessageSent != null)
            {
                MessageSent(userName, message);
            }
        }


        private void btnSend_Click(object sender, EventArgs e)
        {
            channel.SendMessage(this.userName, textBox2.Text);
        }
    }
}
