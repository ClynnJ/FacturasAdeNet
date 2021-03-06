﻿using FacturasAdeNet.COMMON.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacturasAdeNet.COMMON.Interfaces
{
    public interface IRepository<T> where T : Base
    {
        bool Create(T entity);
        bool Edit(T modifiedEntity);
        bool Delete(string id);
        List<T> Read { get; }
    }
}
