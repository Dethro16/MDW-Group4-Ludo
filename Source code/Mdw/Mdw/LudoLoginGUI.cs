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
    public partial class LudoLoginGUI : Form, ILudoServiceReference.ILudoCallback
    {
<<<<<<< HEAD
        private RegisterLoginServiceReference.RegisterLoginClient proxy;
        private ILudoServiceReference.LudoClient proxy1;
=======
        //private RegisterLoginServiceReference.RegisterLoginClient proxy;
        private LudoGamePlayServiceReference.LudoClient proxy1;
        private RegisterLogin.RegisterLoginClient proxy;
        //private ILudoServiceReference.LudoClient proxy1;


>>>>>>> origin/master
        InstanceContext context;

        bool togMove;
        int mValX;
        int mValY;

        private string loginName;
        private static Color color;

        public string LoginName
        {
            get { return loginName; }
            set { loginName = value; }
        }

        public static Color Color
        {
            get { return color; }
            set { color = value; }
        }

        public LudoLoginGUI()
        {
            InitializeComponent();
            context = new InstanceContext(this);
<<<<<<< HEAD
            proxy = new RegisterLoginServiceReference.RegisterLoginClient();
            proxy1 = new ILudoServiceReference.LudoClient(context);
=======
            proxy = new RegisterLogin.RegisterLoginClient();
            proxy1 = new LudoGamePlayServiceReference.LudoClient(context);
>>>>>>> origin/master
        }


        public void showDiceRoll(string userName, int diceNumber)
        {
            /*
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
             */
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

        private Color ChooseColor()
        {

            if ("Red" == cBColor.SelectedItem.ToString())
            {
                return Color.Red;
            }
            if ("Blue" == cBColor.ValueMember)
            {
                return Color.Blue;
            }
            if ("Green" == cBColor.ValueMember)
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



            MessageBox.Show(proxy.Login(tbUsername.Text, tbPassword.Text));
            string check = proxy.Login(tbUsername.Text, tbPassword.Text);


            //MessageBox.Show(proxy.Login(tbUsername.Text, tbPassword.Text));
            //string check = proxy.Login(tbUsername.Text, tbPassword.Text);
            bool login = check.Contains("successfully");
            if (login)
            {

                loginName = tbUsername.Text;
                Color = ChooseColor();
                proxy1.CreatePlayer(loginName, Color);
                //MessageBox.Show("You have successfully logged in");
                LudoGUI game = new LudoGUI();
                this.SetVisibleCore(false);
                game.ShowDialog();
                tbPassword.Text = "";
                this.SetVisibleCore(true);
            }
        }
    }
}
