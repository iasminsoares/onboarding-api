using IntegraApi.Application.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace IntegraApi.Application.Dtos
{
    public class TotverDto : BaseDto
    {
        public bool Ativo { get; set; } = true;

        [Required(ErrorMessage = "Nome é Obrigatório")]
        [MinLength(3, ErrorMessage = "Tamanho mínimo do nome são 3 caracteres")]
        [MaxLength(255, ErrorMessage = "Tamanho máximo do nome são 255 caracteres")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "E-mail é Obrigatório")]
        [MinLength(3, ErrorMessage = "Tamanho mínimo do e-mail exigido 3 caracteres")]
        [MaxLength(255, ErrorMessage = "Tamanho máximo do e-mail são 255 caracteres")]
        public string? Email { get; set; }

        //[Required(ErrorMessage = "Usuário de rede é Obrigatório")]
        //[MinLength(3, ErrorMessage = "Tamanho mínimo do usuário são 3 caracteres")]
        //[MaxLength(100, ErrorMessage = "Tamanho máximo do usuário são 100 caracteres")]
        public string? UsuarioRede { get; set; }

        public TribeEnum Tribo { get; set; }

        public TeamEnum Time { get; set; }
    }
}
