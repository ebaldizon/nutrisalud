using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DB
    {

        public MySqlConnection connection { get; set; }
        private string server;
        private string port;
        private string database;
        private string uid;
        private string password;

        /*public MySql.Data.MySqlClient.MySqlConnection conn { get; set; }
        string myConnectionString = "server=174.136.13.224;uid=purifica_user;pwd=scrum2017;database=purifica_chat;";*/

        public DB()
        {
            Initialize();
        }

        //Initialize values
        public void Initialize()
        {
            
            server = "us-cdbr-azure-west-b.cleardb.com";
            port = "3306";
            database = "nutrisalud";
            uid = "b057632498a663";
            password = "fe538540";

            /*
            server = "127.0.0.1";
            database = "nutrisalud";
            uid = "root";
            password = "";*/


            string connectionString;
            connectionString = "SERVER=" + server + ";" + "PORT=" + port + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            //string connectionString = "server=174.136.13.224;uid=purifica_user;pwd=scrum2017;database=purifica_chat;"; 
            connection = new MySqlConnection(connectionString);
        }

        public bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                return false;
            }
        }


        //Close connection
        public bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                return false;
            }
        }

    }
}
