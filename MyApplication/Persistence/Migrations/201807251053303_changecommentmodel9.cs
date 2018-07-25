namespace MyApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changecommentmodel9 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "QuoteId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "QuoteId");
        }
    }
}
