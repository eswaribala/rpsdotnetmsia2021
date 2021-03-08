using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace InventoryService.Models
{
    [Table("Location")]
    public class Location
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Regional_Code")]
        public long RegionalCode { get; set; }
        [Column("Location_Address")]
        public String LocationAddress { get; set; }
        [Column("Mobile_No")]
        public long MobileNo { get; set; }
        [JsonIgnore]
        public Stock Stock { get; set; }
    }
}
