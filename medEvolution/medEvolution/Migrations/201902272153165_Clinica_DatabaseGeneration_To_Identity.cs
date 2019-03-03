namespace medEvolution.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Clinica_DatabaseGeneration_To_Identity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Empleado", "Clinica_IdClinica", "dbo.Clinica");
            DropPrimaryKey("dbo.Clinica");
            AlterColumn("dbo.Clinica", "IdClinica", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Clinica", "IdClinica");
            AddForeignKey("dbo.Empleado", "Clinica_IdClinica", "dbo.Clinica", "IdClinica");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Empleado", "Clinica_IdClinica", "dbo.Clinica");
            DropPrimaryKey("dbo.Clinica");
            AlterColumn("dbo.Clinica", "IdClinica", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Clinica", "IdClinica");
            AddForeignKey("dbo.Empleado", "Clinica_IdClinica", "dbo.Clinica", "IdClinica");
        }
    }
}
