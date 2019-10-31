using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityMvcApp.Models
{
    public class UserTypes
    {
        [Key]
        public int ID { get; set; }

        public string UserType { get; set; }
    }
}