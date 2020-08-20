using FacturasAdeNet.COMMON.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacturasAdeNet.COMMON.Interfaces
{
    public interface IClientsHandler : IGenericHandler<Client>
    {
        List<Client> PaidClients();
        Client FindByDNI(string dni);
    }
}
