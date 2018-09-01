﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chama.Domain
{
    public interface IRepositoryAsync<TEntity> : IDisposable where TEntity : class
    {

        Task Add(TEntity obj);
        Task <TEntity> GetById(Guid id);
        Task<List<TEntity>> GetAll();
        Task<int> SaveChanges();
    }
}
