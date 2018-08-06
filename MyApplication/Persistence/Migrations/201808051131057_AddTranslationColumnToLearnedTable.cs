namespace MyApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTranslationColumnToLearnedTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Learneds", "Translation", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Learneds", "Translation");
        }
    }
}
