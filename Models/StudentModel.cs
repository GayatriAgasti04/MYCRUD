using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace MYCRUD.Models
{
    public class StudentModel
    {
       // step 1 then add namespace
       [ Display(Name="ID")]

        public int ID { get; set; }
        [Required(ErrorMessage ="This Name is Required..........")]
        public String Name { get; set; }
        [Required(ErrorMessage ="City is Required...........")]
        public string City { get; set; }
        [Required(ErrorMessage ="Address is Reqired...........")]
        public String Address { get; set; }
    }
}