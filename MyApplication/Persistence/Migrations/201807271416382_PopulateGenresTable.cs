namespace MyApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenresTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO genres VALUES ('Action')");
            Sql("INSERT INTO genres VALUES ('Adventure')");
            Sql("INSERT INTO genres VALUES ('Animation')");
            Sql("INSERT INTO genres VALUES ('Biography')");
            Sql("INSERT INTO genres VALUES ('Comedy')");
            Sql("INSERT INTO genres VALUES ('Crime')");
            Sql("INSERT INTO genres VALUES ('Drama')");
            Sql("INSERT INTO genres VALUES ('Family')");
            Sql("INSERT INTO genres VALUES ('Fantasy')");
            Sql("INSERT INTO genres VALUES ('Film-Noir')");
            Sql("INSERT INTO genres VALUES ('History')");
            Sql("INSERT INTO genres VALUES ('Horror')");
            Sql("INSERT INTO genres VALUES ('Music')");
            Sql("INSERT INTO genres VALUES ('Musical')");
            Sql("INSERT INTO genres VALUES ('Mystery')");
            Sql("INSERT INTO genres VALUES ('Romance')");
            Sql("INSERT INTO genres VALUES ('Sci-Fi')");
            Sql("INSERT INTO genres VALUES ('Sport')");
            Sql("INSERT INTO genres VALUES ('Thriller')");
            Sql("INSERT INTO genres VALUES ('War')");
            Sql("INSERT INTO genres VALUES ('Western')");
        }

        public override void Down()
        {
            Sql("DELETE FROM genres");
        }
    }
}
