namespace OhKalkulator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedLeftAndRightKeyMappingForPripravljeneJediObroki : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.PripravljeneJediObroki", name: "PripravljenaJedId", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.PripravljeneJediObroki", name: "ObrokId", newName: "PripravljenaJedId");
            RenameColumn(table: "dbo.PripravljeneJediObroki", name: "__mig_tmp__0", newName: "ObrokId");
            RenameIndex(table: "dbo.PripravljeneJediObroki", name: "IX_PripravljenaJedId", newName: "__mig_tmp__0");
            RenameIndex(table: "dbo.PripravljeneJediObroki", name: "IX_ObrokId", newName: "IX_PripravljenaJedId");
            RenameIndex(table: "dbo.PripravljeneJediObroki", name: "__mig_tmp__0", newName: "IX_ObrokId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.PripravljeneJediObroki", name: "IX_ObrokId", newName: "__mig_tmp__0");
            RenameIndex(table: "dbo.PripravljeneJediObroki", name: "IX_PripravljenaJedId", newName: "IX_ObrokId");
            RenameIndex(table: "dbo.PripravljeneJediObroki", name: "__mig_tmp__0", newName: "IX_PripravljenaJedId");
            RenameColumn(table: "dbo.PripravljeneJediObroki", name: "ObrokId", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.PripravljeneJediObroki", name: "PripravljenaJedId", newName: "ObrokId");
            RenameColumn(table: "dbo.PripravljeneJediObroki", name: "__mig_tmp__0", newName: "PripravljenaJedId");
        }
    }
}
