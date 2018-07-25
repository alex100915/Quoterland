namespace MyApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changecommentmodel6 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Comments", "Created", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Comments", "Created", c => c.DateTime(nullable: false));
        }
    }
}
