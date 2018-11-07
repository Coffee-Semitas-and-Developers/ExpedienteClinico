namespace medEvolution.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Direccion_Municipio_Departamento : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Direccion",
                c => new
                    {
                        Colonia = c.String(nullable: false, maxLength: 30),
                        Pasaje_Calle = c.String(nullable: false, maxLength: 30),
                        Casa = c.String(nullable: false, maxLength: 30),
                        Detalle = c.String(nullable: true, maxLength: 50),
                        Municipio_CodigoMunicipio = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Colonia, t.Pasaje_Calle, t.Casa })
                .ForeignKey("dbo.Municipio", t => t.Municipio_CodigoMunicipio)
                .Index(t => t.Municipio_CodigoMunicipio);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Direccion", "Municipio_CodigoMunicipio", "dbo.Municipio");
            DropIndex("dbo.Direccion", new[] { "Municipio_CodigoMunicipio" });
            DropTable("dbo.Direccion");
        }
    }
}
