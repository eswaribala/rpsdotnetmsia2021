using HotChocolate;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollAPIDockerCompose.Models
{
    public class Employee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order=0)]

        public long EmployeeId { get; set; }
        [GraphQLNonNullType]
        public Name EmployeeName { get; set; }

        //[Key, Column(Order = 1)]
        public DateTime DOB { get; set; }

        public ICollection<Address> AddressList { get; set; }
    }
}
