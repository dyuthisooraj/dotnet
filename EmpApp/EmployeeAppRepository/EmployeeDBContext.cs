using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using EmployeeAppModels;

namespace EmployeeAppRepository
{
    public class EmployeeDBContext : DbContext
    {
        public EmployeeDBContext(DbContextOptions dboptions) : base(dboptions)
        {
        }

        public DbSet<EmployeeRegistration> Details
        {
            get; set;
        }
    }
}