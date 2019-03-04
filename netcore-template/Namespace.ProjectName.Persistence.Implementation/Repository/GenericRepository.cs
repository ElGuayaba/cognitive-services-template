using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Namespace.ProjectName.Domain.Contract;
using Namespace.ProjectName.Persistence.Contract.Repository;

namespace Namespace.ProjectName.Persistence.Implementation.Repository
{
    public class GenericRepository<T> : IAbstractGenericRepository<T> where T : IAggregateRoot
    {
        internal readonly DbContext Context;
        
        internal readonly DbSet<T> DbSet;

        public GenericRepository(C dbDbContext)
        {
            this.Context = dbDbContext ?? throw new ArgumentNullException(nameof(dbDbContext));
            this.DbSet = dbDbContext.Set<T>();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return DbSet;
        }

        public virtual async Task<T> GetById(object id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<T> Insert(T entity)
        {
            var entry = await DbSet.AddAsync(entity);
            
            return entry.Entity;
        }

        public virtual T Update(T entityToUpdate)
        {
            var entry = DbSet.Attach(entityToUpdate);
            
            Context.Entry(entityToUpdate).State = EntityState.Modified;

            return entry.Entity;
        }

        public virtual T Delete(object id)
        {
            T entityToDelete = DbSet.Find(id);
            
            return Delete(entityToDelete);
        }

        public virtual T Delete(T entityToDelete)
        {
            if (Context.Entry(entityToDelete).State == EntityState.Detached)
            {
                DbSet.Attach(entityToDelete);
            }
            
            var entry = DbSet.Remove(entityToDelete);

            return entry.Entity;
        }
    }
}