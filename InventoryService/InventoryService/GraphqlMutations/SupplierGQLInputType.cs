using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryService.GraphqlMutations
{
    public class SupplierGQLInputType : InputObjectGraphType
    {
        public SupplierGQLInputType()
        {
            Name = "SupplierInput";
            Field<NonNullGraphType<SupplierDetailGQLInputType>>("SupplierDetail");
          


        }
    }
}
