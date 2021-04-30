using Microsoft.EntityFrameworkCore;
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
        public DbSet<PetOwner> PetsOwner {get; set;}
        public DbSet<PetAccomodation> PetAccomodations { get; set; }
    }
}
