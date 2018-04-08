namespace MyApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMovies : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies (Title) VALUES ('That 70s Show')");
            Sql("INSERT INTO Movies (Title) VALUES ('Trailer Park Boys')");
            Sql("INSERT INTO Movies (Title) VALUES ('Friends')");
            Sql("INSERT INTO Movies (Title) VALUES ('The Office')");
            Sql("INSERT INTO Movies (Title) VALUES ('How I Met Your Mother')");
            Sql("INSERT INTO Movies (Title) VALUES ('The Big Bang Theory')");
            Sql("INSERT INTO Movies (Title) VALUES ('Californication')");
            Sql("INSERT INTO Movies (Title) VALUES ('2 Broke Girls')");
        }

        public override void Down()
        {
            Sql("DELETE FROM Movies");
        }
    }
}
