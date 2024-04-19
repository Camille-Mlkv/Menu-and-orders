
namespace _253502_Melikava.ApplicationLayer.OrderUseCases.Queries
{
    public sealed record GetOrdersByMenuPositionRequest(string Id) : IRequest<IEnumerable<Order>>
    {
    }
}
