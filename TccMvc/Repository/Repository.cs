using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TccMvc.Context;
using TccMvc.Repository.Interfaces;
namespace TccMvc.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {

        protected AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }


        public async Task<T> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async void Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void DeleteRange(List<T> entity)
        {
            _context.Set<T>().RemoveRange(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public async Task<T> Get(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(predicate);
        }

        
    }
}
