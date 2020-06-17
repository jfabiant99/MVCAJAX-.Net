namespace Infraestructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Students", "Codigo");
            DropColumn("dbo.Students", "LastName");
            DropColumn("dbo.Students", "FechaCreacion");
            DropColumn("dbo.Students", "FechaModificacion");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "FechaModificacion", c => c.DateTime());
            AddColumn("dbo.Students", "FechaCreacion", c => c.DateTime());
            AddColumn("dbo.Students", "LastName", c => c.String(nullable: false));
            AddColumn("dbo.Students", "Codigo", c => c.String(nullable: false));
        }
    }
}
