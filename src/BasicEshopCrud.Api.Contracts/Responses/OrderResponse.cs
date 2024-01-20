namespace BasicEshopCrud.Api.Contracts.Responses;

/// <summary>
/// order response
/// </summary>
public class OrderResponse
{
    /// <summary>
    /// order id
    /// </summary>
    public string OrderId { get; }
    /// <summary>
    /// customer id
    /// </summary>
    public string CustomerId { get; }
    /// <summary>
    /// product id
    /// </summary>
    public string ProductId { get; }
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
        string orderId,
        string customerId,
        string productId,
        string status
    )
    {
        OrderId = orderId;
        CustomerId = customerId;
        ProductId = productId;
        Status = status;
    }
}