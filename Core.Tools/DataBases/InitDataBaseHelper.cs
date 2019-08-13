using Core.Tools.Migrations;
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
        SQLConfigHelper sqlConfig = new SQLConfigHelper();
        DefaultDB dbContext = new DefaultDB();

        public void InitDataBase(DataBaseAddress dataBaseAddress)
        {
            var databaseql = sqlConfig.GetDataBaseSQL(dataBaseAddress.DataBaseType);
            ChangeDataBase(dataBaseAddress);
            dataBaseAddress.DataBases = dbContext.Database.SqlQuery<DataBase>(databaseql).ToList<DataBase>().Where(x=>string.IsNullOrEmpty(dataBaseAddress.DefaultDataBaseName) || x.DataBaseName == dataBaseAddress.DefaultDataBaseName).ToList();

            dataBaseAddress.DataBases.ForEach(x => {
                x.Address = dataBaseAddress.Address;
                x.User = dataBaseAddress.User;
                x.Password = dataBaseAddress.Password;
                x.ConnectionStrings = dataBaseAddress.ConnectionStrings;
                x.DataBaseType = dataBaseAddress.DataBaseType;
            });   
            BackConnection();
        }


        public void InitTable(DataBase dataBase)
        {
            string getDataTableSql = sqlConfig.GetTableSQL(dataBase.DataBaseType).Replace("@DataBaseName", dataBase.DataBaseName);
            ChangeDataBase(dataBase);
            dataBase.Tables = dbContext.Database.SqlQuery<Table>(getDataTableSql).ToList<Table>();
            dataBase.Tables.ForEach(x => {
                x.Address = dataBase.Address;
                x.DataBaseName = dataBase.DataBaseName;
                x.User = dataBase.User;
                x.Password = dataBase.Password;
                x.ConnectionStrings = dataBase.ConnectionStrings;
                x.DataBaseType = dataBase.DataBaseType;
            }); 
            BackConnection();
        }

        public void InitColumn(Table table)
        { 
            string getColumnSql = sqlConfig.GetColumnSQL(table.DataBaseType).Replace("@DataBaseName", table.DataBaseName).Replace("@TableName", table.TableName);
            ChangeDataBase(table);
            table.Columns = dbContext.Database.SqlQuery<Column>(getColumnSql).ToList<Column>();

            table.Columns.ForEach(x => {
                x.Address = table.Address;
                x.DataBaseName = table.DataBaseName;
                x.User = table.User;
                x.Password = table.Password;
                x.DataBaseType = table.DataBaseType;
                x.TableName = table.TableName; 
                x.TableDescription = table.TableDescription; 
                x.ConnectionStrings = table.ConnectionStrings; 
            });
            BackConnection();
            table.Columns.ForEach(x => x.CSharpType = GetColumnType(x.DataBaseType, x.SQLType));
        }

        public string GetColumnType(DataBaseType dataBaseType, string Type)
        {
            string columnType = string.Empty; ;
            switch (dataBaseType)
            {
                case DataBaseType.SQLServer:
                    columnType = dbContext.DataTypeConfigs.FirstOrDefault(y => y.SQLServerType == Type).CSharpType;
                    break;
                case DataBaseType.SQLite:
                    columnType = dbContext.DataTypeConfigs.FirstOrDefault(y => y.SQLiteType == Type).CSharpType;
                    break;
                case DataBaseType.MySQL:
                    columnType = dbContext.DataTypeConfigs.FirstOrDefault(y => y.MySqlType == Type).CSharpType;
                    break; 
            }
            return columnType;
        }




        public void ChangeDataBase(DataBaseAddress baseAddress)
        {
            dbContext.Database.Connection.ConnectionString = baseAddress.ConnectionStrings; 
        }

        public void BackConnection()
        {
            dbContext.Database.Connection.ConnectionString = DefaultDB.DefaultSqltiteConnection;
        }
    }
}
