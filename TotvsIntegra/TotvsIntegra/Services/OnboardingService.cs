﻿using IntegraApi.Application.Domain.Models;
using IntegraApi.Application.Domain.Repositories;
using IntegraApi.Application.Domain.Services;
using IntegraApi.Application.Domain.Services.Comunication;
using IntegraApi.Application.Infrastructure;
using Microsoft.Extensions.Caching.Memory;

namespace IntegraApi.Application.Services
{
    public class OnboardingService(
    IOnboardingRepository repository,
    IUnitOfWork unitOfWork,
    IMemoryCache cache,
    ILogger<OnboardingService> logger
    ) : IOnboardingService
    {
        public async Task<IEnumerable<Onboarding>> ListAsync()
        {
            var result = await cache.GetOrCreateAsync(CacheKeys.OnboardingsList, (entry) =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(5);
                return repository.ListAsync();
            });

            return result ?? [];
        }

        public async Task<Response<Onboarding>> SaveAsync(Onboarding onboarding)
        {
            try
            {
                await repository.AddAsync(onboarding);
                await unitOfWork.CompleteAsync();

                return new Response<Onboarding>(onboarding);
            }
            catch (Exception ex)
            {
                logger.LogError("{message}", $"Não foi possivel salvar o registro. Erro: {ex.Message}");
                return new Response<Onboarding>(ErrorType.Error, "Um erro ocorreu tentando salvar o registro.", ex.Message);
            }
        }

        public async Task<Response<Onboarding>> UpdateAsync(Guid id, Onboarding onboarding)
        {
            var existingOnboarding = await repository.GetByIdAsync(id);
            if (existingOnboarding == null)
            {
                return new Response<Onboarding>(ErrorType.Error, "Registro não encontrado.");
            }

            existingOnboarding = onboarding;

            try
            {
                await unitOfWork.CompleteAsync();
                return new Response<Onboarding>(existingOnboarding);
            }
            catch (Exception ex)
            {
                logger.LogError("{message}", $"Não foi possivel atualizar o registro com o ID {id}. Erro: {ex.Message}");
                return new Response<Onboarding>(ErrorType.Error, "Um erro ocorreu tentando atualizar o registro.", ex.Message);
            }
        }

        public async Task<Response<Onboarding>> DeleteAsync(Guid id)
        {
            var existingOnboarding = await repository.GetByIdAsync(id);
            if (existingOnboarding == null)
            {
                return new Response<Onboarding>(ErrorType.Error, "Registro não encontrado.");
            }

            try
            {
                repository.Remove(existingOnboarding);
                await unitOfWork.CompleteAsync();

                return new Response<Onboarding>(existingOnboarding);
            }
            catch (Exception ex)
            {
                logger.LogError("{message}", $"Não foi possivel  excluir o registro com o ID {id}. Erro: {ex.Message}");
                return new Response<Onboarding>(ErrorType.Error, "Um erro ocorreu tentando excluir o registro.", ex.Message);
            }
        }

        public Task<Response<Onboarding>> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
