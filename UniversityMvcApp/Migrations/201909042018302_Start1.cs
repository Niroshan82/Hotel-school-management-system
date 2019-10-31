namespace UniversityMvcApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Start1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AllocateClassRooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DepartmentId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        SubjectID = c.Int(nullable: false),
                        RoomId = c.Int(nullable: false),
                        date = c.DateTime(nullable: false),
                        Day = c.String(),
                        From = c.String(),
                        To = c.String(),
                        StartTime = c.Time(nullable: false, precision: 7),
                        FinishTime = c.Time(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.Rooms", t => t.RoomId, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.SubjectID, cascadeDelete: true)
                .Index(t => t.DepartmentId)
                .Index(t => t.CourseId)
                .Index(t => t.SubjectID)
                .Index(t => t.RoomId);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 100),
                        Name = c.String(nullable: false),
                        Credit = c.Int(nullable: false),
                        Description = c.String(nullable: false),
                        DepartmentId = c.Int(),
                        TeacherId = c.Int(),
                        SemesterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId)
                .ForeignKey("dbo.Teachers", t => t.TeacherId)
                .ForeignKey("dbo.Semesters", t => t.SemesterId, cascadeDelete: true)
                .Index(t => t.DepartmentId)
                .Index(t => t.TeacherId)
                .Index(t => t.SemesterId);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 7),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoomNo = c.String(),
                        DepartmentId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        ContactNo = c.String(nullable: false),
                        NIC = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        CourID = c.Int(),
                        RegistrationSerial = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourID)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .Index(t => t.DepartmentId)
                .Index(t => t.CourID);
            
            CreateTable(
                "dbo.EnrollCourses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CourseId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                        SubjectID = c.Int(nullable: false),
                        Grade = c.String(),
                        date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.SubjectID, cascadeDelete: true)
                .Index(t => t.CourseId)
                .Index(t => t.StudentId)
                .Index(t => t.SubjectID);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        SubjectID = c.Int(nullable: false, identity: true),
                        DepartmentId = c.Int(),
                        DepartmentName = c.String(),
                        SubCourForId = c.Int(),
                        CourseName = c.String(),
                        Code = c.String(nullable: false, maxLength: 100),
                        Name = c.String(nullable: false),
                        Credit = c.Int(nullable: false),
                        date = c.DateTime(nullable: false),
                        Course_Id = c.Int(),
                        Course_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.SubjectID)
                .ForeignKey("dbo.Courses", t => t.SubCourForId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId)
                .ForeignKey("dbo.Courses", t => t.Course_Id)
                .ForeignKey("dbo.Courses", t => t.Course_Id1)
                .Index(t => t.DepartmentId)
                .Index(t => t.SubCourForId)
                .Index(t => t.Course_Id)
                .Index(t => t.Course_Id1);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        ContactNo = c.String(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        CreditToBeTaken = c.Int(nullable: false),
                        RemainingCredit = c.Int(nullable: false),
                        CreditTaken = c.Int(nullable: false),
                        DesignationId = c.Int(nullable: false),
                        Availability = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.Designations", t => t.DesignationId, cascadeDelete: true)
                .Index(t => t.DepartmentId)
                .Index(t => t.DesignationId);
            
            CreateTable(
                "dbo.Designations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DesignationName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Semesters",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SemesterNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Subjects", "Course_Id1", "dbo.Courses");
            DropForeignKey("dbo.Subjects", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.Courses", "SemesterId", "dbo.Semesters");
            DropForeignKey("dbo.Teachers", "DesignationId", "dbo.Designations");
            DropForeignKey("dbo.Teachers", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Courses", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.EnrollCourses", "SubjectID", "dbo.Subjects");
            DropForeignKey("dbo.Subjects", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Subjects", "SubCourForId", "dbo.Courses");
            DropForeignKey("dbo.AllocateClassRooms", "SubjectID", "dbo.Subjects");
            DropForeignKey("dbo.EnrollCourses", "StudentId", "dbo.Students");
            DropForeignKey("dbo.EnrollCourses", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Students", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Students", "CourID", "dbo.Courses");
            DropForeignKey("dbo.Rooms", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.AllocateClassRooms", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.Courses", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.AllocateClassRooms", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.AllocateClassRooms", "CourseId", "dbo.Courses");
            DropIndex("dbo.Teachers", new[] { "DesignationId" });
            DropIndex("dbo.Teachers", new[] { "DepartmentId" });
            DropIndex("dbo.Subjects", new[] { "Course_Id1" });
            DropIndex("dbo.Subjects", new[] { "Course_Id" });
            DropIndex("dbo.Subjects", new[] { "SubCourForId" });
            DropIndex("dbo.Subjects", new[] { "DepartmentId" });
            DropIndex("dbo.EnrollCourses", new[] { "SubjectID" });
            DropIndex("dbo.EnrollCourses", new[] { "StudentId" });
            DropIndex("dbo.EnrollCourses", new[] { "CourseId" });
            DropIndex("dbo.Students", new[] { "CourID" });
            DropIndex("dbo.Students", new[] { "DepartmentId" });
            DropIndex("dbo.Rooms", new[] { "DepartmentId" });
            DropIndex("dbo.Courses", new[] { "SemesterId" });
            DropIndex("dbo.Courses", new[] { "TeacherId" });
            DropIndex("dbo.Courses", new[] { "DepartmentId" });
            DropIndex("dbo.AllocateClassRooms", new[] { "RoomId" });
            DropIndex("dbo.AllocateClassRooms", new[] { "SubjectID" });
            DropIndex("dbo.AllocateClassRooms", new[] { "CourseId" });
            DropIndex("dbo.AllocateClassRooms", new[] { "DepartmentId" });
            DropTable("dbo.Semesters");
            DropTable("dbo.Designations");
            DropTable("dbo.Teachers");
            DropTable("dbo.Subjects");
            DropTable("dbo.EnrollCourses");
            DropTable("dbo.Students");
            DropTable("dbo.Rooms");
            DropTable("dbo.Departments");
            DropTable("dbo.Courses");
            DropTable("dbo.AllocateClassRooms");
        }
    }
}
