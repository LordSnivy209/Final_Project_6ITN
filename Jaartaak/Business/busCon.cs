using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jaartaak.Business
{
    public class busCon
    {
        private Persistance.persCon _persCon;
        private string _conString;
        private User _loggedInUser;
        
        public busCon()
        {
            _conString = "server=localhost; user id=root; password=1234;database=databasenotities";
            _persCon = new Persistance.persCon(_conString);
            _loggedInUser = null;
        }//public busCon()

        //methods
        public bool Login(string username, string password)
        {
            _loggedInUser = _persCon.getUserFromDB(username, password);
            if(_loggedInUser == null )
            {
                return false;
            }
            else
            {
                return true;
            }
        }//public bool Login(string username, string password)

        public bool Register(string username, string password)
        {
            if (_persCon.getUserFromDB(username, password) != null) 
            {
                return true;
            }
            else 
            { 
                return false; 
            }

        }//public bool Register(string username, string password)


    }//public class busCon
}
