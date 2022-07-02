using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notes
{
    public partial class ServerWindow : Form
    {
        public ServerWindow()
        {
            InitializeComponent();
            Global.serverWindow = this;
        }

        public SettingsWindow settingsWindow;

        private void settingsButton_Click(object sender, EventArgs e)
        {
            try
            {
                settingsWindow.Show();
            }
            catch
            {
                settingsWindow = new SettingsWindow(this);
                settingsWindow.Show();
            }
        }

        private void ServerWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!Global.isServer) return;

            Application.Exit();
        }
    }
}
