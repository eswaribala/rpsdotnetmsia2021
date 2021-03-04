using Microsoft.EntityFrameworkCore;
using PayrollAPIDockerCompose.Contexts;
using PayrollAPIDockerCompose.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollAPIDockerCompose.Repositories
{
    class EmployeeRepository : IEmployeeRepo
    {

        private readonly EmployeeContext _dbContext;

        //dependency injection
        public EmployeeRepository(EmployeeContext dbContext)
        {
            this._dbContext = dbContext;

        }


        public Employee AddEmployee(Employee employee)
        {
            this._dbContext.Add(employee);
            Save();
            return employee;
        }

        public void DeleteEmployeeById(long employeeId)
        {
            var employee = _dbContext.Employees.Find(employeeId);
            _dbContext.Employees.Remove(employee);
            Save();
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            var employees = _dbContext.Employees.Include(employee=> employee.AddressList).ToList();

            return employees;
        }

        public Employee GetEmployeeById(long employeeId)
        {
            var employee = _dbContext.Employees.Include(c => c.AddressList)
               .FirstOrDefault(x => x.EmployeeId == employeeId);

            return employee;

        }

        public void UpdateEmployeeById(Employee employee)
        {
            _dbContext.Entry(employee).State = EntityState.Modified;
            Save();
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
