
namespace _253502_Melikava.ApplicationLayer.OrderUseCases.Queries
{
    public sealed record GetOrdersByMenuPositionRequest(int Id) : IRequest<IEnumerable<Order>>
    {
    }
}
