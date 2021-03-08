using GraphQL.Types;
using InventoryService.GraphqlQueries;
using InventoryService.Models;
using InventoryService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryService.GraphqlMutations
{
    public class StockGQLInputType : InputObjectGraphType
    {
        public StockGQLInputType()
        {
            Name = "StockInput";
            Field<NonNullGraphType<LongGraphType>>("Qty");
            Field<NonNullGraphType<StringGraphType>>("Comments");
            Field<NonNullGraphType<LongGraphType>>("ProductId");
            Field<NonNullGraphType<LongGraphType>>("RegionalCode");

        }
    }
}
