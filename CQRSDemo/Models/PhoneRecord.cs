using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRSDemo.Models
{
    public class PhoneRecord
    {
        public long Id { get; set; }
        public PhoneType Type { get; set; }
        public int AreaCode { get; set; }
        public int Number { get; set; }
    }
}
