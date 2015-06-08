using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace LudoService
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
            string query = "SELECT Username FROM ludoplayers";
            List<string> usernames = new List<string>();
            string query1 = "INSERT INTO ludoplayers (Username, Password) VALUES (@Username, @Password)";
            MySqlCommand cmd = new MySqlCommand(query, connection);

            try
            {
                connection.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string uName = reader.GetString("Username");
                    usernames.Add(uName);
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

            foreach (string item in usernames)
            {
                if (item == userName)
                {
                    return "User already exists.";
                }
            }

            try
            {
                connection.Open();
                MySqlCommand cmd1 = new MySqlCommand(query1, connection);
                cmd1.Parameters.Add("Username", MySqlDbType.VarChar, 20).Value = userName;
                cmd1.Parameters.Add("Password", MySqlDbType.VarChar, 20).Value = password;
                cmd1.ExecuteNonQuery();

                return "You have been successfully registered.";
            }
            catch
            {
                Console.WriteLine("Error whilst loading data");
            }
            finally
            {
                connection.Close();
            }

            return "Error";

        }

        public string Login(string userName, string password)
        {
            string query = "SELECT Username FROM ludoplayers";
            List<string> usernames = new List<string>();

            string query1 = "SELECT Username, Password FROM ludoplayers";
            MySqlCommand cmd = new MySqlCommand(query, connection);

            try
            {
                connection.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string uName = reader.GetString("Username");
                    usernames.Add(uName);
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

            if (usernames.Exists(x => x.Equals(userName)))
            {
                try
                {
                    cmd = new MySqlCommand(query1, connection);

                    connection.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {

                        if (userName == Convert.ToString(reader["Username"]))
                        {
                            if (password != Convert.ToString(reader["Password"]))
                            {
                                return "Wrong password";
                            }
                            if (password == Convert.ToString(reader["Password"]))
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
            }
            else
            {
                return "No such username.";
            }



            return "Error, please try again.";
        }
    }
}
