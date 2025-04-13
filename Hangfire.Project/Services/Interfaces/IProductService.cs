using Hangfire.Project.DataAccess.Entities;

namespace Hangfire.Project.Services.Interfaces
{
    public interface IProductService
    {
        int AddRangeProduct();
        ICollection<Product> GetAllProducts();
    }
}
