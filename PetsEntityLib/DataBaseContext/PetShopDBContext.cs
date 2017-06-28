using PetsEntityLib.Entities;
using System.Data.Entity;

namespace PetsEntityLib.DataBaseContext
{
    public class PetShopDBContext : DbContext
    {
        public PetShopDBContext() : base("name=PetShopDBContext")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }

        //public DbSet<Animal> Animals { get; set; }
        public DbSet<AnimalSold> AnimalSolds { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Stock> Stocks { get; set; }
    }
}

// https://msdn.microsoft.com/en-us/data/jj591621
// https://arian-celina.com/entity-framework-migrations-and-data-seeding/
// https://msdn.microsoft.com/en-us/magazine/jj883952.aspx