using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryService.Models
{
    public class ProductSupplier
    {
        [ForeignKey("Product")]
        public long ProductId { get; set; }
        public Product Product { get; set; }
        [ForeignKey("Supplier")]
        public long SupplierId { get; set; }
        public Supplier Supplier { get; set; }
    }
}
