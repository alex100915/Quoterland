namespace MyApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class YoutubeLinkToQuote : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Quotes", "YoutubeLink", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Quotes", "YoutubeLink");
        }
    }
}
