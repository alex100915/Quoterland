namespace MyApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenreTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Quotes", "GenreId", c => c.Int());
            CreateIndex("dbo.Quotes", "GenreId");
            AddForeignKey("dbo.Quotes", "GenreId", "dbo.Genres", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Quotes", "GenreId", "dbo.Genres");
            DropIndex("dbo.Quotes", new[] { "GenreId" });
            DropColumn("dbo.Quotes", "GenreId");
            DropTable("dbo.Genres");
        }
    }
}
