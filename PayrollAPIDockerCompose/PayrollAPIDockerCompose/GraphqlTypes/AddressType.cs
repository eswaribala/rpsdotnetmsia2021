using GraphQL.Types;
using PayrollAPIDockerCompose.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollAPIDockerCompose.GraphqlTypes
{
    public class AddressType: ObjectGraphType<Address>
    {
        public AddressType()
        {
            Name = "Address";
            Field(_ => _.AddressId, type:
            typeof(IdGraphType)).Description
           ("The Address Id of the Address post.");
            Field(_ => _.DoorNo).Description
            ("Door No.");
            Field(_ => _.StreetName).Description
            ("Street Name");
            Field(_ => _.City).Description
           ("City");
            Field(_ => _.State).Description
           ("Street Name");
           
        }
    }
}
