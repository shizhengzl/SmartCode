namespace Core.Tools.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changecolumns1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DefaultColumn", "Table", c => c.String(unicode: false));
            AlterColumn("dbo.DefaultColumn", "MaxLength", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DefaultColumn", "MaxLength", c => c.Int(nullable: false));
            DropColumn("dbo.DefaultColumn", "Table");
        }
    }
}
