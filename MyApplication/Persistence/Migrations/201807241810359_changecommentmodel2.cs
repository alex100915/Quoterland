namespace MyApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changecommentmodel2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Comments", "Modified", c => c.DateTime());
            AlterColumn("dbo.Comments", "Creator", c => c.Int());
            AlterColumn("dbo.Comments", "Created_by_admin", c => c.Boolean());
            AlterColumn("dbo.Comments", "Created_by_current_user", c => c.Boolean());
            AlterColumn("dbo.Comments", "Upvote_count", c => c.Int());
            AlterColumn("dbo.Comments", "User_has_upvoted", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Comments", "User_has_upvoted", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Comments", "Upvote_count", c => c.Int(nullable: false));
            AlterColumn("dbo.Comments", "Created_by_current_user", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Comments", "Created_by_admin", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Comments", "Creator", c => c.Int(nullable: false));
            AlterColumn("dbo.Comments", "Modified", c => c.DateTime(nullable: false));
        }
    }
}
