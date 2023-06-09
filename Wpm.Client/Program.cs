using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Wpm.Dal;
using Wpm.Domain;
//using Wpm.Domain;

var cb = new ConfigurationBuilder();

cb.AddJsonFile("configuration.json");

var config = cb.Build();

using var db = new WpmDbContext(config);  // el using es para asegurarnos de liberar los objetos no utilazados del DbContext recordemos que el dbContext implementa el idisposable

#region DataAdding

db.Database.EnsureDeleted();
db.Database.EnsureCreated();

var breeds = db.Breeds
    .Include(b => b.Species)
    .Select(b => new { BreedName = b.Name, SpeciesName = b.Species.Name })
    .OrderBy(b=>b.SpeciesName)
    .ThenBy(b=>b.BreedName)
    .ToList();
foreach (var breed in breeds)
{
    Console.WriteLine($"{breed.BreedName} - {breed.SpeciesName}");
}
Console.WriteLine();
//var breeds = db.Breeds
//               .Include(x => x.Species)
//               .ToList();
//foreach (var breed in breeds)
//{
//    Console.WriteLine($"{breed.Name} - {breed.Species.Name}");
//}

//var beagle = new Breed() { Name = "Beagle", SpeciesId = 1 };

//var raul = new Owner() { Name = "Raul" };
//var alberto = new Owner() { Name = "Alberto" };

//var ownnerList_1 = new List<Owner> { raul };

//var gianni = new Pet() { Name = "Gianni", Breed = beagle, Age = 4, Weight = 14, Owners = ownnerList_1 };

//var ownnerList_2 = new List<Owner> { alberto };

//var cati = new Pet() { Name = "Catira", BreedId = 2, Age = 6, Weight = 12, Owners = ownnerList_2 };

//db.SaveChanges();

//Console.WriteLine("Se agregaron  !!!");
#endregion


//var allPets = db.Pets.ToList();

//Console.WriteLine(allPets.Count);

//var cat = new Species() { Name = "Gato" };

//cat.Pets.Add(new Pet() { Name = "Pochaco", Age = 2, Weight = 2 });

//var dog = new Species { Name = "Perro" };

//dog.Pets.Add(new Pet() { Name = "Mini", Age= 2, Weight = 12 });

//var bre = new Breed { Name = "Belgium pastor"};

//bre.Pets.Add(new Pet() { Name = "Cora", Age = 7, Weight = 21 });

//db.Species.Add(cat);

//db.Species.Add(dog);

//db.Breeds.Add(bre);

//db.SaveChanges();