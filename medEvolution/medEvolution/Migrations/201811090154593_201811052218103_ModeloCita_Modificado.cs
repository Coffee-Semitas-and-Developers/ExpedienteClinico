namespace medEvolution.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _201811052218103_ModeloCita_Modificado : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Medico", "Empleado_IdEmpleado", "dbo.Empleado");
            DropIndex("dbo.Medico", new[] { "Empleado_IdEmpleado" });
			DropColumn("dbo.Cita", "Hora");
			DropColumn("dbo.Medico", "Empleado_IdEmpleado");

		}
        
        public override void Down()
        {
            AddColumn("dbo.Medico", "Empleado_IdEmpleado", c => c.Int());
            AddColumn("dbo.Cita", "Hora", c => c.DateTime(nullable: false));
            CreateIndex("dbo.Medico", "Empleado_IdEmpleado");
            AddForeignKey("dbo.Medico", "Empleado_IdEmpleado", "dbo.Empleado", "IdEmpleado");
        }
    }
}
