namespace medEvolution.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrecionBaseDeDatosDireccionYRelaciones : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Clinica", "Direccion_Id", "dbo.Direccion");
            DropForeignKey("dbo.Empleado", "Direccion_Id", "dbo.Direccion");
            DropForeignKey("dbo.Paciente", "Direccion_Id", "dbo.Direccion");
            DropIndex("dbo.Empleado", new[] { "Direccion_Id" });
            DropIndex("dbo.Clinica", new[] { "Direccion_Id" });
            DropIndex("dbo.Paciente", new[] { "Direccion_Id" });
            DropColumn("dbo.Empleado", "Direccion_Id");
            DropColumn("dbo.Clinica", "Direccion_Id");
            DropColumn("dbo.Paciente", "Direccion_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Paciente", "Direccion_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Clinica", "Direccion_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Empleado", "Direccion_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Paciente", "Direccion_Id");
            CreateIndex("dbo.Clinica", "Direccion_Id");
            CreateIndex("dbo.Empleado", "Direccion_Id");
            AddForeignKey("dbo.Paciente", "Direccion_Id", "dbo.Direccion", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Empleado", "Direccion_Id", "dbo.Direccion", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Clinica", "Direccion_Id", "dbo.Direccion", "Id", cascadeDelete: true);
        }
    }
}
