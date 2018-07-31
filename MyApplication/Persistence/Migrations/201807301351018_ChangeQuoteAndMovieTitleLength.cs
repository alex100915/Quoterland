namespace MyApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeQuoteAndMovieTitleLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Quotes", "Content", c => c.String(nullable: false, maxLength: 400));
            AlterColumn("dbo.Movies", "Title", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "Title", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Quotes", "Content", c => c.String(nullable: false, maxLength: 200));
        }
    }
}
