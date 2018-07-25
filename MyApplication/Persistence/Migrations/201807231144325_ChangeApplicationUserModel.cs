namespace MyApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeApplicationUserModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Fullname", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "Profile_picture_url", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Profile_picture_url");
            DropColumn("dbo.AspNetUsers", "Fullname");
        }
    }
}
