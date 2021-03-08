using InventoryService.Contexts;
using InventoryService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryService.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private InventoryContext _dbContext;
        //dependecy injection
        public SupplierRepository(InventoryContext dbContext)
        {
            this._dbContext = dbContext;

        }
        public Supplier AddSupplier(Supplier Supplier)
        {
           
            this._dbContext.Add(Supplier);
            Save();
            return Supplier;

        }

        public bool DeleteSupplierById(long SupplierId)
        {
            bool status = false;
            var supplier = _dbContext.Suppliers.Find(SupplierId);
            _dbContext.Suppliers.Remove(supplier);
            Save();
            if (GetSupplierById(SupplierId) == null)
                status = true;
            return status;
        }

        public IEnumerable<Supplier> GetAllSuppliers()
        {
            return this._dbContext.Suppliers
                   .ToList();
        }

        public Supplier GetSupplierById(long SupplierId)
        {
            var supplier = _dbContext.Suppliers
               
              .FirstOrDefault(x => x.SupplierId == SupplierId);
            return supplier;

        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        
    }
}
