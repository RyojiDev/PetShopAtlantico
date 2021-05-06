using Microsoft.EntityFrameworkCore;
using PetshopAtlantico.DataBaseAccess.Entity.Mappings;
using PetshopAtlantico.Domain;
using PetShopAtlantico.Domain;

namespace PetshopAtlantico.DataBaseAccess.Entity
{
    public class PetShopDbContext : DbContext
    {
        public PetShopDbContext(DbContextOptions<PetShopDbContext> options) : base(options)
        {
            
        }

        public DbSet<Pet> Pets { get; set; }
        public DbSet<PetOwner> PetsOwner { get; set; }
        public DbSet<PetAccomodation> PetAccomodations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PetAccomodationMap());
        }
    }
}
