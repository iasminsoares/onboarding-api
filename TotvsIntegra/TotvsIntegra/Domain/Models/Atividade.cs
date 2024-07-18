using IntegraApi.Application.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace IntegraApi.Application.Domain.Models
{
    public class Atividade : BaseEntity
    {
        [Required]
        public bool Ativo { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        public bool Obrigatorio { get; set; }
        public string? ComoFazer { get; set; }
        public int TempoEstimado { get; set; }
        [Required]
        public ClassificacaoAtividadeEnum Classificacao { get; set; }

        public virtual ICollection<AtividadeOnboarding> Oboardings { get; set; }
    }
}
