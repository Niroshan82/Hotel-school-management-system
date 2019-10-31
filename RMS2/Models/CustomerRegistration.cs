using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RMS2.Models
{
    [Serializable]
    public class CustomerRegistration
    {
        public CustomerRegistration()
        {
            CreateDate = DateTime.Now;
            ModifyDate = DateTime.Now;
        }


        [Key]
        public int RegistrationID { get; set; }
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        public int ContactNo { get; set; }
        [MaxLength(200)]
        public string Address { get; set; }
        [MaxLength(10)]
        public string UserName { get; set; }
        [MaxLength(100)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [MaxLength(10)]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        public string VCode
        {
            get;
            set;
        }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CreateDate
        {
            get;
            set;
        }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ModifyDate
        {
            get;
            set;
        }
    }
}