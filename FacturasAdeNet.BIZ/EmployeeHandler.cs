using FacturasAdeNet.COMMON.Entities;
using FacturasAdeNet.COMMON.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FacturasAdeNet.BIZ
{
    public class EmployeeHandler : IEmployeesHandler
    {
        IRepository<Employee> repo;

        public EmployeeHandler(IRepository<Employee> repo)
        {
            this.repo = repo;
        }
        public List<Employee> ToList => repo.Read;

        public bool Add(Employee entity)
        {
            return repo.Create(entity);
        }

        public bool Delete(string id)
        {
            return repo.Delete(id);
        }

        public bool Edit(Employee entity)
        {
            return repo.Edit(entity);
        }

        public Employee FindById(string id)
        {
            return ToList.Where(e => e.Id == id).SingleOrDefault();
        }
    }
}
