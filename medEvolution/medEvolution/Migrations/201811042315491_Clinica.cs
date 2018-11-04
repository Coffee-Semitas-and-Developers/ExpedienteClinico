namespace medEvolution.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Clinica : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clinica",
                c => new
                    {
                        IdClinica = c.Int(nullable: false),
                        NombreClinica = c.String(nullable: false, maxLength: 30),
                        Telefono = c.String(nullable: false, maxLength: 10),
                        FechaApertura = c.DateTime(nullable: false),
                        Direccion_Colonia = c.String(nullable: false, maxLength: 30),
                        Direccion_Pasaje_Calle = c.String(nullable: false, maxLength: 30),
                        Direccion_Casa = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.IdClinica)
                .ForeignKey("dbo.Direccion", t => new { t.Direccion_Colonia, t.Direccion_Pasaje_Calle, t.Direccion_Casa }, cascadeDelete: true)
                .Index(t => new { t.Direccion_Colonia, t.Direccion_Pasaje_Calle, t.Direccion_Casa });
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clinica", new[] { "Direccion_Colonia", "Direccion_Pasaje_Calle", "Direccion_Casa" }, "dbo.Direccion");
            DropIndex("dbo.Clinica", new[] { "Direccion_Colonia", "Direccion_Pasaje_Calle", "Direccion_Casa" });
            DropTable("dbo.Clinica");
        }
    }
}
