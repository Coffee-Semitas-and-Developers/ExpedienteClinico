namespace medEvolution.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Consulta : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Consulta",
                c => new
                    {
                        IdConsulta = c.Int(nullable: false, identity: true),
                        Sintomatología = c.String(nullable: false, maxLength: 254),
                        Diagnostico = c.String(nullable: false, maxLength: 254),
                        Tratamiento = c.String(nullable: false, maxLength: 254),
                        HoraConsulta = c.DateTime(nullable: false),
                        ProcedimientoEnfermera = c.String(maxLength: 254),
                        Cita_IdCita = c.Int(nullable: false),
                        ConjuntoSignosVitales_IdSignos = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdConsulta)
                .ForeignKey("dbo.Cita", t => t.Cita_IdCita, cascadeDelete: true)
                .ForeignKey("dbo.ConjuntoSignosVitales", t => t.ConjuntoSignosVitales_IdSignos, cascadeDelete: true)
                .Index(t => t.Cita_IdCita)
                .Index(t => t.ConjuntoSignosVitales_IdSignos);
            
            AddColumn("dbo.OrdenExamen", "Consulta_IdConsulta", c => c.Int(nullable: false));
            AddColumn("dbo.Receta", "Consulta_IdConsulta", c => c.Int(nullable: false));
            CreateIndex("dbo.OrdenExamen", "Consulta_IdConsulta");
            CreateIndex("dbo.Receta", "Consulta_IdConsulta");
            AddForeignKey("dbo.OrdenExamen", "Consulta_IdConsulta", "dbo.Consulta", "IdConsulta");
            AddForeignKey("dbo.Receta", "Consulta_IdConsulta", "dbo.Consulta", "IdConsulta");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Consulta", "ConjuntoSignosVitales_IdSignos", "dbo.ConjuntoSignosVitales");
            DropForeignKey("dbo.Receta", "Consulta_IdConsulta", "dbo.Consulta");
            DropForeignKey("dbo.OrdenExamen", "Consulta_IdConsulta", "dbo.Consulta");
            DropForeignKey("dbo.Consulta", "Cita_IdCita", "dbo.Cita");
            DropIndex("dbo.Receta", new[] { "Consulta_IdConsulta" });
            DropIndex("dbo.Consulta", new[] { "ConjuntoSignosVitales_IdSignos" });
            DropIndex("dbo.Consulta", new[] { "Cita_IdCita" });
            DropIndex("dbo.OrdenExamen", new[] { "Consulta_IdConsulta" });
            DropColumn("dbo.Receta", "Consulta_IdConsulta");
            DropColumn("dbo.OrdenExamen", "Consulta_IdConsulta");
            DropTable("dbo.Consulta");
        }
    }
}
