using GraphQL;
using GraphQL.Types;
using InventoryService.GraphqlQueries;
using InventoryService.Models;
using InventoryService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
/*
 * mutation($stock:StockInput!,$catalog:CatalogInput!,$product:ProductInput!,$location:LocationInput!){
  insertStockProductLocation(stock:$stock,catalog:$catalog,product:$product,location:$location){
  qty
    
    
  }
}
{
  "stock": {
    "qty": 6780,
     "comments": "verified",
    "productId": 1,
    "regionalCode": 1
  },
  "catalog": {
    "catalogName": "Electronics"
  },
  "product":{
    "productId": 1,
    "productType":0,
    "catalogId": 1,
    "productDetail": {
      "productName": "Laptop",
      "description": "test",
      "dOP": "2021-03-01",
      "cost": 56000
    }
  } ,
  "location": {
    "locationAddress": "chennai",
    "mobileNo": 9952032862,
"regionalCode": 1    
  }
}
 */


namespace InventoryService.GraphqlMutations
{
    public class InventoryMutation : ObjectGraphType
    {
        private readonly IStockRepository StockRepository;
        private readonly IProductRepository ProductRepository;
        private readonly ILocationRepository LocationRepository;
        private readonly ICatalogRepository CatalogRepository;
       
        public InventoryMutation(IStockRepository _StockRepository,IProductRepository _ProductRepository, ILocationRepository _LocationRepository,ICatalogRepository _CatalogRepository)
        {
            StockRepository = _StockRepository;
            ProductRepository = _ProductRepository;
            LocationRepository = _LocationRepository;
            CatalogRepository = _CatalogRepository;
            Field<StockGQLType>("insertStockProductLocation",
             arguments: new QueryArguments(
                 new QueryArgument<StockGQLInputType> { Name = "stock" },
                 new QueryArgument<CatalogGQLInputType> { Name = "catalog" },
                 new QueryArgument<ProductGQLInputType> { Name = "product" },
                 new QueryArgument<LocationGQLInputType> { Name = "location" }),
             resolve: context =>
             {
                 var stock = context.GetArgument<Stock>("stock");
                 var catalog = context.GetArgument<Catalog>("catalog");
                 var product = context.GetArgument<Product>("product");
                 var location = context.GetArgument<Location>("location");
                 return InsertStock(stock, catalog, product, location);
             });

            Field<StockGQLType>("insertStock",
               arguments: new QueryArguments(new QueryArgument<StockGQLInputType> { Name = "stock" }),
               resolve: context =>
               {
                   return StockRepository.AddStock(context.GetArgument<Stock>("stock"));
               });

            Field<BooleanGraphType>(
                "DeleteStock",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<LongGraphType>>
                { Name = "InvoiceNo" }),
                resolve: context =>
                {
                    var invoiceNo = context.GetArgument<long>("InvoiceNo");
                    StockRepository.DeleteStockById(invoiceNo);
                    return $"InvoiceNo {invoiceNo} is successfully deleted";
                }
            );
        }
        private Stock InsertStock(Stock Stock, Catalog Catalog, Product Product, Location Location)
        {
            if (Stock== null)
                return null;
            var existingCatalog = CatalogRepository.GetCatalogById(Catalog.CatalogId);
            var existingProduct= ProductRepository.GetProductById(Product.ProductId);
            var existingLocation =LocationRepository.GetLocationById(Location.RegionalCode);
            if (existingCatalog == null)
            {
                var newCatalog = CatalogRepository.AddCatalog(Catalog);
                Product.CatalogId = newCatalog.CatalogId;
            }
            if ((existingProduct == null) && (existingLocation==null))
            {
               Product.CatalogId=existingCatalog.CatalogId;
                var newProduct = ProductRepository.AddProduct(Product);
                var newLocation = LocationRepository.AddLocation(Location);
                Stock.ProductId = newProduct.ProductId;
                Stock.RegionalCode = newLocation.RegionalCode;
                return StockRepository.AddStock(Stock);
            }
            else
            {
                Stock.ProductId = existingProduct.ProductId;
                Stock.RegionalCode = existingLocation.RegionalCode;
                return StockRepository.AddStock(Stock);
            }
        }
    }
}