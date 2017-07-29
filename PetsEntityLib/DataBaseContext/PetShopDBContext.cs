using PetsEntityLib.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace PetsEntityLib.DataBaseContext
{
    public class PetShopDBContext : DbContext
    {
        public PetShopDBContext() : base("name=PetShopDBContext")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Animal> Animals { get; set; }
        public DbSet<AnimalSold> AnimalSolds { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Coursem2m> CoursesManyToManys { get; set; }
        public DbSet<JoinCustomerCourse> JoinCustomerCourses { get; set; }
        //public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        /*protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }*/
    }
}

// https://msdn.microsoft.com/en-us/data/jj591621
// https://arian-celina.com/entity-framework-migrations-and-data-seeding/
// https://msdn.microsoft.com/en-us/magazine/jj883952.aspx