namespace BasicEshopCrud.Domain;

public class Order
{
    public long? Id { get; set; }

    public long CustomerId { get; set; }

    public long ProductId { get; set; }

    public string Status { get; set; }
}
