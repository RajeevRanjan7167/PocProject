using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SSISApp.Repository.RepInterfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetAsync(object id);
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(object id);
        int CountAsync(Expression<Func<T, bool>> expression);
        IBaseRepository<T> WithoutSaveAsync();
        IBaseRepository<T> WithSaveAsync();
        Task SaveChangesAsync();
    }
}
