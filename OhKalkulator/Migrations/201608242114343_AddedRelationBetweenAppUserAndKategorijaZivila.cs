namespace OhKalkulator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRelationBetweenAppUserAndKategorijaZivila : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.KategorijeZivil", "UporabnikId", c => c.String(maxLength: 128));
            CreateIndex("dbo.KategorijeZivil", "UporabnikId");
            AddForeignKey("dbo.KategorijeZivil", "UporabnikId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.KategorijeZivil", "UporabnikId", "dbo.AspNetUsers");
            DropIndex("dbo.KategorijeZivil", new[] { "UporabnikId" });
            DropColumn("dbo.KategorijeZivil", "UporabnikId");
        }
    }
}
