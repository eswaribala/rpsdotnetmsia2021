using InventoryService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryService.Repositories
{
    public interface ICatalogRepository
    {
        Catalog AddCatalog(Catalog Catalog);
        IEnumerable<Catalog> GetAllCatalogs();
        Catalog GetCatalogById(long CatalogId);
        bool DeleteCatalogById(long CatalogId);

     }
}
