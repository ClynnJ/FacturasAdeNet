using FacturasAdeNet.COMMON.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacturasAdeNet.COMMON.Interfaces
{
    public interface IGenericHandler<T> where T:Base
    {
        bool Add(T entity);
        List<T> ToList { get; }
        bool Delete(string id);
        bool Edit(T entity);
        T FindById(string id);
    }
}
