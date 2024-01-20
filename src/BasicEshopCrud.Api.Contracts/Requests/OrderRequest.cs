namespace BasicEshopCrud.Api.Contracts.Requests;

/// <summary>
/// order request
/// </summary>
public class OrderRequest
{
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
    /// <param name="customerId"></param>
    /// <param name="productId"></param>
    /// <param name="status"></param>
    public OrderRequest(
        string customerId,
        string productId,
        string status
    )
    {
        CustomerId = customerId;
        ProductId = productId;
        Status = status;
    }

}
