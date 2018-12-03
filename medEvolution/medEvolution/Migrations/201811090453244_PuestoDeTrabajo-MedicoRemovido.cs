namespace medEvolution.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PuestoDeTrabajoMedicoRemovido : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cita", "Medico_IdEmpleado", "dbo.Medico");
            DropForeignKey("dbo.Medico", "IdEmpleado", "dbo.Empleado");
            DropForeignKey("dbo.Medico", "Horario_De_Atencion_CodigoHorario", "dbo.HorarioDeAtencion");
            DropIndex("dbo.Cita", new[] { "Medico_IdEmpleado" });
            DropIndex("dbo.Medico", new[] { "IdEmpleado" });
            DropIndex("dbo.Medico", new[] { "Especialidad_Desempeniada_CodigoEspecialidad" });
            DropIndex("dbo.Medico", new[] { "Horario_De_Atencion_CodigoHorario" });
            CreateTable(
                "dbo.PuestoDeTrabajo",
                c => new
                    {
                        CodigoPuesto = c.Int(nullable: false, identity: true),
                        NombrePuesto = c.String(nullable: false),
                        Salario = c.Decimal(nullable: false, precision: 2, scale: 2),
                        Horario_De_Atencion_CodigoHorario = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CodigoPuesto)
                .ForeignKey("dbo.HorarioDeAtencion", t => t.Horario_De_Atencion_CodigoHorario, cascadeDelete: true)
                .Index(t => t.Horario_De_Atencion_CodigoHorario);
            
            AddColumn("dbo.Cita", "Hora", c => c.DateTime(nullable: false));
            AddColumn("dbo.Empleado", "Puesto_De_Trabajo_CodigoPuesto", c => c.Int(nullable: false));
            AddColumn("dbo.Empleado", "Jvpm", c => c.String(nullable: true, maxLength: 10));
            AddColumn("dbo.Empleado", "Especialidad_Desempeniada_CodigoEspecialidad", c => c.Int(nullable: true));
            AlterColumn("dbo.HorarioDeAtencion", "NumeroCitasAtender", c => c.Int());
            CreateIndex("dbo.Empleado", "Puesto_De_Trabajo_CodigoPuesto");
            CreateIndex("dbo.Empleado", "Especialidad_Desempeniada_CodigoEspecialidad");
            AddForeignKey("dbo.Empleado", "Puesto_De_Trabajo_CodigoPuesto", "dbo.PuestoDeTrabajo", "CodigoPuesto");
            DropColumn("dbo.Cita", "Medico_IdEmpleado");
            DropColumn("dbo.Empleado", "Cargo");
            DropColumn("dbo.Empleado", "Salario");
            DropColumn("dbo.Empleado", "HorasLaborales");
            DropTable("dbo.Medico");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Medico",
                c => new
                    {
                        IdEmpleado = c.Int(nullable: false),
                        Jvpm = c.Int(nullable: false),
                        Especialidad_Desempeniada_CodigoEspecialidad = c.Int(nullable: false),
                        Horario_De_Atencion_CodigoHorario = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdEmpleado);
            
            AddColumn("dbo.Empleado", "HorasLaborales", c => c.String(nullable: false));
            AddColumn("dbo.Empleado", "Salario", c => c.Double(nullable: false));
            AddColumn("dbo.Empleado", "Cargo", c => c.String(nullable: false, maxLength: 30));
            AddColumn("dbo.Cita", "Medico_IdEmpleado", c => c.Int(nullable: false));
            DropForeignKey("dbo.Empleado", "Puesto_De_Trabajo_CodigoPuesto", "dbo.PuestoDeTrabajo");
            DropForeignKey("dbo.PuestoDeTrabajo", "Horario_De_Atencion_CodigoHorario", "dbo.HorarioDeAtencion");
            DropIndex("dbo.PuestoDeTrabajo", new[] { "Horario_De_Atencion_CodigoHorario" });
            DropIndex("dbo.Empleado", new[] { "Especialidad_Desempeniada_CodigoEspecialidad" });
            DropIndex("dbo.Empleado", new[] { "Puesto_De_Trabajo_CodigoPuesto" });
            AlterColumn("dbo.HorarioDeAtencion", "NumeroCitasAtender", c => c.Int(nullable: false));
            DropColumn("dbo.Empleado", "Especialidad_Desempeniada_CodigoEspecialidad");
            DropColumn("dbo.Empleado", "Jvpm");
            DropColumn("dbo.Empleado", "Puesto_De_Trabajo_CodigoPuesto");
            DropColumn("dbo.Cita", "Hora");
            DropTable("dbo.PuestoDeTrabajo");
            CreateIndex("dbo.Medico", "Horario_De_Atencion_CodigoHorario");
            CreateIndex("dbo.Medico", "Especialidad_Desempeniada_CodigoEspecialidad");
            CreateIndex("dbo.Medico", "IdEmpleado");
            CreateIndex("dbo.Cita", "Medico_IdEmpleado");
            AddForeignKey("dbo.Medico", "Horario_De_Atencion_CodigoHorario", "dbo.HorarioDeAtencion", "CodigoHorario");
            AddForeignKey("dbo.Medico", "IdEmpleado", "dbo.Empleado", "IdEmpleado");
            AddForeignKey("dbo.Cita", "Medico_IdEmpleado", "dbo.Medico", "IdEmpleado");
        }
    }
}
