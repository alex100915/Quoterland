namespace MyApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changecommentmodel7 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "ParentId", "dbo.AspNetUsers");
            DropIndex("dbo.Comments", new[] { "ParentId" });
            DropColumn("dbo.Comments", "ParentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comments", "ParentId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Comments", "ParentId");
            AddForeignKey("dbo.Comments", "ParentId", "dbo.AspNetUsers", "Id");
        }
    }
}
