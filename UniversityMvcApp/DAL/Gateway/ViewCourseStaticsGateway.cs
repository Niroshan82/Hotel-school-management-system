using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityMvcApp.Models;

namespace UniversityMvcApp.DAL.Gateway
{
    public class ViewCourseStaticsGateway
    {
        private string connectionString =
          WebConfigurationManager.ConnectionStrings["UniversityDbContext"].ConnectionString;

        public Models.ViewCourseStatics GetView(Models.Course course1)
        {
           ViewCourseStatics aViewCourseStatics = new ViewCourseStatics();
            SqlConnection connection = new SqlConnection(connectionString);
            string Query = "SELECT Teachers.Name as TN,Courses.Name as Name,Courses.SemesterId as SemesterId,Courses.Code as Code FROM Courses JOIN Teachers ON Courses.TeacherId=Teachers.Id WHERE Courses.Id='" + course1.Id + "'";
            SqlCommand command = new SqlCommand(Query, connection);
           
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
               aViewCourseStatics.Code=reader["Code"].ToString();
                aViewCourseStatics.Name=reader["Name"].ToString();
                aViewCourseStatics.AssignedTo=reader["TN"].ToString();
                aViewCourseStatics.SemesterId=(int)reader["SemesterId"];

            }
            reader.Close();
            connection.Close();


            return aViewCourseStatics;
        }
        }
    }
