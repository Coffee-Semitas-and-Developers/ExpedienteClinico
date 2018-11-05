namespace medEvolution.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Cita : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cita",
                c => new
                    {
                        IdCita = c.Int(nullable: false, identity: true),
                        FechaCreada = c.DateTime(nullable: false),
                        FechaCita = c.DateTime(nullable: false),
                        Causa = c.String(nullable: false, maxLength: 100),
                        Medico_IdEmpleado = c.Int(nullable: false),
                        Paciente_IdPaciente = c.Int(nullable: false),
                        Estado_CodigoEstado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdCita)
                .ForeignKey("dbo.Estado", t => t.Estado_CodigoEstado)
                .ForeignKey("dbo.Medico", t => t.Medico_IdEmpleado)
                .ForeignKey("dbo.Paciente", t => t.Paciente_IdPaciente)
                .Index(t => t.Medico_IdEmpleado)
                .Index(t => t.Paciente_IdPaciente)
                .Index(t => t.Estado_CodigoEstado);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cita", "Paciente_IdPaciente", "dbo.Paciente");
            DropForeignKey("dbo.Cita", "Medico_IdEmpleado", "dbo.Medico");
            DropForeignKey("dbo.Cita", "Estado_CodigoEstado", "dbo.Estado");
            DropIndex("dbo.Cita", new[] { "Estado_CodigoEstado" });
            DropIndex("dbo.Cita", new[] { "Paciente_IdPaciente" });
            DropIndex("dbo.Cita", new[] { "Medico_IdEmpleado" });
            DropTable("dbo.Cita");
        }
    }
}
