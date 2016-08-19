namespace OhKalkulator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedObrokiTableAndRelationshipToPripravljeneJedi : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Obroki",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImeObroka = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PripravljeneJediObroki",
                c => new
                    {
                        PripravljenaJedId = c.Int(nullable: false),
                        ObrokId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PripravljenaJedId, t.ObrokId })
                .ForeignKey("dbo.Obroki", t => t.PripravljenaJedId, cascadeDelete: true)
                .ForeignKey("dbo.PripravljeneJedi", t => t.ObrokId, cascadeDelete: true)
                .Index(t => t.PripravljenaJedId)
                .Index(t => t.ObrokId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PripravljeneJediObroki", "ObrokId", "dbo.PripravljeneJedi");
            DropForeignKey("dbo.PripravljeneJediObroki", "PripravljenaJedId", "dbo.Obroki");
            DropIndex("dbo.PripravljeneJediObroki", new[] { "ObrokId" });
            DropIndex("dbo.PripravljeneJediObroki", new[] { "PripravljenaJedId" });
            DropTable("dbo.PripravljeneJediObroki");
            DropTable("dbo.Obroki");
        }
    }
}
