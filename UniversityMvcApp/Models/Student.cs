using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UniversityMvcApp.Models
{
    public class Student
    {
        
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter Student Name")]


        public string Name { get; set; }
        [Required(ErrorMessage = "Please Enter Student Email")]
        [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", ErrorMessage = "Please Enter Valid Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter Student Contact No")]
        [DisplayName("Contact No")]
        public string ContactNo { get; set; }

        [Required(ErrorMessage = "Please Enter NIC")]
        public string NIC { get; set; }


        [Required(ErrorMessage = "Please Enter  Address")]
        public string Address { get; set; }

      
        [DisplayName("DepartmentId")]   
        
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }

        
        [DisplayName("CourID")]

        public int? CourID { get; set; }
        [ForeignKey("CourID")]
        public virtual Course Course { get; set; }

        public string RegistrationSerial { get; set; }

        public List<EnrollCourses> EnrollCourses { get; set; }

    }
}