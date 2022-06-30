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
    public partial class SettingsWindow : Form
    {
        public SettingsWindow(Form inWindow)
        {
            InitializeComponent();

            currentWindow = inWindow;
        }

        Form currentWindow;

        private void servermodeButton_Click(object sender, EventArgs e)
        {
            if (!Global.isServer)
            {
                ServerWindow serverWindow = new ServerWindow();
                serverWindow.Show();

                Global.mainWindow.Hide();
                Global.isServer = true;
            }
            else
            {
                Global.isServer = false;
                Global.mainWindow.Show();
                Global.serverWindow.Close();
            }
            
            Close();
        }

        private void settingsCloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SettingsWindow_Load(object sender, EventArgs e)
        {
            if (Global.isServer)
            {
                servermodeButton.Text = "Enable client mode";
            }
        }
    }
}
