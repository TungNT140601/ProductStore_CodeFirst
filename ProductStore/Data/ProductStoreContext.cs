using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductStore.Models.Product;

namespace ProductStore.Data
{
    public class ProductStoreContext : DbContext
    {
        public ProductStoreContext (DbContextOptions<ProductStoreContext> options)
            : base(options)
        {
        }

        public DbSet<ProductEntity> ProductEntity { get; set; } = default!;
    }
}
