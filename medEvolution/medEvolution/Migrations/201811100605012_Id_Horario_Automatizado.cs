namespace medEvolution.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Id_Horario_Automatizado : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PuestoDeTrabajo", "Horario_De_Atencion_CodigoHorario", "dbo.HorarioDeAtencion");
            DropPrimaryKey("dbo.HorarioDeAtencion");
            AlterColumn("dbo.HorarioDeAtencion", "CodigoHorario", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.HorarioDeAtencion", "CodigoHorario");
            AddForeignKey("dbo.PuestoDeTrabajo", "Horario_De_Atencion_CodigoHorario", "dbo.HorarioDeAtencion", "CodigoHorario", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PuestoDeTrabajo", "Horario_De_Atencion_CodigoHorario", "dbo.HorarioDeAtencion");
            DropPrimaryKey("dbo.HorarioDeAtencion");
            AlterColumn("dbo.HorarioDeAtencion", "CodigoHorario", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.HorarioDeAtencion", "CodigoHorario");
            AddForeignKey("dbo.PuestoDeTrabajo", "Horario_De_Atencion_CodigoHorario", "dbo.HorarioDeAtencion", "CodigoHorario", cascadeDelete: true);
        }
    }
}
