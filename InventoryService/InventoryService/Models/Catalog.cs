using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace InventoryService.Models
{
    [Table("Catalog")]
    public class Catalog
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column("Catalog_Id")]
        public long CatalogId { get; set; }
        [Column("Catalog_Name")]
        [StringLength(100)]
        [Required]
        public String CatalogName { get; set; }
        [JsonIgnore]
       public ICollection<Product> ProductList { get; set; }

    }
}
