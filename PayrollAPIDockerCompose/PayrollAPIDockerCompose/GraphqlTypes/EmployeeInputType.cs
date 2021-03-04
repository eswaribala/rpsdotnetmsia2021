using GraphQL.Types;
using PayrollAPIDockerCompose.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//mutation($employee: employeeInput!){
//    createEmployee(employee:$employee){
//        firstName,
//    lastName,
//    middleName,
//    dOB,
//  }
//}
//{
//    "employee": {
//        "employeeName": {
//            "firstName": "Parameswari",
//      "lastName": "",
//      "middleName": ""
//        },
//    "dOB": "1970-12-02"
//    }
//}
namespace PayrollAPIDockerCompose.GraphqlTypes
{
    public class EmployeeInputType : InputObjectGraphType
    {
        public EmployeeInputType()
        {
            Name = "employeeInput";
            Field<NonNullGraphType<NameInputType>>("EmployeeName");
            Field<NonNullGraphType<DateGraphType>>("DOB");
        }
    }
}
