namespace medEvolution.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModeloCita_Modificado : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Direccion", "Detalle", c => c.String(nullable: true, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Direccion", "Detalle", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
