
using IntegraApi.Application.Domain.Models;
using IntegraApi.Application.Domain.Repositories;
using IntegraApi.Application.Domain.Services;
using IntegraApi.Application.Domain.Services.Comunication;
using IntegraApi.Application.Dtos;
using IntegraApi.Application.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace IntegraApi.Application.Services
{
    public class AtividadeService(
        IAtividadeRepository repository,
        IUnitOfWork unitOfWork,
        IMemoryCache cache,
        ILogger<AtividadeService> logger
    ) : IAtividadeService
        
    {
        public async Task<IEnumerable<Atividade>> ListAsync()
        {
            var result = await cache.GetOrCreateAsync(CacheKeys.AtividadesList, (entry) =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(5);
                return repository.ListAsync();
            });

            return result ?? [];
        }

        public async Task<Response<Atividade>> SaveAsync(Atividade atividade)
        {
            try
            {
                await repository.AddAsync(atividade);
                await unitOfWork.CompleteAsync();

                return new Response<Atividade>(atividade);
            }
            catch (Exception ex)
            {
                logger.LogError("{message}", $"Não foi possivel salvar o registro. Erro: {ex.Message}");
                return new Response<Atividade>(ErrorType.Error, "Um erro ocorreu tentando salvar o registro.", ex.Message);
            }
        }

        public async Task<Response<Atividade>> UpdateAsync(Guid id, Atividade atividade)
        {
            var existingAtividade = await repository.GetByIdAsync(id);
            if (existingAtividade == null)
            {
                return new Response<Atividade>(ErrorType.Error, "Registro não encontrado.");
            }

            AtualizaPropriedadeAtividade(existingAtividade, atividade);

            try
            {

                repository.Update(existingAtividade);
                await unitOfWork.CompleteAsync();
                return new Response<Atividade>(existingAtividade);
            }
            catch (Exception ex)
            {
                logger.LogError("{message}", $"Não foi possivel atualizar o registro com o ID {id}. Erro: {ex.Message}");
                return new Response<Atividade>(ErrorType.Error, "Um erro ocorreu tentando atualizar o registro.", ex.Message);
            }
        }

        public async Task<Response<Atividade>> DeleteAsync(Guid id)
        {
            var existingAtividade = await repository.GetByIdAsync(id);
            if (existingAtividade == null)
            {
                return new Response<Atividade>(ErrorType.Error, "Registro não encontrado.");
            }

            try
            {
                repository.Remove(existingAtividade);
                await unitOfWork.CompleteAsync();

                return new Response<Atividade>(existingAtividade);
            }
            catch (Exception ex)
            {
                logger.LogError("{message}", $"Não foi possivel  excluir o registro com o ID {id}. Erro: {ex.Message}");
                return new Response<Atividade>(ErrorType.Error, "Um erro ocorreu tentando excluir o registro.", ex.Message);
            }
        }

        public async Task<Response<Atividade>> GetByIdAsync(Guid id)
        {
            var existingAtividade = await repository.GetByIdAsync(id);
            if (existingAtividade == null)
            {
                return new Response<Atividade>(ErrorType.Error, "Registro não encontrado.");
            }
            
            try
            {
                await unitOfWork.CompleteAsync();
                return new Response<Atividade>(existingAtividade);
            }
            catch (Exception ex)
            {
                logger.LogError("{message}", $"Não foi possivel encontrar o registro com o ID {id}. Erro: {ex.Message}");
                return new Response<Atividade>(ErrorType.Error, "Um erro ocorreu tentando encontrar o registro.", ex.Message);
            }
        }

        public async Task<IEnumerable<AtividadeOptionsDto>> GetOptions()
        {
           var atividades = await repository.ListAsync();
           return atividades.Select(a => new AtividadeOptionsDto
           {
               Value = a.Id,
               Label = a.Descricao
           }).ToList();
        }

        private void AtualizaPropriedadeAtividade(Atividade existingAtividade, Atividade atividadeModificada)
        {
            existingAtividade.Descricao = atividadeModificada.Descricao;
            existingAtividade.Classificacao = atividadeModificada.Classificacao;
            existingAtividade.ComoFazer = atividadeModificada.ComoFazer;
            existingAtividade.TempoEstimado = atividadeModificada.TempoEstimado;
            existingAtividade.Ativo = atividadeModificada.Ativo;
            existingAtividade.Obrigatorio = atividadeModificada.Obrigatorio;
            existingAtividade.CriadoPor = atividadeModificada.CriadoPor;
            existingAtividade.AlteradoPor = atividadeModificada.AlteradoPor;
            existingAtividade.DataCriacao = atividadeModificada.DataCriacao;
            existingAtividade.CriadoPor = "Iasmin";
            existingAtividade.AlteradoPor = "Iasmin";
            existingAtividade.DataCriacao = DateTime.Now;

        }
    }
}
