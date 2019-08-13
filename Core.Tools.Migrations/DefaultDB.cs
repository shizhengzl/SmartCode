using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.UsuallyCommon;
using MySql.Data.EntityFramework;

namespace Core.Tools.Migrations
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class DefaultDB : DbContext
    {
        //如果您想要针对其他数据库和/或数据库提供程序，请在应用程序配置文件中修改“DefaultSqlite”
        //连接字符串。
        public DefaultDB()
            : base(DefaultSqltiteConnection)
        {

            this.Configuration.AutoDetectChangesEnabled = false;
        }

        //"server=192.168.1.202;port=3306;database=DefaultDB;user=root;password=Yunshu123;CharSet=utf8;sslmode=none"
        public static string DefaultSqltiteConnection { get { return System.Configuration.ConfigurationManager.ConnectionStrings["DefaultDB"].ToStringExtension(); } }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();//移除复数表名的契约  
        }

        //为您要在模型中包含的每种实体类型都添加 DbSet。有关配置和使用 Code First  模型
        //的详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=390109。

        public virtual DbSet<DefaultColumn> Columns { get; set; }


        public virtual DbSet<SQLConfig> SQLConfigs { get; set; }


        public virtual DbSet<DataBaseAddress> DataBaseAddresses { get; set; }

        public virtual DbSet<DataTypeConfig> DataTypeConfigs { get; set; }
        
    }

}
