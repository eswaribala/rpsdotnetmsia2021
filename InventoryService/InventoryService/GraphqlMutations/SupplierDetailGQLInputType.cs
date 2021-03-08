using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryService.GraphqlMutations
{
    public class SupplierDetailGQLInputType : InputObjectGraphType
    {
        public SupplierDetailGQLInputType()
        {
            Name = "SupplierDetailInput";
            Field<NonNullGraphType<StringGraphType>>("SupplierName");
            Field<NonNullGraphType<StringGraphType>>("Address");
            Field<NonNullGraphType<LongGraphType>>("ContactNo");


        }
    }
}