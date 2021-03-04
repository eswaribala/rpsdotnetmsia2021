using GraphQL.Types;
using PayrollAPIDockerCompose.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollAPIDockerCompose.GraphqlTypes
{
    public class EmployeeType : ObjectGraphType<Employee>
    {
        public EmployeeType()
        {
            Name = "Employee";
            Field(_ => _.EmployeeId).Description("Employee's Id.");
            Field(_ => _.EmployeeName.FirstName).Description
            ("First Name of the Employee");
            Field(_ => _.EmployeeName.MiddleName).Description
           ("Middle Name of the Employee");
            Field(_ => _.EmployeeName.LastName).Description
           ("Last Name of the Employee");
            Field(_ => _.DOB).Description
            ("Date of Birth");

        }
    }
}
