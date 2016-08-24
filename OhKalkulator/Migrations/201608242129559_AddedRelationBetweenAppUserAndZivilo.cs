namespace OhKalkulator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRelationBetweenAppUserAndZivilo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Zivila", "UporabnikId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Zivila", "UporabnikId");
            AddForeignKey("dbo.Zivila", "UporabnikId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Zivila", "UporabnikId", "dbo.AspNetUsers");
            DropIndex("dbo.Zivila", new[] { "UporabnikId" });
            DropColumn("dbo.Zivila", "UporabnikId");
        }
    }
}
