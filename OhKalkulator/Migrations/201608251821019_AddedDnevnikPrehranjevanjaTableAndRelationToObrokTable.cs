namespace OhKalkulator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDnevnikPrehranjevanjaTableAndRelationToObrokTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DnevnikiPrehranjevanja",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Datum = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        TipObroka = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Obroki", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DnevnikiPrehranjevanja", "Id", "dbo.Obroki");
            DropIndex("dbo.DnevnikiPrehranjevanja", new[] { "Id" });
            DropTable("dbo.DnevnikiPrehranjevanja");
        }
    }
}
