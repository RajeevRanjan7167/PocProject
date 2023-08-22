using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSISApp.Service.IServices
{
    public interface IBaseService<TViewModel> where TViewModel : class
    {
        Task<IEnumerable<TViewModel>> GetAllAsync();
        Task<TViewModel> GetAsync(int id);
        Task<TViewModel> CreateAsync(TViewModel entity);
        Task<TViewModel> UpdateAsync(TViewModel entity);
        Task<TViewModel> UpdateAsync(int Id, TViewModel obj);
        Task<TViewModel> DeleteAsync(int id);
    }
}
