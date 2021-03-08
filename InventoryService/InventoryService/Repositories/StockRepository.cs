using InventoryService.Contexts;
using InventoryService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryService.Repositories
{
    public class StockRepository : IStockRepository
    {
        private InventoryContext _dbContext;
        //dependecy injection
        public StockRepository(InventoryContext dbContext)
        {
            this._dbContext = dbContext;

        }
        public Stock AddStock(Stock Stock)
        {
            //Product product = GetStockById(Stock.ProductId);
            //Stock.Product = product;
            this._dbContext.Add(Stock);
            Save();
            return Stock;

        }

        public bool DeleteStockById(long invoiceNo)
        {
            bool status = false;
            var stock= _dbContext.Stocks.Find(invoiceNo);
            _dbContext.Stocks.Remove(stock);
            Save();
            if (GetStockById(invoiceNo) == null)
                status = true;
            return status;
        }

        public IEnumerable<Stock> GetAllStocks()
        {
            return this._dbContext.Stocks
                .Include(s => s.Product)
                .Include(s=>s.Location)
                .ToList();
        }

        public Stock GetStockById(long invoiceNo)
        {
            var stock = _dbContext.Stocks
                .Include(c =>c.Product )
                 .Include(s => s.Location)
               .FirstOrDefault(x => x.InvoiceNo == invoiceNo);
            return stock;

        }

        public Stock UpdateStock(Stock Stock)
        {
            _dbContext.Entry(Stock).State = EntityState.Modified;
            Save();
            return Stock;
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
