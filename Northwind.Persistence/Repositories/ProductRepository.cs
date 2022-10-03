using Microsoft.EntityFrameworkCore;
using Northwind.Domain.Base;
using Northwind.Domain.Models;
using Northwind.Domain.Repositories;
using Northwind.Persistence.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Persistence.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(NorthwindContext dbContext) : base(dbContext)
        {
        }

        public void Edit(Product product)
        {
            Update(product);
        }

        public async Task<IEnumerable<Product>> GetAllProduct(bool trackChanges)
        {
            return await FindAll(trackChanges)
                .OrderBy(p => p.ProductId)
                .Include(c => c.Category)
                .Include(s => s.Supplier)
                .ToListAsync();
        }

        public async Task<Product> GetProductById(int productId, bool trackChanges)
        {
            return await FindByCondition(p => p.ProductId.Equals(productId), trackChanges)
                .Where(x => x.ProductPhotos.Any(y => y.PhotoProductId == x.ProductId))
                .Include(x => x.ProductPhotos)
                .Include(y => y.Category)
                .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetProductOneSales(bool trackChanges)
        {
            // throw new NotImplementedException();
            /*var product =  await FindAll(trackChanges).Include(
                p => p.ProductPhotos.SingleOrDefault())
                .ToListAsync();
            return product;*/
            var product = await _dbContext.Products.Where(x => x.ProductPhotos.Any(y => y.PhotoProductId == x.ProductId))
                .Include(p => p.ProductPhotos)
                .ToListAsync();
            return product;
        }

        public async Task<IEnumerable<Product>> GetProductPaged(int pageIndex, int pageSize, bool trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(p => p.ProductId)
                .Include(c => c.Category)
                .Include(s => s.Supplier)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<Product> GetProductSalesById(int productId, bool trackChanges)
        {
            //throw new NotImplementedException();
            return await FindByCondition(c => c.ProductId.Equals(productId), trackChanges).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsOnSales(bool trackChanges)
        {
            //throw new NotImplementedException();
            var product = await _dbContext.Products
                .Where(x => x.ProductPhotos.Any(y=> y.PhotoProductId == x.ProductId))
                .Include(x => x.ProductPhotos)
                .ToListAsync();
            return product;

        }

        public void Insert(Product product)
        {
            Create(product);
        }

        public void Remove(Product product)
        {
            Delete(product);
        }
    }
}
