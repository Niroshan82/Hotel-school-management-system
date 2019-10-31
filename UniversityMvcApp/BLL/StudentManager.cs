using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityMvcApp.DAL.Gateway;

namespace UniversityMvcApp.BLL
{
    public class StudentManager
    {
        StudentGateway studentGateway = new StudentGateway();
        public string GetRegistration(Models.Student student)
        {
            return studentGateway.GetRegistrationNumber(student);
        }
    }
}