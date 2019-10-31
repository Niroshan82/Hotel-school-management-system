using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityMvcApp.DAL.Gateway;
using UniversityMvcApp.Models;

namespace UniversityMvcApp.BLL
{
    public class TeacherManager
    {
        TeacherGateway aTeacherGateway = new TeacherGateway();
        public bool DoesEmailExist(string code)
        {
            if (aTeacherGateway.DoesEmailExist(code))
            {
                return true;
            }
            else
            {
                return false;
            }
        }



       public List<Teacher> GetTeachers()
        {
           return aTeacherGateway.GetTeachers();
        }
    }
}