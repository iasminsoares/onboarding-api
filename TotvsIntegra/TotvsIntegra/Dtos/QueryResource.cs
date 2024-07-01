namespace IntegraApi.Application.Dtos
{
    public class QueryResource
    {
        public required int Page { get; init; }
        public required int ItemsPerPage { get; init; }
    }
}
