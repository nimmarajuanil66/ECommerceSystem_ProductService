using ProductService.Application.Interfaces.Repositories;
using ProductService.Domain.Entites;
using ProductService.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Persistence.Repositories
{
    public class ProductRepository:IProductRepository
    {
        private readonly AppDbContext _appDbContext;

        public ProductRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddAsync(Product product)
        {
            await _appDbContext.Products.AddAsync(product);
            await  _appDbContext.SaveChangesAsync();

        }
        public async Task<Product?>GetByIdAsync(Guid id)
        {
            return await _appDbContext.Products.FindAsync(id);

           
        }

    }
}
