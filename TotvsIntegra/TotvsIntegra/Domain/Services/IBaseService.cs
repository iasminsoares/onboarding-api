using IntegraApi.Application.Domain.Services.Comunication;

namespace IntegraApi.Application.Domain.Services
{
    public interface IBaseService<T> where T : class
    {
        Task<IEnumerable<T>> ListAsync();
        Task<Response<T>> SaveAsync(T entity);
        Task<Response<T>> UpdateAsync(Guid id, T entity);
        Task<Response<T>> GetByIdAsync(Guid id);
        Task<Response<T>> DeleteAsync(Guid id);
    }
}
