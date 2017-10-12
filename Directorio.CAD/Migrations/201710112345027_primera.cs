namespace Directorio.CAD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class primera : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Persona", name: "CargoAsignado_Id", newName: "CargoAsignadoId");
            RenameIndex(table: "dbo.Persona", name: "IX_CargoAsignado_Id", newName: "IX_CargoAsignadoId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Persona", name: "IX_CargoAsignadoId", newName: "IX_CargoAsignado_Id");
            RenameColumn(table: "dbo.Persona", name: "CargoAsignadoId", newName: "CargoAsignado_Id");
        }
    }
}
