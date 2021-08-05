using eShop.Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.AppService.ServiceInterfaces
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProducts();
    }
}
