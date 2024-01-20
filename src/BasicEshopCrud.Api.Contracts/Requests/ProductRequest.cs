namespace BasicEshopCrud.Api.Contracts.Requests;

/// <summary>
/// product request
/// </summary>
public class ProductRequest
{
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
    /// Creates request
    /// </summary>
    /// <param name="name"></param>
    /// <param name="description"></param>
    /// <param name="sku"></param>
    public ProductRequest(
        string name,
        string description,
        string sku
    )
    {
        Name = name;
        Description = description;
        Sku = sku;
    }
}
