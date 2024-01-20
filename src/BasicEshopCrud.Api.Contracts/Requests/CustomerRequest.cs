namespace BasicEshopCrud.Api.Contracts.Requests;

/// <summary>
/// customer request 
/// </summary>
public class CustomerRequest
{
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
    /// Creates request
    /// </summary>
    /// <param name="firstName"></param>
    /// <param name="lastName"></param>
    /// <param name="phone"></param>
    /// <param name="email"></param>
    public CustomerRequest(
        string firstName,
        string lastName,
        string phone,
        string email
    )
    {
        FirstName = firstName;
        LastName = lastName;
        Phone = phone;
        Email = email;
    }
}
