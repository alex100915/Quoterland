namespace MyApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeLengthAttributesInQuotesTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Quotes", "Content", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Quotes", "PhraseToLearn", c => c.String(nullable: false, maxLength: 40));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Quotes", "PhraseToLearn", c => c.String(nullable: false, maxLength: 60));
            AlterColumn("dbo.Quotes", "Content", c => c.String(nullable: false, maxLength: 300));
        }
    }
}
