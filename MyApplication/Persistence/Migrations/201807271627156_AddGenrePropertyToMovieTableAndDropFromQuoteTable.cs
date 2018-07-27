namespace MyApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenrePropertyToMovieTableAndDropFromQuoteTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Quotes", "GenreId", "dbo.Genres");
            DropIndex("dbo.Quotes", new[] { "GenreId" });
            AddColumn("dbo.Movies", "GenreId", c => c.Int());
            CreateIndex("dbo.Movies", "GenreId");
            AddForeignKey("dbo.Movies", "GenreId", "dbo.Genres", "Id");
            DropColumn("dbo.Quotes", "GenreId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Quotes", "GenreId", c => c.Int());
            DropForeignKey("dbo.Movies", "GenreId", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "GenreId" });
            DropColumn("dbo.Movies", "GenreId");
            CreateIndex("dbo.Quotes", "GenreId");
            AddForeignKey("dbo.Quotes", "GenreId", "dbo.Genres", "Id");
        }
    }
}
