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

public class OrderRepository : IOrderRepository, IDisposable
{
    private readonly BasicEshopCrudContext _context;

    private readonly IUnitOfWork _unitOfWork;

    private bool _disposed;

    public OrderRepository(IUnitOfWork unitOfWork)
    {
        this._unitOfWork = unitOfWork;
    }

    public async Task<Order> GetOrderAsync(long orderId)
    {
        var orderInfo =
            await Task.FromResult(this._unitOfWork.Context.Orders.FirstOrDefault(c => c.Id == orderId));

        if (orderInfo != null)
        {
            return new Order()
            {
                Id = orderInfo.Id,
                CustomerId = orderInfo.CustomerId,
                ProductId = orderInfo.ProductId,
                Status = orderInfo.Status
            };
        }
        else
        {
            throw new InvalidOrderException("Internal Order Info not found.");
        }
    }

    public async Task<long> InsertOrderAsync(OrderRequest order)
    {
        var orderModel = new Orders()
        {
            CustomerId = order.CustomerId,
            ProductId = order.ProductId,
            Status = order.Status
        };

        await this._unitOfWork.Context.Orders.AddAsync(orderModel);
        await this._unitOfWork.CommitAsync();

        return orderModel.Id;
    }

    public async Task UpdateOrderAsync(long orderId, OrderRequest order)
    {
        var orderInfo =
            await Task.FromResult(this._unitOfWork.Context.Orders.FirstOrDefault(c => c.Id == orderId));

        if (orderInfo != null)
        {
            orderInfo.CustomerId = order.CustomerId;
            orderInfo.ProductId = order.ProductId;
            orderInfo.Status = order.Status;
            orderInfo.UpdatedDate = DateTime.UtcNow;

            this._unitOfWork.Context.Orders.Update(orderInfo);
            await this._unitOfWork.CommitAsync();
        }
        else
        {
            throw new InvalidOrderException("Internal Order Info not found.");
        }
    }

    public async Task DeleteOrderAsync(long orderId)
    {
        var orderInfo =
            await Task.FromResult(this._unitOfWork.Context.Orders.FirstOrDefault(c => c.Id == orderId));

        if (orderInfo != null)
        {
            this._unitOfWork.Context.Orders.Remove(orderInfo);
            await this._unitOfWork.CommitAsync();
        }
        else
        {
            throw new InvalidOrderException("Internal Order Info not found.");
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
