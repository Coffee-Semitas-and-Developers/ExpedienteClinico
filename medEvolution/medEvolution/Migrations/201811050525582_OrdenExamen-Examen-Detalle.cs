namespace medEvolution.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrdenExamenExamenDetalle : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DetalleExamenes",
                c => new
                    {
                        DetalleExamenesId = c.Int(nullable: false, identity: true),
                        OrdenExamen_IdOrden = c.Int(nullable: false),
                        Examen_CodigoExamen = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DetalleExamenesId)
                .ForeignKey("dbo.Examen", t => t.Examen_CodigoExamen, cascadeDelete: true)
                .ForeignKey("dbo.OrdenExamen", t => t.OrdenExamen_IdOrden, cascadeDelete: true)
                .Index(t => t.OrdenExamen_IdOrden)
                .Index(t => t.Examen_CodigoExamen);
            
            CreateTable(
                "dbo.Examen",
                c => new
                    {
                        CodigoExamen = c.Int(nullable: false),
                        TipoMuestra = c.String(nullable: false, maxLength: 30),
                        NombreExamen = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.CodigoExamen);
            
            CreateTable(
                "dbo.OrdenExamen",
                c => new
                    {
                        IdOrden = c.Int(nullable: false, identity: true),
                        Urgencia = c.Boolean(nullable: false),
                        Resultado = c.Byte(),
                        FechaResultado = c.DateTime(),
                    })
                .PrimaryKey(t => t.IdOrden);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DetalleExamenes", "OrdenExamen_IdOrden", "dbo.OrdenExamen");
            DropForeignKey("dbo.DetalleExamenes", "Examen_CodigoExamen", "dbo.Examen");
            DropIndex("dbo.DetalleExamenes", new[] { "Examen_CodigoExamen" });
            DropIndex("dbo.DetalleExamenes", new[] { "OrdenExamen_IdOrden" });
            DropTable("dbo.OrdenExamen");
            DropTable("dbo.Examen");
            DropTable("dbo.DetalleExamenes");
        }
    }
}
