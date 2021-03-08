using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryService.GraphqlMutations
{
    public class LocationGQLInputType : InputObjectGraphType
    {
        public LocationGQLInputType()
        {
            Name = "LocationInput";
            Field<NonNullGraphType<StringGraphType>>("LocationAddress");
            Field<NonNullGraphType<LongGraphType>>("MobileNo");
            Field<NonNullGraphType<LongGraphType>>("RegionalCode");

        }
    }
}