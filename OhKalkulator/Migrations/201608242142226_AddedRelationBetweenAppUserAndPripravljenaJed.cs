namespace OhKalkulator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRelationBetweenAppUserAndPripravljenaJed : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PripravljeneJedi", "UporabnikId", c => c.String(maxLength: 128));
            CreateIndex("dbo.PripravljeneJedi", "UporabnikId");
            AddForeignKey("dbo.PripravljeneJedi", "UporabnikId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PripravljeneJedi", "UporabnikId", "dbo.AspNetUsers");
            DropIndex("dbo.PripravljeneJedi", new[] { "UporabnikId" });
            DropColumn("dbo.PripravljeneJedi", "UporabnikId");
        }
    }
}
