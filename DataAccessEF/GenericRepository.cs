using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain;
using System.Linq.Expressions;

namespace DataAccessEF
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly DataContext context;
        public GenericRepository(DataContext context)
        {
            this.context = context;
        }
        public void Add(T entity)
        {
            context.Set<T>().Add(entity);
        }
        
        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return context.Set<T>().Where(expression);
        }
        public IEnumerable<T> GetAll()
        {
            return context.Set<T>().ToList();
        }
        public T GetById(int id)
        {
            return context.Set<T>().Find(id);
        }
        public void Remove(T entity)
        {
            context.Set<T>().Remove(entity);
        }
        
    }
}
