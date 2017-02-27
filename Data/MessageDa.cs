using Entities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class MessageDa
    {
        public bool create(Message message)
        {

            DB db = new Data.DB();
            try
            {

                //open connection
                if (db.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = db.connection;
                    cmd = db.connection.CreateCommand();

                    cmd.CommandText = "INSERT INTO messages(send, text, user_id, room_id) VALUES(@send, @text, @user_id, @room_id)";

                    cmd.Parameters.AddWithValue("@send", message.Send);
                    cmd.Parameters.AddWithValue("@text", message.Text);
                    cmd.Parameters.AddWithValue("@user_id", message.UserId);
                    cmd.Parameters.AddWithValue("@room_id", message.roomId);

                    //Execute command
                    cmd.ExecuteNonQuery();

                    //close connection
                    db.CloseConnection();
                    return true;
                }
                else
                {
                    return false;
                }


            }
            catch (MySqlException ex)
            {
                return false;
            }
        }


        public DataTable Read(Message message)
        {
            DB db = new Data.DB();
            try
            {

                //string query = "select u.name, m.text from messages as m, users as u  where room_id = " + message.roomId +" ";

                string query = "select u.name, m.text from messages as m, users as u where room_id = "+ message.roomId + " and u.id_user = m.user_id";

                //open connection
                if (db.OpenConnection() == true)
                {
                  
                    MySqlCommand cmd = new MySqlCommand(query, db.connection);
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    DataTable dt = new DataTable();
                    dt.Load(dataReader);

                    //close Data Reader
                    dataReader.Close();

                    //close Connection
                    db.CloseConnection();

                    //return list to be displayed
                    return dt;
                }
                else
                {
                    return null;
                }
            }
            catch(Exception)
            {
                return null;
            }

              
        }


    }
}
