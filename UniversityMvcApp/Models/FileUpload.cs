using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityMvcApp.Models
{
    public class FileUpload
    {
        public int ID { get; set; }
        public string FileId { get; set; }
        public string FileName { get; set; }
        public string FileUrl { get; set; }
        public IEnumerable<FileUpload> FileList { get; set; }
    }
}