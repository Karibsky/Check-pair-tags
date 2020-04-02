namespace TestTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Logs",
                c => new
                    {
                        LogID = c.Int(nullable: false, identity: true),
                        Time = c.DateTime(nullable: false),
                        Result = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.LogID);
            
            CreateTable(
                "dbo.Texts",
                c => new
                    {
                        TextID = c.Int(nullable: false, identity: true),
                        TextSource = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.TextID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Texts");
            DropTable("dbo.Logs");
        }
    }
}
