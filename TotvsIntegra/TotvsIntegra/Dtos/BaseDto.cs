namespace IntegraApi.Application.Dtos
{
    public class BaseDto
    {
        public Guid? Id { get; set; }
        public DateTime? DataCriacao { get; set; }
        public string? CriadoPor { get; set; }
        public DateTime? UltimaAlteracao { get; set; }
        public string? AlteradoPor { get; set; }
    }
}
