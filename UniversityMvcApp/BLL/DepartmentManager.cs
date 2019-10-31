using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityMvcApp.DAL.Gateway;
using UniversityMvcApp.Models;

namespace UniversityMvcApp.BLL
{
    public class DepartmentManager
    {
        DepartmentGateway aDepartmentGateway = new DepartmentGateway();

        public bool IsCodeExist(string code)
        {
            if (aDepartmentGateway.IsCodeExist(code))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsNameExist(string name)
        {
            if (aDepartmentGateway.IsNameExist(name))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Department> GetDepartments()
        {
            return aDepartmentGateway.GetAllDepartment();
        }

        public List<Models.Department> GetAllDepartments()
        {
            return aDepartmentGateway.GetAllDepartment();
        }
    }
}