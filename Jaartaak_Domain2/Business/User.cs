using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jaartaak.Business
{
    public class User
    {
        private int _userID;

        public int UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }
        private int _orgID;
        public int orgID
        {
            get { return _orgID; }
            set { _orgID = value; }
        }

        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }
        private string _password;
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        //constructors
        public User(int id, int orgID, string name, string password)
        {
            _userID = id;
            _orgID = orgID;
            _userName = name;
            _password = password;
        }

        public User(string name, string password)
        {
            _userID = 0;
            _userName = name;
            _password = password;
        }

        //methods

        public override string ToString()
        {
            return _userName;
        }

    }
}
