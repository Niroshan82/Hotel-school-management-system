using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityMvcApp.Models;

namespace UniversityMvcApp.DAL.Gateway
{
    public class AllocateClassRoomGateway
    {
        private string connectionString =
          WebConfigurationManager.ConnectionStrings["UniversityDbContext"].ConnectionString;

        public bool IsTimeAlocated(AllocateClassRoom allocateClassRoom)
        {
            bool message = false;
            SqlConnection connection = new SqlConnection(connectionString);
            string Query = "SELECT * FROM AllocateClassRooms WHERE((StartTime>'" + (allocateClassRoom.StartTime + TimeSpan.FromMinutes(1)) + "' AND StartTime<'" + (allocateClassRoom.FinishTime - TimeSpan.FromMinutes(1)) + "') OR(StartTime<'" + (allocateClassRoom.StartTime + TimeSpan.FromMinutes(1)) + "' AND  FinishTime>'" + (allocateClassRoom.StartTime + TimeSpan.FromMinutes(1)) + "'))AND RoomId='" + allocateClassRoom.RoomId + "' AND Day='" + allocateClassRoom.Day + "'";
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

        public bool HasClass(AllocateClassRoom allocateClassRoom)
        {
            bool message = false;
            SqlConnection connection = new SqlConnection(connectionString);
            string Query = "SELECT * FROM AllocateClassRooms WHERE((StartTime>'" + (allocateClassRoom.StartTime + TimeSpan.FromMinutes(1)) + "' AND StartTime<'" + (allocateClassRoom.FinishTime - TimeSpan.FromMinutes(1)) + "') OR(StartTime<'" + (allocateClassRoom.StartTime + TimeSpan.FromMinutes(1)) + "' AND  FinishTime>'" + (allocateClassRoom.StartTime + TimeSpan.FromMinutes(1)) + "'))AND Day='" + allocateClassRoom.Day + "'AND CourseId='" + allocateClassRoom.CourseId + "'";
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








    }
}