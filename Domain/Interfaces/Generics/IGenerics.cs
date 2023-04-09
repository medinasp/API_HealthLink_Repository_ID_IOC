namespace Domain.Interfaces.Generics
{
    public interface IGenerics<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task CreateAsync(TEntity entity);
        Task UpdateAsync(int id, TEntity entity);
        Task DeleteAsync(int id);
    }
}
