using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryService.Models
{
    [Owned]
    public class SupplierDetail
    {
        [Column("Supplier_Name")]
        public String SupplierName { get; set; }
        [Column("Address")]
        public String Address { get; set; }
        [Column("Contact_No")]
        public long ContactNo { get; set; }
    }
}
