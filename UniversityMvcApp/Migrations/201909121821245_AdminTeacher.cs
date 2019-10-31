namespace UniversityMvcApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdminTeacher : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserAdmins",
                c => new
                    {
                        UserID = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 100),
                        Password = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.UserTeachers",
                c => new
                    {
                        UserID = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 100),
                        Password = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserTeachers");
            DropTable("dbo.UserAdmins");
        }
    }
}
