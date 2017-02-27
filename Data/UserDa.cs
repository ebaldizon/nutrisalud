using Entities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class UserDa
    {
        public bool create(User user)
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

                    cmd.CommandText = "INSERT INTO users(id_user, name, email, password) VALUES(@id_user, @name, @email, @password)";

                    cmd.Parameters.AddWithValue("@id_user", user.Id);
                    cmd.Parameters.AddWithValue("@name", user.Name);
                    cmd.Parameters.AddWithValue("@email", user.Email);
                    cmd.Parameters.AddWithValue("@password", user.Password);

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
    }
}
