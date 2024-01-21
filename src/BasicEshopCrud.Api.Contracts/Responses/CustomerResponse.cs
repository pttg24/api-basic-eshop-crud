namespace BasicEshopCrud.Api.Contracts.Responses;

/// <summary>
/// customer response
/// </summary>
public class CustomerResponse
{
    /// <summary>
    /// customer id
    /// </summary>
    public long? CustomerId { get; }
    /// <summary>
    /// first name
    /// </summary>
    public string FirstName { get; }
    /// <summary>
    /// last name
    /// </summary>
    public string LastName { get; }
    /// <summary>
    /// phone
    /// </summary>
    public string Phone { get; }
    /// <summary>
    /// email
    /// </summary>
    public string Email { get; }

    /// <summary>
    /// Creates response
    /// </summary>
    /// <param name="customerId"></param>
    /// <param name="firstName"></param>
    /// <param name="lastName"></param>
    /// <param name="phone"></param>
    /// <param name="email"></param>
    public CustomerResponse(
        long? customerId,
        string firstName,
        string lastName,
        string phone,
        string email
    )
    {
        CustomerId = customerId;
        FirstName = firstName;
        LastName = lastName;
        Phone = phone;
        Email = email;
    }
}
