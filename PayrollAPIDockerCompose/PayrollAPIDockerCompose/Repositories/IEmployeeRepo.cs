using PayrollAPIDockerCompose.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollAPIDockerCompose.Repositories
{
    public interface IEmployeeRepo
    {
        //Add
        Employee AddEmployee(Employee Employeee);
        //Update
        void UpdateEmployeeById(Employee employee);
        //Delete
        void DeleteEmployeeById(long employeeId);
        //Retrieve alll
        IEnumerable<Employee> GetAllEmployees();
        //Retrieve ById
        Employee GetEmployeeById(long employeeId);       
        

    }
}
