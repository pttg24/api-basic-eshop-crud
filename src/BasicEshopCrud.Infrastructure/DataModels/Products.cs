using System;

namespace BasicEshopCrud.Infrastructure.DataModels;

public partial class Products
{
    public Products()
    {
        this.CreatedDate = DateTime.Now;
        this.UpdatedDate = DateTime.Now;
    }

    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Sku { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}