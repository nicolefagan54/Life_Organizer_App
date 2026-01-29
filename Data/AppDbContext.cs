using Microsoft.EntityFrameworkCore;
using LifeOrganizerApp.Models;

namespace LifeOrganizerApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users => Set<User>();
        public DbSet<AppTask> Tasks => Set<AppTask>();
        public DbSet<HealthRecord> HealthRecords => Set<HealthRecord>();
        public DbSet<Kid> Kids => Set<Kid>();
        public DbSet<Event> Events => Set<Event>();
        public DbSet<Chore> Chores => Set<Chore>();
    }
}
