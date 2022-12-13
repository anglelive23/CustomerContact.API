using CustomerContacts.Data;
using CustomerContacts.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CustomerContacts.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        ApplicationDbContext _context;
        public BaseRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public T Find(Expression<Func<T, bool>> cretria, string[] includes = null)
        {
            IQueryable<T> query = _context.Set<T>();
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return query.FirstOrDefault(cretria);
        }

        public IEnumerable<T> GetAll(string[] includes = null)
        {
            IQueryable<T> query = _context.Set<T>();

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return query.ToList();
        }

        public void Update()
        {
            _context.SaveChanges();
        }

        public void Post(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }
    }
}
