using AutoMapper;
using IntegraApi.Application.Domain.Models;
using IntegraApi.Application.Dtos;

namespace IntegraApi.Application.Mapping
{
    public class ModelToDtoProfile : Profile
    {
        public ModelToDtoProfile()
        {
            CreateMap<Totver, TotverDto>();

            CreateMap<Atividade, AtividadeDto>();

            CreateMap<Onboarding, OnboardingDto>();

            CreateMap<AtividadeOnboarding, AtividadeOnboardingDto>();
        }
    }
}
