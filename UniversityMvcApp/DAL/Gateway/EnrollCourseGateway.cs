using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityMvcApp.Models;

namespace UniversityMvcApp.DAL.Gateway
{
    public class EnrollCourseGateway
    {
        private string connectionString =
           WebConfigurationManager.ConnectionStrings["UniversityDbContext"].ConnectionString;
        public Models.Student SearchStudentById(int studentId)
        {
            throw new NotImplementedException();
        }

        public List<Models.Course> GetCourseByDepartment(Models.Student student)
        {
            throw new NotImplementedException();
        }

        public Models.Department SearchDepartmentStudentById(int departmentId)
        {
            Department department = new Department();
            SqlConnection connection = new SqlConnection(connectionString);
            string Query = "SELECT * FROM Departments Where ID='" + departmentId + "' ";
            SqlCommand command = new SqlCommand(Query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {


                department.Name = reader["Name"].ToString();



            }
            reader.Close();
            connection.Close();


            return department;
        }

        public List<EnrollCourses> GetEnrollCourseByDepartment(int studentId)
        {
            List<EnrollCourses> courses = new List<EnrollCourses>();
            SqlConnection connection = new SqlConnection(connectionString);
            string Query = "SELECT * FROM EnrollCourses Where StudentId='" + studentId + "' ";
            SqlCommand command = new SqlCommand(Query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {

                EnrollCourses course = new EnrollCourses()
                {
                    CourseId = (int)reader["CourseId"],

                };

                courses.Add(course);

            }
            reader.Close();
            connection.Close();


            return courses;

        }

        public List<EnrollCoursesBasic> GetEnrollCourseBasicByDepartment(int studentId)
        {
            List<EnrollCoursesBasic> courses = new List<EnrollCoursesBasic>();
            SqlConnection connection = new SqlConnection(connectionString);
            string Query = "SELECT * FROM EnrollCoursesBasics Where StudentId='" + studentId + "' ";
            SqlCommand command = new SqlCommand(Query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {

                EnrollCoursesBasic course = new EnrollCoursesBasic()
                {
                    CourseId = (int)reader["CourseId"],

                };

                courses.Add(course);

            }
            reader.Close();
            connection.Close();


            return courses;

        }

        public Course GetCourseByStudent(int p)
        {
            Course course = new Course();
            SqlConnection connection = new SqlConnection(connectionString);
            string Query = "SELECT * FROM Courses Where Id='" + p + "' ";
            SqlCommand command = new SqlCommand(Query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {

                course.Id = (int)reader["Id"];
                course.Code = reader["Code"].ToString();



            }
            reader.Close();
            connection.Close();


            return course;
        }


        public bool UpdateEnrollCourse(EnrollCourses enrollCourse)
        {
            bool msg = false;
            SqlConnection connection = new SqlConnection(connectionString);
            string Query = "Update EnrollCourses SET CourseId='" + enrollCourse.CourseId + "'" + "," + "Grade='" + enrollCourse.Grade + "'" +
                " WHERE SubjectID='" + enrollCourse.SubjectID + "'" + "and StudentId='" + enrollCourse.StudentId + "'";
            SqlCommand command = new SqlCommand(Query, connection);
            connection.Open();
            int efrow = command.ExecuteNonQuery();

            if (efrow != 0)
            {
                msg = true;
            }


                
            connection.Close();


            return msg;
        }

        //public bool UpdateEnrollCourse(EnrollCoursesBasic enrollCourse)
        //{
        //    bool msg = false;
        //    SqlConnection connection = new SqlConnection(connectionString);
        //    string Query = "Update EnrollCoursesBasic SET CourseId='" + enrollCourse.CourseId + "'" + "," + "Grade='" + enrollCourse.Grade + "'" +
        //        " WHERE SubjectID='" + enrollCourse.SubjectID + "'" + "and StudentId='" + enrollCourse.StudentId + "'";
        //    SqlCommand command = new SqlCommand(Query, connection);
        //    connection.Open();
        //    int efrow = command.ExecuteNonQuery();

        //    if (efrow != 0)
        //    {
        //        msg = true;
        //    }



        //    connection.Close();


        //    return msg;
        //}

    }
}