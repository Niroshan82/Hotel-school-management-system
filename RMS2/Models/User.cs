using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RMS2.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int UserID { get; set; }
        [MaxLength(10)]
        [Required(ErrorMessage = "This Field Required")]
        public string UserName { get; set; }
        [MaxLength(10)]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "This Field Required")]
        public string Password { get; set; }

        [NotMapped]
        public string LoginErrorMessage { get; set; }
    }
}