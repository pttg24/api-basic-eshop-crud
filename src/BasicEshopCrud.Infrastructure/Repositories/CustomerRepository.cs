using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicEshopCrud.Api.Contracts.Requests;
using BasicEshopCrud.Domain;
using BasicEshopCrud.Domain.Exceptions;
using BasicEshopCrud.Domain.Interfaces;
using BasicEshopCrud.Infrastructure.DataModels;

namespace BasicEshopCrud.Infrastructure.Repositories;

public class CustomerRepository : ICustomerRepository, IDisposable
{
    private readonly BasicEshopCrudContext _context;

    private readonly IUnitOfWork _unitOfWork;

    private bool _disposed;

    public CustomerRepository(IUnitOfWork unitOfWork) 
    {
        this._unitOfWork = unitOfWork;
    }

    public async Task<Customer> GetCustomerAsync(long customerId)
    {
        var customerInfo = 
            await Task.FromResult(this._unitOfWork.Context.Customers.FirstOrDefault(c => c.Id == customerId));

        if (customerInfo != null)
        {
            return new Customer()
            {
                Id = customerInfo.Id,
                FirstName = customerInfo.FirstName,
                LastName = customerInfo.LastName,
                Email = customerInfo.Email,
                Phone = customerInfo.Phone
            };
        }
        else
        {
            throw new InvalidCustomerException("Internal Customer Info not found.");
        }
    }

    public async Task<long> InsertCustomerAsync(CustomerRequest customer)
    {
        var customerModel = new Customers()
        {
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            Email = customer.Email,
            Phone = customer.Phone,
        };

        await this._unitOfWork.Context.Customers.AddAsync(customerModel);
        await this._unitOfWork.CommitAsync();

        return customerModel.Id;
    }

    public async Task UpdateCustomerAsync(long customerId, CustomerRequest customer)
    {
        var customerInfo = 
            await Task.FromResult(this._unitOfWork.Context.Customers.FirstOrDefault(c => c.Id == customerId));

        if (customerInfo != null)
        {
            customerInfo.FirstName = customer.FirstName;
            customerInfo.LastName = customer.LastName;
            customerInfo.Phone = customer.Phone;
            customerInfo.Email = customer.Email;
            customerInfo.UpdatedDate = DateTime.UtcNow;

            this._unitOfWork.Context.Customers.Update(customerInfo);
            await this._unitOfWork.CommitAsync();
        }
        else
        {
            throw new InvalidCustomerException("Internal Customer Info not found.");
        }
    }

    public async Task DeleteCustomerAsync(long customerId)
    {
        var customerInfo = 
            await Task.FromResult(this._unitOfWork.Context.Customers.FirstOrDefault(c => c.Id == customerId));

        if (customerInfo != null)
        {
            this._unitOfWork.Context.Customers.Remove(customerInfo);
            await this._unitOfWork.CommitAsync();
        }
        else
        {
            throw new InvalidCustomerException("Internal Customer Info not found.");
        }
    }

    public void Dispose()
    {
        this.Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (this._disposed)
            return;

        if (disposing)
        {
            this._unitOfWork.Context.Dispose();
        }

        this._disposed = true;
    }
}
