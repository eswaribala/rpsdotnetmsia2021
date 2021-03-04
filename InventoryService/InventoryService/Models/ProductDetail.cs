using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryService.Models
{
    [Owned]
    public class ProductDetail
    {
        [Column("Product_Name")]
        public String ProductName { get; set; }
        [Column("Description")]
        public String Description { get; set; }
        [Column("Purchase_Date")]
        //Date of Purchase
        public DateTime DOP { get; set; }
        [Column("Cost")]
        public long Cost { get; set; }
        
    }
}
