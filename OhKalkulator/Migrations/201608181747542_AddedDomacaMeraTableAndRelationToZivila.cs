namespace OhKalkulator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDomacaMeraTableAndRelationToZivila : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DomaceMere",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImeMere = c.String(nullable: false, maxLength: 255),
                        Razmerje = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Zivila", "DomacaMeraId", c => c.Int(nullable: false));
            CreateIndex("dbo.Zivila", "DomacaMeraId");
            AddForeignKey("dbo.Zivila", "DomacaMeraId", "dbo.DomaceMere", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Zivila", "DomacaMeraId", "dbo.DomaceMere");
            DropIndex("dbo.Zivila", new[] { "DomacaMeraId" });
            DropColumn("dbo.Zivila", "DomacaMeraId");
            DropTable("dbo.DomaceMere");
        }
    }
}
