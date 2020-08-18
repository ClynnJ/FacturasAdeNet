using FacturasAdeNet.COMMON.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacturasAdeNet.COMMON.Interfaces
{
    public interface IRepository<T> where T : Base
    {
        bool Create(T entity);
        bool Edit(string id, T modifiedEntity);
        bool Delete(T entity);
        List<T> Read { get; }
    }
}
