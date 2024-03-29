namespace MyApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTranslationToLearningsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Learnings", "Translation", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Learnings", "Translation");
        }
    }
}
