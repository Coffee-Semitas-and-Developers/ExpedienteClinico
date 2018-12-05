namespace medEvolution.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CambiarDecimalString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ConjuntoSignosVitales", "PresionArterial", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ConjuntoSignosVitales", "PresionArterial", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
