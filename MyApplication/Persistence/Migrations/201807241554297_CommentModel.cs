namespace MyApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CommentModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ParentId = c.String(maxLength: 128),
                        Created = c.DateTime(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Content = c.String(),
                        Creator = c.Int(nullable: false),
                        Fullname = c.String(),
                        Profile_picture_url = c.String(),
                        file_url = c.String(),
                        Created_by_admin = c.Boolean(nullable: false),
                        Upvote_count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
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
