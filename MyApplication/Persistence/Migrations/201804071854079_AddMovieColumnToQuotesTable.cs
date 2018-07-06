namespace MyApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMovieColumnToQuotesTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Quotes", "MovieId", c => c.Int(nullable: false));
            CreateIndex("dbo.Quotes", "MovieId");
            AddForeignKey("dbo.Quotes", "MovieId", "dbo.Movies", "Id", cascadeDelete: true);
            DropColumn("dbo.Quotes", "MovieName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Quotes", "MovieName", c => c.String());
            DropForeignKey("dbo.Quotes", "MovieId", "dbo.Movies");
            DropIndex("dbo.Quotes", new[] { "MovieId" });
            DropColumn("dbo.Quotes", "MovieId");
        }
    }
}
