namespace MyApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewMovies : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies (Title) VALUES ('Two and a half Men')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM Movies WHERE Title='Two and a half Men'");
        }
    }
}
