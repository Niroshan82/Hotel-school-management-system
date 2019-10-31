using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityMvcApp.DAL.Gateway;

namespace UniversityMvcApp.BLL
{
    public class ViewResultManager
    {
        ViewResultGateway viewResultGateway = new ViewResultGateway();
        public List<Models.ResultView> GetResultOfStudent(int studentId)
        {
            return viewResultGateway.GetResultOfStudent(studentId);
        }
    }
}