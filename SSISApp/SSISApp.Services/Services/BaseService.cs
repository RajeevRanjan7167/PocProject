using AutoMapper;
using SSISApp.Common.Exceptions;
using SSISApp.Repository.RepInterfaces;
using SSISApp.Service.IServices;

namespace SSISApp.Service.Services
{
    public abstract class BaseService<TViewModel, TRepository, TDomainModel> : IBaseService<TViewModel>
        where TViewModel : class
        where TDomainModel : class
        where TRepository : IBaseRepository<TDomainModel>
    {
        private readonly TRepository _repository;
        private readonly IMapper _mapper;

        public BaseService(TRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public async virtual Task<TViewModel> CreateAsync(TViewModel entity)
        {
            var modelReturned = _mapper.Map<TDomainModel>(entity);
            return _mapper.Map<TViewModel>(await _repository.CreateAsync(modelReturned).ConfigureAwait(false));
        }

        public async virtual Task<TViewModel> DeleteAsync(int id)
        {
            return _mapper.Map<TViewModel>(await _repository.DeleteAsync(id).ConfigureAwait(false));
        }

        public async virtual Task<IEnumerable<TViewModel>> GetAllAsync()
        {
            var modelReturned = await _repository.GetAllAsync().ConfigureAwait(false);
            return _mapper.Map<IEnumerable<TViewModel>>(modelReturned);
        }

        public async virtual Task<TViewModel> GetAsync(int id)
        {
            var objReturned = await _repository.GetAsync(id).ConfigureAwait(false);
            if (objReturned == null)
                throw new DataNotFound(typeof(TViewModel).ToString());

            return _mapper.Map<TViewModel>(objReturned);
        }

        public virtual async Task<TViewModel> UpdateAsync(TViewModel entity)
        {
            var modelReturned = _mapper.Map<TDomainModel>(entity);
            return _mapper.Map<TViewModel>(await _repository.UpdateAsync(modelReturned).ConfigureAwait(false));
        }

        public async virtual Task<TViewModel> UpdateAsync(int Id, TViewModel obj)
        {
            var existingData = await _repository.GetAsync(Id).ConfigureAwait(false);
            var modelReturned = _mapper.Map(obj, existingData);
            return _mapper.Map<TViewModel>(await _repository.UpdateAsync(modelReturned).ConfigureAwait(false));
        }
    }
}
