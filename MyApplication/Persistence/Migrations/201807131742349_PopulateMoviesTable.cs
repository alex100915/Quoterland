namespace MyApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMoviesTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies (Title) VALUES ('Gone with the Wind')");
            Sql("INSERT INTO Movies (Title) VALUES ('The Godfather')");
            Sql("INSERT INTO Movies (Title) VALUES ('On the Waterfront')");
            Sql("INSERT INTO Movies (Title) VALUES ('The Wizard of Oz')");
            Sql("INSERT INTO Movies (Title) VALUES ('Casablanca')");
            Sql("INSERT INTO Movies (Title) VALUES ('Sudden Impact')");
            Sql("INSERT INTO Movies (Title) VALUES ('Sunset Boulevard')");
            Sql("INSERT INTO Movies (Title) VALUES ('Star Wars')");
            Sql("INSERT INTO Movies (Title) VALUES ('All About Eve')");
            Sql("INSERT INTO Movies (Title) VALUES ('Taxi Driver')");
            Sql("INSERT INTO Movies (Title) VALUES ('Cool Hand Luke')");
            Sql("INSERT INTO Movies (Title) VALUES ('Apocalypse Now')");
            Sql("INSERT INTO Movies (Title) VALUES ('Love Story')");
            Sql("INSERT INTO Movies (Title) VALUES ('The Maltese Falcon')");
            Sql("INSERT INTO Movies (Title) VALUES ('In the Heat of the Night')");
            Sql("INSERT INTO Movies (Title) VALUES ('Citizen Kane')");
            Sql("INSERT INTO Movies (Title) VALUES ('White Heat')");
            Sql("INSERT INTO Movies (Title) VALUES ('The Silence of the Lambs')");
            Sql("INSERT INTO Movies (Title) VALUES ('Jerry Maguire')");
            Sql("INSERT INTO Movies (Title) VALUES ('She Done Him Wrong')");
            Sql("INSERT INTO Movies (Title) VALUES ('Midnight Cowboy')");
            Sql("INSERT INTO Movies (Title) VALUES ('A Few Good Men')");
            Sql("INSERT INTO Movies (Title) VALUES ('Grand Hotel')");
            Sql("INSERT INTO Movies (Title) VALUES ('When Harry Met Sally')");
            Sql("INSERT INTO Movies (Title) VALUES ('To Have and Have Not')");
            Sql("INSERT INTO Movies (Title) VALUES ('Jaws')");
            Sql("INSERT INTO Movies (Title) VALUES ('The Terminator')");
            Sql("INSERT INTO Movies (Title) VALUES ('The Pride of the Yankees')");
            Sql("INSERT INTO Movies (Title) VALUES ('Field of Dreams')");
            Sql("INSERT INTO Movies (Title) VALUES ('Forrest Gump')");
            Sql("INSERT INTO Movies (Title) VALUES ('Bonnie and Clyde')");
            Sql("INSERT INTO Movies (Title) VALUES ('The Graduate')");
            Sql("INSERT INTO Movies (Title) VALUES ('The Sixth Sense')");
            Sql("INSERT INTO Movies (Title) VALUES ('A Streetcar Named Desire')");
            Sql("INSERT INTO Movies (Title) VALUES ('Now Voyager')");
            Sql("INSERT INTO Movies (Title) VALUES ('Shane')");
            Sql("INSERT INTO Movies (Title) VALUES ('Some Like It Hot')");
            Sql("INSERT INTO Movies (Title) VALUES ('Frankenstein')");
            Sql("INSERT INTO Movies (Title) VALUES ('Apollo 13')");
            Sql("INSERT INTO Movies (Title) VALUES ('Dirty Harry')");
            Sql("INSERT INTO Movies (Title) VALUES ('Animal Crackers')");
            Sql("INSERT INTO Movies (Title) VALUES ('A League of Their Own')");
            Sql("INSERT INTO Movies (Title) VALUES ('Annie Hall')");
        }

        public override void Down()
        {
            Sql("DELETE FROM Movies");
        }
    }
}
