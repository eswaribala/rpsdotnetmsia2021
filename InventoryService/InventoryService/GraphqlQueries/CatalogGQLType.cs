using GraphQL.Types;
using InventoryService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryService.GraphqlQueries
{
    public class CatalogGQLType:ObjectGraphType<Catalog>
    {
        public CatalogGQLType()
        {
            Name = "Catalog";
            Field(_ => _.CatalogId).Description("Catalog Id.");
            Field(_ => _.CatalogName).Description("Catalog Name.");
        }
    }
}
