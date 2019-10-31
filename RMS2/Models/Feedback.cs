using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RMS2.Models
{
    [Serializable]
    public class Feedback
    {
        [Key]
        public int FeedbackID { get; set; }
        [MaxLength(20)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string Comments { get; set; }
        public int Rating { get; set; }
        public DateTime EnteredDate { get; set; }
    }
}