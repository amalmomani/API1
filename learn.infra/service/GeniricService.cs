using learn.core.Repository;
using learn.core.servise;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.infra.service
{
    public class GeniricService : IGeniricService
    {
        private readonly IGeniricRepository repo;
        public GeniricService(IGeniricRepository repo)
        {
            this.repo = repo;
        }
        public string NumberOfCategory()
        {
            return repo.NumberOfCategory();
        }

        public List<string> NumberOfCourse()
        {
            return repo.NumberOfCourse();
        }

        public List<string> studentmark()
        {
            return repo.studentmark();  
        }
    }
}
