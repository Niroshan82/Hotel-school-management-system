namespace UniversityMvcApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SubName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserTeachers", "SubName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserTeachers", "SubName");
        }
    }
}
