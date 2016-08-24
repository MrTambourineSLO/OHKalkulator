namespace OhKalkulator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRelationBetweenAppUserAndObroki : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Obroki", "UporabnikId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Obroki", "UporabnikId");
            AddForeignKey("dbo.Obroki", "UporabnikId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Obroki", "UporabnikId", "dbo.AspNetUsers");
            DropIndex("dbo.Obroki", new[] { "UporabnikId" });
            DropColumn("dbo.Obroki", "UporabnikId");
        }
    }
}
