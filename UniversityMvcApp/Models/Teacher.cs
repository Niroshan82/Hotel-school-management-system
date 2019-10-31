using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using DataAnnotationsExtensions;

namespace UniversityMvcApp.Models
{
    public class Teacher
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Please enter a name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter an address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter an email")]
        [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", ErrorMessage = "Please enter a valid email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter a contact number")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a valid  Number")]
        public string ContactNo { get; set; }

       
        [Required(ErrorMessage = "Please select a department")]
        [DisplayName("Department")]
       
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }

        [DisplayName("Credit to be taken")]
        [Required(ErrorMessage = "Please enter credit to be taken")]
        [Range(1, 140,ErrorMessage = "CreditToBeTaken cannot be a negative number")]
        public int CreditToBeTaken { get; set; }

       

        public virtual List<Course> Courses { get; set; }
        
        public int RemainingCredit { get; set; }

        public int CreditTaken { get; set; }

        [Required(ErrorMessage = "Please select a designation")]
        public int DesignationId { get; set; }
       [ForeignKey("DesignationId")]
        public virtual Designation Designation { get; set; }

        public string Availability { get; set; }




    }
}