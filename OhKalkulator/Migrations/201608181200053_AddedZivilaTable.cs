namespace OhKalkulator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedZivilaTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Zivila",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SifraGorenje = c.Int(),
                        Ime = c.String(nullable: false, maxLength: 255),
                        TezaVGramih = c.Int(nullable: false),
                        OhKoeficient = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            // Privzeta vrednost za težo v gramih naj bo 1 (gram)
            AlterColumn("Zivila", "TezaVGramih", c => c.Int(nullable: false, defaultValue: 1));
        }
        
        public override void Down()
        {
            DropTable("dbo.Zivila");
        }
    }
}
