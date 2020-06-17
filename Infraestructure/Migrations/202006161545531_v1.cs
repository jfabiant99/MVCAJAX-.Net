namespace Infraestructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentID = c.Int(nullable: false, identity: true),
                        Codigo = c.String(nullable: false),
                        StudentName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        FechaCreacion = c.DateTime(),
                        FechaModificacion = c.DateTime(),
                        StudentAddress = c.String(nullable: false),
                        Activo = c.Boolean(),
                    })
                .PrimaryKey(t => t.StudentID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Students");
        }
    }
}
