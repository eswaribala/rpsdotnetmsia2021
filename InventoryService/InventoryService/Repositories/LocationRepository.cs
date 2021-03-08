using InventoryService.Contexts;
using InventoryService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryService.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private InventoryContext _dbContext;
        //dependecy injection
        public LocationRepository(InventoryContext dbContext)
        {
            this._dbContext = dbContext;

        }
        public Location AddLocation(Location Location)
        {
           
            this._dbContext.Add(Location);
            Save();
            return Location;

        }

        public bool DeleteLocationById(long RegionalCode)
        {
            bool status = false;
            var location = _dbContext.Locations.Find(RegionalCode);
            _dbContext.Locations.Remove(location);
            Save();
            if (GetLocationById(RegionalCode) == null)
                status = true;
            return status;
        }

        public IEnumerable<Location> GetAllLocations()
        {
            return this._dbContext.Locations
                .Include(l => l.Stock)
               .ToList();
        }

        public Location GetLocationById(long RegionalCode)
        {
            var location = _dbContext.Locations
                .Include(l => l.Stock)
              .FirstOrDefault(x => x.RegionalCode == RegionalCode);
            return location;

        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        
    }
}
