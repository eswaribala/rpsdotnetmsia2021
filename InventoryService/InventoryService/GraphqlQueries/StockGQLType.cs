using GraphQL.Types;
using InventoryService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryService.GraphqlQueries
{
    public class StockGQLType : ObjectGraphType<Stock>
    {
        public StockGQLType()
        {
            Name = "Stock";
            Field(_ => _.InvoiceNo).Description("Invoice No");
            Field(_ => _.Qty).Description("Qty");
            Field(_ => _.Comments).Description("Comments");
            
            Field(_ => _.Location.RegionalCode).Description("Regional Code");
            Field(_ => _.Location.LocationAddress).Description("Location Address");
            Field(_ => _.Location.MobileNo).Description("MobileNo");
            Field(_ => _.Product.ProductId).Description("Product Id");
            Field(_ => _.Product.ProductDetail.ProductName).Description("Product Name");
            Field(_ => _.Product.ProductDetail.Description).Description("Product Description");
            Field(_ => _.Product.ProductDetail.Cost).Description("Cost");
            Field(_ => _.Product.ProductDetail.DOP).Description("DOP");
            Field(_ => _.Product.ProductType).Description("Product Type");
            Field(_ => _.Product.Catalog.CatalogId).Description("Catalog Id");
            Field(_ => _.Product.Catalog.CatalogName).Description("Catalog Name");


        }
    }
}
