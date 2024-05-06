using Jaartaak.Business;
using Jaartaak.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jaartaak.Persistance
{
    internal class persCon
    {
        private string _connectionstring;

        public persCon(string connString)
        {
            _connectionstring = connString;
        }

        //OrgMapper
        //may be useless but i'll keep it here for now

        public List<Organisation> getOrgsFromDB(string orgName)
        {
            OrgMapper mapper = new OrgMapper(_connectionstring);
            return mapper.getOrgsFromDB(orgName);

        }
        //userMapper

        public List<User> getUsersFromDB()
        {
            UserMapper mapper = new UserMapper(_connectionstring);
            return mapper.getUsersFromDB();
        }
        public User getUserFromDB(string name, string pasWord)
        {
            UserMapper mapper = new UserMapper(_connectionstring);
            return mapper.getUserFromDB(name, pasWord);
        }
        public User addUserToDB(int orgID, string name, string pasWord)
        {
            UserMapper mapper = new UserMapper(_connectionstring);
            return mapper.addUserToDB(orgID, name, pasWord);
        }


        //noteMapper
        public List<Note> getNotesFromDB(int userID)
        {
            NoteMapper mapper = new NoteMapper(_connectionstring);
            return mapper.getNotesFromDB(userID);
        }

        public Note addItemToDB(string userID, string title, string content, DateTime creationDate)
        {
            NoteMapper mapper = new NoteMapper(_connectionstring);
            return mapper.addItemToDB(userID, title, content, creationDate);
        }
    }
}
