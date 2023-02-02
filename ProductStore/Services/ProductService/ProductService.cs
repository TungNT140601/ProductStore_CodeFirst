using Microsoft.EntityFrameworkCore;
using ProductStore.Data;
using ProductStore.Models.Product;

namespace ProductStore.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly ProductStoreContext _context;
        public ProductService(ProductStoreContext context)
        {
            _context = context;
        }
        public async Task<List<ProductDto>> GetListProduct()
        {
            var list = _context.ProductEntity.Where(x => x.IsDelete == false).ToList();
            var result = new List<ProductDto>();
            foreach (var item in list)
            {
                var productDto = new ProductDto()
                {
                    ProductId = item.ProductId,
                    Price = item.Price,
                    ProductName = item.ProductName,
                    Quantity = item.Quantity
                };
                result.Add(productDto);
            }
            return result;
        }
        public async Task<ProductDto> GetProductById(int id)
        {
            var productEntity = _context.ProductEntity.Where(x => x.ProductId == id && x.IsDelete == false).FirstOrDefault();

            if (productEntity == null)
            {
                return null;
            }
            else
            {
                return new ProductDto()
                {
                    Price = productEntity.Price,
                    ProductName = productEntity.ProductName,
                    Quantity = productEntity.Quantity,
                    ProductId = productEntity.ProductId
                };
            }
        }
        public async Task<ProductDto> CreateOrUpdate(ProductDto productDto)
        {
            if (productDto != null)
            {
                var product = _context.ProductEntity.Where(x => x.ProductId == productDto.ProductId && x.IsDelete == false).FirstOrDefault();
                if (product == null)
                {
                    product = new ProductEntity()
                    {
                        IsDelete = false,
                        ProductId = productDto.ProductId,
                        ProductName = productDto.ProductName,
                        Price = productDto.Price,
                        Quantity = productDto.Quantity
                    };
                    _context.ProductEntity.Add(product);
                    _context.SaveChanges();
                    return new ProductDto()
                    {
                        ProductName = product.ProductName,
                        Price = product.Price,
                        Quantity = product.Quantity,
                        ProductId = product.ProductId,
                    };
                }
                else
                {
                    product.ProductName = productDto.ProductName;
                    product.Price = productDto.Price;
                    product.Quantity = productDto.Quantity;
                    _context.Update(product);
                    _context.SaveChanges();
                    return new ProductDto()
                    {
                        ProductName = product.ProductName,
                        Price = product.Price,
                        Quantity = product.Quantity,
                        ProductId = product.ProductId,
                    };
                }
            }
            else
            {
                return null;
            }
        }
        public async Task<bool> DeleteProduct(int id)
        {
            var check = _context.ProductEntity.Where(_ => _.ProductId == id && _.IsDelete == false).FirstOrDefault();
            if (check == null)
            {
                return false;
            }
            else
            {
                check.IsDelete = true;
                _context.ProductEntity.Update(check);
                await _context.SaveChangesAsync();
                return true;
            }
        }
    }
}
