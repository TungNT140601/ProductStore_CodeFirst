using ProductStore.Models.Product;

namespace ProductStore.Services.ProductService
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetListProduct();
        Task<ProductDto> GetProductById(int id);
        Task<ProductDto> CreateOrUpdate(ProductDto productDto);
        Task<bool> DeleteProduct(int id);
    }
}
