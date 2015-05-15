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

namespace Mdw
{

    public interface IChatClient
    {
        [OperationContract(IsOneWay = true)]
        void ReceiveMessage(string user, string message);    

    }
    public partial class Chat : Form, IChatClient
    {

       
        public Chat()
        {
            InitializeComponent();
        }

        public void ReceiveMessage(string user, string message)
        {
            lBChatH.Items.Add(user + ": " + message);

        }

        private void btn_Login_Click(object sender, EventArgs e)
        {

        }

        private void btn_Send_Click(object sender, EventArgs e)
        {

        }




    }
}
