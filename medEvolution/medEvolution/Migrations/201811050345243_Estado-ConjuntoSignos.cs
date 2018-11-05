namespace medEvolution.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EstadoConjuntoSignos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ConjuntoSignosVitales",
                c => new
                    {
                        IdSignos = c.Int(nullable: false, identity: true),
                        PresionArterial = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Temperatura = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Peso = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PulsoCardiaco = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Estatura = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.IdSignos);
            
            CreateTable(
                "dbo.Estado",
                c => new
                    {
                        CodigoEstado = c.Int(nullable: false),
                        NombreEstado = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.CodigoEstado);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Estado");
            DropTable("dbo.ConjuntoSignosVitales");
        }
    }
}
