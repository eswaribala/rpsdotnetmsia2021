using HotChocolate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollAPIDockerCompose.Models
{
    [Owned]
    public class Name
    {
        [GraphQLNonNullType]
        public string FirstName { get; set; }
        [GraphQLNonNullType]
        public string MiddleName { get; set; }
        [GraphQLNonNullType]
        public string LastName { get; set; }
    }
}
