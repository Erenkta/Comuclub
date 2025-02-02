using Comuclub.Entities;
using Microsoft.EntityFrameworkCore;

namespace Comuclub.Data
{
    public class ComuClubContext : DbContext
    {
        public DbSet<Address> Addresses {  get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<Event> Events { get; set; } 
        public DbSet<Organizer> Organizers { get; set; }


        public ComuClubContext(DbContextOptions<ComuClubContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Organizer>()
                .HasMany(organizer => organizer.Clubs)
                .WithOne(club => club.Organizer)
                .HasForeignKey(club => club.OrganizerId);

            modelBuilder.Entity<Club>()
                .HasMany(club => club.Events)
                .WithOne(events => events.Club)
                .HasForeignKey(events => events.ClubId);

            modelBuilder.Entity<Event>()
                .HasOne(e => e.Address)
                .WithOne()
                .HasForeignKey<Event>(e => e.AddressId);


        }
    }
}
