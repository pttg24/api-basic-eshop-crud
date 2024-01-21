namespace BasicEshopCrud.Api.Contracts.Responses.Custom;

public class CreatedProductResponse
{
    public long ProductId { get; }

    public CreatedProductResponse(long productId)
    {
        ProductId = productId;
    }
}
