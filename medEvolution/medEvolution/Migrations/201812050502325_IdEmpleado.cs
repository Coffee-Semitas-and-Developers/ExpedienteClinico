namespace medEvolution.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IdEmpleado : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cita", "Medico_IdEmpleado", "dbo.Empleado");
            DropPrimaryKey("dbo.Empleado");
            AlterColumn("dbo.Empleado", "IdEmpleado", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Empleado", "IdEmpleado");
            AddForeignKey("dbo.Cita", "Medico_IdEmpleado", "dbo.Empleado", "IdEmpleado");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cita", "Medico_IdEmpleado", "dbo.Empleado");
            DropPrimaryKey("dbo.Empleado");
            AlterColumn("dbo.Empleado", "IdEmpleado", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Empleado", "IdEmpleado");
            AddForeignKey("dbo.Cita", "Medico_IdEmpleado", "dbo.Empleado", "IdEmpleado");
        }
    }
}
