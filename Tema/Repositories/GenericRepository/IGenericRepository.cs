using Tema.Models.Base;

namespace Tema.Repositories.GenericRepository
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        Task<List<TEntity>> GetAllAsync();
        
        Task CreateAsync(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);
        void DeleteAll();
        
        Task<TEntity> FindByIdAsync(object id);
        TEntity FindById(object id);

        Task<bool> SaveAsync();
        bool Save();

    }
}
