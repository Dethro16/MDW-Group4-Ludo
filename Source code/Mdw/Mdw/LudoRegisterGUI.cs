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
    public partial class LudoRegisterGUI : Form
    {
        private RegisterLoginServiceReference.RegisterLoginClient proxy;
        InstanceContext context;

        bool togMove;
        int mValX;
        int mValY;

        public LudoRegisterGUI()
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

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btRegister_Click(object sender, EventArgs e)
        {

            if (tbPassword.Text != tbRePassword.Text)
            {
                MessageBox.Show("Your passwords do not match.");
                ClearFields();
            }
            else
            {
                string check = proxy.Register(tbUsername.Text, tbPassword.Text, tbRePassword.Text);
                MessageBox.Show(check);
                bool regi = check.Contains("successfully");
                if (regi)
                {
                    this.Close();
                }
                ClearFields();
            }

        }

        private void ClearFields()
        {
            tbUsername.Text = "";
            tbPassword.Text = "";
            tbRePassword.Text = "";
        }
    }
}
