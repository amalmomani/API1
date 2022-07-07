using learn.core.DTO;
using learn.core.Repository;
using learn.core.servise;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.infra.service
{
    public class Student_DTOService:IStudent_DTOService
    {
        private readonly IStudent_DTORepository repo;
        public Student_DTOService(IStudent_DTORepository repo)
        {
            this.repo = repo;
        }
        public List<Student_DTO> getinfo()
        {
            return repo.getinfo();
        }
    }
}
