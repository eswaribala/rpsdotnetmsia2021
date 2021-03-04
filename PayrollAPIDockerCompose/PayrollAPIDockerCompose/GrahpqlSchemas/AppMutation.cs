using GraphQL;
using GraphQL.Types;
using PayrollAPIDockerCompose.GraphqlTypes;
using PayrollAPIDockerCompose.Models;
using PayrollAPIDockerCompose.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollAPIDockerCompose.GrahpqlSchemas
{
    public class AppMutation:ObjectGraphType
    {
        public AppMutation(IEmployeeRepo repository)
        {
            Field<EmployeeType>(
                "createEmployee",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<EmployeeInputType>>
                { Name = "employee" }),
                resolve: context =>
                {
                    var employee = context.GetArgument<Employee>("employee");
                    return repository.AddEmployee(employee);
                }
            );

            Field<StringGraphType>(
                "deleteEmployee",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<LongGraphType>> 
                { Name = "employeeId" }),
                resolve: context =>
                {
                    var employeeId = context.GetArgument<long>("employeeId");
                    repository.DeleteEmployeeById(employeeId);
                    return $"EmployeeId {employeeId} is successfully deleted";
                }
            );
        }
    }
}
