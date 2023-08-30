using MembershipSystem.Core.DatabaseEntities;
using Microsoft.EntityFrameworkCore;

namespace MembershipSystem.Infrastructure.Repository;
public class DatabaseContext : DbContext {

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
    }

    //Entities
    public DbSet<Person> Persons { get; set; }
}
