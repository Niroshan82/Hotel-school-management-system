using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityMvcApp.Models
{
    public class tblFileDetails
    {
        [Key]
        public int SQLID { get; set; }

        public string FILENAME { get; set; }

        public string FILEURL { get; set; }
    }
}