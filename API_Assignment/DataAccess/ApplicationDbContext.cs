using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Assignment.Models;
using Microsoft.EntityFrameworkCore;
using static API_Assignment.Models.Company;

namespace API_Assignment.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Dividends> Divident { get; set; }
        public DbSet<Previous> Previous { get; set; }
        public DbSet<Market> Market { get; set; }

    }
}
