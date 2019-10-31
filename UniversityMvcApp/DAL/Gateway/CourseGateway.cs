using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityMvcApp.Models;

namespace UniversityMvcApp.DAL.Gateway
{
    public class CourseGateway
    {
        private bool message = false;
        private string connectionString =
            WebConfigurationManager.ConnectionStrings["UniversityDbContext"].ConnectionString;
        public bool IsCodeExist(string code)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string Query = "SELECT * FROM Courses Where Code='" + code + "' ";
            SqlCommand command = new SqlCommand(Query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                message = true;
            }
            reader.Close();
            connection.Close();


            return message;

        }

        public bool IsNameExist(string name)
        {

            SqlConnection connection = new SqlConnection(connectionString);
            string Query = "SELECT * FROM Courses Where Name='" + name + "' ";
            SqlCommand command = new SqlCommand(Query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                message = true;
            }
            reader.Close();
            connection.Close();

            return message;
        }

        public List<Course> GetAllCourses()
        {

            SqlConnection connection = new SqlConnection(connectionString);
            string Query = "SELECT * FROM Courses ";
            SqlCommand command = new SqlCommand(Query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Course> courses = new List<Course>();
            while (reader.Read())
            {
                Course course = new Course()
                {
                    Id = (int)reader["Id"],
                    Name = reader["Name"].ToString(),
                    Code = reader["Code"].ToString(),
                    DepartmentId = (int)reader["DepartmentId"],
                    Credit = (int)reader["Credit"],
                    SemesterId = (int)reader["SemesterId"],
                    TeacherId = reader["TeacherId"] as int? ?? default(int)
                };
                courses.Add(course);
            }
            reader.Close();
            connection.Close();

            return courses;
        }

        public List<Subject> GetAllSubjects()
        {

            SqlConnection connection = new SqlConnection(connectionString);
            string Query0 = "SELECT * FROM Subjects ";
            SqlCommand command0 = new SqlCommand(Query0, connection);
            connection.Open();
            SqlDataReader reader0 = command0.ExecuteReader();
            List<Subject> subject0 = new List<Subject>();
            while (reader0.Read())
            {
                Subject subject = new Subject()
                {
                    SubjectID = (int)reader0["SubjectID"],
                    DepartmentId =(int)reader0["DepartmentId"],
                    DepartmentName =reader0["DepartmentName"].ToString(),
                    SubCourForId = (int)reader0["SubCourForId"],
                    CourseName = reader0["CourseName"].ToString(),

                    Code = reader0["Code"].ToString(),
                    Name = reader0["Name"].ToString(),
                    Credit=(int)reader0["Credit"],
                    
                    date=(DateTime)reader0["date"],
                };
                subject0.Add(subject);
            }
            reader0.Close();
            connection.Close();


            return subject0;
        }






    //public List<Course> GetAllCourses()
    //{
    //    SqlConnection connection = new SqlConnection(connectionString);
    //    string Query = "SELECT * FROM Courses ";
    //    SqlCommand command = new SqlCommand(Query, connection);
    //    connection.Open();
    //    SqlDataReader reader = command.ExecuteReader();
    //    List<Course> courses0 = new List<Course>();
    //    while (reader.Read())
    //    {
    //        Course course = new Course()
    //        {
    //            Id = (int)reader["Id"],
    //            Name = reader["Name"].ToString(),
    //            Code = reader["Code"].ToString(),
    //            DepartmentId = (int)reader["DepartmentId"],
    //            Credit=(int)reader["Credit"],
    //            SemesterId=(int)reader["SemesterId"],
    //            TeacherId =reader["TeacherId"] as int? ?? default(int)
    //        };
    //        courses0.Add(course);
    //    }
    //    reader.Close();
    //    connection.Close();

    //    //List<Subject> viewResult0 = new List<Subject>();
    //    List<Course> courses = new List<Course>();
    //    foreach (var viewResult in courses0)
    //    {
    //       // SqlConnection connection = new SqlConnection(connectionString);
    //        connection.Open();
    //        string Query0 = "SELECT * FROM Subjects WHERE SubCourForId='" + viewResult.Id + "'";
    //        SqlCommand command0 = new SqlCommand(Query0, connection);

    //        SqlDataReader reader2 = command0.ExecuteReader();
    //        while (reader2.Read())
    //        {

    //            viewResult.Code = reader2["Code"].ToString();
    //            viewResult.Name = reader2["Name"].ToString();
    //            courses.Add(viewResult);
    //        }

    //        reader2.Close();
    //        connection.Close();

    //    }

    //        return courses;
    //}

    //public List<Subject> GetAllSubjects()
    //{

    //    SqlConnection connection = new SqlConnection(connectionString);
    //    string Query0 = "SELECT * FROM Subjects ";
    //    SqlCommand command0 = new SqlCommand(Query0, connection);
    //    connection.Open();
    //    SqlDataReader reader0 = command0.ExecuteReader();
    //    List<Subject> subject0 = new List<Subject>();
    //    while (reader0.Read())
    //    {
    //        Subject subject = new Subject()
    //        {
    //            SubjectID = (int)reader0["SubjectID"],
    //            Name = reader0["Name"].ToString(),
    //            Code = reader0["Code"].ToString(),
    //            //Id = (int)reader["Id"],
    //            //Name = reader["Name"].ToString(),
    //            //Code = reader["Code"].ToString(),
    //            //DepartmentId = (int)reader["DepartmentId"],
    //            //Credit = (int)reader["Credit"],
    //            //SemesterId = (int)reader["SemesterId"],
    //            //TeacherId = reader["TeacherId"] as int? ?? default(int)
    //        };
    //        subject0.Add(subject);
    //    }
    //    reader0.Close();
    //    connection.Close();

    //    List<Subject> subjects = new List<Subject>();

    //    foreach (var SubResult in subject0)
    //    {

    //       // SqlConnection connection = new SqlConnection(connectionString);
    //        string Query = "SELECT * FROM Subjects WHERE SubCourForId='" + SubResult.SubCourForId + "'";
    //        SqlCommand command = new SqlCommand(Query, connection);
    //        connection.Open();
    //        SqlDataReader reader = command.ExecuteReader();

    //        //string Query0 = "SELECT * FROM Subjects WHERE SubCourForId='" + courses.Sa + "'";
    //        while (reader.Read())
    //        {
    //            Subject subject = new Subject()
    //            {
    //                SubjectID = (int)reader["SubjectID"],
    //                Name = reader["Name"].ToString(),
    //                Code = reader["Code"].ToString(),

    //            };
    //            subjects.Add(subject);
    //        }
    //        reader.Close();
    //        connection.Close();

    //    }



    //    return subjects;
    //}





    public bool IsCourseAssign(int courseId)
        {
            
            SqlConnection connection = new SqlConnection(connectionString);
            string Query = "SELECT * FROM Courses Where Id='" + courseId + "' ";
            SqlCommand command = new SqlCommand(Query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                if((reader["TeacherId"] as int? )!=null)
                {
                    message = true;
                }

           
                
            }
            reader.Close();
            connection.Close();

            return message;
        }



        public bool AssignTeacher(Course Courses)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string Query = "UPDATE Courses SET TeacherId='"+Courses.TeacherId+"' WHERE Id='"+Courses.Id+"'   ";
            SqlCommand command = new SqlCommand(Query, connection);
            connection.Open();
            int roweff = command.ExecuteNonQuery();
            if (roweff!=0)
            {
                message = true;
            }
           
            connection.Close();

            return message;
        }


       
    }
}