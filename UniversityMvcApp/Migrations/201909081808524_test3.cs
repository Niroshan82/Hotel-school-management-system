namespace UniversityMvcApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
               "dbo.EnrollCourses",
               c => new
               {
                   Id = c.Int(nullable: false, identity: true),
                   DepartmentName = c.String(),
                   CourseId = c.Int(nullable: false),
                   StudentId = c.Int(nullable: false),
                   StudentSerialNum = c.String(),
                   SubjectID = c.Int(nullable: false),
                   Grade = c.String(),
                   date = c.DateTime(nullable: false),
               })
               .PrimaryKey(t => t.Id)

               .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
               .ForeignKey("dbo.Students", t => t.StudentId)
               .ForeignKey("dbo.Subjects", t => t.SubjectID, cascadeDelete: true)

               .Index(t => t.CourseId)
               .Index(t => t.StudentId)
               .Index(t => t.SubjectID);
        }
        
        public override void Down()
        {
        }
    }
}
