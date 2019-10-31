using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityMvcApp.DAL.Gateway;
using UniversityMvcApp.Models;

namespace UniversityMvcApp.BLL
{
    public class EnrollCourseManager
    {
        EnrollCourseGateway enrollCourseGateway = new EnrollCourseGateway();
        private string connectionString =
            WebConfigurationManager.ConnectionStrings["UniversityDbContext"].ConnectionString;
        public Models.Student SearchStudentById(int studentId)
        {
            Student student = new Student();
            SqlConnection connection = new SqlConnection(connectionString);
            string Query = "SELECT * FROM Students Where Id='" + studentId + "' ";
            SqlCommand command = new SqlCommand(Query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {


                student.DepartmentId = (int)reader["DepartmentId"];
                student.Name = reader["Name"].ToString();



            }
            reader.Close();
            connection.Close();


            return student;

        }

        public List<Models.Course> GetCourseByDepartment(Models.Student student)
        {
            List<Course> courses = new List<Course>();
            SqlConnection connection = new SqlConnection(connectionString);
            string Query = "SELECT * FROM Courses Where DepartmentId='" + student.DepartmentId + "' ";
            SqlCommand command = new SqlCommand(Query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {

                Course course = new Course()
                {
                    Id = (int)reader["Id"],
                    Code = reader["Code"].ToString()
                };

                courses.Add(course);

            }
            reader.Close();
            connection.Close();


            return courses;
        }

        public Department SearchDepartmentStudentById(int departmentId)
        {
            return enrollCourseGateway.SearchDepartmentStudentById(departmentId);
        }

        public List<EnrollCourses> GetEnrollCourseByDepartment(int studentId)
        {
            return enrollCourseGateway.GetEnrollCourseByDepartment(studentId);
        }

        public List<EnrollCoursesBasic> GetEnrollCourseBasicByDepartment(int studentId)
        {
            return enrollCourseGateway.GetEnrollCourseBasicByDepartment(studentId);
        }


        internal Course GetCourseByStudent(int p)
        {
            return enrollCourseGateway.GetCourseByStudent(p);
        }

        public bool UpdateEnrollCourse(EnrollCourses enrollCourse)
        {
            return enrollCourseGateway.UpdateEnrollCourse(enrollCourse);
        }
    }
}