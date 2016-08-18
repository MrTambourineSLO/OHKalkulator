namespace OhKalkulator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPripravljenaJedTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PripravljeneJedi",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ime = c.String(nullable: false, maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PripravljeneJediZivila",
                c => new
                    {
                        PripravljenaJedId = c.Int(nullable: false),
                        ZiviloId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PripravljenaJedId, t.ZiviloId })
                .ForeignKey("dbo.PripravljeneJedi", t => t.PripravljenaJedId, cascadeDelete: true)
                .ForeignKey("dbo.Zivila", t => t.ZiviloId, cascadeDelete: true)
                .Index(t => t.PripravljenaJedId)
                .Index(t => t.ZiviloId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PripravljeneJediZivila", "ZiviloId", "dbo.Zivila");
            DropForeignKey("dbo.PripravljeneJediZivila", "PripravljenaJedId", "dbo.PripravljeneJedi");
            DropIndex("dbo.PripravljeneJediZivila", new[] { "ZiviloId" });
            DropIndex("dbo.PripravljeneJediZivila", new[] { "PripravljenaJedId" });
            DropTable("dbo.PripravljeneJediZivila");
            DropTable("dbo.PripravljeneJedi");
        }
    }
}
