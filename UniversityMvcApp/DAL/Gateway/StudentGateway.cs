using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace UniversityMvcApp.DAL.Gateway
{
    public class StudentGateway
    {
        public string ConnectionString = WebConfigurationManager.ConnectionStrings["UniversityDBContext"].ConnectionString;


        public string GetRegistrationNumber(Models.Student student)
        {
            int count = 0;
            SqlConnection connection = new SqlConnection(ConnectionString);

            string Query = "SELECT (COUNT(1)+1) FROM Students WHERE DepartmentId='"+student.DepartmentId+"'and NIC='"+student.NIC+"' and CourID='" + student.CourID + "' ";

            SqlCommand command = new SqlCommand(Query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                count = (int)reader[0];
            }
            connection.Close();

            string Query2 = "SELECT * FROM Departments WHERE ID='" + student.DepartmentId + "' ";

            SqlCommand command2 = new SqlCommand(Query2, connection);
            connection.Open();
            SqlDataReader reader2 = command2.ExecuteReader();
            string DeptCode="";
            while (reader2.Read())
            {
                DeptCode = reader2["Code"].ToString();
            }
            connection.Close();

            string Query3 = "SELECT * FROM Courses WHERE ID='" + student.CourID + "' ";

            SqlCommand command3 = new SqlCommand(Query3, connection);
            connection.Open();
            SqlDataReader reader3 = command3.ExecuteReader();
            string DeptCode2 = "";
            while (reader3.Read())
            {
                DeptCode2 = reader3["Code"].ToString();
            }
            connection.Close();

            string registration = DeptCode2 + "-" + student.NIC ;


            return registration;

        }
    }
}