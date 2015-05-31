using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mdw
{
    public partial class LudoGUI : Form
    {
        public LudoGUI()
        {
            InitializeComponent();

            lbChat.Items.Add("hi");
            lbChat.Items.Add("How u doin?");
        }


    }
}
