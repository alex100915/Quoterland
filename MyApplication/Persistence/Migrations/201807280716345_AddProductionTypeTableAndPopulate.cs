namespace MyApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProductionTypeTableAndPopulate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductionTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            Sql("INSERT INTO productiontypes VALUES ('Movie')");
            Sql("INSERT INTO productiontypes VALUES ('TV Show')");
        }
        
        public override void Down()
        {
            DropTable("dbo.ProductionTypes");
        }
    }
}
