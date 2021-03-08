using GraphQL.Types;
using InventoryService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryService.GraphqlQueries
{
    public class LocationGQLType:ObjectGraphType<Location> {
    public LocationGQLType()
    {
        Name = "Location";
        Field(_ => _.RegionalCode).Description("Regional Code");
        Field(_ => _.LocationAddress).Description("Location Address");
        Field(_ => _.MobileNo).Description("Mobile No");
        }
}
}
