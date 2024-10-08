﻿using IntegraApi.Application.Domain.Models;
using IntegraApi.Application.Domain.Repositories;
using IntegraApi.Application.Domain.Services;
using IntegraApi.Application.Domain.Services.Comunication;
using IntegraApi.Application.Dtos;
using IntegraApi.Application.Infrastructure;
using Microsoft.Extensions.Caching.Memory;

namespace IntegraApi.Application.Services
{
    public class TotverService(
    ITotverRepository repository,
    IUnitOfWork unitOfWork,
    IMemoryCache cache,
    ILogger<TotverService> logger
    ) : ITotverService
    {
        public async Task<IEnumerable<Totver>> ListAsync()
        {
            var result = await cache.GetOrCreateAsync(CacheKeys.TotversList, (entry) =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(5);
                return repository.ListAsync();
            });

            return result ?? [];
        }

        public async Task<IEnumerable<AtividadeOptionsDto>> GetOptions()
        {
            var atividades = await repository.ListAsync();
            return atividades.Select(a => new AtividadeOptionsDto
            {
                Value = a.Id,
                Label = a.Nome
            }).ToList();
        }

        public async Task<Response<Totver>> SaveAsync(Totver totver)
        {
            try
            {
                await repository.AddAsync(totver);
                await unitOfWork.CompleteAsync();

                return new Response<Totver>(totver);
            }
            catch (Exception ex)
            {
                logger.LogError("{message}", $"Não foi possivel salvar o registro. Erro: {ex.Message}");
                return new Response<Totver>(ErrorType.Error, "Um erro ocorreu tentando salvar o registro.", ex.Message);
            }
        }

        public async Task<Response<Totver>> UpdateAsync(Guid id, Totver totver)
        {
            var existingTotver = await repository.GetByIdAsync(id);
            if (existingTotver == null)
            {
                return new Response<Totver>(ErrorType.Error, "Registro não encontrado.");
            }

            AtualizaPropriedadeTotver(existingTotver, totver);

            try
            {
                repository.Update(existingTotver);
                await unitOfWork.CompleteAsync();
                return new Response<Totver>(existingTotver);
            }
            catch (Exception ex)
            {
                logger.LogError("{message}", $"Não foi possivel atualizar o registro com o ID {id}. Erro: {ex.Message}");
                return new Response<Totver>(ErrorType.Error, "Um erro ocorreu tentando atualizar o registro.", ex.Message);
            }
        }

        public async Task<Response<Totver>> DeleteAsync(Guid id)
        {
            var existingTotver = await repository.GetByIdAsync(id);
            if (existingTotver == null)
            {
                return new Response<Totver>(ErrorType.Error, "Registro não encontrado.");
            }

            try
            {
                repository.Remove(existingTotver);
                await unitOfWork.CompleteAsync();

                return new Response<Totver>(existingTotver);
            }
            catch (Exception ex)
            {
                logger.LogError("{message}", $"Não foi possivel  excluir o registro com o ID {id}. Erro: {ex.Message}");
                return new Response<Totver>(ErrorType.Error, "Um erro ocorreu tentando excluir o registro.", ex.Message);
            }
        }

        public Task<Response<Totver>> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        private void AtualizaPropriedadeTotver(Totver existingTotver, Totver totverModificada)
        {
            existingTotver.Nome = totverModificada.Nome;
            existingTotver.Email = totverModificada.Email;
            existingTotver.Tribo = totverModificada.Tribo;
            existingTotver.Time = totverModificada.Time;
            existingTotver.Ativo = totverModificada.Ativo;
            existingTotver.UsuarioRede = "Iasmin";
            existingTotver.CriadoPor = "Iasmin";
            existingTotver.AlteradoPor = "Iasmin";
            existingTotver.DataCriacao = DateTime.Now;

        }
    }
}
