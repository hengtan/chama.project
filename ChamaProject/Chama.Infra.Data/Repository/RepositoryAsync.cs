using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Chama.Domain;
using Chama.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Chama.Infra.Data.Repository
{
    public class RepositoryAsync<TEntity> : IRepositoryAsync<TEntity> where TEntity : class
    {
        protected readonly ChamaContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Add(TEntity obj)
        {
            await DbSet.AddAsync(obj);
        }

        public async Task<TEntity> GetById(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        //TODO CREATE THE ASYNC METHODS REMOVE AND UPDATE
    }
}
