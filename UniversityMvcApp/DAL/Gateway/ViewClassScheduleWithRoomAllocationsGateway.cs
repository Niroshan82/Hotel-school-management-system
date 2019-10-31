using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityMvcApp.Models;

namespace UniversityMvcApp.DAL.Gateway
{
    public class ViewClassScheduleWithRoomAllocationsGateway
    {
        private string connectionString =
          WebConfigurationManager.ConnectionStrings["UniversityDbContext"].ConnectionString;

        //List<ViewClassScheduleWithRoomAllocation> viewClassScheduleWithRoomAllocations = new List<ViewClassScheduleWithRoomAllocation>();
        public ViewClassScheduleWithRoomAllocation GetView(Course course)
        {

            List<Models.ViewClassScheduleWithRoomAllocation> viewClassScheduleWithRoomAllocations0 = new List<ViewClassScheduleWithRoomAllocation>();

            ViewClassScheduleWithRoomAllocation viewClassScheduleWithRoomAllocations = new ViewClassScheduleWithRoomAllocation();

            SqlConnection connection = new SqlConnection(connectionString);
            string Query = "SELECT * FROM AllocateClassRooms JOIN Rooms ON AllocateClassRooms.RoomId=Rooms.Id WHERE CourseId='" + course.Id + "'";
            SqlCommand command = new SqlCommand(Query, connection);
            viewClassScheduleWithRoomAllocations.DepartmentName = course.Code;
            viewClassScheduleWithRoomAllocations.CourseName = course.Name;
            viewClassScheduleWithRoomAllocations.ScheduleInfo = "";
            viewClassScheduleWithRoomAllocations.SubjectCode = "";

          //  viewClassScheduleWithRoomAllocations3.SubjectCode = "";


            // string SubjectCode = "";

            //viewClassScheduleWithRoomAllocations.SubjectName = "";
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if(!reader.HasRows)
            {
                viewClassScheduleWithRoomAllocations.ScheduleInfo = "Not Scheduled Yet!";
            }
            else
            {
                while (reader.Read())
                {
                    viewClassScheduleWithRoomAllocations.ScheduleInfo += "RooM No: " + reader["RoomNo"].ToString();
                    viewClassScheduleWithRoomAllocations.ScheduleInfo += ", "+reader["Day"].ToString();
                    viewClassScheduleWithRoomAllocations.ScheduleInfo += ", " + reader["From"].ToString();
                    viewClassScheduleWithRoomAllocations.ScheduleInfo += "- " + reader["TO"].ToString();
                    viewClassScheduleWithRoomAllocations.ScheduleInfo += "\n ";
                    viewClassScheduleWithRoomAllocations.SubjectCode = reader["SubjectID"].ToString();

                }
               viewClassScheduleWithRoomAllocations0.Add(viewClassScheduleWithRoomAllocations);

             

            }

            var viewClassScheduleWithRoomAllocations60 = viewClassScheduleWithRoomAllocations0;


            reader.Close();
            connection.Close();

            //List<ViewClassScheduleWithRoomAllocation> viewClassScheduleWithRoomAllocations0 = new List<ViewClassScheduleWithRoomAllocation>();

            //ViewClassScheduleWithRoomAllocation viewClassScheduleWithRoomAllocations1 = new ViewClassScheduleWithRoomAllocation();



            //foreach (var viewResult in viewClassScheduleWithRoomAllocations0)
            //{
            //    connection.Open();
            //    string Query0 = "SELECT * FROM Subjects WHERE SubjectID='" + viewResult.SubjectCode + "'";
            //    SqlCommand command0 = new SqlCommand(Query0, connection);


            //    //SqlCommand cmd2 = new SqlCommand(query2, connection);
            //    SqlDataReader reader2 = command0.ExecuteReader();
            //    while (reader2.Read())
            //    {

            //        viewResult.SubjectCode = reader2["Code"].ToString();
            //        viewResult.SubjectName = reader2["Name"].ToString();
            //        //viewClassScheduleWithRoomAllocations1.Add(viewResult);
            //        //viewClassScheduleWithRoomAllocations1
            //    }

            //    reader2.Close();
            //    connection.Close();

            //}

            ViewClassScheduleWithRoomAllocation viewClassScheduleWithRoomAllocations3 = new ViewClassScheduleWithRoomAllocation();

            foreach (var viewClassScheduleWithRoomAllocations1 in viewClassScheduleWithRoomAllocations0)
            {
                connection.Open();
                string Query0 = "SELECT * FROM Subjects WHERE SubjectID='" + viewClassScheduleWithRoomAllocations1.SubjectCode + "'";
                SqlCommand command0 = new SqlCommand(Query0, connection);

                

                viewClassScheduleWithRoomAllocations.SubjectCode = "";
                viewClassScheduleWithRoomAllocations.SubjectName = "";



                //SqlCommand cmd2 = new SqlCommand(query2, connection);
                SqlDataReader reader2 = command0.ExecuteReader();
                while (reader2.Read())
                {

                   
                 //   viewClassScheduleWithRoomAllocations3.SubjectCode = reader["SubjectID"].ToString();



                    viewClassScheduleWithRoomAllocations.SubjectCode = reader2["Code"].ToString();
                    viewClassScheduleWithRoomAllocations.SubjectName = reader2["Name"].ToString();
                    //viewClassScheduleWithRoomAllocations1.Add(viewResult);
                    //viewClassScheduleWithRoomAllocations1
                }
                //viewClassScheduleWithRoomAllocations.Add(viewClassScheduleWithRoomAllocations3);
                //viewClassScheduleWithRoomAllocations= viewClassScheduleWithRoomAllocations + viewClassScheduleWithRoomAllocations3;

                reader2.Close();
                connection.Close();

            }

            ViewClassScheduleWithRoomAllocation viewClassScheduleWithRoomAllocations2 = new ViewClassScheduleWithRoomAllocation();

            // viewClassScheduleWithRoomAllocations2 = TypeMerger.MergeTypes(viewClassScheduleWithRoomAllocations3, viewClassScheduleWithRoomAllocations3);

            var viewClassScheduleWithRoomAllocations62 = viewClassScheduleWithRoomAllocations;

          //  var result = TypeMerger.MergeTypes(viewClassScheduleWithRoomAllocations60, viewClassScheduleWithRoomAllocations62);
            // viewClassScheduleWithRoomAllocations2 = new  { viewClassScheduleWithRoomAllocations, viewClassScheduleWithRoomAllocations3 };

            return viewClassScheduleWithRoomAllocations62 ;
        }

        public ViewClassScheduleWithRoomAllocation GetView2(Subject subject)
        {

            List<Models.ViewClassScheduleWithRoomAllocation> viewClassScheduleWithRoomAllocations0 = new List<ViewClassScheduleWithRoomAllocation>();

            ViewClassScheduleWithRoomAllocation viewClassScheduleWithRoomAllocations = new ViewClassScheduleWithRoomAllocation();

            SqlConnection connection = new SqlConnection(connectionString);
            string Query = "SELECT * FROM AllocateClassRooms JOIN Rooms ON AllocateClassRooms.RoomId=Rooms.Id WHERE SubjectID='" + subject.SubjectID + "'";
            SqlCommand command = new SqlCommand(Query, connection);
            viewClassScheduleWithRoomAllocations.DepartmentId = subject.DepartmentId;
            viewClassScheduleWithRoomAllocations.DepartmentName = subject.DepartmentName;
            viewClassScheduleWithRoomAllocations.CourseName = subject.CourseName;
            viewClassScheduleWithRoomAllocations.SubjectCode = subject.Code;
            viewClassScheduleWithRoomAllocations.SubjectName = subject.Name;
            viewClassScheduleWithRoomAllocations.ScheduleInfo = "";
            
           
           

            //  viewClassScheduleWithRoomAllocations3.SubjectCode = "";


            // string SubjectCode = "";

            //viewClassScheduleWithRoomAllocations.SubjectName = "";
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (!reader.HasRows)
            {
                viewClassScheduleWithRoomAllocations.ScheduleInfo = "Not Scheduled Yet!";
            }
            else
            {
                while (reader.Read())
                {
                    viewClassScheduleWithRoomAllocations.ScheduleInfo += "RooM No: " + reader["RoomNo"].ToString();
                    viewClassScheduleWithRoomAllocations.ScheduleInfo += ", " + reader["Day"].ToString();
                    viewClassScheduleWithRoomAllocations.ScheduleInfo += ", " + reader["From"].ToString();
                    viewClassScheduleWithRoomAllocations.ScheduleInfo += "- " + reader["TO"].ToString();
                    viewClassScheduleWithRoomAllocations.ScheduleInfo += "\n ";
                   // viewClassScheduleWithRoomAllocations.SubjectCode = reader["SubjectID"].ToString();

                }
                viewClassScheduleWithRoomAllocations0.Add(viewClassScheduleWithRoomAllocations);


              //  return viewClassScheduleWithRoomAllocations0;
            }

         //  var viewClassScheduleWithRoomAllocations60 = viewClassScheduleWithRoomAllocations0;

           //retern viewClassScheduleWithRoomAllocations60;
            reader.Close();
            connection.Close();
            return viewClassScheduleWithRoomAllocations;
            //List<ViewClassScheduleWithRoomAllocation> viewClassScheduleWithRoomAllocations0 = new List<ViewClassScheduleWithRoomAllocation>();

            //ViewClassScheduleWithRoomAllocation viewClassScheduleWithRoomAllocations1 = new ViewClassScheduleWithRoomAllocation();



            //foreach (var viewResult in viewClassScheduleWithRoomAllocations0)
            //{
            //    connection.Open();
            //    string Query0 = "SELECT * FROM Subjects WHERE SubjectID='" + viewResult.SubjectCode + "'";
            //    SqlCommand command0 = new SqlCommand(Query0, connection);


            //    //SqlCommand cmd2 = new SqlCommand(query2, connection);
            //    SqlDataReader reader2 = command0.ExecuteReader();
            //    while (reader2.Read())
            //    {

            //        viewResult.SubjectCode = reader2["Code"].ToString();
            //        viewResult.SubjectName = reader2["Name"].ToString();
            //        //viewClassScheduleWithRoomAllocations1.Add(viewResult);
            //        //viewClassScheduleWithRoomAllocations1
            //    }

            //    reader2.Close();
            //    connection.Close();

            //}

            //ViewClassScheduleWithRoomAllocation viewClassScheduleWithRoomAllocations3 = new ViewClassScheduleWithRoomAllocation();

            //foreach (var viewClassScheduleWithRoomAllocations1 in viewClassScheduleWithRoomAllocations0)
            //{
            //    connection.Open();
            //    string Query0 = "SELECT * FROM Subjects WHERE SubjectID='" + viewClassScheduleWithRoomAllocations1.SubjectCode + "'";
            //    SqlCommand command0 = new SqlCommand(Query0, connection);



            //    viewClassScheduleWithRoomAllocations.SubjectCode = "";
            //    viewClassScheduleWithRoomAllocations.SubjectName = "";



            //    //SqlCommand cmd2 = new SqlCommand(query2, connection);
            //    SqlDataReader reader2 = command0.ExecuteReader();
            //    while (reader2.Read())
            //    {


            //        //   viewClassScheduleWithRoomAllocations3.SubjectCode = reader["SubjectID"].ToString();



            //        viewClassScheduleWithRoomAllocations.SubjectCode = reader2["Code"].ToString();
            //        viewClassScheduleWithRoomAllocations.SubjectName = reader2["Name"].ToString();
            //        //viewClassScheduleWithRoomAllocations1.Add(viewResult);
            //        //viewClassScheduleWithRoomAllocations1
            //    }
            //    //viewClassScheduleWithRoomAllocations.Add(viewClassScheduleWithRoomAllocations3);
            //    //viewClassScheduleWithRoomAllocations= viewClassScheduleWithRoomAllocations + viewClassScheduleWithRoomAllocations3;

            //    reader2.Close();
            //    connection.Close();

            //}

            //ViewClassScheduleWithRoomAllocation viewClassScheduleWithRoomAllocations2 = new ViewClassScheduleWithRoomAllocation();

            // viewClassScheduleWithRoomAllocations2 = TypeMerger.MergeTypes(viewClassScheduleWithRoomAllocations3, viewClassScheduleWithRoomAllocations3);

            // var viewClassScheduleWithRoomAllocations62 = viewClassScheduleWithRoomAllocations;

            //  var result = TypeMerger.MergeTypes(viewClassScheduleWithRoomAllocations60, viewClassScheduleWithRoomAllocations62);
            // viewClassScheduleWithRoomAllocations2 = new  { viewClassScheduleWithRoomAllocations, viewClassScheduleWithRoomAllocations3 };

            // return viewClassScheduleWithRoomAllocations60;
        }
    }
}