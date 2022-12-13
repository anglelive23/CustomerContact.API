using System.Linq.Expressions;

namespace CustomerContacts.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        T Find(Expression<Func<T, bool>> cretria, string[] includes = null);
        IEnumerable<T> GetAll(string[] includes = null);

        void Update();

        void Post(T entity);

        void Delete(T entity);
    }
}
