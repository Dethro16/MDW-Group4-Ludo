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
    public partial class RegisterLoginGUI : Form
    {
        private RegisterLoginServiceReference.RegisterLoginClient proxy;
        InstanceContext context;
        
        //RegisterLoginServiceReference.RegisterClient proxy;
        //Service
        //Regi
        public RegisterLoginGUI()
        {
            InitializeComponent();
            context = new InstanceContext(this);
            proxy = new RegisterLoginServiceReference.RegisterLoginClient();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
           MessageBox.Show(proxy.Login(tbUserNameL.Text, tbPasswordL.Text));
        }

        private void btn_Register_Click(object sender, EventArgs e)
        {
            if (tbPasswordR.Text != tbConfPass.Text)
            {
                MessageBox.Show("Your passwords do not match.");
            }
            else
            {
                MessageBox.Show(proxy.Register(tbUserNameR.Text, tbPasswordR.Text, tbConfPass.Text));
            }
        }
    }
}
