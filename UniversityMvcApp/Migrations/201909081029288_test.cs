namespace UniversityMvcApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
           

            CreateTable(
            "dbo.EnrollCoursesBasics",
            c => new
            {
                Id = c.Int(nullable: false, identity: true),
                DepartmentName = c.String(),
                CourseId = c.Int(nullable: false),
                StudentId = c.Int(nullable: false),
                StudentSerialNum = c.String(),
                date = c.DateTime(nullable: false),

            })
            .PrimaryKey(t => t.Id)
            .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)

            .ForeignKey("dbo.Students", t => t.StudentId)


            .Index(t => t.CourseId)
            .Index(t => t.StudentId);




            


        }
        
        public override void Down()
        {
           
        }
    }
}
