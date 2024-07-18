using System.ComponentModel;

namespace IntegraApi.Application.Domain.Enums
{
    public enum ClassificacaoAtividadeEnum : ushort
    {
        [Description("Baixa")]
        Baixa = 0,
        [Description("Média")]
        Media = 1,
        [Description("Alta")]
        Alta = 2,
        [Description("Não Definido")]
        NaoDefinido = 3
    }
}
