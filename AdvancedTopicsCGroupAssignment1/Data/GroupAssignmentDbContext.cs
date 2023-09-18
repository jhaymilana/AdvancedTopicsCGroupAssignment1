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
        public DbSet<BusinessAddress> BusinessAddresses { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure many-to-many relationship between Business and Address
            modelBuilder.Entity<BusinessAddress>()
                .HasKey(ba => new { ba.BusinessId, ba.AddressId });

            modelBuilder.Entity<BusinessAddress>()
                .HasOne(ba => ba.Business)
                .WithMany(b => b.businesssAdresses)
                .HasForeignKey(ba => ba.BusinessId);

            modelBuilder.Entity<BusinessAddress>()
                .HasOne(ba => ba.Address)
                .WithMany(a => a.businesssAdresses)
                .HasForeignKey(ba => ba.AddressId);

            // Configure one-to-many relationship between Business and Person
            modelBuilder.Entity<PersonBusiness>()
                .HasKey(pb => new { pb.PersonId, pb.BusinessId });

            modelBuilder.Entity<PersonBusiness>()
                .HasOne(pb => pb.Person)
                .WithMany(p => p.PersonBusinesses)
                .HasForeignKey(pb => pb.PersonId);

            modelBuilder.Entity<PersonBusiness>()
                .HasOne(pb => pb.Business)
                .WithMany(b => b.personBusinesses)
                .HasForeignKey(pb => pb.BusinessId);

            // Add any other model configurations you might have here
        }

    }
}
