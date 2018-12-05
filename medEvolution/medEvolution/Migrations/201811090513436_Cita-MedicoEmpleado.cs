namespace medEvolution.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CitaMedicoEmpleado : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Empleado", new[] { "Especialidad_Desempeniada_CodigoEspecialidad" });
            AddColumn("dbo.Cita", "Medico_IdEmpleado", c => c.Int(nullable: false));
            AlterColumn("dbo.Empleado", "Especialidad_Desempeniada_CodigoEspecialidad", c => c.Int(nullable: false));
            CreateIndex("dbo.Cita", "Medico_IdEmpleado");
            CreateIndex("dbo.Empleado", "Especialidad_Desempeniada_CodigoEspecialidad");
            AddForeignKey("dbo.Cita", "Medico_IdEmpleado", "dbo.Empleado", "IdEmpleado");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cita", "Medico_IdEmpleado", "dbo.Empleado");
            DropIndex("dbo.Empleado", new[] { "Especialidad_Desempeniada_CodigoEspecialidad" });
            DropIndex("dbo.Cita", new[] { "Medico_IdEmpleado" });
            AlterColumn("dbo.Empleado", "Especialidad_Desempeniada_CodigoEspecialidad", c => c.Int());
            DropColumn("dbo.Cita", "Medico_IdEmpleado");
            CreateIndex("dbo.Empleado", "Especialidad_Desempeniada_CodigoEspecialidad");
        }
    }
}
