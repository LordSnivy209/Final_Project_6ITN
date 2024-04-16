using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jaartaak.Business
{
    public class Organisation
    {
        private int _orgID;
        public int OrgID 
        { 
            get { return _orgID;}
            set { _orgID = value; } 
        }
        private string _orgName;
        public string OrgName
        {
            get { return _orgName;}
            set { _orgName = value; }
        }
        private string _orgPassword;
        public string OrgPassword
        {
            get { return _orgPassword; }
            set { _orgPassword = value; }
        }

        //constructors
        public Organisation(int id, string name, string password)
        {
            _orgID = id;
            _orgName = name;
            _orgPassword = password;
        }

        public Organisation(string name, string password)
        {
            _orgID = 0;
            _orgName = name;
            _orgPassword = password;
        }

        public override string ToString()
        {
            return _orgName;
        }
    }
}
