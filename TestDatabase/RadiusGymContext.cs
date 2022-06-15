using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TestDatabaseSqlite.Entities;

namespace TestDatabase
{
    public class RadiusGymContext : DbContext
    {
        public DbSet<Member> Members { get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }
        public DbSet<AccessHistory> AccessHistory { get; set; }
        public DbSet<AccessInformation> AccessInformation { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=RadiusGym.db", options =>
            {
                options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
            });
            base.OnConfiguring(optionsBuilder);
        }
    }
}