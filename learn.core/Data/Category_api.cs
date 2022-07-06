using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace learn.core.Data
{
    public class Category_api
    {
        [Key]
        public int? categoryId { get; set; }
        public string categoryName { get; set; }
        public string imagePath { get; set; }
        public ICollection<course_api> course_Apis { get; set; }
    }
}
