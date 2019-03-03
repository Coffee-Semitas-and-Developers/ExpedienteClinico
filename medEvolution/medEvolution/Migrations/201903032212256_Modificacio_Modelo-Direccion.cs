namespace medEvolution.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Modificacio_ModeloDireccion : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Empleado", new[] { "Direccion_Colonia", "Direccion_Pasaje_Calle", "Direccion_Casa" }, "dbo.Direccion");
            DropForeignKey("dbo.Clinica", new[] { "Direccion_Colonia", "Direccion_Pasaje_Calle", "Direccion_Casa" }, "dbo.Direccion");
            DropForeignKey("dbo.Direccion", "Municipio_CodigoMunicipio", "dbo.Municipio");
            DropForeignKey("dbo.Paciente", new[] { "Direccion_Colonia", "Direccion_Pasaje_Calle", "Direccion_Casa" }, "dbo.Direccion");
            DropIndex("dbo.Empleado", new[] { "Direccion_Colonia", "Direccion_Pasaje_Calle", "Direccion_Casa" });
            DropIndex("dbo.Clinica", new[] { "Direccion_Colonia", "Direccion_Pasaje_Calle", "Direccion_Casa" });
            DropIndex("dbo.Direccion", new[] { "Municipio_CodigoMunicipio" });
            DropIndex("dbo.Paciente", new[] { "Direccion_Colonia", "Direccion_Pasaje_Calle", "Direccion_Casa" });
            RenameColumn(table: "dbo.Empleado", name: "Direccion_Colonia", newName: "Direccion_Id");
            RenameColumn(table: "dbo.Clinica", name: "Direccion_Colonia", newName: "Direccion_Id");
            RenameColumn(table: "dbo.Paciente", name: "Direccion_Colonia", newName: "Direccion_Id");
            DropPrimaryKey("dbo.Direccion");
            DropPrimaryKey("dbo.Municipio");
            AddColumn("dbo.Direccion", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Direccion", "Municipio_CodigoDepartamento", c => c.Int(nullable: false));
            AlterColumn("dbo.Empleado", "Direccion_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Clinica", "Direccion_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Paciente", "Direccion_Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Direccion", "Id");
            AddPrimaryKey("dbo.Municipio", new[] { "CodigoMunicipio", "Departamento_CodigoDepartamento" });
            CreateIndex("dbo.Empleado", "Direccion_Id");
            CreateIndex("dbo.Clinica", "Direccion_Id");
            CreateIndex("dbo.Direccion", new[] { "Municipio_CodigoMunicipio", "Municipio_CodigoDepartamento" });
            CreateIndex("dbo.Paciente", "Direccion_Id");
            AddForeignKey("dbo.Empleado", "Direccion_Id", "dbo.Direccion", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Clinica", "Direccion_Id", "dbo.Direccion", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Direccion", new[] { "Municipio_CodigoMunicipio", "Municipio_CodigoDepartamento" }, "dbo.Municipio", new[] { "CodigoMunicipio", "Departamento_CodigoDepartamento" });
            AddForeignKey("dbo.Paciente", "Direccion_Id", "dbo.Direccion", "Id", cascadeDelete: true);
            DropColumn("dbo.Empleado", "Direccion_Pasaje_Calle");
            DropColumn("dbo.Empleado", "Direccion_Casa");
            DropColumn("dbo.Clinica", "Direccion_Pasaje_Calle");
            DropColumn("dbo.Clinica", "Direccion_Casa");
            DropColumn("dbo.Paciente", "Direccion_Pasaje_Calle");
            DropColumn("dbo.Paciente", "Direccion_Casa");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Paciente", "Direccion_Casa", c => c.String(nullable: false, maxLength: 30));
            AddColumn("dbo.Paciente", "Direccion_Pasaje_Calle", c => c.String(nullable: false, maxLength: 30));
            AddColumn("dbo.Clinica", "Direccion_Casa", c => c.String(nullable: false, maxLength: 30));
            AddColumn("dbo.Clinica", "Direccion_Pasaje_Calle", c => c.String(nullable: false, maxLength: 30));
            AddColumn("dbo.Empleado", "Direccion_Casa", c => c.String(nullable: false, maxLength: 30));
            AddColumn("dbo.Empleado", "Direccion_Pasaje_Calle", c => c.String(nullable: false, maxLength: 30));
            DropForeignKey("dbo.Paciente", "Direccion_Id", "dbo.Direccion");
            DropForeignKey("dbo.Direccion", new[] { "Municipio_CodigoMunicipio", "Municipio_CodigoDepartamento" }, "dbo.Municipio");
            DropForeignKey("dbo.Clinica", "Direccion_Id", "dbo.Direccion");
            DropForeignKey("dbo.Empleado", "Direccion_Id", "dbo.Direccion");
            DropIndex("dbo.Paciente", new[] { "Direccion_Id" });
            DropIndex("dbo.Direccion", new[] { "Municipio_CodigoMunicipio", "Municipio_CodigoDepartamento" });
            DropIndex("dbo.Clinica", new[] { "Direccion_Id" });
            DropIndex("dbo.Empleado", new[] { "Direccion_Id" });
            DropPrimaryKey("dbo.Municipio");
            DropPrimaryKey("dbo.Direccion");
            AlterColumn("dbo.Paciente", "Direccion_Id", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Clinica", "Direccion_Id", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Empleado", "Direccion_Id", c => c.String(nullable: false, maxLength: 30));
            DropColumn("dbo.Direccion", "Municipio_CodigoDepartamento");
            DropColumn("dbo.Direccion", "Id");
            AddPrimaryKey("dbo.Municipio", "CodigoMunicipio");
            AddPrimaryKey("dbo.Direccion", new[] { "Colonia", "Pasaje_Calle", "Casa" });
            RenameColumn(table: "dbo.Paciente", name: "Direccion_Id", newName: "Direccion_Colonia");
            RenameColumn(table: "dbo.Clinica", name: "Direccion_Id", newName: "Direccion_Colonia");
            RenameColumn(table: "dbo.Empleado", name: "Direccion_Id", newName: "Direccion_Colonia");
            CreateIndex("dbo.Paciente", new[] { "Direccion_Colonia", "Direccion_Pasaje_Calle", "Direccion_Casa" });
            CreateIndex("dbo.Direccion", "Municipio_CodigoMunicipio");
            CreateIndex("dbo.Clinica", new[] { "Direccion_Colonia", "Direccion_Pasaje_Calle", "Direccion_Casa" });
            CreateIndex("dbo.Empleado", new[] { "Direccion_Colonia", "Direccion_Pasaje_Calle", "Direccion_Casa" });
            AddForeignKey("dbo.Paciente", new[] { "Direccion_Colonia", "Direccion_Pasaje_Calle", "Direccion_Casa" }, "dbo.Direccion", new[] { "Colonia", "Pasaje_Calle", "Casa" }, cascadeDelete: true);
            AddForeignKey("dbo.Direccion", "Municipio_CodigoMunicipio", "dbo.Municipio", "CodigoMunicipio");
            AddForeignKey("dbo.Clinica", new[] { "Direccion_Colonia", "Direccion_Pasaje_Calle", "Direccion_Casa" }, "dbo.Direccion", new[] { "Colonia", "Pasaje_Calle", "Casa" }, cascadeDelete: true);
            AddForeignKey("dbo.Empleado", new[] { "Direccion_Colonia", "Direccion_Pasaje_Calle", "Direccion_Casa" }, "dbo.Direccion", new[] { "Colonia", "Pasaje_Calle", "Casa" }, cascadeDelete: true);
        }
    }
}
