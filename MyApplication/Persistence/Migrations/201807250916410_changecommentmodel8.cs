namespace MyApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changecommentmodel8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "Parent", c => c.String());
            AlterColumn("dbo.Comments", "Creator", c => c.String());
            DropColumn("dbo.Comments", "Created_by_admin");
            DropColumn("dbo.Comments", "Created_by_current_user");
            DropColumn("dbo.Comments", "User_has_upvoted");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comments", "User_has_upvoted", c => c.Boolean());
            AddColumn("dbo.Comments", "Created_by_current_user", c => c.Boolean());
            AddColumn("dbo.Comments", "Created_by_admin", c => c.Boolean());
            AlterColumn("dbo.Comments", "Creator", c => c.Int());
            DropColumn("dbo.Comments", "Parent");
        }
    }
}
