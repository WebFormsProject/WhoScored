using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using WhoScored.Data.Contracts;

namespace WhoScored.Data
{
    public class WhoScoredRepository<T> : IWhoScoredRepository<T> where T : class
    {
        public WhoScoredRepository(IWhoScoredContext context)
        {
            Guard.WhenArgument(context, "context").IsNull();

            this.Context = context;
            this.DbSet = this.Context.Set<T>();
        }

        public IWhoScoredContext Context
        {
            get; set;
        }

        public IDbSet<T> DbSet
        {
            get; set;
        }

        public void Add(T entity)
        {
            DbEntityEntry entry = this.Context.Entry(entity);
            entry.State = EntityState.Added;
        }

        public void Update(T entity)
        {
            DbEntityEntry entry = this.Context.Entry(entity);
            entry.State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            DbEntityEntry entry = this.Context.Entry(entity);
            entry.State = EntityState.Deleted;
        }

        public T GetById(object id)
        {
            return this.DbSet.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return this.DbSet;
        }

        private DbEntityEntry AttachIfDetached(T entity)
        {
            DbEntityEntry entry = this.Context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.DbSet.Attach(entity);
            }

            return entry;
        }
    }
}
