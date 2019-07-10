namespace PracticeProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addartistid : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Events", name: "Artist_Id", newName: "ArtistId");
            RenameIndex(table: "dbo.Events", name: "IX_Artist_Id", newName: "IX_ArtistId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Events", name: "IX_ArtistId", newName: "IX_Artist_Id");
            RenameColumn(table: "dbo.Events", name: "ArtistId", newName: "Artist_Id");
        }
    }
}
