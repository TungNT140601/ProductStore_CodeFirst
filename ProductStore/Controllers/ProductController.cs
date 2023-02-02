using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductStore.Data;
using ProductStore.Models.Product;
using ProductStore.Services.ProductService;

namespace ProductStore.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductStoreContext _context;
        private readonly IProductService _productService;
        public ProductController(ProductStoreContext context, IProductService productService)
        {
            _context = context;
            _productService = productService;
        }

        [HttpGet]
        public async Task<List<ProductDto>> GetListProduct()
        {
            return await _productService.GetListProduct();
        }

        [HttpGet]
        public async Task<ProductDto> GetProductById([Required] int id)
        {
            return await _productService.GetProductById(id);
        }

        [HttpPost]
        public async Task<ProductDto> CreateOrUpdate(ProductDto productDto)
        {
            return await _productService.CreateOrUpdate(productDto);
        }
        
        [HttpDelete]
        public async Task<bool> DeleteProduct([Required] int id)
        {
            return await _productService.DeleteProduct(id);
        }
    }
}
