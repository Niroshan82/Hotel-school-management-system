using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityMvcApp.Models;

namespace UniversityMvcApp.DAL.Gateway
{
    public class DepartmentGateway
    {
        private bool message = false;
        private string connectionString =
            WebConfigurationManager.ConnectionStrings["UniversityDbContext"].ConnectionString;
        public bool IsCodeExist(string code)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string Query = "SELECT * FROM Departments Where Code='" + code + "' ";
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
            string Query = "SELECT * FROM Departments Where Name='" + name + "' ";
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


        public List<Department> GetAllDepartment()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string Query = "SELECT * FROM Departments ";
            SqlCommand command = new SqlCommand(Query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Department> departments=new List<Department>();
            while (reader.Read())
            {
                Department department = new Department()
                {
                    ID=(int)reader["ID"],
                    Name = reader["Name"].ToString(),
                    Code=reader["Code"].ToString()
                };
                departments.Add(department);
            }
            reader.Close();
            connection.Close();

            return departments;
        }
    }
}