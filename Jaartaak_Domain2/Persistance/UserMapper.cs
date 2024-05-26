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
        public User addUserToDB(int orgID, string name, string pasWord)
        {
            using (MySqlConnection conn = new MySqlConnection(_connectionstring))
            {
                conn.Open();

                // Step 1: Check if the username already exists
                MySqlCommand checkCmd = new MySqlCommand("SELECT COUNT(*) FROM gebruiker WHERE username = @name", conn);
                checkCmd.Parameters.AddWithValue("@name", name);
                int userCount = Convert.ToInt32(checkCmd.ExecuteScalar());

                if (userCount > 0)
                {
                    // Username already exists
                    throw new Exception("Username already exists");
                }

                // Step 2: Insert the new user
                MySqlCommand cmd = new MySqlCommand("INSERT INTO gebruiker (orgID, username, passwordUser) VALUES (@orgID, @name, @pasWord); SELECT LAST_INSERT_ID();", conn);
                cmd.Parameters.AddWithValue("@orgID", orgID);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@pasWord", pasWord);

                int newUserId = Convert.ToInt32(cmd.ExecuteScalar());

                // Step 3: Retrieve the newly created user
                MySqlCommand getUserCmd = new MySqlCommand("SELECT * FROM gebruiker WHERE userID = @userID", conn);
                getUserCmd.Parameters.AddWithValue("@userID", newUserId);

                User result = null;
                using (MySqlDataReader reader = getUserCmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        result = new User(
                            Convert.ToInt32(reader["userID"]),
                            Convert.ToInt32(reader["orgID"]),
                            Convert.ToString(reader["username"]),
                            Convert.ToString(reader["passwordUser"]));
                    }
                }

                return result;
            }
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
        // paste getuser here make sure that there'll be a getUsername
        public User getUserNameFromDB(string name)
        {
            MySqlConnection conn = new MySqlConnection(_connectionstring);
            MySqlCommand cmd = new MySqlCommand("Select userID, orgId, username, passwordUser from databasenotities.gebruiker" +
                " where username = @name", conn);
            cmd.Parameters.AddWithValue("@name", name);
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
