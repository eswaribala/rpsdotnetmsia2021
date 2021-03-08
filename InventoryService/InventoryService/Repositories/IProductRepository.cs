using InventoryService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryService.Repositories
{
    public interface IProductRepository
    {

        Product AddProduct(Product Product);
        IEnumerable<Product> GetAllProducts();
        Product GetProductById(long ProductId);
        bool DeleteProductById(long ProductId);

    }
}
