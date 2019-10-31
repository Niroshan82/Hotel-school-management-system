using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RMS2.Models
{
    [Serializable]
    public class FoodCategory
    {
        [Key]
        public int CategoryID { get; set; }
        [MaxLength(10)]
        public string CategoryName { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
    }
}