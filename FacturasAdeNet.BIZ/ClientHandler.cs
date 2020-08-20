using FacturasAdeNet.COMMON.Entities;
using FacturasAdeNet.COMMON.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FacturasAdeNet.BIZ
{
    public class ClientHandler : IClientsHandler
    {
        IRepository<Client> repo;
        
        public ClientHandler(IRepository<Client> repo)
        {
            this.repo = repo;
        }
        public List<Client> ToList => repo.Read;

        public bool Add(Client entity)
        {
            return repo.Create(entity);
        }

        public bool Delete(string id)
        {
            return repo.Delete(id);
        }

        public bool Edit(Client entity)
        {
            return repo.Edit(entity);
        }

        public Client FindByDNI(string dni)
        {
            return ToList.Where(e => e.DNI == dni).SingleOrDefault();
        }

        public Client FindById(string id)
        {
            return ToList.Where(e => e.Id == id).SingleOrDefault();
        }

        public List<Client> PaidClients()
        {
            return ToList.Where(e => e.Status == 1).ToList();
        }
    }
}
