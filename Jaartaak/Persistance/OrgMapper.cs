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

    }
}
