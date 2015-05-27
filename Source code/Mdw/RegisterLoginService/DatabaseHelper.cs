using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace RegisterLoginService
{
    class DatabaseHelper
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;


        /// <summary>
        /// Server name
        /// </summary>
        public string Server
        {
            get { return server; }
            set { server = value; }
        }

        /// <summary>
        /// Database name
        /// </summary>
        public string Database
        {
            get { return database; }
            set { database = value; }
        }

        /// <summary>
        /// Username 
        /// </summary>
        public string UID
        {
            get { return uid; }
            set { uid = value; }
        }

        /// <summary>
        /// Database password
        /// </summary>
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public DatabaseHelper()
        {
            server = "athena01.fhict.local";
            database = "dbi297569";
            uid = "dbi297569";
            password = "7LJpqGxqkB";

            string Provider_string;
            Provider_string = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(Provider_string);
        }

        public DatabaseHelper(string server, string database, string uid, string password)
        {
            server = "athena01.fhict.local";
            database = "dbi297569";
            uid = "dbi297569";
            password = "7LJpqGxqkB";

            string Provider_string;
            Provider_string = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(Provider_string);
        }

        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {

                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server. Contact administrator");
                        break;

                    case 1045:
                        Console.WriteLine("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }




        public string Register(string userName, string password)
        {
            string query = "SELECT "+userName+" FROM ludoplayers WHERE login="+userName;
            string query1 = "INSERT INTO ludoplayers (Username, `Password) VALUES (" + userName + "," + password + ")";
            connection.Open();
            MySqlCommand cmd = new MySqlCommand(query, connection);
            int exist = Convert.ToInt32(cmd.ExecuteScalar());
            connection.Close();

            if (exist > 0)
            {
                return "User already exists.";
            }
            else
            {
                connection.Open();
                MySqlCommand cmd1 = new MySqlCommand(query1, connection);
                connection.Close();
                return "You have been successfully registered.";
            }
            
        }

        public string Login(string userName, string password)
        {
            string query = "SELECT Username, Password FROM login";
            MySqlCommand cmd = new MySqlCommand(query, connection);

            try
            {
                connection.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (userName != Convert.ToString(reader["Username"]))
                    {
                        return "No such username.";
                    }
                    if (password != Convert.ToString(reader["Password"]))
                    {
                        return "Wrong password.";
                    }
                    if (userName == Convert.ToString(reader["Username"]) == true)
                    {
                        if (password == Convert.ToString(reader["Password"]) == true)
                        {
                            return "You have successfully logged in.";
                        }
                    }

                }


            }
            catch
            {
                Console.WriteLine("Error whilst loading data");
            }

            finally
            {
                connection.Close();
            }
            return "Error, please try again.";
        }

    }
}
