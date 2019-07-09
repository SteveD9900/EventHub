namespace PracticeProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changes : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Types", newName: "TypeEs");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.TypeEs", newName: "Types");
        }
    }
}
