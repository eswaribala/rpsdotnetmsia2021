using InventoryService.Contexts;
using InventoryService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryService.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private InventoryContext _dbContext;

        public ProductRepository(InventoryContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Product AddProduct(Product Product)
        {
            this._dbContext.Add(Product);
            Save();
            return Product;
        }

        public bool DeleteProductById(long ProductId)
        {
            bool status = false;
            var product = _dbContext.Products.Find(ProductId);
            _dbContext.Products.Remove(product);
            Save();
            if (GetProductById(ProductId) == null)
                status = true;
            return status;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return this._dbContext.Products
                //.Include(p =>p.ProductSuppliers )
               .ToList();
        }

        public Product GetProductById(long ProductId)
        {
            var product = _dbContext.Products
               //.Include(p => p.ProductSuppliers)
             .FirstOrDefault(x => x.ProductId == ProductId);
            return product;
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
