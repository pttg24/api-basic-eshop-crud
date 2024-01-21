namespace BasicEshopCrud.Api.Contracts.Responses.Custom;

public class CreatedOrderResponse
{
    public long OrderId { get; }

    public CreatedOrderResponse(long orderId)
    {
        OrderId = orderId;
    }
}
