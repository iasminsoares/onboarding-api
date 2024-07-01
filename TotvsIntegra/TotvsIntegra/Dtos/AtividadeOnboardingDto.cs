using IntegraApi.Application.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace IntegraApi.Application.Dtos
{
    public class AtividadeOnboardingDto: BaseDto
    {
        [Required(ErrorMessage = "O identificador do onboarding é Obrigatório")]
        public Guid OnboardingId { get; set; }

        [Required(ErrorMessage = "O identificador da atividade é Obrigatório")]
        public Guid AtividadeId { get; set; }
        public StatusEnum StatusAtividade { get; set; } = StatusEnum.NaoIniciado;
        public string? Comentário { get; set; }
    }
}
