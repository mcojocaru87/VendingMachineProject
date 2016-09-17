using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Linq.Expressions;
using VendingMachine.Data;


namespace VendingMachine.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext context;

        public Repository(DbContext context)
        {
            this.context = context;
        }

        public T Get(int id)
        {
            return context.Set<T>().Find(id);
        }
        public IEnumerable<T> GetAll()
        {
            return context.Set<T>().ToList();
        }
        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>().Where(predicate);
        }
        public T SingleOrDefault(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>().SingleOrDefault(predicate);
        }

        public void Add(T entity)
        {
            context.Set<T>().Add(entity);
        }
        public void Remove(T entity)
        {
            context.Set<T>().Remove(entity);
        }

        public VendingMachineContext VendingMachineContext
        {
            get { return context as VendingMachineContext; }
        }

    }
}
