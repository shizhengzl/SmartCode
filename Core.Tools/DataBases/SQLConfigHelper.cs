using Core.Tools.Migrations;
using Core.UsuallyCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Tools
{

    public class SQLConfigHelper
    {
        DefaultDB defaultDB = new DefaultDB();

        /// <summary>
        /// 获取数据库SQL
        /// </summary>
        /// <param name="dataBaseType"></param>
        /// <returns></returns>
        public String GetDataBaseSQL(DataBaseType dataBaseType)
        {
            return GetSql(dataBaseType, GetSqlType.Database);
        }

        /// <summary>
        /// 获取表SQL
        /// </summary>
        /// <param name="dataBaseType"></param>
        /// <returns></returns>
        public String GetTableSQL(DataBaseType dataBaseType)
        {
            return GetSql(dataBaseType, GetSqlType.Table);
        }

        /// <summary>
        /// 获取列SQL
        /// </summary>
        /// <param name="dataBaseType"></param>
        /// <returns></returns>
        public String GetColumnSQL(DataBaseType dataBaseType)
        {
            return GetSql(dataBaseType, GetSqlType.Column);
        }

        /// <summary>
        /// 根据条件查询配置
        /// </summary>
        /// <param name="dataBaseType"></param>
        /// <param name="getSqlType"></param>
        /// <returns></returns>
        public String GetSql(DataBaseType dataBaseType, GetSqlType getSqlType)
        {
            var Sql = string.Empty;
            switch (dataBaseType)
            {
                case DataBaseType.MySQL:
                    switch (getSqlType)
                    {
                        case GetSqlType.Database:
                            Sql = defaultDB.SQLConfigs.FirstOrDefault(x => x.Type == DataBaseType.MySQL).GetDataBaseSQL;
                            break;
                        case GetSqlType.Table:
                            Sql = defaultDB.SQLConfigs.FirstOrDefault(x => x.Type == DataBaseType.MySQL).GetTableSQL;
                            break;
                        case GetSqlType.Column:
                            Sql = defaultDB.SQLConfigs.FirstOrDefault(x => x.Type == DataBaseType.MySQL).GetColumnSQL;
                            break;
                    }
                    break;
                case DataBaseType.SQLServer:
                    switch (getSqlType)
                    {
                        case GetSqlType.Database:
                            Sql = defaultDB.SQLConfigs.FirstOrDefault(x => x.Type == DataBaseType.SQLServer).GetDataBaseSQL;
                            break;
                        case GetSqlType.Table:
                            Sql = defaultDB.SQLConfigs.FirstOrDefault(x => x.Type == DataBaseType.SQLServer).GetTableSQL;
                            break;
                        case GetSqlType.Column:
                            Sql = defaultDB.SQLConfigs.FirstOrDefault(x => x.Type == DataBaseType.SQLServer).GetColumnSQL;
                            break;
                    }
                    break;
                case DataBaseType.SQLite:
                    switch (getSqlType)
                    {
                        case GetSqlType.Database:
                            Sql = defaultDB.SQLConfigs.FirstOrDefault(x => x.Type == DataBaseType.SQLite).GetDataBaseSQL;
                            break;
                        case GetSqlType.Table:
                            Sql = defaultDB.SQLConfigs.FirstOrDefault(x => x.Type == DataBaseType.SQLite).GetTableSQL;
                            break;
                        case GetSqlType.Column:
                            Sql = defaultDB.SQLConfigs.FirstOrDefault(x => x.Type == DataBaseType.SQLite).GetColumnSQL;
                            break;
                    }
                    break;
            }
            return Sql;
        }

    }


    public enum GetSqlType
    {
        Database = 1,
        Table = 2,
        Column = 3,
        View = 4,
        Proc = 5
    }
}
