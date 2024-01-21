using BasicEshopCrud.Api.Contracts.Requests;

namespace BasicEshopCrud.Domain.Interfaces
{
    public interface ICustomerRepository
    {
        Task<Customer> GetCustomerAsync(long customerId);

        Task<long> InsertCustomerAsync(CustomerRequest customer);

        Task UpdateCustomerAsync(long customerId, CustomerRequest customer);

        Task DeleteCustomerAsync(long customerId);
    }
}
