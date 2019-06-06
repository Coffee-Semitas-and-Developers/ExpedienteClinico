namespace medEvolution.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrecionBaseDeDatosDireccionYRelacionesAdición : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Empleado", "Direccion_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Clinica", "Direccion_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Paciente", "Direccion_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Empleado", "Direccion_Id");
            CreateIndex("dbo.Clinica", "Direccion_Id");
            CreateIndex("dbo.Paciente", "Direccion_Id");
            AddForeignKey("dbo.Clinica", "Direccion_Id", "dbo.Direccion", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Empleado", "Direccion_Id", "dbo.Direccion", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Paciente", "Direccion_Id", "dbo.Direccion", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Paciente", "Direccion_Id", "dbo.Direccion");
            DropForeignKey("dbo.Empleado", "Direccion_Id", "dbo.Direccion");
            DropForeignKey("dbo.Clinica", "Direccion_Id", "dbo.Direccion");
            DropIndex("dbo.Paciente", new[] { "Direccion_Id" });
            DropIndex("dbo.Clinica", new[] { "Direccion_Id" });
            DropIndex("dbo.Empleado", new[] { "Direccion_Id" });
            DropColumn("dbo.Paciente", "Direccion_Id");
            DropColumn("dbo.Clinica", "Direccion_Id");
            DropColumn("dbo.Empleado", "Direccion_Id");
        }
    }
}
