namespace MyApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataAnnotations : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Quotes", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Quotes", new[] { "UserId" });
            AlterColumn("dbo.Movies", "Title", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Quotes", "Content", c => c.String(nullable: false, maxLength: 300));
            AlterColumn("dbo.Quotes", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Quotes", "PhraseToLearn", c => c.String(nullable: false, maxLength: 60));
            AlterColumn("dbo.Quotes", "YoutubeLink", c => c.String(nullable: false));
            CreateIndex("dbo.Quotes", "UserId");
            AddForeignKey("dbo.Quotes", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Quotes", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Quotes", new[] { "UserId" });
            AlterColumn("dbo.Quotes", "YoutubeLink", c => c.String());
            AlterColumn("dbo.Quotes", "PhraseToLearn", c => c.String());
            AlterColumn("dbo.Quotes", "UserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Quotes", "Content", c => c.String());
            AlterColumn("dbo.Movies", "Title", c => c.String());
            CreateIndex("dbo.Quotes", "UserId");
            AddForeignKey("dbo.Quotes", "UserId", "dbo.AspNetUsers", "Id");
        }
    }
}
