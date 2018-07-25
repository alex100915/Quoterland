namespace MyApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changecommentmodel5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        Id = c.String(),
                        ParentId = c.String(maxLength: 128),
                        Created = c.DateTime(nullable: false),
                        Modified = c.DateTime(),
                        Content = c.String(),
                        Creator = c.Int(),
                        Fullname = c.String(),
                        Profile_picture_url = c.String(),
                        file_url = c.String(),
                        Created_by_admin = c.Boolean(),
                        Created_by_current_user = c.Boolean(),
                        Upvote_count = c.Int(),
                        User_has_upvoted = c.Boolean(),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.AspNetUsers", t => t.ParentId)
                .Index(t => t.ParentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "ParentId", "dbo.AspNetUsers");
            DropIndex("dbo.Comments", new[] { "ParentId" });
            DropTable("dbo.Comments");
        }
    }
}
