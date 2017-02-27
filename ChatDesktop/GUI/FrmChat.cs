using Business;
using ChatDesktop.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatDesktop
{
    public partial class FrmChat : Form
    {
        public FrmChat()
        {
            InitializeComponent();
            //autoReadChat();
        }

        private void btnSendMsg_Click(object sender, EventArgs e)
        {
            MessageBus messageBus = new MessageBus();

            /*
             * Custom Message Error
             * return 1 - roomId
             * return 2 - userId
             * return 0 - okay
             */

            int result = messageBus.validateMessage(txtRoomId.Text, txtUserId.Text);

            if(result == 0)
            {
                Entities.Message message = new Entities.Message();
                message.Send = DateTime.Today;
                message.Text = txtSendMessage.Text;
                message.roomId = Int32.Parse(txtRoomId.Text);
                message.UserId = Int32.Parse(txtUserId.Text);

                if(messageBus.create(message))
                {
                    MessageBox.Show("Mensaje Enviado");
                }
                else
                {
                    MessageBox.Show("El mensaje no se pudo enviar");
                }
            }
            else if (result == 1)
            {
                MessageBox.Show("Por favor ingrese un número de room valido");
            }
            else if (result == 2)
            {
                MessageBox.Show("Por favor ingrese un ID valido");
            }




        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FrmControlPanel frmControlPanel = new FrmControlPanel();
            this.Hide();
            frmControlPanel.ShowDialog();
            this.Close();
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            MessageBus messageBus = new MessageBus();

            int result = messageBus.validateMessage(txtRoomId.Text, txtUserId.Text);


            if (result == 0)
            {
                Entities.Message message = new Entities.Message();
                message.roomId = Int32.Parse(txtRoomId.Text);
                message.UserId = Int32.Parse(txtUserId.Text);

                DataTable dt = messageBus.read(message);
                if (dt != null)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        string msg = "";

                        int cont = 0;
                        foreach (DataColumn column in dt.Columns)
                        {
                            if (cont == 0)
                            {
                                msg += row[column].ToString() + ": ";
                                cont++;
                            }
                            else
                            {
                                msg += row[column].ToString() + "";
                                cont++;
                            }

                        }
                        rtxtChat.Text += msg + System.Environment.NewLine;
                    }
                }
                else
                {
                    MessageBox.Show("No se pudo cargar los mensajes");
                }
            }
            else if (result == 1)
            {
                MessageBox.Show("Por favor ingrese un número de room valido");
            }
            else if (result == 2)
            {
                MessageBox.Show("Por favor ingrese un ID valido");
            }
            else
            {
                MessageBox.Show("Se ha presentado un error en el sistema");
            }

        }

        public void autoReadChat()
        {
            //Creamos el delegado 
            ThreadStart ThreadStartReadChat = new ThreadStart(ReadChat);
            //Creamos la instancia del hilo 
            Thread threadReadChat = new Thread(ThreadStartReadChat);
            //Iniciamos el hilo 
            threadReadChat.Start();
        }


        public void ReadChat()
        {
            while(true)
            {
               try
                {
                    MessageBus messageBus = new MessageBus();

                    int result = messageBus.validateMessage(txtRoomId.Text, txtUserId.Text);


                    if (result == 0)
                    {
                        Entities.Message message = new Entities.Message();
                        message.roomId = Int32.Parse(txtRoomId.Text);
                        message.UserId = Int32.Parse(txtUserId.Text);

                        DataTable dt = messageBus.read(message);
                        if (dt != null)
                        {
                            foreach (DataRow row in dt.Rows)
                            {
                                string msg = "";

                                int cont = 0;
                                foreach (DataColumn column in dt.Columns)
                                {
                                    if(cont == 0)
                                    {
                                        msg += row[column].ToString() + ": ";
                                        cont++;
                                    }
                                    else
                                    {
                                        msg += row[column].ToString() + "";
                                        cont++;
                                    }
                                    
                                }
                                rtxtChat.Text += msg + System.Environment.NewLine;
                            }
                        }
                        else
                        {
                            MessageBox.Show("No se pudo cargar los mensajes");
                        }
                    }
                    else if (result == 1)
                    {
                       MessageBox.Show("Por favor ingrese un número de room valido");
                    }
                    else if (result == 2)
                    {
                        MessageBox.Show("Por favor ingrese un ID valido");
                    }
                    else
                    {
                        MessageBox.Show("Se ha presentado un error en el sistema");
                    }

                }
                catch(Exception)
                {

                }
                
            }
        }
            


    }
}
