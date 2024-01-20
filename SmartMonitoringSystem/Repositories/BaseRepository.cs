using Microsoft.EntityFrameworkCore;
using SmartMonitoringSystem.Interface;
using SmartMonitoringSystem.Models;
using System.Linq.Expressions;

namespace SmartMonitoringSystem.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private FypContext context;
        public BaseRepository(FypContext context)
        {
            this.context = context;
        }

        public T Add(T entity)
        {
            return context.Set<T>().Add(entity).Entity;            
        }

        public void AddRange(IEnumerable<T> entities)
        {
            context.Set<T>().AddRange(entities);
        }
        public void Update(T entity)
        {
            context.Set<T>().Attach(entity);
            context.Entry(entity).State= EntityState.Modified;
        }

        public void Delete(T entity)
        {
            context.Set<T>().Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            context.Set<T>().RemoveRange(entities);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return context.Set<T>().Where(expression);
        }

        public IEnumerable<T> GetAll()
        {
            return context.Set<T>();
        }

        public T GetById(long id)
        {
            return context.Set<T>().Find(id);
        }

        public void Save()
        {
            context.SaveChanges();
        }        
    }
}
