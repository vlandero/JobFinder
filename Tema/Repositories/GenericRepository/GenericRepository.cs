using Microsoft.EntityFrameworkCore;
using Tema.Models;
using Microsoft.Data.SqlClient;
using Tema.Models.Base;

namespace Tema.Repositories.GenericRepository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly MyAppContext _context;
        protected readonly DbSet<TEntity> _table;

        public GenericRepository(MyAppContext context)
        {
            _context = context;
            _table = _context.Set<TEntity>();
        }
        public async Task<List<TEntity>> GetAllAsync()
        {
            var allEntities = await _table.AsNoTracking().ToListAsync();
            return allEntities;
        }

        public async Task CreateAsync(TEntity entity)
        {
            await _table.AddAsync(entity);
        }
        public async Task CreateRangeAsync(IEnumerable<TEntity> entities)
        {
            await _table.AddRangeAsync(entities);
        }
        public void Update(TEntity entity)
        {
            _table.Update(entity);
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            _table.UpdateRange(entities);
        }
        public void Delete(TEntity entity)
        {
            _table.Remove(entity);
        }
        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            _table.RemoveRange(entities);
        }
        public async Task<TEntity> FindByIdAsync(object id)
        {
            return await _table.FindAsync(id);
        }
        public async Task<bool> SaveAsync()
        {
            try
            {
                return await _context.SaveChangesAsync() > 0;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
            }

            return false;
        }
    }
}
