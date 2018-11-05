namespace medEvolution.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RecetaMedicamento : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Medicamento",
                c => new
                    {
                        CodigoMedicamento = c.Int(nullable: false),
                        NombreMedicamento = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.CodigoMedicamento);
            
            CreateTable(
                "dbo.Receta",
                c => new
                    {
                        IdReceta = c.Int(nullable: false, identity: true),
                        Instrucciones = c.String(nullable: false, maxLength: 254),
                        Medicamento_CodigoMedicamento = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdReceta)
                .ForeignKey("dbo.Medicamento", t => t.Medicamento_CodigoMedicamento, cascadeDelete: true)
                .Index(t => t.Medicamento_CodigoMedicamento);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Receta", "Medicamento_CodigoMedicamento", "dbo.Medicamento");
            DropIndex("dbo.Receta", new[] { "Medicamento_CodigoMedicamento" });
            DropTable("dbo.Receta");
            DropTable("dbo.Medicamento");
        }
    }
}
