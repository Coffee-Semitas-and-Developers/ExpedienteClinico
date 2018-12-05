namespace medEvolution.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CambioDeFormatoATime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cita", "Hora", c => c.Time(nullable: false, precision: 4));
            AlterColumn("dbo.HorarioDeAtencion", "HoraInicio", c => c.Time(nullable: false, precision: 4));
            AlterColumn("dbo.HorarioDeAtencion", "HoraFin", c => c.Time(nullable: false, precision: 4));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.HorarioDeAtencion", "HoraFin", c => c.DateTime(nullable: false));
            AlterColumn("dbo.HorarioDeAtencion", "HoraInicio", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Cita", "Hora", c => c.DateTime(nullable: false));
        }
    }
}
