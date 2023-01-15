using Tema.Models.Base;
using Tema.Repositories.GenericRepository;

namespace Tema.Services.Generic
{
    public class GenericService<T> : IGenericService<T> where T : BaseEntity
    {
        private readonly IGenericRepository<T> _repository;
        public GenericService(IGenericRepository<T> repository)
        {
            _repository = repository;
        }
        public T GetById(Guid id)
        {
            return _repository.FindById(id);
        }
        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _repository.FindByIdAsync(id);
        }
        public async Task Create(T newEntity)
        {
            await _repository.CreateAsync(newEntity);
            await _repository.SaveAsync();
        }
        public void DeleteAll()
        {
            _repository.DeleteAll();
            _repository.Save();
        }
        public void Delete(T entity)
        {
            _repository.Delete(entity);
            _repository.Save();
        }
        public void Update(T entity)
        {
            _repository.Update(entity);
            _repository.Save();
        }
    }
}
