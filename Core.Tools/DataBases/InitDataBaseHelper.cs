using Core.UsuallyCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Tools
{
    public class InitDataBaseHelper
    {
        SQLConfig sqlConfig = new SQLConfig();
        public void InitDataBase(DataBaseAddress dataBaseAddress)
        {
            var databaseql = sqlConfig.GetDataBaseSQL(dataBaseAddress.DataBaseType);
        }
    }
}
