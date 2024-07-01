using System.ComponentModel.DataAnnotations;

namespace IntegraApi.Application.Domain.Models
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public  string CriadoPor { get; set; }
        public DateTime? UltimaAlteracao { get; set; }
        public string? AlteradoPor { get; set; }
    }
}
