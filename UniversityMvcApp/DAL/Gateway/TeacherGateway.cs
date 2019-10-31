using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityMvcApp.Models;

namespace UniversityMvcApp.DAL.Gateway
{
    public class TeacherGateway
    {
        private bool message = false;

        private string connectionString =
            WebConfigurationManager.ConnectionStrings["UniversityDbContext"].ConnectionString;

        public bool DoesEmailExist(string email)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string Query = "SELECT * FROM Teachers Where Email='" + email + "' ";
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



       public List<Teacher> GetTeachers()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string Query = "SELECT * FROM Teachers ";
            SqlCommand command = new SqlCommand(Query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Teacher> teachers = new List<Teacher>();
            while (reader.Read())
            {
                Teacher teacher = new Teacher()
                {
                    ID = (int)reader["ID"],
                    Name = reader["Name"].ToString(),
                    DepartmentId =(int) reader["DepartmentId"],
                    CreditToBeTaken = (int)reader["CreditToBeTaken"]
                    
                };
                teachers.Add(teacher);
            }
            reader.Close();
            connection.Close();

            return teachers;
        }
    }
}