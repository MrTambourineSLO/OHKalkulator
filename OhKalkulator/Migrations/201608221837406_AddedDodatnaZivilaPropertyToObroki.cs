namespace OhKalkulator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDodatnaZivilaPropertyToObroki : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ObrokiZivila",
                c => new
                    {
                        ObrokId = c.Int(nullable: false),
                        ZiviloId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ObrokId, t.ZiviloId })
                .ForeignKey("dbo.Obroki", t => t.ObrokId, cascadeDelete: true)
                .ForeignKey("dbo.Zivila", t => t.ZiviloId, cascadeDelete: true)
                .Index(t => t.ObrokId)
                .Index(t => t.ZiviloId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ObrokiZivila", "ZiviloId", "dbo.Zivila");
            DropForeignKey("dbo.ObrokiZivila", "ObrokId", "dbo.Obroki");
            DropIndex("dbo.ObrokiZivila", new[] { "ZiviloId" });
            DropIndex("dbo.ObrokiZivila", new[] { "ObrokId" });
            DropTable("dbo.ObrokiZivila");
        }
    }
}
