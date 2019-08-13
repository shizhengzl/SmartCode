namespace Core.Tools.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initdatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DefaultColumn",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ColumnName = c.String(unicode: false),
                        ColumnDescription = c.String(unicode: false),
                        CSharpType = c.String(unicode: false),
                        IsIdentity = c.Boolean(nullable: false),
                        IsPrimarykey = c.Boolean(nullable: false),
                        MaxLength = c.Int(),
                        IsRequire = c.Boolean(nullable: false),
                        Scale = c.Byte(nullable: false),
                        DefaultValue = c.String(unicode: false),
                        SQLType = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DataBaseAddress",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address = c.String(unicode: false),
                        User = c.String(unicode: false),
                        Password = c.String(unicode: false),
                        Port = c.Int(nullable: false),
                        DefaultDataBaseName = c.String(unicode: false),
                        DataBaseType = c.Int(nullable: false),
                        ConnectionStrings = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DataTypeConfig",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SQLServerType = c.String(unicode: false),
                        MySqlType = c.String(unicode: false),
                        OracleType = c.String(unicode: false),
                        SQLiteType = c.String(unicode: false),
                        CSharpType = c.String(unicode: false),
                        SQLDBType = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SQLConfig",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        GetDataBaseSQL = c.String(unicode: false),
                        GetTableSQL = c.String(unicode: false),
                        GetColumnSQL = c.String(unicode: false),
                        GetProducuteSQL = c.String(unicode: false),
                        GetViewSQL = c.String(unicode: false),
                        GetIndexSQL = c.String(unicode: false),
                        GetSYNONYMSQL = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SQLConfig");
            DropTable("dbo.DataTypeConfig");
            DropTable("dbo.DataBaseAddress");
            DropTable("dbo.DefaultColumn");
        }
    }
}
