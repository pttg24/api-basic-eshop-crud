using BasicEshopCrud.Api.Contracts.Requests;

namespace BasicEshopCrud.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetProductAsync(long productId);

        Task<long> InsertProductAsync(ProductRequest product);

        Task UpdateProductAsync(long productId, ProductRequest product);

        Task DeleteProductAsync(long productId);
    }
}
