using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RMS2.Models
{
    [Serializable]
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }
        [MaxLength(10)]
        public string EmpCode { get; set; }
        [MaxLength(10)]
        public string Status { get; set; }
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        [MaxLength(10)]
        public string Gender { get; set; }
        [MaxLength(15)]
        public string NicNo { get; set; }
        public int ContactNo { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        [MaxLength(200)]
        public string Address { get; set; }
        [MaxLength(20)]
        public string Position { get; set; }
        [MaxLength(500)]
        public string Image { get; set; }
    }
}