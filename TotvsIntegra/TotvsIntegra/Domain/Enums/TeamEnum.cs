using System.ComponentModel;

namespace IntegraApi.Application.Domain.Enums
{
    public enum TeamEnum : ushort
    {
        [Description("PlataformaESegmentos")]
        Baixa = 0,
        [Description("Sebrae")]
        Media = 1,
        [Description("CNI")]
        Alta = 2,
        [Description("CSI")]
        NaoDefinido = 3
    }
}
