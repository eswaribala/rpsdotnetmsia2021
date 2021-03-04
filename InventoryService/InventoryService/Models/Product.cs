using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryService.Models
{
    public enum ProductType {Regular,Seasonal}
    [Table("Product")]
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column("Product_Id")]
        public long ProductId { get; set; }
        public ProductDetail ProductDetail { get; set; }
        [Column("Product_Type")]
        public ProductType ProductType { get; set; }
        [ForeignKey("Catalog")]
        [Column("Catalog_Id")]
        public long CatalogId { get; set; }
        public Catalog Catalog { get; set; }
       
        public ICollection<ProductSupplier> ProductSuppliers { get; set; }

        public Stock Stock;
    }
}
