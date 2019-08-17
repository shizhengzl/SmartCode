namespace Core.Tools.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changecolumns : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DefaultColumn", "MaxLength", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DefaultColumn", "MaxLength", c => c.Int());
        }
    }
}
