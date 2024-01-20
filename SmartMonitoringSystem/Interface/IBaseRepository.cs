using System.Linq.Expressions;

namespace SmartMonitoringSystem.Interface
{
    public interface IBaseRepository<T>
    {
        T Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Update (T entity);
        T GetById(long id);
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        void Save();
       
    }
}
