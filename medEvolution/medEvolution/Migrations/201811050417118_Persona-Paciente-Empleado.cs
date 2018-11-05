namespace medEvolution.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PersonaPacienteEmpleado : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Empleado",
                c => new
                    {
                        IdEmpleado = c.Int(nullable: false),
                        Cargo = c.String(nullable: false, maxLength: 30),
                        FechaContratacion = c.DateTime(nullable: false),
                        FechaDespido = c.DateTime(nullable:true),
                        Salario = c.Double(nullable: false),
                        HorasLaborales = c.String(nullable: false),
                        Clinica_IdClinica = c.Int(nullable: false),
                        Estado_CodigoEstado = c.Int(nullable: false),
                        Dui = c.String(nullable: false, maxLength: 10),
                        Nombre1 = c.String(nullable: false, maxLength: 15),
                        Nombre2 = c.String(maxLength: 15),
                        Apellido1 = c.String(nullable: false, maxLength: 15),
                        Apellido2 = c.String(maxLength: 15),
                        Telefono = c.String(nullable: false, maxLength: 9),
                        Celular = c.String(nullable: false, maxLength: 9),
                        TipoSangre = c.String(maxLength: 10),
                        FechaNac = c.DateTime(nullable: false),
                        Sexo = c.String(nullable: false, maxLength: 10),
                        Ocupacion = c.String(nullable: false, maxLength: 30),
                        CorreoElectronico = c.String(nullable: false),
                        Alergia = c.String(nullable: false, maxLength: 50),
                        Discapacidad = c.Boolean(nullable: false),
                        TipoDiscapacidad = c.String(nullable: true, maxLength: 254),
                        NombreMadre = c.String(nullable: true,maxLength: 15),
                        ApellidoMadre = c.String(nullable: true, maxLength: 15),
                        NombrePadre = c.String(nullable: true, maxLength: 15),
                        ApellidoPadre = c.String(nullable: true, maxLength: 15),
                        EstadoCivil = c.String(nullable: false, maxLength: 20),
                        NombreConyugue = c.String(maxLength: 15),
                        ApellidoConyugue = c.String(maxLength: 15),
                        NombreContactoEmergencia = c.String(nullable: false, maxLength: 15),
                        ApellidoContactoEmergencia = c.String(nullable: false, maxLength: 15),
                        TelefonoContactoEmergencia = c.String(nullable: false, maxLength: 9),
                        CelularContactoEmergencia = c.String(nullable: false, maxLength: 9),
                        Direccion_Colonia = c.String(nullable: false, maxLength: 30),
                        Direccion_Pasaje_Calle = c.String(nullable: false, maxLength: 30),
                        Direccion_Casa = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.IdEmpleado)
                .ForeignKey("dbo.Clinica", t => t.Clinica_IdClinica)
                .ForeignKey("dbo.Direccion", t => new { t.Direccion_Colonia, t.Direccion_Pasaje_Calle, t.Direccion_Casa }, cascadeDelete: true)
                .ForeignKey("dbo.Estado", t => t.Estado_CodigoEstado)
                .Index(t => t.Clinica_IdClinica)
                .Index(t => t.Estado_CodigoEstado)
                .Index(t => new { t.Direccion_Colonia, t.Direccion_Pasaje_Calle, t.Direccion_Casa });
            
            CreateTable(
                "dbo.Paciente",
                c => new
                    {
                        IdPaciente = c.Int(nullable: false, identity: true),
                        FechaCreacion = c.DateTime(nullable: false),
                        FechaDeBaja = c.DateTime(nullable: true),
                        Estado_CodigoEstado = c.Int(nullable: false),
                        Dui = c.String(nullable: false, maxLength: 10),
                        Nombre1 = c.String(nullable: false, maxLength: 15),
                        Nombre2 = c.String(maxLength: 15),
                        Apellido1 = c.String(nullable: false, maxLength: 15),
                        Apellido2 = c.String(maxLength: 15),
                        Telefono = c.String(nullable: false, maxLength: 9),
                        Celular = c.String(nullable: false, maxLength: 9),
                        TipoSangre = c.String(maxLength: 10),
                        FechaNac = c.DateTime(nullable: false),
                        Sexo = c.String(nullable: false, maxLength: 10),
                        Ocupacion = c.String(nullable: false, maxLength: 30),
                        CorreoElectronico = c.String(nullable: false),
                        Alergia = c.String(nullable: false, maxLength: 50),
                        Discapacidad = c.Boolean(nullable: false),
                        TipoDiscapacidad = c.String(nullable: true, maxLength: 254),
                        NombreMadre = c.String(nullable: true, maxLength: 15),
                        ApellidoMadre = c.String(nullable: true, maxLength: 15),
                        NombrePadre = c.String(nullable: true, maxLength: 15),
                        ApellidoPadre = c.String(nullable: true, maxLength: 15),
                        EstadoCivil = c.String(nullable: false, maxLength: 20),
                        NombreConyugue = c.String(maxLength: 15),
                        ApellidoConyugue = c.String(maxLength: 15),
                        NombreContactoEmergencia = c.String(nullable: false, maxLength: 15),
                        ApellidoContactoEmergencia = c.String(nullable: false, maxLength: 15),
                        TelefonoContactoEmergencia = c.String(nullable: false, maxLength: 9),
                        CelularContactoEmergencia = c.String(nullable: false, maxLength: 9),
                        Direccion_Colonia = c.String(nullable: false, maxLength: 30),
                        Direccion_Pasaje_Calle = c.String(nullable: false, maxLength: 30),
                        Direccion_Casa = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.IdPaciente)
                .ForeignKey("dbo.Direccion", t => new { t.Direccion_Colonia, t.Direccion_Pasaje_Calle, t.Direccion_Casa }, cascadeDelete: true)
                .ForeignKey("dbo.Estado", t => t.Estado_CodigoEstado)
                .Index(t => t.Estado_CodigoEstado)
                .Index(t => new { t.Direccion_Colonia, t.Direccion_Pasaje_Calle, t.Direccion_Casa });
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Empleado", "Estado_CodigoEstado", "dbo.Estado");
            DropForeignKey("dbo.Paciente", "Estado_CodigoEstado", "dbo.Estado");
            DropForeignKey("dbo.Paciente", new[] { "Direccion_Colonia", "Direccion_Pasaje_Calle", "Direccion_Casa" }, "dbo.Direccion");
            DropForeignKey("dbo.Empleado", new[] { "Direccion_Colonia", "Direccion_Pasaje_Calle", "Direccion_Casa" }, "dbo.Direccion");
            DropForeignKey("dbo.Empleado", "Clinica_IdClinica", "dbo.Clinica");
            DropIndex("dbo.Paciente", new[] { "Direccion_Colonia", "Direccion_Pasaje_Calle", "Direccion_Casa" });
            DropIndex("dbo.Paciente", new[] { "Estado_CodigoEstado" });
            DropIndex("dbo.Empleado", new[] { "Direccion_Colonia", "Direccion_Pasaje_Calle", "Direccion_Casa" });
            DropIndex("dbo.Empleado", new[] { "Estado_CodigoEstado" });
            DropIndex("dbo.Empleado", new[] { "Clinica_IdClinica" });
            DropTable("dbo.Paciente");
            DropTable("dbo.Empleado");
        }
    }
}
