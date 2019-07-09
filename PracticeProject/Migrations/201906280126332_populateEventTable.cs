namespace PracticeProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateEventTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Types(Id, Name) VALUES(1, 'Jazz')");
            Sql("INSERT INTO Types(Id, Name) VALUES(2, 'Blues')");
            Sql("INSERT INTO Types(Id, Name) VALUES(3, 'Blues')");
            Sql("INSERT INTO Types(Id, Name) VALUES(4, 'Countryside')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM Types WHERE Id IN (1,2,3,4)");
        }
    }
}
