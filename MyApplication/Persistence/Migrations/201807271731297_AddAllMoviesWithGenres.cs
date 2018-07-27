namespace MyApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAllMoviesWithGenres : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "GenreId", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "GenreId" });
            AlterColumn("dbo.Movies", "GenreId", c => c.Int(nullable: false));
            CreateIndex("dbo.Movies", "GenreId");
            AddForeignKey("dbo.Movies", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);

            Sql("INSERT INTO Movies (Title,GenreId) VALUES ('Gone with the Wind',7)");
            Sql("INSERT INTO Movies (Title,GenreId) VALUES ('The Godfather',6)");
            Sql("INSERT INTO Movies (Title,GenreId) VALUES ('On the Waterfront',6)");
            Sql("INSERT INTO Movies (Title,GenreId) VALUES ('The Wizard of Oz',2)");
            Sql("INSERT INTO Movies (Title,GenreId) VALUES ('Casablanca',7)");
            Sql("INSERT INTO Movies (Title,GenreId) VALUES ('Sudden Impact',1)");
            Sql("INSERT INTO Movies (Title,GenreId) VALUES ('Sunset Boulevard',7)");
            Sql("INSERT INTO Movies (Title,GenreId) VALUES ('Star Wars',1)");
            Sql("INSERT INTO Movies (Title,GenreId) VALUES ('All About Eve',7)");
            Sql("INSERT INTO Movies (Title,GenreId) VALUES ('Taxi Driver',6)");
            Sql("INSERT INTO Movies (Title,GenreId) VALUES ('Cool Hand Luke',6)");
            Sql("INSERT INTO Movies (Title,GenreId) VALUES ('Apocalypse Now',7)");
            Sql("INSERT INTO Movies (Title,GenreId) VALUES ('Love Story',7)");
            Sql("INSERT INTO Movies (Title,GenreId) VALUES ('The Maltese Falcon',10)");
            Sql("INSERT INTO Movies (Title,GenreId) VALUES ('In the Heat of the Night',6)");
            Sql("INSERT INTO Movies (Title,GenreId) VALUES ('Citizen Kane',7)");
            Sql("INSERT INTO Movies (Title,GenreId) VALUES ('White Heat',1)");
            Sql("INSERT INTO Movies (Title,GenreId) VALUES ('The Silence of the Lambs',6)");
            Sql("INSERT INTO Movies (Title,GenreId) VALUES ('Jerry Maguire',5)");
            Sql("INSERT INTO Movies (Title,GenreId) VALUES ('She Done Him Wrong',5)");
            Sql("INSERT INTO Movies (Title,GenreId) VALUES ('Midnight Cowboy',7)");
            Sql("INSERT INTO Movies (Title,GenreId) VALUES ('A Few Good Men',7)");
            Sql("INSERT INTO Movies (Title,GenreId) VALUES ('Grand Hotel',7)");
            Sql("INSERT INTO Movies (Title,GenreId) VALUES ('When Harry Met Sally',5)");
            Sql("INSERT INTO Movies (Title,GenreId) VALUES ('To Have and Have Not',2)");
            Sql("INSERT INTO Movies (Title,GenreId) VALUES ('Jaws',2)");
            Sql("INSERT INTO Movies (Title,GenreId) VALUES ('The Terminator',1)");
            Sql("INSERT INTO Movies (Title,GenreId) VALUES ('The Pride of the Yankees',4)");
            Sql("INSERT INTO Movies (Title,GenreId) VALUES ('Field of Dreams',7)");
            Sql("INSERT INTO Movies (Title,GenreId) VALUES ('Forrest Gump',7)");
            Sql("INSERT INTO Movies (Title,GenreId) VALUES ('Bonnie and Clyde',1)");
            Sql("INSERT INTO Movies (Title,GenreId) VALUES ('The Graduate',5)");
            Sql("INSERT INTO Movies (Title,GenreId) VALUES ('The Sixth Sense',7)");
            Sql("INSERT INTO Movies (Title,GenreId) VALUES ('A Streetcar Named Desire',7)");
            Sql("INSERT INTO Movies (Title,GenreId) VALUES ('Now Voyager',7)");
            Sql("INSERT INTO Movies (Title,GenreId) VALUES ('Shane',7)");
            Sql("INSERT INTO Movies (Title,GenreId) VALUES ('Some Like It Hot',5)");
            Sql("INSERT INTO Movies (Title,GenreId) VALUES ('Frankenstein',7)");
            Sql("INSERT INTO Movies (Title,GenreId) VALUES ('Apollo 13',2)");
            Sql("INSERT INTO Movies (Title,GenreId) VALUES ('Dirty Harry',1)");
            Sql("INSERT INTO Movies (Title,GenreId) VALUES ('Animal Crackers',5)");
            Sql("INSERT INTO Movies (Title,GenreId) VALUES ('A League of Their Own',5)");
            Sql("INSERT INTO Movies (Title,GenreId) VALUES ('Annie Hall',5)");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "GenreId", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "GenreId" });
            AlterColumn("dbo.Movies", "GenreId", c => c.Int());
            CreateIndex("dbo.Movies", "GenreId");
            AddForeignKey("dbo.Movies", "GenreId", "dbo.Genres", "Id");

            Sql("DELETE FROM movies");
        }
    }
}
