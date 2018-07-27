namespace MyApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenreIdsToExistingMovies : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Movies SET GenreId='7' WHERE Title=('Gone with the Wind')");
            Sql("UPDATE Movies SET GenreId='6' WHERE Title=('The Godfather')");
            Sql("UPDATE Movies SET GenreId='6' WHERE Title=('On the Waterfront')");
            Sql("UPDATE Movies SET GenreId='2' WHERE Title=('The Wizard of Oz')");
            Sql("UPDATE Movies SET GenreId='7' WHERE Title=('Casablanca')");
            Sql("UPDATE Movies SET GenreId='1' WHERE Title=('Sudden Impact')");
            Sql("UPDATE Movies SET GenreId='7' WHERE Title=('Sunset Boulevard')");
            Sql("UPDATE Movies SET GenreId='1' WHERE Title=('Star Wars')");
            Sql("UPDATE Movies SET GenreId='7' WHERE Title=('All About Eve')");
            Sql("UPDATE Movies SET GenreId='6' WHERE Title=('Taxi Driver')");
            Sql("UPDATE Movies SET GenreId='6' WHERE Title=('Cool Hand Luke')");
            Sql("UPDATE Movies SET GenreId='7' WHERE Title=('Apocalypse Now')");
            Sql("UPDATE Movies SET GenreId='7' WHERE Title=('Love Story')");
            Sql("UPDATE Movies SET GenreId='10' WHERE Title=('The Maltese Falcon')");
            Sql("UPDATE Movies SET GenreId='6' WHERE Title=('In the Heat of the Night')");
            Sql("UPDATE Movies SET GenreId='7' WHERE Title=('Citizen Kane')");
            Sql("UPDATE Movies SET GenreId='1' WHERE Title=('White Heat')");
            Sql("UPDATE Movies SET GenreId='6' WHERE Title=('The Silence of the Lambs')");
            Sql("UPDATE Movies SET GenreId='5' WHERE Title=('Jerry Maguire')");
            Sql("UPDATE Movies SET GenreId='5' WHERE Title=('She Done Him Wrong')");
            Sql("UPDATE Movies SET GenreId='7' WHERE Title=('Midnight Cowboy')");
            Sql("UPDATE Movies SET GenreId='7' WHERE Title=('A Few Good Men')");
            Sql("UPDATE Movies SET GenreId='7' WHERE Title=('Grand Hotel')");
            Sql("UPDATE Movies SET GenreId='5' WHERE Title=('When Harry Met Sally')");
            Sql("UPDATE Movies SET GenreId='2' WHERE Title=('To Have and Have Not')");
            Sql("UPDATE Movies SET GenreId='2' WHERE Title=('Jaws')");
            Sql("UPDATE Movies SET GenreId='1' WHERE Title=('The Terminator')");
            Sql("UPDATE Movies SET GenreId='4' WHERE Title=('The Pride of the Yankees')");
            Sql("UPDATE Movies SET GenreId='7' WHERE Title=('Field of Dreams')");
            Sql("UPDATE Movies SET GenreId='7' WHERE Title=('Forrest Gump')");
            Sql("UPDATE Movies SET GenreId='1' WHERE Title=('Bonnie and Clyde')");
            Sql("UPDATE Movies SET GenreId='5' WHERE Title=('The Graduate')");
            Sql("UPDATE Movies SET GenreId='7' WHERE Title=('The Sixth Sense')");
            Sql("UPDATE Movies SET GenreId='7' WHERE Title=('A Streetcar Named Desire')");
            Sql("UPDATE Movies SET GenreId='7' WHERE Title=('Now Voyager')");
            Sql("UPDATE Movies SET GenreId='7' WHERE Title=('Shane')");
            Sql("UPDATE Movies SET GenreId='5' WHERE Title=('Some Like It Hot')");
            Sql("UPDATE Movies SET GenreId='7' WHERE Title=('Frankenstein')");
            Sql("UPDATE Movies SET GenreId='2' WHERE Title=('Apollo 13')");
            Sql("UPDATE Movies SET GenreId='1' WHERE Title=('Dirty Harry')");
            Sql("UPDATE Movies SET GenreId='5' WHERE Title=('Animal Crackers')");
            Sql("UPDATE Movies SET GenreId='5' WHERE Title=('A League of Their Own')");
            Sql("UPDATE Movies SET GenreId='5' WHERE Title=('Annie Hall')");
        }
        
        public override void Down()
        {
            Sql("UPDATE Movies SET GenreId=null WHERE Title=('Gone with the Wind')");
            Sql("UPDATE Movies SET GenreId=null WHERE Title=('The Godfather')");
            Sql("UPDATE Movies SET GenreId=null WHERE Title=('On the Waterfront')");
            Sql("UPDATE Movies SET GenreId=null WHERE Title=('The Wizard of Oz')");
            Sql("UPDATE Movies SET GenreId=null WHERE Title=('Casablanca')");
            Sql("UPDATE Movies SET GenreId=null WHERE Title=('Sudden Impact')");
            Sql("UPDATE Movies SET GenreId=null WHERE Title=('Sunset Boulevard')");
            Sql("UPDATE Movies SET GenreId=null WHERE Title=('Star Wars')");
            Sql("UPDATE Movies SET GenreId=null WHERE Title=('All About Eve')");
            Sql("UPDATE Movies SET GenreId=null WHERE Title=('Taxi Driver')");
            Sql("UPDATE Movies SET GenreId=null WHERE Title=('Cool Hand Luke')");
            Sql("UPDATE Movies SET GenreId=null WHERE Title=('Apocalypse Now')");
            Sql("UPDATE Movies SET GenreId=null WHERE Title=('Love Story')");
            Sql("UPDATE Movies SET GenreId=null WHERE Title=('The Maltese Falcon')");
            Sql("UPDATE Movies SET GenreId=null WHERE Title=('In the Heat of the Night')");
            Sql("UPDATE Movies SET GenreId=null WHERE Title=('Citizen Kane')");
            Sql("UPDATE Movies SET GenreId=null WHERE Title=('White Heat')");
            Sql("UPDATE Movies SET GenreId=null WHERE Title=('The Silence of the Lambs')");
            Sql("UPDATE Movies SET GenreId=null WHERE Title=('Jerry Maguire')");
            Sql("UPDATE Movies SET GenreId=null WHERE Title=('She Done Him Wrong')");
            Sql("UPDATE Movies SET GenreId=null WHERE Title=('Midnight Cowboy')");
            Sql("UPDATE Movies SET GenreId=null WHERE Title=('A Few Good Men')");
            Sql("UPDATE Movies SET GenreId=null WHERE Title=('Grand Hotel')");
            Sql("UPDATE Movies SET GenreId=null WHERE Title=('When Harry Met Sally')");
            Sql("UPDATE Movies SET GenreId=null WHERE Title=('To Have and Have Not')");
            Sql("UPDATE Movies SET GenreId=null WHERE Title=('Jaws')");
            Sql("UPDATE Movies SET GenreId=null WHERE Title=('The Terminator')");
            Sql("UPDATE Movies SET GenreId=null WHERE Title=('The Pride of the Yankees')");
            Sql("UPDATE Movies SET GenreId=null WHERE Title=('Field of Dreams')");
            Sql("UPDATE Movies SET GenreId=null WHERE Title=('Forrest Gump')");
            Sql("UPDATE Movies SET GenreId=null WHERE Title=('Bonnie and Clyde')");
            Sql("UPDATE Movies SET GenreId=null WHERE Title=('The Graduate')");
            Sql("UPDATE Movies SET GenreId=null WHERE Title=('The Sixth Sense')");
            Sql("UPDATE Movies SET GenreId=null WHERE Title=('A Streetcar Named Desire')");
            Sql("UPDATE Movies SET GenreId=null WHERE Title=('Now Voyager')");
            Sql("UPDATE Movies SET GenreId=null WHERE Title=('Shane')");
            Sql("UPDATE Movies SET GenreId=null WHERE Title=('Some Like It Hot')");
            Sql("UPDATE Movies SET GenreId=null WHERE Title=('Frankenstein')");
            Sql("UPDATE Movies SET GenreId=null WHERE Title=('Apollo 13')");
            Sql("UPDATE Movies SET GenreId=null WHERE Title=('Dirty Harry')");
            Sql("UPDATE Movies SET GenreId=null WHERE Title=('Animal Crackers')");
            Sql("UPDATE Movies SET GenreId=null WHERE Title=('A League of Their Own')");
            Sql("UPDATE Movies SET GenreId=null WHERE Title=('Annie Hall')");
        }
    }
}
