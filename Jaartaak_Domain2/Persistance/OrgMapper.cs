using Google.Protobuf.Compiler;
using Jaartaak.Business;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jaartaak.Persistance
{
    internal class OrgMapper
    {
        //fields
        private string _connectionString;
        public OrgMapper(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Organisation> getOrgsFromDB(string orgName)
        {
            MySqlConnection conn = new MySqlConnection(_connectionString);
            //SELECT * FROM databasenotities.organisation;
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM databasenotities.organisation");
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            List<Organisation> organisations = new List<Organisation>();
            while (reader.Read())
            {
                Organisation Org = new Organisation(
                    Convert.ToInt32(reader["orgID"]),
                    Convert.ToString(reader["orgName"]),
                    Convert.ToString(reader["orgPassword"]));
                organisations.Add(Org);

            }
            conn.Close();
            return organisations;
        }

        public Organisation getOrgFromDB(string name, string pasWord)
        {
            MySqlConnection conn = new MySqlConnection(_connectionString);
            MySqlCommand cmd = new MySqlCommand("Select * from databasenotities.organisation" +
                " where orgName = @name and orgPassword = @pasWord", conn);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@pasWord", pasWord);
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            Organisation result = null;
            while (reader.Read())
            {
                result = new Organisation(
                    Convert.ToInt32(reader["orgID"]),
                    Convert.ToString(reader["orgName"]),
                    Convert.ToString(reader["orgPassword"]));
            }
            conn.Close();
            return result;
        }

        public List<Note> getOrgNotesFromDB(int orgID)
        {
            MySqlConnection conn = new MySqlConnection(_connectionString);
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM gebruiker AS u INNER JOIN notitie AS n ON u.userID = n.userID INNER JOIN organisation AS o ON u.orgID = o.orgID WHERE u.orgID = @orgID", conn);
            cmd.Parameters.AddWithValue("@orgID", orgID);
            
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            List<Note> notes = new List<Note>();
            while (reader.Read())
            {
                Note result = new Note(
                    Convert.ToInt32(reader["noteID"]),
                    Convert.ToString(reader["userID"]),
                    Convert.ToString(reader["title"]),
                    Convert.ToString(reader["content"]),
                    Convert.ToDateTime(reader["creationDate"]));
                notes.Add(result);
            }
            conn.Close();
            return notes;
        }

    }
}
