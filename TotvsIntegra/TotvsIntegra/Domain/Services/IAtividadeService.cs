using IntegraApi.Application.Domain.Models;
using IntegraApi.Application.Dtos;

namespace IntegraApi.Application.Domain.Services
{
    public interface IAtividadeService : IBaseService<Atividade>
    {
        Task<IEnumerable<AtividadeOptionsDto>> GetOptions();
    }
}
