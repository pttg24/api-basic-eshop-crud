using System;

namespace BasicEshopCrud.Infrastructure.DataModels;

public partial class Customers
{
    public Customers()
    {
        this.CreatedDate = DateTime.Now;
        this.UpdatedDate = DateTime.Now;
    }

    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}