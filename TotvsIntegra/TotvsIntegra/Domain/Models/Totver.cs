using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using IntegraApi.Application.Domain.Enums;

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
        public string UsuarioRede { get; set; }

        [Required]
        public  TribeEnum Tribo { get; set; }
        [Required]
        public  TeamEnum Time { get; set; }
    }
}
