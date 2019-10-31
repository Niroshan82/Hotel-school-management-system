using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace UniversityMvcApp.Models
{
    public class UniversityDbContext:DbContext
    {
       public DbSet<Course> Courses { get; set; }
       public DbSet<Department> Departments { get; set; }
       public DbSet<Teacher> Teachers { get; set; }
       public DbSet<Student> Students { get; set; }
       public DbSet<Semester> Semesters { get; set; }

       public DbSet<Designation> Designations { get; set; }
       public DbSet<Room> Rooms { get; set; }
       public DbSet<AllocateClassRoom> AllocateClassRooms { get; set; }
       public DbSet<EnrollCourses> EnrollCourses { get; set; }

       public DbSet<Subject> Subjects { get; set; }
    
       public DbSet<EnrollCoursesBasic> EnrollCoursesBasics { get; set; }

       public DbSet<User> User { get; set; }

        public DbSet<FileUpload> FileUpload { get; set; }

        public DbSet<tblFileDetails> tblFileDetails { get; set; }

        public DbSet<UserTypes> UserTypes { get; set; }

        public DbSet<UserAdmin> UserAdmins { get; set; }

        public DbSet<UserTeacher> UserTeachers { get; set; }








    }
}