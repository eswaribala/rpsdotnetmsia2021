using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PayrollAPIDockerCompose.Models;
using PayrollAPIDockerCompose.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace PayrollAPIDockerCompose.Controllers
{
    [ApiVersion("1")]
   [ApiVersion("2")]
    [Route("api/v{version:apiVersion}/[controller]")]
   // [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepo _empRepository;

        //dependency injection
        public EmployeeController(IEmployeeRepo empRepository)
        {
            this._empRepository = empRepository;
        }



        // GET: api/Employee
        [MapToApiVersion("1")]
        [Route("Employees")]
        [HttpGet]
        public IActionResult Get()
        {
            var employees = this._empRepository.GetAllEmployees();
            return new OkObjectResult(employees);
        }

        // GET: api/Employee/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(long id)
        {
            var employee = this._empRepository.GetEmployeeById(id);
            return new OkObjectResult(employee);
        }

        // POST: api/Employee
        [HttpPost]
        public IActionResult Post([FromBody] Employee employee)
        {
            using (var scope = new TransactionScope())
            {
                _empRepository.AddEmployee(employee);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = employee.EmployeeId }, employee);
            }
        }

        // PUT: api/Employee/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Employee employee)
        {
            if (employee != null)
            {
                using (var scope = new TransactionScope())
                {
                    _empRepository.UpdateEmployeeById(employee);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _empRepository.DeleteEmployeeById(id);
            return new OkResult();
        }
    }

}
