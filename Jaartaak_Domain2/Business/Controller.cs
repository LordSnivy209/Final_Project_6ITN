using Jaartaak.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Jaartaak.Business
{
    public class Controller
    {
        private Persistance.persCon _persCon;
        private string _connectionstring;
        private User _loggedInUser;
        private User _registeredUser;
        private Organisation _loggedInOrg;
     

        
        //properties
        public User LoggedInUser { get { return _loggedInUser; } }
        //public Organisation 
        public Organisation LoggedInOrg { get { return _loggedInOrg; } }

        public Controller()
        {
            _connectionstring = "server=localhost; user id=root; password=1234;database=databasenotities";
            _persCon = new Persistance.persCon(_connectionstring);
            _loggedInUser = null;
        }//public busCon()

        //methods

        //USERS
        public bool Login(string username, string password)
        {
            _loggedInUser = _persCon.getUserFromDB(username, password);
            return _loggedInUser != null;
        }//public bool Login(string username, string password)

        public bool Register(int orgID, string username, string password)
        {
            try
            {
                _registeredUser = _persCon.addUserToDB(orgID, username, password);
                return _registeredUser != null;
            }
            catch (Exception ex)
            {
                return _registeredUser == null;
            }
        }//public bool Register(string username, string password)
        public List<User> GetAllUsers(int orgID)
        {
            return _persCon.getUsersFromDB(orgID);
        }//public List<User> GetAllUsers(int orgID)
        public List<Note> GetNotes()
        {
            if (_loggedInUser == null)
            {
                return null;
            }
            else
            {
                return _persCon.getNotesFromDB(_loggedInUser.UserID);
            }
        }// public List<Note> GetNotes()
        public User getUserNameFromDB(string username)
        {
            return _persCon.getUserNameFromDB(username);
        }//public User getUserNameFromDB(string username)

        public bool addUserToOrg(int orgID, int userID)
        {
            try
            {
                _persCon.AddUserToOrg(orgID, userID);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }//public bool addUserToOrg(int orgID, int userID)




        //NOTES
        public bool addNoteToDB(int userID, string title, string content, DateTime creationDate)
        {
            if (_persCon.addItemToDB(userID, title, content, creationDate) == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }//public bool addNoteToDB(int userID, string title, string content, DateTime creationDate)

        public List<Note> searchNotes(int userID, string title)
        {

                return _persCon.searchNotesFromDB(userID, title);

        }//public List<Note> searchNotes(int userID, string title)

        public bool editNoteInDB(int noteID, string newTitle, string newContent)
        {
            try
            {
                _persCon.editNoteInDB(noteID, newTitle, newContent);
                
                return true;
            }
            catch (Exception ex)
            {
                return false; 
            }
        }//public bool editNoteInDB(int noteID, string newTitle, string newContent)

        public Note GetNoteById(int noteID)
        {
            return _persCon.GetNoteById(noteID);
        }// public Note GetNoteById(int noteID)

        public bool deleteNoteFromDB(int noteID)
        {
            try
            {
                _persCon.deleteNoteFromDB(noteID);
                
                return true;
            }
            catch (Exception ex)
            {
                return false; 
            }
        }//public bool deleteNoteFromDB(int noteID)

        public List<Note> orderNotesByCDDesc(int userID)
        {
            return _persCon.orderByCDDesc(userID);
        }

        public List<Note> orderNotesByCDAsc(int userID)
        {
            return _persCon.orderByCDAsc(userID);
        }

        public List<Note> orderByTitleAsc(int userID)
        {
            return _persCon.orderByTitleAsc(userID);
        }

        public List<Note> orderByTitleDesc(int userID)
        {
            return _persCon.orderByTitleDesc(userID);
        }


        //ORGANISATIONS
        public bool LoginAsBusiness(string username, string password)
        {
            _loggedInOrg = _persCon.getOrgFromDB(username, password);
            return _loggedInUser != null;
        }//public bool LoginAsBusiness(string username, string password)

        public List<Note> getOrgNotes(int orgID)
        {
            return _persCon.getOrgNotes(orgID);
        }

    }//public class busCon
}
