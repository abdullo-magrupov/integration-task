using Synel.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synel.DAL
{
    public class SynelDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Log> Logs { get; set; }
    }
}
