using Entities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class RoomDa
    {
        public bool create(Room room)
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

                    cmd.CommandText = "INSERT INTO rooms(id_room) VALUES(@id_room)";

                    cmd.Parameters.AddWithValue("@id_room", room.Id);

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
