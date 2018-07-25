namespace MyApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class PopulateMissingColumnsForMoviesManager : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE aspnetusers SET fullname='Movies Manager', profile_picture_url='../../images/admin-user-icon.jpg' WHERE Id='4b8cdc5e-f4f7-4a68-9b88-d093f33898cf'");
        }

        public override void Down()
        {
            Sql("UPDATE aspnetusers SET fullname='', profile_picture_url='' WHERE Id='4b8cdc5e-f4f7-4a68-9b88-d093f33898cf'");
        }
    }
}
