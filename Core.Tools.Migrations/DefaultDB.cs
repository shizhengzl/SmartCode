using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.UsuallyCommon;

namespace Core.Tools.Migrations
{
    public class DefaultDB : DbContext
    {
        //如果您想要针对其他数据库和/或数据库提供程序，请在应用程序配置文件中修改“DefaultSqlite”
        //连接字符串。
        public DefaultDB()
            : base(DefaultSqltiteConnection)
        {

            this.Configuration.AutoDetectChangesEnabled = false;
        }

        //"Data Source=172.18.132.141;port=3306;Initial Catalog=DefaultSqlite;uid=root;password=123456;Charset=utf8"
        public static string DefaultSqltiteConnection { get { return System.Configuration.ConfigurationManager.ConnectionStrings["DefaultDB"].ToStringExtension(); } }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();//移除复数表名的契约  
        }

        //为您要在模型中包含的每种实体类型都添加 DbSet。有关配置和使用 Code First  模型
        //的详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=390109。

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
 
    } 
     
}
