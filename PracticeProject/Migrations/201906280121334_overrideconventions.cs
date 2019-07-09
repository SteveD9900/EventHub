namespace PracticeProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class overrideconventions : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Events", "Artist_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Events", "Type_Id", "dbo.Types");
            DropIndex("dbo.Events", new[] { "Artist_Id" });
            DropIndex("dbo.Events", new[] { "Type_Id" });
            AlterColumn("dbo.Events", "Venue", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Events", "Artist_Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Events", "Type_Id", c => c.Byte(nullable: false));
            AlterColumn("dbo.Types", "Name", c => c.String(nullable: false, maxLength: 255));
            CreateIndex("dbo.Events", "Artist_Id");
            CreateIndex("dbo.Events", "Type_Id");
            AddForeignKey("dbo.Events", "Artist_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Events", "Type_Id", "dbo.Types", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "Type_Id", "dbo.Types");
            DropForeignKey("dbo.Events", "Artist_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Events", new[] { "Type_Id" });
            DropIndex("dbo.Events", new[] { "Artist_Id" });
            AlterColumn("dbo.Types", "Name", c => c.String());
            AlterColumn("dbo.Events", "Type_Id", c => c.Byte());
            AlterColumn("dbo.Events", "Artist_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Events", "Venue", c => c.String());
            CreateIndex("dbo.Events", "Type_Id");
            CreateIndex("dbo.Events", "Artist_Id");
            AddForeignKey("dbo.Events", "Type_Id", "dbo.Types", "Id");
            AddForeignKey("dbo.Events", "Artist_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
