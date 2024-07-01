using AutoMapper;
using IntegraApi.Application.Domain.Models;
using IntegraApi.Application.Dtos;

namespace IntegraApi.Application.Mapping
{
    public class DtoToModelProfile : Profile
    {
        public DtoToModelProfile()
        {
            CreateMap<TotverDto, Totver>();

            CreateMap<AtividadeDto, Atividade>();

            CreateMap<OnboardingDto, Onboarding>();

            CreateMap<AtividadeOnboardingDto, AtividadeOnboarding>();


        }
    }
}
