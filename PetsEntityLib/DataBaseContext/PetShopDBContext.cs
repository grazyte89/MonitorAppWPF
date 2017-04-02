using PetsEntityLib.Entities;
using System.Data.Entity;

namespace PetsEntityLib.DataBaseContext
{
    public class PetShopDBContext : DbContext
    {
        public PetShopDBContext() : base("name=PetShopDBContext")
        {
        }

        public DbSet<Animal> Animals { get; set; }
        public DbSet<AnimalSold> AnimalSolds { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Stock> Stocks { get; set; }

        // https://msdn.microsoft.com/en-us/data/jj591621
    }
}
