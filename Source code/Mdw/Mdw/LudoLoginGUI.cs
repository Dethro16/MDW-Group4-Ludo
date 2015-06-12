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
    public partial class LudoLoginGUI : Form
    {
        public static string userName;
        public static Color color;

        private RegisterLoginServiceReference.RegisterLoginClient proxy;

        InstanceContext context;

        bool togMove;
        int mValX;
        int mValY;

        public LudoLoginGUI()
        {
            InitializeComponent();
            context = new InstanceContext(this);
            proxy = new RegisterLoginServiceReference.RegisterLoginClient();
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
            if (cBColor.SelectedIndex != -1)
            {
                if (e.KeyChar == (char)13)
                {
                    Login();
                }
            }
        }

        private Color ChooseColor()
        {
            if ("Red" == cBColor.SelectedItem.ToString())
            {
                return Color.Red;
            }
            if ("Blue" == cBColor.SelectedItem.ToString())
            {
                return Color.Blue;
            }
            if ("Green" == cBColor.SelectedItem.ToString())
            {
                return Color.Green;
            }
            else
            {
                return Color.Yellow;
            }
        }

        private void Login()
        {
            color = ChooseColor();
            string check = proxy.Login(tbUsername.Text, tbPassword.Text, color);
            MessageBox.Show(check);


            bool login = check.Contains("successfully");
            if (login)
            {
                userName = tbUsername.Text;

                LudoGUI game = new LudoGUI();
                this.SetVisibleCore(false);
                game.ShowDialog();
                tbPassword.Text = "";
                this.SetVisibleCore(true);
            }
        }

        private void cBColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            btLogin.Enabled = true;
        }
    }
}
