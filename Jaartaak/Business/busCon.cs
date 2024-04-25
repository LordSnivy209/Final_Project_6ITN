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
        
        public busCon()
        {
            _conString = "server=localhost; user id=root; password=1234;database=databasenotities";
            _persCon = new Persistance.persCon(_conString);
        }
    }
}
