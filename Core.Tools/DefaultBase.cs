using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Tools
{
    public class DefaultBase : DbContext
    {


        public static string DefaultBaseConnection { get { return System.Configuration.ConfigurationManager.ConnectionStrings["DefaultBase"].ToStringExtension(); } }
        public DefaultSqlite()
         : base(DefaultSqltiteConnection)
        {

            this.Configuration.AutoDetectChangesEnabled = false;
        }


    }
}
