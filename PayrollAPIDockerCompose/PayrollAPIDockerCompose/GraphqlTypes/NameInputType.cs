using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollAPIDockerCompose.GraphqlTypes
{
    public class NameInputType : InputObjectGraphType
    {
        public NameInputType()
        {
            Name = "nameInput";
            Field<NonNullGraphType<StringGraphType>>("FirstName");
            Field<NonNullGraphType<StringGraphType>>("MiddleName");
            Field<NonNullGraphType<StringGraphType>>("LastName");
        }
    }
}
