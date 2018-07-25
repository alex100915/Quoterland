namespace MyApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changecommentmodel4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "ParentId", "dbo.AspNetUsers");
            DropIndex("dbo.Comments", new[] { "ParentId" });
            DropTable("dbo.Comments");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false),
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
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Comments", "ParentId");
            AddForeignKey("dbo.Comments", "ParentId", "dbo.AspNetUsers", "Id");
        }
    }
}
