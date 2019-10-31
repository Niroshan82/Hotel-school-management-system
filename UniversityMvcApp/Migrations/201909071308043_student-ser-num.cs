namespace UniversityMvcApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class studentsernum : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EnrollCourses", "StudentSerialNum", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.EnrollCourses", "StudentSerialNum");
        }
    }
}
