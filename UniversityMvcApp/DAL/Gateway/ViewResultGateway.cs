using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityMvcApp.Models;

namespace UniversityMvcApp.DAL.Gateway
{
    public class ViewResultGateway
    {
        private string connectionString =
            WebConfigurationManager.ConnectionStrings["UniversityDbContext"].ConnectionString;

        public List<Models.ResultView> GetResultOfStudent(int studentId)
        {
            List<ResultView> viewResults = new List<ResultView>();
            SqlConnection connection = new SqlConnection(connectionString);

            string Query = "SELECT * FROM EnrollCourses WHERE StudentId='" + studentId + "'";
            SqlCommand command = new SqlCommand(Query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ResultView viewResult = new ResultView();
                viewResult.CourseCode = reader["CourseId"].ToString();
                viewResult.SubjectCode = reader["SubjectID"].ToString();


                if (reader["Grade"].ToString() == "")
                {
                    viewResult.Grade = "Not Published Yet!";
                }
                else
                {
                    viewResult.Grade = reader["Grade"].ToString();
                }
                viewResults.Add(viewResult);
            }
            reader.Close();
            connection.Close();



            List<ResultView> viewResult0 = new List<ResultView>();
            foreach (var viewResult in viewResults)
            {
                connection.Open();
                string Query0 = "SELECT * FROM Subjects WHERE SubjectID='" + viewResult.SubjectCode + "'";
                SqlCommand command0 = new SqlCommand(Query0, connection);

               
                //SqlCommand cmd2 = new SqlCommand(query2, connection);
                SqlDataReader reader2 = command0.ExecuteReader();
                while (reader2.Read())
                {

                    viewResult.SubjectCode = reader2["Code"].ToString();
                    viewResult.SubjectName = reader2["Name"].ToString();
                    viewResult0.Add(viewResult);
                }

                reader2.Close();
                connection.Close();

            }




            List<ResultView> viewResult1 = new List<ResultView>();
            foreach (var viewResult in viewResults)
            {
                connection.Open();
                string query = "SELECT * FROM Courses WHERE Id='" + viewResult.CourseCode + "'";
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader reader1 = cmd.ExecuteReader();
                while (reader1.Read())
                {
                    viewResult.CourseCode = reader1["Code"].ToString();
                    viewResult.Name = reader1["Name"].ToString();

                    viewResult1.Add(viewResult);
                }
                reader1.Close();            
                connection.Close();
            }

            return viewResult1;
        }
    }
}