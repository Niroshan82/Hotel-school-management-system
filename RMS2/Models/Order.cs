using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RMS2.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        [MaxLength(50)]
        public string OrderNumber { get; set; }
        [MaxLength(10)]
        public string OrderName { get; set; }
        public DateTime Date { get; set; }
        public float TotalMoney { get; set; }
        public bool Confirm { get; set; }

        public virtual ICollection<OrderDetails> OrderDetailsList { get; set; }
    }
}