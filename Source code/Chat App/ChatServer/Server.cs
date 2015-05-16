using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Only these 2 needed, need .runtime.Serialization for datamembers
using System.ServiceModel;
using System.ServiceModel.PeerResolvers;

namespace ChatApplication
{
    public partial class Server : Form
    {
        //Found on msdn for peer to peer
        //This can all be added to the main service for the game
        //We just have to change the app.config accordingly
        private CustomPeerResolverService cprs;
        private ServiceHost host;

        public Server()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                cprs = new CustomPeerResolverService();
                cprs.RefreshInterval = TimeSpan.FromSeconds(5);
                host = new ServiceHost(cprs);
                cprs.ControlShape = true;
                cprs.Open();
                host.Open(TimeSpan.FromDays(1000000));
                lblMessage.Text = "Server started successfully.";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                cprs.Close();
                host.Close();
                lblMessage.Text = "Server stopped successfully.";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
    }
}
