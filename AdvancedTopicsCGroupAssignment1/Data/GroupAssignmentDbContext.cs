using AdvancedTopicsCGroupAssignment1.Models;
using Microsoft.EntityFrameworkCore;

namespace AdvancedTopicsCGroupAssignment1.Data
{
    public class GroupAssignmentDbContext : DbContext
    {
        public GroupAssignmentDbContext(DbContextOptions<GroupAssignmentDbContext> options) : base(options) { }

        public DbSet<Person> Persons { get; set; } = default!;
        public DbSet<Address> Addresss { get; set; } = default!;
        public DbSet<Business> Businesss { get; set; } = default!;
        public DbSet<PersonAddress> PersonAddresses { get; set; } = default!;
        public DbSet<PersonBusiness> PersonBusinesss { get; set; } = default!;
    }
}
