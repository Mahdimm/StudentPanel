using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace test_app1.Models
{
    public class Student
    {
        [Display(Name = "کد")]
        public int ID { get; set; }
        [Required(ErrorMessage = "مقدار ضروری")]
        [Display(Name = "نام")]
        public string Name { get; set; }
        [Required(ErrorMessage = "مقدار ضروری")]
        [Display(Name = "نام خانوادگی")]
        public string Family { get; set; }
        [Required(ErrorMessage = "مقدار ضروری")]
        [Display(Name = "سن")]
        public string Age { get; set; }
        [Required(ErrorMessage = "مقدار ضروری")]
        [Display(Name = "آدرس")]
        public string Address { get; set; }
    }
}