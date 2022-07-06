using learn.core.Data;
using learn.core.Repository;
using learn.core.servise;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.infra.service
{
    public class categoryService : ICategoryService
    {
        private readonly ICategoryRepository repo;
        public categoryService(ICategoryRepository repo)
        {
            this.repo = repo;
        }
        public bool deletecat(int id)
        {
            return repo.deletecat(id);
        }
        public int count()
        {
            return repo.count();
        }
        public List<Category_api> getall()
        {
            return repo.getall();
        }

        public Category_api getbyidcat(int id)
        {
            return repo.getbyidcat(id);
        }

        public bool insertcat(Category_api categorey_Api)
        {
            return repo.insertcat(categorey_Api);
        }

        public bool updatecat(Category_api categorey_Api)
        {
            return repo.updatecat(categorey_Api);
        }
    }
}
