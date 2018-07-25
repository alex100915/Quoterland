namespace MyApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changecommentmodel3 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Comments");
            AlterColumn("dbo.Comments", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Comments", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Comments");
            AlterColumn("dbo.Comments", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Comments", "Id");
        }
    }
}
