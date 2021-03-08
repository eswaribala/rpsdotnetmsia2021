using InventoryService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryService.Repositories
{
    public interface ISupplierRepository
    {
        Supplier AddSupplier(Supplier Supplier);
        IEnumerable<Supplier> GetAllSuppliers();
        Supplier GetSupplierById(long SupplierId);
        bool DeleteSupplierById(long SupplierId);

     }
}
