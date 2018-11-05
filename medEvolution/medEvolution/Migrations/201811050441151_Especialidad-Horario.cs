namespace medEvolution.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EspecialidadHorario : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EspecialidadDesempeniada",
                c => new
                    {
                        CodigoEspecialidad = c.Int(nullable: false),
                        NombreEspecialidad = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.CodigoEspecialidad);
            
            CreateTable(
                "dbo.HorarioDeAtencion",
                c => new
                    {
                        CodigoHorario = c.Int(nullable: false),
                        HoraInicio = c.DateTime(nullable: false),
                        HoraFin = c.DateTime(nullable: false),
                        NumeroCitasAtender = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CodigoHorario);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.HorarioDeAtencion");
            DropTable("dbo.EspecialidadDesempeniada");
        }
    }
}
