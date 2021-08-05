using eShop.Domain.Aggregates;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eShop.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly eShopContext _db;

        public ProductRepository(eShopContext db)
        {
            _db = db;
        }

        public async Task<List<Product>> GetAll()
        {
            return await _db.Products.ToListAsync();
        }

        public async Task<Product> GetById(int id)
        {
            return await _db.Products.FindAsync(id);
        }

        public Task<Product> GetByName(string name)
        {
            return _db.Products.SingleOrDefaultAsync(x => x.Name.ToLower() == name.ToLower());
        }
    }
}
