using GraphQL.Types;
using GraphQL.Utilities;
using InventoryService.GraphqlMutations;
using InventoryService.GraphqlQueries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryService.GraphqlSchemas
{
    public class InventorySchema:Schema
    {
        public InventorySchema(IServiceProvider ServiceProvider)
        {
            Query= ServiceProvider.GetRequiredService<InventoryQuery>();
            Mutation = ServiceProvider.GetRequiredService<InventoryMutation>();
        }
    }
}
