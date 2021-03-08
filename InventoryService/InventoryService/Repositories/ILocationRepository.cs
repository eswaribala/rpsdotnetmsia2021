using InventoryService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryService.Repositories
{
    public interface ILocationRepository
    {
        Location AddLocation(Location Location);
        IEnumerable<Location> GetAllLocations();
        Location GetLocationById(long RegionalCode);
        bool DeleteLocationById(long LocationId);

     }
}
