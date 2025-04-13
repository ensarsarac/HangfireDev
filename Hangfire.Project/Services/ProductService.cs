using Hangfire.Project.DataAccess.Context;
using Hangfire.Project.DataAccess.Entities;
using Hangfire.Project.Services.Interfaces;

namespace Hangfire.Project.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public int AddRangeProduct()
        {

             List<Product> products = new()
            {
                new Product { Id = Guid.NewGuid(), Name = "Laptop", Description = "High performance laptop", Price = 899.99m, Stock = 25 },
                new Product { Id = Guid.NewGuid(), Name = "Smartphone", Description = "Latest model smartphone", Price = 699.99m, Stock = 50 },
                new Product { Id = Guid.NewGuid(), Name = "Headphones", Description = "Noise-cancelling headphones", Price = 199.99m, Stock = 30 },
                new Product { Id = Guid.NewGuid(), Name = "Monitor", Description = "27-inch 4K monitor", Price = 299.99m, Stock = 15 },
                new Product { Id = Guid.NewGuid(), Name = "Keyboard", Description = "Mechanical keyboard with RGB", Price = 120.00m, Stock = 60 },
                new Product { Id = Guid.NewGuid(), Name = "Mouse", Description = "Ergonomic wireless mouse", Price = 49.99m, Stock = 100 },
                new Product { Id = Guid.NewGuid(), Name = "Smartwatch", Description = "Fitness tracking smartwatch", Price = 199.00m, Stock = 40 },
                new Product { Id = Guid.NewGuid(), Name = "Tablet", Description = "10-inch tablet with 64GB storage", Price = 349.99m, Stock = 20 },
                new Product { Id = Guid.NewGuid(), Name = "Camera", Description = "DSLR camera with 18-55mm lens", Price = 599.99m, Stock = 10 },
                new Product { Id = Guid.NewGuid(), Name = "Speaker", Description = "Portable Bluetooth speaker", Price = 79.99m, Stock = 75 }
            };

            _context.Products.AddRange(products);
            var result = _context.SaveChanges();

            if(result > 0)
                return result;
            else return 0;

    }

    public ICollection<Product> GetAllProducts()
    {
            var products = _context.Products.ToList();

            return products;
    }
}
}
