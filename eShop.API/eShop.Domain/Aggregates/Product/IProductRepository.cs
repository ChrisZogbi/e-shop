using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Domain.Aggregates
{
    public interface IProductRepository
    {
        Task<Product> GetByName(string name);
        Task<Product> GetById(int id);
        Task<List<Product>> GetAll();
    }
}
