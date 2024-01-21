using System;

namespace BasicEshopCrud.Infrastructure.DataModels;

public partial class Orders
{
    public Orders()
    {
        this.CreatedDate = DateTime.Now;
        this.UpdatedDate = DateTime.Now;
    }

    public long Id { get; set; }
    public long  ProductId { get; set; }
    public long CustomerId { get; set; }
    public string Status { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}
