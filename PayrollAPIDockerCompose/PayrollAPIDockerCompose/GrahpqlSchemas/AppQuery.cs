using GraphQL;
using GraphQL.Types;
using PayrollAPIDockerCompose.GraphqlTypes;
using PayrollAPIDockerCompose.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollAPIDockerCompose.GrahpqlSchemas
{
    public class AppQuery : ObjectGraphType
    {
        public AppQuery(IEmployeeRepo repository)
        {
            Name = "EmployeeQuery";
            Field<EmployeeType>(
                "employeeById",
                arguments: new QueryArguments(new QueryArgument<LongGraphType> { Name = "employeeId" }),
                resolve: context => repository.GetEmployeeById(context.GetArgument<long>("employeeId"))
                );
            Field<ListGraphType<EmployeeType>>(
               "employees",
               resolve: context => repository.GetAllEmployees()
           );
        }
    }
}
