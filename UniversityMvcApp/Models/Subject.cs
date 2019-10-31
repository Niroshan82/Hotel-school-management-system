using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversityMvcApp.Models
{

    
    public class Subject
    {

        public int SubjectID { get; set; }

        [DisplayName("Department")]
        public int? DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }

        [DisplayName("DepName")]
        public string DepartmentName { get; set; }

        [DisplayName("Course")]
        public int? SubCourForId { get; set; }
        [ForeignKey("SubCourForId")]
        public virtual Course Course { get; set; }

        [DisplayName("CourseName")]
        public string CourseName { get; set; }

        
        [Required(ErrorMessage = "Please enter course code")]
        [StringLength(100, MinimumLength = 5)]
        public string Code { get; set; }

       
        [Required(ErrorMessage = "Please enter course name")]
        //[Unique("TestDataAnnotations.EntitiesModel")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter credit")]
        [Range(1, 140)]
        public int Credit { get; set; }


        //[DisplayName("SubCourForId")]

        //public int? SubCourForId { get; set; }
        //[ForeignKey("SubCourForId")]
        //public virtual Course Course { get; set; }

        

        public virtual List<AllocateClassRoom> AllocateClassRooms { get; set; }




        public DateTime date { get; set; }

        

       




    }
}