using GraphQL;
using GraphQL.Types;
using InventoryService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryService.GraphqlQueries
{
    public class InventoryQuery:ObjectGraphType
    {
        public InventoryQuery(IStockRepository StockRepository)
        {
            Name = "InventoryQuery";
            //get all stocks
            Field<ListGraphType<StockGQLType>>(
              "stocks",
              resolve: context => StockRepository.GetAllStocks()
          ) ;

            //get stock by id
            Field<StockGQLType>(
               "stock",
               arguments: new QueryArguments(new QueryArgument<LongGraphType> { Name = "invoiceNo" }),
               resolve: context =>StockRepository.GetStockById(context.GetArgument<long>("invoiceNo"))
           
               );

        }

    }
}
