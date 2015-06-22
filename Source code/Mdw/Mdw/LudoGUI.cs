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
        bool tokenOnField = false;
        Bitmap red = Properties.Resources.TokenRed;
        Bitmap blue = Properties.Resources.TokenBlue;
        Bitmap yellow = Properties.Resources.TokenYellow;
        Bitmap green = Properties.Resources.TokenGreen;

        Panel selectedPanel = null;
        List<Panel> controllist = new List<Panel>();


        InstanceContext context;
        LudoGamePlayServiceReference.LudoClient proxy;

        string userName = LudoLoginGUI.userName;
        Color color = LudoLoginGUI.color;
        int caseSwitch;

        public List<PictureBox> ReturnBaseTokens(Color c)
        {
            List<PictureBox> BaseTokens = new List<PictureBox>();
            if (c == Color.Red)
            {
                BaseTokens.Add(tokenRed1);
                BaseTokens.Add(tokenRed2);
                BaseTokens.Add(tokenRed3);
                BaseTokens.Add(tokenRed4);
            }
            else if (c == Color.Green)
            {
                BaseTokens.Add(tokenGre1);
                BaseTokens.Add(tokenGre2);
                BaseTokens.Add(tokenGre3);
                BaseTokens.Add(tokenGre4);
            }
            else if (c == Color.Blue)
            {
                BaseTokens.Add(tokenBlu1);
                BaseTokens.Add(tokenBlu2);
                BaseTokens.Add(tokenBlu3);
                BaseTokens.Add(tokenBlu4);
            }
            else if (c == Color.Yellow)
            {
                BaseTokens.Add(tokenYel1);
                BaseTokens.Add(tokenYel2);
                BaseTokens.Add(tokenYel3);
                BaseTokens.Add(tokenYel4);
            }
            return BaseTokens;
        }



        public LudoGUI()
        {

            InitializeComponent();
            context = new InstanceContext(this);
            proxy = new LudoGamePlayServiceReference.LudoClient(context);
            proxy.Subscribe();

            proxy.CreatePlayers(LudoLoginGUI.userName, LudoLoginGUI.color);

            proxy.GetPlayerColor(userName, color);


            OnPlayerLogin(proxy.GetPlayer(Color.Red), Color.Red);
            OnPlayerLogin(proxy.GetPlayer(Color.Blue), Color.Blue);
            OnPlayerLogin(proxy.GetPlayer(Color.Green), Color.Green);
            OnPlayerLogin(proxy.GetPlayer(Color.Yellow), Color.Yellow);


            foreach (Panel pb in this.Controls.OfType<Panel>())
            {
                controllist.Add(pb);
                pb.Enabled = false;
            }

            //EnablePanels(false, color);

        }

        public void OnPlayerLogin(string playername, Color color)
        {
            string temp = color.ToString();

            switch (temp)
            {
                case "Color [Red]":
                    this.tbRed.Text = playername;
                    if (playername != "Empty")
                    {
                        foreach (PictureBox item in ReturnBaseTokens(color))
                        {
                            item.BackgroundImage = red;
                        }
                    }
                    break;
                case "Color [Blue]":
                    this.tbBlue.Text = playername;
                    if (playername != "Empty")
                    {
                        foreach (PictureBox item in ReturnBaseTokens(color))
                        {
                            item.BackgroundImage = blue;
                        }
                    }
                    break;
                case "Color [Green]":
                    this.tbGreen.Text = playername;
                    if (playername != "Empty")
                    {
                        foreach (PictureBox item in ReturnBaseTokens(color))
                        {
                            item.BackgroundImage = green;
                        }
                    }
                    break;
                case "Color [Yellow]":
                    this.tbYellow.Text = playername;
                    if (playername != "Empty")
                    {
                        foreach (PictureBox item in ReturnBaseTokens(color))
                        {
                            item.BackgroundImage = yellow;
                        }
                    }
                    break;
            }

            if (playername != "Empty")
            {
                lbChat.Items.Add("[" + DateTime.Now.ToString("HH:MM") + "] ~~~ <" + playername + "> has joined!!! ~~~");
                lbChat.TopIndex = lbChat.Items.Count - 1;
            }

        }

        public void OnChatCallback(string username, string message)
        {
            lbChat.Items.Add("[" + DateTime.Now.ToString("HH:MM") + "] <" + username + ">: " + message);
            lbChat.TopIndex = lbChat.Items.Count - 1;
        }

        public void EnablePanels(bool state, Color color)
        {
            foreach (Panel item in controllist)
            {
                if (state)
                {
                    if (item.BackgroundImage == EnablePic(color))
                    {
                        item.Enabled = true;
                    }
                    else
                    {
                        item.Enabled = false;
                    }
                }
                else
                {
                    item.Enabled = false;
                }
            }
        }

        public Bitmap EnablePic(Color color)
        {
            switch (color.ToString())
            {
                case "Color [Red]":
                    return red;
                case "Color [Blue]":
                    return blue;
                case "Color [Yellow]":
                    return yellow;
                case "Color [Green]":
                    return green;
                default: return null;
            }
        }

        public void OnRollCallback(string username, int diceroll)
        {
            lbChat.Items.Add("[" + DateTime.Now.ToString("HH:MM") + "] ~~~ <" + username + "> rolled a " + diceroll.ToString() + "!!! ~~~");
            lbChat.TopIndex = lbChat.Items.Count - 1;

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
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources.Dice);
            player.Play();

            string temp = proxy.RollToClient(userName);
            proxy.Roll(userName);

            lbChat.Items.Add(temp);
            lbChat.TopIndex = lbChat.Items.Count - 1;

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
                    foreach (PictureBox item in ReturnBaseTokens(color))
                    {
                        item.Enabled = true;
                    }
                    tBTurn.Text = "Move a token!";
                    pbDice.Image = Properties.Resources.d6;
                    break;
            }

            tokenOnField = false;
            foreach (Panel item in controllist)
            {
                if (item.BackgroundImage == EnablePic(color))
                {
                    if (!item.Name.Contains("goal"))
                        tokenOnField = true;
                }
            }
            if (tokenOnField)
            {
                tBTurn.Text = "Move a token!";
                EnablePanels(true, color);
            }
            else
            {
                if (proxy.NumberToClient() != 6)
                {
                    tBTurn.Text = "End of turn!";
                    proxy.NextTurn();
                }
            }
            this.pbDice.Enabled = false;

        }

        private void LudoGUI_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void PanelOnClick(object sender, EventArgs e)
        {
            Panel p = (Panel)sender;

            //MessageBox.Show(p.Name);
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources.TokenMove);
            player.Play();

            if (!p.Name.Contains("goal"))
            {
                string destination = proxy.MoveToken(p.Name, color);
                if (destination == p.Name)
                {
                    MessageBox.Show("No stacking allowed (Maybe in v2!)");
                    return;
                }
                foreach (Panel panel in controllist)
                {
                    if (panel.Name == destination)
                    {
                        if (proxy.GetReadyToEat() != Color.Black)
                        {
                            proxy.EatToClient(userName, proxy.GetReadyToEat());

                            foreach (PictureBox pic in ReturnBaseTokens(proxy.GetReadyToEat()))
                            {
                                if (pic.BackgroundImage == null)
                                {
                                    pic.BackgroundImage = EnablePic(proxy.GetReadyToEat());
                                    break;
                                }
                            }
                            //break;

                        }
                        proxy.MoveToClient(userName, p.Name, color, panel.Name);
                      
                        panel.BackgroundImage = p.BackgroundImage;
                        p.BackgroundImage = null;
                    }
                }

            }
            if (proxy.NumberToClient() == 6)
            {
                this.pbDice.Enabled = true;
                tBTurn.Text = "Roll the dice!";
                foreach (PictureBox item in ReturnBaseTokens(color))
                {
                    item.Enabled = false;
                }
            }
            else
            {
                proxy.NextTurn();
                tBTurn.Text = "End of turn!";
            }


            EnablePanels(false, color);

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
            lbChat.TopIndex = lbChat.Items.Count - 1;
            tbChat.Clear();
            tbChat.Focus();
        }

        private void tbChat_KeyPress(object sender, KeyPressEventArgs e)
        {

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
            tBTurn.Text = "Roll the dice!";
            lbChat.TopIndex = lbChat.Items.Count - 1;
            this.btStart.Enabled = false;
        }


        private void PictureBoxOnClick(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;

            System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources.TokenMove);
            player.Play();

            string destination = proxy.PutTokenInPlay(color, true);

            proxy.PlaceToken(userName, pb.Name, color, destination);

            foreach (Panel panel in controllist)
            {
                panel.BackgroundImageLayout = ImageLayout.Stretch;
                if (panel.Name == destination)
                {
                    panel.BackgroundImage = pb.BackgroundImage;
                }
            }
            pb.BackgroundImage = null;
            this.pbDice.Enabled = true;

            EnablePanels(false, color);

            foreach (PictureBox item in ReturnBaseTokens(color))
            {
                item.Enabled = false;
            }

            if (proxy.NumberToClient() == 6)
            {
                tBTurn.Text = "Roll the dice!";
            }
            else
            {
                tBTurn.Text = "End of turn!";
            }

        }

        public void OnPlaceToken(string TokenName, Color color, string destination)
        {

            foreach (PictureBox pic in ReturnBaseTokens(color))
            {
                if (pic.Name == TokenName)
                {
                    foreach (Panel panel in controllist)
                    {
                        panel.BackgroundImageLayout = ImageLayout.Stretch;
                        if (panel.Name == destination)
                        {
                            panel.BackgroundImage = pic.BackgroundImage;
                        }
                    }
                    pic.BackgroundImage = null;
                    return;
                }
            }

        }

        public void OnMoveToken(string TokenName, Color color, string destination)
        {
            foreach (Panel p in controllist)
            {
                if (p.Name == TokenName)
                {
                    foreach (Panel panel in controllist)
                    {
                        panel.BackgroundImageLayout = ImageLayout.Stretch;
                        if (panel.Name == destination)
                        {
                            panel.BackgroundImage = p.BackgroundImage;
                        }
                    }
                    p.BackgroundImage = null;
                    return;
                }
            }
        }

        public void OnTokenEat(string playername, Color color)
        {
            foreach (PictureBox pic in ReturnBaseTokens(color))
            {
                if (pic.BackgroundImage == null)
                {
                    pic.BackgroundImage = EnablePic(color);
                    return;
                }
            }
        }

    }
}