using Domain.Interfaces;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessEF
{
    public class GenericRepositoryJourneyFlight<T> : IGenericRepositoryJourneyFlight<T> where T : class
    {
        protected readonly DataContext context;
        public GenericRepositoryJourneyFlight(DataContext context)
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
        public IEnumerable<T> GetByOriginAndDestination(Expression<Func<T, bool>> expression)
        {
            return context.Set<T>().Where(expression);
        }
        public void Remove(T entity)
        {
            context.Set<T>().Remove(entity);
        }
    }
}
