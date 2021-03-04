using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryService.Models
{
    [Table("Stock")]
    public class Stock
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Invoice_No")]
        public long InvoiceNo { get; set; }
        [Column("Qty")]
        public long Qty { get; set; }
        [Column("Comments")]
        public String Comments { get; set; }
        
        [ForeignKey("Product")]
        [Column("Product_Id")]
        public long ProductId { get; set; }
        public Product Product { get; set; }
         
        [ForeignKey("Location")]
        [Column("Location_Id")]
        public long LocationId { get; set; }
        public Location Location { get; set; }
       
    }
}
