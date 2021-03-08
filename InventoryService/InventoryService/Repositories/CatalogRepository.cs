using InventoryService.Contexts;
using InventoryService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryService.Repositories
{
    public class CatalogRepository : ICatalogRepository
    {
        private InventoryContext _dbContext;
        //dependecy injection
        public CatalogRepository(InventoryContext dbContext)
        {
            this._dbContext = dbContext;

        }
        public Catalog AddCatalog(Catalog Catalog)
        {
           
            this._dbContext.Add(Catalog);
            Save();
            return Catalog;

        }

        public bool DeleteCatalogById(long CatalogNo)
        {
            bool status = false;
            var catalog = _dbContext.Catalogs.Find(CatalogNo);
            _dbContext.Catalogs.Remove(catalog);
            Save();
            if (GetCatalogById(CatalogNo) == null)
                status = true;
            return status;
        }

        public IEnumerable<Catalog> GetAllCatalogs()
        {
            return this._dbContext.Catalogs
                .Include(c => c.ProductList)
               .ToList();
        }

        public Catalog GetCatalogById(long CatalogNo)
        {
            var catalog = _dbContext.Catalogs
                .Include(c => c.ProductList)
              .FirstOrDefault(x => x.CatalogId == CatalogNo);
            return catalog;

        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        
    }
}
