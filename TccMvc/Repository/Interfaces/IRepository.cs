using System.Linq.Expressions;
namespace TccMvc.Repository.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(Expression<Func<T, bool>> predicate);
        Task<T> GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void DeleteRange(List<T> entity);
    }
}
