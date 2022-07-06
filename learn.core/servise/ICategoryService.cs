using learn.core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.servise
{
    public interface ICategoryService
    {
        public bool insertcat(Category_api categorey_Api);
        public bool updatecat(Category_api categorey_Api);

        public bool deletecat(int id);

        public List<Category_api> getall();

        public Category_api getbyidcat(int id);
        public int count();

    }
}
