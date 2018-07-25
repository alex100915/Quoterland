namespace MyApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changecommentmodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "Created_by_current_user", c => c.Boolean(nullable: false));
            AddColumn("dbo.Comments", "User_has_upvoted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "User_has_upvoted");
            DropColumn("dbo.Comments", "Created_by_current_user");
        }
    }
}
