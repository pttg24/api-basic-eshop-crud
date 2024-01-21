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

public class ProductRepository : IProductRepository, IDisposable
{
    private readonly BasicEshopCrudContext _context;

    private readonly IUnitOfWork _unitOfWork;

    private bool _disposed;

    public ProductRepository(IUnitOfWork unitOfWork)
    {
        this._unitOfWork = unitOfWork;
    }

    public async Task<Product> GetProductAsync(long productId)
    {
        var productInfo =
            await Task.FromResult(this._unitOfWork.Context.Products.FirstOrDefault(c => c.Id == productId));

        if (productInfo != null)
        {
            return new Product()
            {
                Id = productInfo.Id,
                Name = productInfo.Name,
                Description = productInfo.Description,
                Sku = productInfo.Sku
            };
        }
        else
        {
            throw new InvalidProductException("Internal Product Info not found.");
        }
    }

    public async Task<long> InsertProductAsync(ProductRequest product)
    {
        var productModel = new Products()
        {
            Name = product.Name,
            Description = product.Description,
            Sku = product.Sku
        };

        await this._unitOfWork.Context.Products.AddAsync(productModel);
        await this._unitOfWork.CommitAsync();

        return productModel.Id;
    }

    public async Task UpdateProductAsync(long productId, ProductRequest product)
    {
        var productInfo =
            await Task.FromResult(this._unitOfWork.Context.Products.FirstOrDefault(c => c.Id == productId));

        if (productInfo != null)
        {
            productInfo.Name = product.Name;
            productInfo.Description = product.Description;
            productInfo.Sku = product.Sku;
            productInfo.UpdatedDate = DateTime.UtcNow;

            this._unitOfWork.Context.Products.Update(productInfo);
            await this._unitOfWork.CommitAsync();
        }
        else
        {
            throw new InvalidProductException("Internal Product Info not found.");
        }
    }

    public async Task DeleteProductAsync(long productId)
    {
        var productInfo =
            await Task.FromResult(this._unitOfWork.Context.Products.FirstOrDefault(c => c.Id == productId));

        if (productInfo != null)
        {
            this._unitOfWork.Context.Products.Remove(productInfo);
            await this._unitOfWork.CommitAsync();
        }
        else
        {
            throw new InvalidProductException("Internal Product Info not found.");
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
