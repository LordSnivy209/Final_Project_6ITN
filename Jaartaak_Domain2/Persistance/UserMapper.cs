using Google.Protobuf.Compiler;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jaartaak.Business;

namespace Jaartaak.Persistance
{
    internal class UserMapper
    {
        //fields
        private string _connectionstring;

        //constructor
        public UserMapper(string connectionstring)
        {
            _connectionstring = connectionstring;
        }

        public List<User> getUsersFromDB()
        {
            MySqlConnection conn = new MySqlConnection(_connectionstring);
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM gebruiker", conn);
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            List<User> List = new List<User>();
            while (reader.Read())
            {
                User user = new User(
                    Convert.ToInt32(reader["userID"]),
                     Convert.ToInt32(reader["orgID"]),
                    Convert.ToString(reader["username"]),
                    Convert.ToString(reader["passwordUser"]));
                List.Add(user);

            }
            conn.Close();
            return List;
        }
        //hiermee voegt de organisatie een gebruiker toe //moet aangepast worden!!!
        public void addUserToDB(string name, string pasWord)
        {
            MySqlConnection conn = new MySqlConnection(_connectionstring);
            MySqlCommand cmd = new MySqlCommand("INSERT INTO gebruiker (username, passwordUser) VALUES (@name, @pasWord)", conn);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@pasWord", pasWord);
            conn.Open();
            try
            {

                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                conn.Close();

            }

            conn.Close();

        }
        //select * from bucketlistdatabase.persoon where naamPersoon = 'TestNaam' and paswoordPersoon = '1234';

        public User getUserFromDB(string name, string pasWord)
        {
            MySqlConnection conn = new MySqlConnection(_connectionstring);
            MySqlCommand cmd = new MySqlCommand("Select userID, orgId, username, passwordUser from databasenotities.gebruiker" +
                " where username = @name and passwordUser = @pasWord", conn);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@pasWord", pasWord);
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            User result = null;
            while (reader.Read())
            {
                result = new User(
                    Convert.ToInt32(reader["userID"]),
                    Convert.ToInt32(reader["orgID"]),
                    Convert.ToString(reader["username"]),
                    Convert.ToString(reader["passwordUser"]));
            }
            conn.Close();
            return result;
        }
    }
}
