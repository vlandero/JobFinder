using Tema.Models.Base;

namespace Tema.Repositories.GenericRepository
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        Task<List<TEntity>> GetAllAsync();
        
        Task CreateAsync(TEntity entity);
        Task CreateRangeAsync(IEnumerable<TEntity> entities);

        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);

        void Delete(TEntity entity);
        void DeleteRange(IEnumerable<TEntity> entities);
        
        Task<TEntity> FindByIdAsync(object id);
        
        Task<bool> SaveAsync();

    }
}
