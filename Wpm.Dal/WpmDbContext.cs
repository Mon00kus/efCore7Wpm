using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Wpm.Domain;

namespace Wpm.Dal;
public class WpmDbContext : DbContext
{
   private string? connectionString;
   public DbSet<Species> Species { get; set; }
   public DbSet<Pet> Pets { get; set; }
   public DbSet<Breed> Breeds { get; set; }
   public DbSet<Owner> Owners { get; set; }
   public DbSet<OwnerPet> OwnerPet{ get; set; }

   //public WpmDbContext()
   //{
   //   connectionString = @"Data source=DESKTOP-QLP7P2N;Initial Catalog=Wpm;Integrated Security=true;Trust Server Certificate=true;";
   //}

    public WpmDbContext(IConfiguration configuration)
   {
      connectionString = configuration.GetConnectionString("Wpm");
   }
   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
   {
      optionsBuilder.UseSqlServer(@connectionString);
   }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Species>().HasData(
            new Species() { Name = "Canis", Id = 1 },
            new Species() { Name = "Gatus", Id = 2 },
            new Species() { Name = "Primate", Id = 3 },
            new Species() { Name = "Oricta", Id = 4 }
        );
        modelBuilder.Entity<Owner>().HasData(
            new Owner() { Name = "Raul", Id = 1 },
            new Owner() { Name = "Alberto", Id = 2 },
            new Owner() { Name = "Jessica", Id = 3 }
        );
        modelBuilder.Entity<Breed>().HasData(
            new Breed() { Name = "Beagle", Id = 1, SpeciesId = 1 },
            new Breed() { Name = "Boxer", Id = 2, SpeciesId = 1 },
            new Breed() { Name = "Pitbull", Id = 3, SpeciesId = 1 },
            new Breed() { Name = "Siames", Id = 4, SpeciesId = 2 },
            new Breed() { Name = "Gorilla", Id = 5, SpeciesId = 3 }
        );
        modelBuilder.Entity<Pet>().HasData(
            new Pet() { Name = "Gianni", Id = 1, BreedId = 1, Age = 10, Weight = 1 },
            new Pet() { Name = "Nina", Id = 2, BreedId = 1, Age = 10, Weight = 1 },
            new Pet() { Name = "Cheschire cat", Id = 3, BreedId = 4, Age = 10, Weight = 1 },
            new Pet() { Name = "Cati", Id = 4, BreedId = 1, Age = 10, Weight = 1 },
            new Pet() { Name = "Roger Rabbit", Id = 5, BreedId = 3, Age = 10, Weight = 1 }
        );
        modelBuilder.Entity<OwnerPet>().HasData(
            new[] {
                new OwnerPet() { OwnersId = 1, PetsId = 1, Id = 1 },
                new OwnerPet() { OwnersId = 3, PetsId = 2, Id = 2 },
                new OwnerPet() { OwnersId = 2, PetsId = 2, Id = 3 },
                new OwnerPet() { OwnersId = 3, PetsId = 3, Id = 4 },
                new OwnerPet() { OwnersId = 2, PetsId = 4, Id = 5 }
            }
        );
    }
}