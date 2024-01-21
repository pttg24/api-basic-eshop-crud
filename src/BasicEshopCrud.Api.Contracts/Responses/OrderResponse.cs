namespace BasicEshopCrud.Api.Contracts.Responses;

/// <summary>
/// order response
/// </summary>
public class OrderResponse
{
    /// <summary>
    /// order id
    /// </summary>
    public long? OrderId { get; }
    /// <summary>
    /// customer id
    /// </summary>
    public long CustomerId { get; }
    /// <summary>
    /// product id
    /// </summary>
    public long ProductId { get; }
    /// <summary>
    /// status
    /// </summary>
    public string Status { get; }

    /// <summary>
    /// Creates request
    /// </summary>
    /// <param name="orderId"></param>
    /// <param name="customerId"></param>
    /// <param name="productId"></param>
    /// <param name="status"></param>
    public OrderResponse(
        long? orderId,
        long customerId,
        long productId,
        string status
    )
    {
        OrderId = orderId;
        CustomerId = customerId;
        ProductId = productId;
        Status = status;
    }
}