namespace OhKalkulator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedKategorijeZivilTableAndRelationshipPropertiesToZivilaAndKZ : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.KategorijeZivil",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ime = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Zivila", "KategorijaZivilaId", c => c.Int(nullable: false));
            CreateIndex("dbo.Zivila", "KategorijaZivilaId");
            AddForeignKey("dbo.Zivila", "KategorijaZivilaId", "dbo.KategorijeZivil", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Zivila", "KategorijaZivilaId", "dbo.KategorijeZivil");
            DropIndex("dbo.Zivila", new[] { "KategorijaZivilaId" });
            DropColumn("dbo.Zivila", "KategorijaZivilaId");
            DropTable("dbo.KategorijeZivil");
        }
    }
}
