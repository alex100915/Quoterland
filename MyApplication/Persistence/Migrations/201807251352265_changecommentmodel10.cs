namespace MyApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changecommentmodel10 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "User_has_upvoted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "User_has_upvoted");
        }
    }
}
