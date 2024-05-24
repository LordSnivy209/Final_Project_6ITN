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
        public User getUsernameFromDB(string username, string pasWord)
        {
            UserMapper mapper = new UserMapper(_connectionstring);
            return mapper.getUserFromDB(username, pasWord);
        }
        public User addUserToDB(int orgID, string name, string pasWord)
        {
            UserMapper mapper = new UserMapper(_connectionstring);
            return mapper.addUserToDB(orgID, name, pasWord);
        }
        public User getUserNameFromDB(string username)
        {
            UserMapper mapper = new UserMapper(_connectionstring);
            return mapper.getUserNameFromDB(username);
        }

        //noteMapper
        public List<Note> getNotesFromDB(int userID)
        {
            NoteMapper mapper = new NoteMapper(_connectionstring);
            return mapper.getNotesFromDB(userID);
        }

        public Note addItemToDB(int userID, string title, string content, DateTime creationDate)
        {
            NoteMapper mapper = new NoteMapper(_connectionstring);
            return mapper.addItemToDB(userID, title, content, creationDate);
        }

        public List<Note> searchNotesFromDB(int userID, string title) 
        {
            NoteMapper mapper = new NoteMapper(_connectionstring);
            return mapper.SearchNotes(userID, title);
        }

        public void editNoteInDB(int noteID, string newTitle, string newContent)
        {
            NoteMapper mapper = new NoteMapper(_connectionstring);
            mapper.editNoteInDB(noteID, newTitle, newContent);
        }

        public Note GetNoteById(int noteID)
        {
            NoteMapper mapper = new NoteMapper(_connectionstring);
            return mapper.GetNoteById(noteID);
        }

        public void deleteNoteFromDB(int noteID)
        {
            NoteMapper mapper = new NoteMapper(_connectionstring);
            mapper.deleteNoteFromDB(noteID);
        }

    }
}
