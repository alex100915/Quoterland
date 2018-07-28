namespace MyApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProductionTypeToMoviesTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "ProductionTypeId", c => c.Int());
            CreateIndex("dbo.Movies", "ProductionTypeId");
            AddForeignKey("dbo.Movies", "ProductionTypeId", "dbo.ProductionTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "ProductionTypeId", "dbo.ProductionTypes");
            DropIndex("dbo.Movies", new[] { "ProductionTypeId" });
            DropColumn("dbo.Movies", "ProductionTypeId");
        }
    }
}
