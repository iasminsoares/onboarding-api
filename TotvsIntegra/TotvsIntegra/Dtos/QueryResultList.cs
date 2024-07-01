namespace IntegraApi.Application.Dtos
{
    public class QueryResultList<T>
    {
        public required int TotalItems { get; init; } = 0;
        public required List<T> Items { get; init; } = [];
    }
}
