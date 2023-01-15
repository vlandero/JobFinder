using Tema.Models.Base;

namespace Tema.Services.Generic
{
    public interface IGenericService<T> where T : BaseEntity
    {
        Task Create(T newEntity);
        void DeleteAll();
        void Delete(T entity);
        T GetById(Guid id);
        Task<T> GetByIdAsync(Guid id);
        void Update(T entity);
    }
}
