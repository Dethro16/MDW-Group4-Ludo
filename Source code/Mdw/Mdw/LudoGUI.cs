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
        ILudoServiceReference.ILudoCallback
    {
        Panel selectedPanel = null;

        InstanceContext context;
        ILudoServiceReference.LudoClient proxy;
        string userName;

        public LudoGUI()
        {
            InitializeComponent();
            context = new InstanceContext(this);
            proxy = new ILudoServiceReference.LudoClient(context);
            proxy.Subscribe();
        }

        public void showDiceRoll(string userName, int diceNumber)
        {
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
        }

        private void pbDice_Click(object sender, EventArgs e)
        {
            proxy.Roll(userName);
        }

        private void RollDiceGUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            proxy.Unsubscribe();
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
            proxy.Unsubscribe();
            LudoLoginGUI login = new LudoLoginGUI();
            login.Show();
            this.SetVisibleCore(false);
        }
        #endregion

    }
}
