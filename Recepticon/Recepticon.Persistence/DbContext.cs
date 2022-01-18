using System;
using Microsoft.EntityFrameworkCore;
using Recepticon.Domain.Users;

namespace Recepticon.Persistence
{
    public class RecepticonDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        //public DbSet<Department> Departments { get; set; }
        //public DbSet<Salary> Salaries { get; set; }
        public RecepticonDbContext(DbContextOptions<RecepticonDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
