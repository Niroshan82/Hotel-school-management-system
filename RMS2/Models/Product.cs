using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RMS2.Models
{
    [Serializable]
    public class Product
    {
        [Key]
        public int ProductID { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage ="This field is required")]
        public string ProductName { get; set; }

        [MaxLength(10)]
        [Required(ErrorMessage = "This field is required")]
        public string ItemCode { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public float Price { get; set; }

        [MaxLength(10)]
        public string Category { get; set; }

        [MaxLength(500)]
        [Required(ErrorMessage = "This field is required")]
        public string Description { get; set; }

        [MaxLength(500)]
        public string Image { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
    }
}