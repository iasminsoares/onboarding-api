﻿using IntegraApi.Application.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace IntegraApi.Application.Dtos
{
    public class OnboardingDto : BaseDto
    {
        [Required(ErrorMessage = "O padrinho do onboarding é Obrigatório")]
        public Guid PadrinhoId { get; set; }

        [Required(ErrorMessage = "O Apadrinhado (novo TOTVER) do onboarding é Obrigatório")]
        public Guid NovoTotverId { get; set; }

        public StatusEnum StatusOnboarding { get; set; } = StatusEnum.NaoIniciado;

        public virtual required ICollection<AtividadeOnboardingDto> Atividades { get; set; }
    }
}
