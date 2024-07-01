using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace IntegraApi.Application.Domain.Models
{
    public class Totver : BaseEntity
    {
        [Required]
        [DefaultValue(true)]
        public required bool Ativo { get; set; }
        [Required]
        public required string Nome { get; set; }
        [Required]
        public required string Email { get; set; }
        [Required]
        public required string UsuarioRede { get; set; }
        [Required]
        public required string Tribo { get; set; }
        [Required]
        public required string Time { get; set; }
    }
}
