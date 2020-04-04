using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected proyect_weightContext Proyect_weightContext { get; set; }

        public RepositoryBase(proyect_weightContext proyect_weightContext)
        {
            this.Proyect_weightContext = proyect_weightContext;
        }

        public IEnumerable<T> FindAll()
        {
            return this.Proyect_weightContext.Set<T>();
        }

        public IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.Proyect_weightContext.Set<T>().Where(expression);
        }

        public void Create(T entity)
        {
            this.Proyect_weightContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this.Proyect_weightContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            this.Proyect_weightContext.Set<T>().Remove(entity);
        }

        public void Save()
        {
            this.Proyect_weightContext.SaveChanges();
        }
    }
}
