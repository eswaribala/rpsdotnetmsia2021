using GraphQL.Types;
using InventoryService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryService.GraphqlQueries
{
    public class SupplierGQLType : ObjectGraphType<Supplier>
    {
        public SupplierGQLType()
        {
            Name = "Suppler";
            Field(_ => _.SupplierId).Description("Supplier Id");
            Field(_ => _.SupplierDetail.SupplierName).Description("Supplier Name");
            Field(_ => _.SupplierDetail.Address).Description("Supplier Address");
            Field(_ => _.SupplierDetail.ContactNo).Description("Contact No");

        }
    }
}
