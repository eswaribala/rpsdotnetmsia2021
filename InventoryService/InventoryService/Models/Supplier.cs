using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace InventoryService.Models
{
    [Table("Supplier")]
    public class Supplier
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key,Column("SupplierId",Order =0)]
        public long SupplierId { get; set; }
       // [Key, Column("Country_Code",Order = 1)]
       // public long CountryCode { get; set; }
        public SupplierDetail SupplierDetail { get; set; }
        [JsonIgnore]
        public ICollection<ProductSupplier> ProductSuppliers { get; set; }

    }
}
