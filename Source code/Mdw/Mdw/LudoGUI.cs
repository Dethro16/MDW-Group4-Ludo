﻿using System;
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
            }

        }

        public void OnChatCallback(string username, string message)
        {
            lbChat.Items.Add("[" + DateTime.Now.ToString("HH:MM") + "] <" + username + ">: " + message);
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
                    pbDice.Image = Properties.Resources.d6;
                    break;
            }

            bool tokenOnField = false;
            foreach (Panel item in controllist)
            {
                if (item.BackgroundImage == EnablePic(color))
                {
                    tokenOnField = true;
                }
            }
            if (tokenOnField)
            {
                EnablePanels(true, color);
            }
            else 
            {
                if (proxy.NumberToClient() != 6)
                {
                 proxy.NextTurn();
                }
            }
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

            //MessageBox.Show(p.Name);

           
            string s = proxy.MoveToken(p.Name, color);
            foreach (Panel panel in controllist)
            {
                if (panel.Name == s)
                {
                    proxy.MoveToClient(userName, p.Name, color, panel.Name);
                    panel.BackgroundImage = p.BackgroundImage;
                    p.BackgroundImage = null;
                }
            }
            if (proxy.NumberToClient() == 6)
            {
                this.pbDice.Enabled = true;
                foreach (PictureBox item in ReturnBaseTokens(color))
                {
                    item.Enabled = false;
                }
            }
            else
            {
                proxy.NextTurn();
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


        private void PictureBoxOnClick(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;

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

    }
}