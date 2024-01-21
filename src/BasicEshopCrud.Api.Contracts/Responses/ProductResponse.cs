namespace BasicEshopCrud.Api.Contracts.Responses;

/// <summary>
/// product response
/// </summary>
public class ProductResponse
{
    /// <summary>
    /// product id
    /// </summary>
    public long? ProductId { get; }
    /// <summary>
    /// name
    /// </summary>
    public string Name { get; }
    /// <summary>
    /// description
    /// </summary>
    public string Description { get; }
    /// <summary>
    /// sku
    /// </summary>
    public string Sku { get; }

    /// <summary>
    /// Creates response
    /// </summary>
    /// <param name="productId"></param>
    /// <param name="name"></param>
    /// <param name="description"></param>
    /// <param name="sku"></param>
    public ProductResponse(
        long? productId,
        string name,
        string description,
        string sku
    )
    {
        ProductId = productId;
        Name = name;
        Description = description;
        Sku = sku;
    }
}

