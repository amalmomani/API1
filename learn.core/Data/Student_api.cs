using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace learn.core.Data
{
    public class Student_api
    {
        [Key]
        public int studentId { get; set; }
        public string studentName { get; set; }
        public DateTime birthdate { get; set; }
        public int mark { get; set; }
      
    }
}
