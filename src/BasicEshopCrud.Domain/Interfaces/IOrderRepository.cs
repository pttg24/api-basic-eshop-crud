using BasicEshopCrud.Api.Contracts.Requests;

namespace BasicEshopCrud.Domain.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order> GetOrderAsync(long orderId);

        Task<long> InsertOrderAsync(OrderRequest order);

        Task UpdateOrderAsync(long orderId, OrderRequest order);

        Task DeleteOrderAsync(long orderId);
    }
}
