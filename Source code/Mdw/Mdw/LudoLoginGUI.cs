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
    public partial class LudoLoginGUI : Form
    {
        //private RegisterLoginServiceReference.RegisterLoginClient proxy;
        private LudoGamePlayServiceReference.LudoClient proxy1;
        private RegisterLogin.RegisterLoginClient proxy;
        //private ILudoServiceReference.LudoClient proxy1;


        InstanceContext context;

        bool togMove;
        int mValX;
        int mValY;

        public LudoLoginGUI()
        {
            InitializeComponent();
            context = new InstanceContext(this);
            proxy = new RegisterLogin.RegisterLoginClient();
            proxy1 = new LudoGamePlayServiceReference.LudoClient(context);
        }

        #region dragdrop
        private void pbDragDrop_MouseDown(object sender, MouseEventArgs e)
        {
            togMove = true;
            mValX = e.X;
            mValY = e.Y;
        }

        private void pbDragDrop_MouseUp(object sender, MouseEventArgs e)
        {
            togMove = false;
        }

        private void pbDragDrop_MouseMove(object sender, MouseEventArgs e)
        {
            if (togMove)
                this.SetDesktopLocation(MousePosition.X - mValX, MousePosition.Y - mValY);
        }
        #endregion

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void lRegister_Click(object sender, EventArgs e)
        {
            LudoRegisterGUI regi = new LudoRegisterGUI();
            regi.ShowDialog();
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void tbPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                Login();
            }
        }

        private void Login()
        {



            MessageBox.Show(proxy.Login(tbUsername.Text, tbPassword.Text));
            string check = proxy.Login(tbUsername.Text, tbPassword.Text);


            //MessageBox.Show(proxy.Login(tbUsername.Text, tbPassword.Text));
            //string check = proxy.Login(tbUsername.Text, tbPassword.Text);
            bool login = check.Contains("successfully");
            if (login)
            {
                LudoGUI game = new LudoGUI();
                this.SetVisibleCore(false);
                game.ShowDialog();
                tbPassword.Text = "";
                this.SetVisibleCore(true);
            }
        }
    }
}
