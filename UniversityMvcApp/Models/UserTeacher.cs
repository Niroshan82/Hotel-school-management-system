using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UniversityMvcApp.Models
{
    public class UserTeacher
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int UserID { get; set; }
        [MaxLength(100)]
        [Required(ErrorMessage = "This Field Required")]
        public string UserName { get; set; }
        [MaxLength(100)]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "This Field Required")]
        public string Password { get; set; }

        public string SubName { get; set; }

        [NotMapped]
        public string LoginErrorMessage { get; set; }
    }
}