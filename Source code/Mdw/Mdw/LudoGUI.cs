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
    public partial class LudoGUI : Form,
        LudoGamePlayServiceReference.ILudoCallback
    {
        ChatClient client = null;
        Panel selectedPanel = null;

        InstanceContext context;
        LudoGamePlayServiceReference.LudoClient proxy;

        string userName;

        public LudoGUI()
        {

            InitializeComponent();
            context = new InstanceContext(this);
            proxy = new LudoGamePlayServiceReference.LudoClient(context);
            proxy.Subscribe();

            userName = proxy.GetPlayerName();
            this.tbRed.Text = proxy.GetColorPlayer(Color.Red);
            this.tbBlue.Text = proxy.GetColorPlayer(Color.Blue);
            this.tbGreen.Text = proxy.GetColorPlayer(Color.Green);
            this.tbYellow.Text = proxy.GetColorPlayer(Color.Yellow);

            client = new ChatClient();
            client.Start(client, userName);
            client.ReceiveMsg += new ReceiveMessage(client_ReceiveMsg);
            client.NewNames += new GotNames(client_NewNames);


            

            
        }

        void client_NewNames(object sender, List<string> names)
        {
            lBPlayers.Items.Clear();
            foreach (string item in names)
            {
                if (item != userName)
                {
                    lBPlayers.Items.Add(item);
                }
            }
        }

        void client_ReceiveMsg(string sender, string message)
        {
            if (message.Length > 0)
            {
                lbChat.Text += Environment.NewLine + sender + ">" + message;
            }
        }


        public void showDiceRoll(string userName, int diceNumber)
        {
            string s = "<" + userName + "> has rolled a " + diceNumber.ToString();
            lbChat.Items.Add(s);

            int caseSwitch = diceNumber;
            switch (caseSwitch)
            {
                case 1:
                    pbDice.Image = Properties.Resources.d1;
                    break;
                case 2:
                    pbDice.Image = Properties.Resources.d2;
                    break;
                case 3:
                    pbDice.Image = Properties.Resources.d3;
                    break;
                case 4:
                    pbDice.Image = Properties.Resources.d4;
                    break;
                case 5:
                    pbDice.Image = Properties.Resources.d5;
                    break;
                case 6:
                    pbDice.Image = Properties.Resources.d6;
                    break;
            }
        }

        private void pbDice_Click(object sender, EventArgs e)
        {
            proxy.Roll(userName);
        }

        private void RollDiceGUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            proxy.Unsubscribe();
            client.Stop(userName);
        }

        private int GetSquareNumber(Panel p)
        {
            switch (p.Name)
            {
                case "": return 1;
                default: return 0;
            }
        }

        private void PanelOnClick(object sender, EventArgs e)
        {
            Panel p = (Panel)sender;

            MessageBox.Show(p.Name);
        }
        #region Leave Button functions
        private void btLeave_MouseDown(object sender, MouseEventArgs e)
        {
            btLeave.BackgroundImage = Properties.Resources.buttondown;
        }

        private void btLeave_MouseUp(object sender, MouseEventArgs e)
        {
            btLeave.BackgroundImage = Properties.Resources.button;
        }

        private void btLeave_Click(object sender, EventArgs e)
        {
            proxy.Unsubscribe();
            this.Close();
        }
        #endregion

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (lBPlayers.SelectedIndex >= 0 && lBPlayers.SelectedIndex < lBPlayers.Items.Count)
            {
                SendMessage();
            }
        }

        private void SendMessage()
        {
            if (lBPlayers.Items.Count != 0)
            {
                lbChat.Text += Environment.NewLine + userName + ">" + rtbChat.Text;
                if (lBPlayers.SelectedItems.Count == 0)
                {
                    client.SendMessage(rtbChat.Text, userName, lBPlayers.Items[0].ToString());
                }
                else
                {
                    if (!string.IsNullOrEmpty(lBPlayers.SelectedItem.ToString()))
                    {
                        client.SendMessage(rtbChat.Text, userName, lBPlayers.SelectedItem.ToString());
                    }
                }
                rtbChat.Clear();
            }
        }

    }
}
