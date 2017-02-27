using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatDesktop.GUI
{
    public partial class FrmControlPanel : Form
    {
        public FrmControlPanel()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            FrmRegister frmRegister = new GUI.FrmRegister();
            this.Hide();
            frmRegister.ShowDialog();
            this.Close();
        }

        private void btnRoom_Click(object sender, EventArgs e)
        {
            FrmRoom frmRoom = new FrmRoom();
            this.Hide();
            frmRoom.ShowDialog();
            this.Close();
        }

        private void btnChat_Click(object sender, EventArgs e)
        {
            FrmChat frmChat = new FrmChat();
            this.Hide();
            frmChat.ShowDialog();
            this.Close();
        }
    }
}
