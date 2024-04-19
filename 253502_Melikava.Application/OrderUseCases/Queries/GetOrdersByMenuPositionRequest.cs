
namespace _253502_Melikava.Application.OrderUseCases.Queries
{
    public sealed record GetOrdersByMenuPositionRequest(string Id) : IRequest<IEnumerable<Order>>
    {
    }
}
