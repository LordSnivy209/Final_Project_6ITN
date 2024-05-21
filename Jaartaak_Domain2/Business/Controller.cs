using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jaartaak.Business
{
    public class Controller
    {
        private Persistance.persCon _persCon;
        private string _connectionstring;
        private User _loggedInUser;
        private User _registeredUser;
        
        //properties
        public User LoggedInUser { get { return _loggedInUser; } }

        public Controller()
        {
            _connectionstring = "server=localhost; user id=root; password=1234;database=databasenotities";
            _persCon = new Persistance.persCon(_connectionstring);
            _loggedInUser = null;
        }//public busCon()

        //methods
        public bool Login(string username, string password)
        {
            _loggedInUser = _persCon.getUserFromDB(username, password);
            return _loggedInUser != null;
        }//public bool Login(string username, string password)

        public bool Register(int orgID, string username, string password)
        {
            _registeredUser = _persCon.addUserToDB(orgID, username, password);
            return _registeredUser != null;
        }//public bool Register(string username, string password)
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
        }


    }//public class busCon
}
