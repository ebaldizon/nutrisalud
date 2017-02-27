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
    public partial class FrmRegister : Form
    {
        public FrmRegister()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            UserBus userBus = new UserBus();

            /* 
               CUSTOM MESSAGE TEXT ERROR
               if result = 0 - okay 
               if result = 1 - Error for id
               if resuit = 2 - Error for name
               if result = 3 Error for email
               if result = 4 Error for password
            */
            int result = userBus.validateUserText(txtId.Text, txtName.Text, txtEmail.Text, txtPassword.Text);

            if (result == 0)
            {
                User user = new User();
                user.Id = Int32.Parse(txtId.Text);
                user.Name = txtName.Text;
                user.Email = txtEmail.Text;
                user.Password = txtPassword.Text;

                /* 
                    CUSTOM MESSAGE DATABASE ERROR 
                    if resultCreate = true --> User Create
                    uf resultCreate = false --> User not create
                */
                bool resultCreate = userBus.create(user);

                if (resultCreate)
                {
                    MessageBox.Show("Se registro el usuario en el sistema");
                }
                else
                {
                    MessageBox.Show("No se pudo registrar el usuario en el sistema");
                }
            }
            else if (result == 1)
            {
                MessageBox.Show("Por favor ingrese un número de cédula valido");
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
