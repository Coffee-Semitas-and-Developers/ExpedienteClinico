namespace medEvolution.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Medico : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.IdEmpleado)
                .ForeignKey("dbo.Empleado", t => t.IdEmpleado)
                .ForeignKey("dbo.EspecialidadDesempeniada", t => t.Especialidad_Desempeniada_CodigoEspecialidad)
                .ForeignKey("dbo.HorarioDeAtencion", t => t.Horario_De_Atencion_CodigoHorario)
                .Index(t => t.IdEmpleado)
                .Index(t => t.Especialidad_Desempeniada_CodigoEspecialidad)
                .Index(t => t.Horario_De_Atencion_CodigoHorario);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Medico", "Horario_De_Atencion_CodigoHorario", "dbo.HorarioDeAtencion");
            DropForeignKey("dbo.Medico", "Especialidad_Desempeniada_CodigoEspecialidad", "dbo.EspecialidadDesempeniada");
            DropForeignKey("dbo.Medico", "IdEmpleado", "dbo.Empleado");
            DropIndex("dbo.Medico", new[] { "Horario_De_Atencion_CodigoHorario" });
            DropIndex("dbo.Medico", new[] { "Especialidad_Desempeniada_CodigoEspecialidad" });
            DropIndex("dbo.Medico", new[] { "IdEmpleado" });
            DropTable("dbo.Medico");
        }
    }
}
