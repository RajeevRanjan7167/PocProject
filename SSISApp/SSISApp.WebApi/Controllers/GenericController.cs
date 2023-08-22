using Microsoft.AspNetCore.Mvc;
using SSISApp.Service.IServices;
using static SSISApp.WebApi.Models.Model;

namespace SSISApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class GenericController<TViewModel, TService> : ControllerBase
        where TService : IBaseService<TViewModel>
        where TViewModel : class
    {
        private readonly TService _service;
        private readonly IWebHostEnvironment _environment;

        public GenericController( TService service, IWebHostEnvironment environment)
        {
            this._service = service;
            this._environment = environment;
        }

        [HttpGet]
        public async virtual Task<Response<TViewModel>> GetAllAsync()
        {
            var list = await _service.GetAllAsync().ConfigureAwait(false);
            return new Response<TViewModel>()
            {
                list = list,
                status = true
            };
        }

        [HttpGet("{id}")]
        public async virtual Task<Response<TViewModel>> Get(int id)
        {
            return new Response<TViewModel>()
            {
                data = await _service.GetAsync(id).ConfigureAwait(false),
                status = true
            };
        }

        [HttpPut("{id}")]
        public async virtual Task<Response<TViewModel>> Put(int id, TViewModel viewModel)
        {
            if (viewModel == null || id == 0)
                throw new ArgumentNullException("Data master is null");

            return new Response<TViewModel>()
            {
                data = await _service.UpdateAsync(id, viewModel).ConfigureAwait(false),
                status = true
            };
        }

        [HttpPost]
        public async virtual Task<Response<TViewModel>> Post(TViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException("Data master is null");

            return new Response<TViewModel>()
            {
                data = await _service.CreateAsync(viewModel).ConfigureAwait(false),
                status = true
            };
        }

        [HttpDelete("{id}")]
        public async Task<Response<TViewModel>> delete(int id)
        {
            return new Response<TViewModel>()
            {
                data = await _service.DeleteAsync(id).ConfigureAwait(false),
                status = true
            };
        }
    }
}
