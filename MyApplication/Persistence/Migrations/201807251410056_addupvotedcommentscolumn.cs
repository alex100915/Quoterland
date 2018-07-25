namespace MyApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addupvotedcommentscolumn : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UpvotedComments",
                c => new
                    {
                        CommentId = c.Int(nullable: false),
                        ApplicationUserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.CommentId, t.ApplicationUserId })
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId, cascadeDelete: true)
                .ForeignKey("dbo.Comments", t => t.CommentId, cascadeDelete: true)
                .Index(t => t.CommentId)
                .Index(t => t.ApplicationUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UpvotedComments", "CommentId", "dbo.Comments");
            DropForeignKey("dbo.UpvotedComments", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.UpvotedComments", new[] { "ApplicationUserId" });
            DropIndex("dbo.UpvotedComments", new[] { "CommentId" });
            DropTable("dbo.UpvotedComments");
        }
    }
}
