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
                //53-56
                #region startingSquares
                case "startRed": return 53;
                case "startBlue": return 54;
                case "startGreen": return 55;
                case "startYellow": return 56;
                #endregion

                //57-76
                #region homeSquares
                case "homeRed1": return 57;
                case "homeRed2": return 58;
                case "homeRed3": return 59;
                case "homeRed4": return 60;
                case "homeRed5": return 61;

                case "homeBlue1": return 62;
                case "homeBlue2": return 63;
                case "homeBlue3": return 64;
                case "homeBlue4": return 65;
                case "homeBlue5": return 66;

                case "homeGreen1": return 67;
                case "homeGreen2": return 68;
                case "homeGreen3": return 69;
                case "homeGreen4": return 70;
                case "homeGreen5": return 71;

                case "homeYellow1": return 72;
                case "homeYellow2": return 73;
                case "homeYellow3": return 74;
                case "homeYellow4": return 75;
                case "homeYellow5": return 76;
                #endregion
    
                //77-92
                #region goalSquares
                case "goalRed1": return 77;
                case "goalRed2": return 78;
                case "goalRed3": return 79;
                case "goalRed4": return 80;

                case "goalBlue1": return 81;
                case "goalBlue2": return 82;
                case "goalBlue3": return 83;
                case "goalBlue4": return 84;

                case "goalGreen1": return 85;
                case "goalGreen2": return 86;
                case "goalGreen3": return 87;
                case "goalGreen4": return 88;

                case "goalYellow1": return 89;
                case "goalYellow2": return 90;
                case "goalYellow3": return 91;
                case "goalYellow4": return 92;
                #endregion

                //1-52
                #region normalSquares
                case "field1": return 1;
                case "field2": return 2;
                case "field3": return 3;
                case "field4": return 4;
                case "field5": return 5;
                case "field6": return 6;
                case "field7": return 7;
                case "field8": return 8;
                case "field9": return 9;
                case "field10": return 10;
                case "field11": return 11;
                case "field12": return 12;
                case "field13": return 13;
                case "field14": return 14;
                case "field15": return 15;
                case "field16": return 16;
                case "field17": return 17;
                case "field18": return 18;
                case "field19": return 19;
                case "field20": return 20;
                case "field21": return 21;
                case "field22": return 22;
                case "field23": return 23;
                case "field24": return 24;
                case "field25": return 25;
                case "field26": return 26;
                case "field27": return 27;
                case "field28": return 28;
                case "field29": return 29;
                case "field30": return 30;
                case "field31": return 31;
                case "field32": return 32;
                case "field33": return 33;
                case "field34": return 34;
                case "field35": return 35;
                case "field36": return 36;
                case "field37": return 37;
                case "field38": return 38;
                case "field39": return 39;
                case "field40": return 40;
                case "field41": return 41;
                case "field42": return 42;
                case "field43": return 43;
                case "field44": return 44;
                case "field45": return 45;
                case "field46": return 46;
                case "field47": return 47;
                case "field48": return 48;
                case "field49": return 49;
                case "field50": return 50;
                case "field51": return 51;
                case "field52": return 52;
                #endregion

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
            this.Close();
        }
        #endregion

    }
}
