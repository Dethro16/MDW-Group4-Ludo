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
        Panel selectedPanel = null;


        public LudoGUI()
        {
            InitializeComponent();
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
    }
}
