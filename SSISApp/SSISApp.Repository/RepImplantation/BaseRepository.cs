using Microsoft.EntityFrameworkCore;
using SSISApp.Repository.RepInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace SSISApp.Repository.RepImplantation
{
    public abstract class BaseRepository<TEntity, TConText> : IBaseRepository<TEntity>
        where TEntity : class
        where TConText : DbContext
    {
        private readonly TConText _context;
        private bool _saveChanges = true;
        public BaseRepository(TConText context)
        {
            this._context = context;
        }

        public int CountAsync(Expression<Func<TEntity, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public async virtual Task<TEntity> CreateAsync(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            if (_saveChanges)
                await _context.SaveChangesAsync().ConfigureAwait(false);

            return entity;
        }

        public async virtual Task<TEntity> DeleteAsync(object id)
        {
            var entity = await GetAsync(id).ConfigureAwait(false);
            if (entity == null)
                return entity;

            _context.Remove(entity);
            if (_saveChanges)
                await _context.SaveChangesAsync().ConfigureAwait(false);

            return entity;
        }

        public async virtual Task<List<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync().ConfigureAwait(false);
        }

        public async virtual Task<TEntity> GetAsync(object id)
        {
            return await _context.Set<TEntity>().FindAsync(id).ConfigureAwait(false);
        }

        public async Task SaveChangesAsync()
        {
            if (_saveChanges)
                await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            if (_saveChanges)
                await _context.SaveChangesAsync().ConfigureAwait(false);

            return entity;
        }

        public virtual IBaseRepository<TEntity> WithoutSaveAsync()
        {
            _saveChanges = false;
            return this;
        }

        public virtual IBaseRepository<TEntity> WithSaveAsync()
        {
            _saveChanges = true;
            return this;
        }
    }
}
