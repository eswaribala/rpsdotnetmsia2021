using Microsoft.EntityFrameworkCore;
using PayrollAPIDockerCompose.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollAPIDockerCompose.Contexts
{
    public class EmployeeContext:DbContext
    {

        public EmployeeContext()
        {
        }

        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {
            this.Database.EnsureCreated();
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Address> Addresses { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
       .HasMany(c => c.AddressList)
       .WithOne(e => e.Employee);
        }
    }
}
