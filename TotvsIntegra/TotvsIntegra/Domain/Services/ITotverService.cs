using IntegraApi.Application.Domain.Models;
using IntegraApi.Application.Dtos;

namespace IntegraApi.Application.Domain.Services
{
    public interface ITotverService : IBaseService<Totver>
    {
        Task<IEnumerable<AtividadeOptionsDto>> GetOptions();
    }
}
