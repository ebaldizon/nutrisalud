using Business;
using Entities;
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
    public partial class FrmRoom : Form
    {
        public FrmRoom()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            RoomBus roomBus = new RoomBus();

            if (roomBus.validateBus(txtRoom.Text))
            {
                Room room = new Room();
                room.Id = Int32.Parse(txtRoom.Text);

                if(roomBus.create(room))
                {
                    MessageBox.Show("Room agregada al sistema");
                }
                else
                {
                    MessageBox.Show("No se pudo agregar al sistema");
                }
            }
            else
            {
                MessageBox.Show("Por favor rellenar el campo Room Number con número");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FrmControlPanel frmControlPanel = new FrmControlPanel();
            this.Hide();
            frmControlPanel.ShowDialog();
            this.Close();
        }
    }
}
