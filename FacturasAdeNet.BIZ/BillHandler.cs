using FacturasAdeNet.COMMON.Entities;
using FacturasAdeNet.COMMON.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FacturasAdeNet.BIZ
{
    public class BillHandler : IBillsHandler
    {
        IRepository<Bill> repo;

        public BillHandler(IRepository<Bill> repo)
        {
            this.repo = repo;
        }
        public List<Bill> ToList => repo.Read;

        public bool Add(Bill entity)
        {
            return repo.Create(entity);
        }

        public bool Delete(string id)
        {
            return repo.Delete(id);
        }

        public bool Edit(Bill entity)
        {
            return repo.Edit(entity);
        }

        public Bill FindById(string id)
        {
            return ToList.Where(e => e.Id == id).SingleOrDefault();
        }
    }
}
