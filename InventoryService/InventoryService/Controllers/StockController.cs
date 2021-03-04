using InventoryService.Models;
using InventoryService.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace InventoryService.Controllers
{
    [ApiVersion("1")]
    [ApiVersion("2")]
    [Route("api/v{version:apiVersion}/[controller]")]
    // [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockRepository _StockRepository;

        public StockController(IStockRepository StockRepository)
        {
            _StockRepository = StockRepository;

        }

        // GET: api/Stock
       // [MapToApiVersion("1")]
        [Route("Stocks")]
        [HttpGet]
        public IActionResult Get()
        {
            var stocks = this._StockRepository.GetAllStocks();
            return new OkObjectResult(stocks);
        }
        

        // GET: api/Stock/5
        [HttpGet("{invoiceNo}", Name = "Get")]
        public IActionResult Get(long invoiceNo)
        {
            var stock = this._StockRepository.GetStockById(invoiceNo);
            return new OkObjectResult(stock);
        }

        // POST: api/Employee
        [HttpPost]
        public IActionResult Post([FromBody] Stock Stock)
        {
            using (var scope = new TransactionScope())
            {
                _StockRepository.AddStock(Stock);
                scope.Complete();
                return CreatedAtAction(nameof(Get), 
                    new { id = Stock.InvoiceNo}, Stock);
            }
        }

        // PUT: api/Stock/5
        [HttpPut("{invoiceNo}")]
        public IActionResult Put(int invoiceNo, [FromBody] Stock Stock)
        {
            if (Stock != null)
            {
                using (var scope = new TransactionScope())
                {
                    _StockRepository.UpdateStock(Stock);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{invoiceNo}")]
        public IActionResult Delete(long invoiceNo)
        {
            _StockRepository.DeleteStockById(invoiceNo);
            return new OkResult();
        }

    }
}
