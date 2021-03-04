using InventoryService.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryService.Repositories
{
    public interface IStockRepository 
    {
        //CRUD operation
        Stock AddStock(Stock Stock);
        IEnumerable<Stock> GetAllStocks();
        Stock GetStockById(long invoiceNo);

        bool DeleteStockById(long invoiceNo);
        Stock UpdateStock(Stock Stock);


    }
}
