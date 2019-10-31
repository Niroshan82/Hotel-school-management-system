using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace UniversityMvcApp.DAL.Gateway
{
    public class UnallocateAllClassroomGateway
    {
        private bool message = false;
        private string connectionString =
            WebConfigurationManager.ConnectionStrings["UniversityDbContext"].ConnectionString;
        public bool UpdateCourses()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string Query = "Delete AllocateClassRooms";
            SqlCommand command = new SqlCommand(Query, connection);
            connection.Open();
            int roweff = command.ExecuteNonQuery();
            if (roweff != 0)
            {
                message = true;
            }

            connection.Close();

            return message;
        }
    }
}