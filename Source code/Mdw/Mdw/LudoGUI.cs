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
        Panel selectedPanel = null;
        List<Panel> controllist = new List<Panel>();
        

        InstanceContext context;
        LudoGamePlayServiceReference.LudoClient proxy;

        string userName = LudoLoginGUI.userName;
        Color color = LudoLoginGUI.color;
        int caseSwitch;

        public LudoGUI()
        {

            InitializeComponent();
            context = new InstanceContext(this);
            proxy = new LudoGamePlayServiceReference.LudoClient(context);
            proxy.Subscribe();

            proxy.CreatePlayers(LudoLoginGUI.userName, LudoLoginGUI.color);

            proxy.GetPlayerColor(userName, color);

            this.tbRed.Text = proxy.GetPlayer(Color.Red);
            this.tbBlue.Text = proxy.GetPlayer(Color.Blue);
            this.tbGreen.Text = proxy.GetPlayer(Color.Green);
            this.tbYellow.Text = proxy.GetPlayer(Color.Yellow);

            //controllist.Add(pbDice);
            //controllist.Add(pbRed);
            //controllist.Add(pbBlue);
            //controllist.Add(pbGreen);
            //controllist.Add(pbYellow);

            foreach (Panel pb in this.Controls.OfType<Panel>())
            {
                controllist.Add(pb);
            }
            EnablePanels(false);

        }

        public void OnPlayerLogin(string playername, Color color)
        {
            string temp = color.ToString();

            switch (temp)
            {
                case "Color [Red]":
                    this.tbRed.Text = playername;
                    break;
                case "Color [Blue]":
                    this.tbBlue.Text = playername;
                    break;
                case "Color [Green]":
                    this.tbGreen.Text = playername;
                    break;
                case "Color [Yellow]":
                    this.tbYellow.Text = playername;
                    break;
            }
        }

        public void OnChatCallback(string username, string message)
        {
            lbChat.Items.Add("["+DateTime.Now.ToString("HH:MM")+"] <" + username + ">: " + message);
        }

        public void EnablePanels(bool state)
        {
            foreach (Panel item in controllist)
            {
                item.Enabled = state;
            }
        }

        public void OnRollCallback(string username, int diceroll)
        {
            lbChat.Items.Add("["+DateTime.Now.ToString("HH:MM") + "] ~~~ <" + username + "> rolled a " + diceroll.ToString()+"!!! ~~~");

            caseSwitch = diceroll;
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
            string temp = proxy.RollToClient(userName);
            proxy.Roll(userName);
            
            lbChat.Items.Add(temp);

            switch (proxy.NumberToClient())
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

            EnablePanels(true);
            this.pbDice.Enabled = false;

        }

        private void LudoGUI_FormClosing(object sender, FormClosingEventArgs e)
        {

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

            if (proxy.NumberToClient() == 6)
            {
                this.pbDice.Enabled = true;
            }
            else
            {
                proxy.NextTurn();
            }

            EnablePanels(false);
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
            this.Close();
        }
        #endregion

        private void BtnSend_Click(object sender, EventArgs e)
        {
            string message = this.tbChat.Text;
            string temp = proxy.ChatToClient(userName, message);

            proxy.Chat(userName, message);
            lbChat.Items.Add(temp);
            tbChat.Clear();
            tbChat.Focus();
        }

        private void tbChat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                string message = this.tbChat.Text;
                string temp = proxy.ChatToClient(userName, message);

                proxy.Chat(userName, message);
                lbChat.Items.Add(temp);
                tbChat.Clear();
                tbChat.Focus();
            }
        }

        private void pbRed_Click(object sender, EventArgs e)
        {

        }

        private void btStart_Click(object sender, EventArgs e)
        {
            if (proxy.Check(userName))
            {
                OnPlayerTurn();
            }
            else
            {
                proxy.StartGame();
            }

        }

        public void OnPlayerTurn()
        {
            this.pbDice.Enabled = true;
            lbChat.Items.Add("[" + DateTime.Now.ToString("HH:MM") + "] ~~~ Its your turn!!! ~~~");
            this.btStart.Enabled = false;
        }




    }
}
