namespace UniversityMvcApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EnrollCoursesBasics", "Subject_SubjectID", "dbo.Subjects");
            DropIndex("dbo.EnrollCoursesBasics", new[] { "Subject_SubjectID" });
            

        }
        
        public override void Down()
        {
            AddColumn("dbo.EnrollCoursesBasics", "Subject_SubjectID", c => c.Int());
            CreateIndex("dbo.EnrollCoursesBasics", "Subject_SubjectID");
            AddForeignKey("dbo.EnrollCoursesBasics", "Subject_SubjectID", "dbo.Subjects", "SubjectID");
        }
    }
}
