using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace learn.core.Data
{
    public class course_api
    {
        [Key]
        public int? courseId { get; set; }
        public string courseName { get; set; }
        public int coursePrice { get; set; }
        public int categoryId { get; set; }
        [ForeignKey("categoryId")]
        public virtual Category_api Category { get; set; }
    }
}
