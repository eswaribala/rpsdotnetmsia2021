using GraphQL.Types;
using PayrollAPIDockerCompose.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollAPIDockerCompose.GraphqlTypes
{
    public class AddressInputType : InputObjectGraphType
    {
        public AddressInputType()
            {
                Name = "addressInput";

            Field<NonNullGraphType<StringGraphType>>("DoorNo");
            Field<NonNullGraphType<StringGraphType>>("StreetName");
            Field<NonNullGraphType<StringGraphType>>("City");
            Field<NonNullGraphType<StringGraphType>>("State");

        }
    }
}
