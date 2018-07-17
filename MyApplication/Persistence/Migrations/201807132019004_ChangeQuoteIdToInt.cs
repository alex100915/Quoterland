namespace MyApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeQuoteIdToInt : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Learneds", "QuoteId", "dbo.Quotes");
            DropForeignKey("dbo.Learnings", "QuoteId", "dbo.Quotes");
            DropIndex("dbo.Learneds", new[] { "QuoteId" });
            DropIndex("dbo.Learnings", new[] { "QuoteId" });
            DropPrimaryKey("dbo.Learneds");
            DropPrimaryKey("dbo.Quotes");
            DropPrimaryKey("dbo.Learnings");
            AlterColumn("dbo.Learneds", "QuoteId", c => c.Int(nullable: false));
            AlterColumn("dbo.Quotes", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Learnings", "QuoteId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Learneds", new[] { "QuoteId", "ApplicationUserId" });
            AddPrimaryKey("dbo.Quotes", "Id");
            AddPrimaryKey("dbo.Learnings", new[] { "QuoteId", "ApplicationUserId" });
            CreateIndex("dbo.Learneds", "QuoteId");
            CreateIndex("dbo.Learnings", "QuoteId");
            AddForeignKey("dbo.Learneds", "QuoteId", "dbo.Quotes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Learnings", "QuoteId", "dbo.Quotes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Learnings", "QuoteId", "dbo.Quotes");
            DropForeignKey("dbo.Learneds", "QuoteId", "dbo.Quotes");
            DropIndex("dbo.Learnings", new[] { "QuoteId" });
            DropIndex("dbo.Learneds", new[] { "QuoteId" });
            DropPrimaryKey("dbo.Learnings");
            DropPrimaryKey("dbo.Quotes");
            DropPrimaryKey("dbo.Learneds");
            AlterColumn("dbo.Learnings", "QuoteId", c => c.Byte(nullable: false));
            AlterColumn("dbo.Quotes", "Id", c => c.Byte(nullable: false, identity: true));
            AlterColumn("dbo.Learneds", "QuoteId", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.Learnings", new[] { "QuoteId", "ApplicationUserId" });
            AddPrimaryKey("dbo.Quotes", "Id");
            AddPrimaryKey("dbo.Learneds", new[] { "QuoteId", "ApplicationUserId" });
            CreateIndex("dbo.Learnings", "QuoteId");
            CreateIndex("dbo.Learneds", "QuoteId");
            AddForeignKey("dbo.Learnings", "QuoteId", "dbo.Quotes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Learneds", "QuoteId", "dbo.Quotes", "Id", cascadeDelete: true);
        }
    }
}
