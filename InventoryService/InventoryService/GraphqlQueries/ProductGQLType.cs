using GraphQL.Types;
using InventoryService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryService.GraphqlQueries
{
    public class ProductGQLType: ObjectGraphType<Product>
    {
        public ProductGQLType()
        {
            Name = "Product";
            Field(_ => _.ProductId).Description("Product Id");
            Field(_ => _.ProductDetail.ProductName).Description("Product Name");
            Field(_ => _.ProductDetail.Description).Description("Product Description");
            Field(_ => _.ProductDetail.Cost).Description("Cost");
            Field(_ => _.ProductDetail.DOP).Description("DOP");
            Field(_ => _.ProductType).Description("Product Type");
        }
    }
}
