namespace MyApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StoringLearnedAndLearningQuotes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Learneds",
                c => new
                    {
                        QuoteId = c.Byte(nullable: false),
                        ApplicationUserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.QuoteId, t.ApplicationUserId })
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .ForeignKey("dbo.Quotes", t => t.QuoteId, cascadeDelete: true)
                .Index(t => t.QuoteId)
                .Index(t => t.ApplicationUserId);
            
            CreateTable(
                "dbo.Learnings",
                c => new
                    {
                        QuoteId = c.Byte(nullable: false),
                        ApplicationUserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.QuoteId, t.ApplicationUserId })
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .ForeignKey("dbo.Quotes", t => t.QuoteId, cascadeDelete: true)
                .Index(t => t.QuoteId)
                .Index(t => t.ApplicationUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Learnings", "QuoteId", "dbo.Quotes");
            DropForeignKey("dbo.Learnings", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Learneds", "QuoteId", "dbo.Quotes");
            DropForeignKey("dbo.Learneds", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Learnings", new[] { "ApplicationUserId" });
            DropIndex("dbo.Learnings", new[] { "QuoteId" });
            DropIndex("dbo.Learneds", new[] { "ApplicationUserId" });
            DropIndex("dbo.Learneds", new[] { "QuoteId" });
            DropTable("dbo.Learnings");
            DropTable("dbo.Learneds");
        }
    }
}
