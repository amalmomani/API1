using learn.core.Data;
using learn.core.servise;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;

        }
        [HttpDelete("delete/{id}")] //delete record from database
        public bool detecategory(int id)
        {

            return categoryService.deletecat(id);
        }
        [HttpGet]//retrevie all data
        public List<Category_api> category()
        {
            return categoryService.getall();
        }
        [HttpGet("{id}")] // retrive data by id
        public Category_api category(int id)
        {

            return categoryService.getbyidcat(id);
        }
        [HttpPost]//insert new record in database
        public bool createcategory([FromBody] Category_api cc)
        {

            return categoryService.insertcat(cc);
        }
        [HttpPut] //update
        public bool updatecourse([FromBody] Category_api cc)
        {

            return categoryService.updatecat(cc);
        }

        [HttpGet]
        [Route("c")]
        public int Count()
        {
            return categoryService.count();
        }
    }
}
