namespace UniversityMvcApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SubIdNullable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EnrollCourses", "SubjectID", "dbo.Subjects");
            DropIndex("dbo.EnrollCourses", new[] { "SubjectID" });
            AlterColumn("dbo.EnrollCourses", "SubjectID", c => c.Int());
            CreateIndex("dbo.EnrollCourses", "SubjectID");
            AddForeignKey("dbo.EnrollCourses", "SubjectID", "dbo.Subjects", "SubjectID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EnrollCourses", "SubjectID", "dbo.Subjects");
            DropIndex("dbo.EnrollCourses", new[] { "SubjectID" });
            AlterColumn("dbo.EnrollCourses", "SubjectID", c => c.Int(nullable: false));
            CreateIndex("dbo.EnrollCourses", "SubjectID");
            AddForeignKey("dbo.EnrollCourses", "SubjectID", "dbo.Subjects", "SubjectID", cascadeDelete: true);
        }
    }
}
