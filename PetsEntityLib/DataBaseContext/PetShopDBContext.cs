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
        //public DbSet<Coursem2m> CoursesManyToManys { get; set; }
        public DbSet<JoinCustomerCourse> JoinCustomerCourses { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        /*protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<Animal>()
                .Property(e => e.GENDER)
                .IsUnicode(false);

            modelBuilder.Entity<Animal>()
                .Property(e => e.TYPE)
                .IsUnicode(false);

            modelBuilder.Entity<Animal>()
                .Property(e => e.STATUS)
                .IsUnicode(false);

            modelBuilder.Entity<Animal>()
                .HasMany(e => e.AnimalSolds)
                .WithRequired(e => e.Animal)
                .HasForeignKey(e => e.ANIMAL_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Course>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<Course>()
                .Property(e => e.SUBJECT_TYPE)
                .IsUnicode(false);

            modelBuilder.Entity<Course>()
                .HasMany(e => e.Customers)
                .WithRequired(e => e.Course)
                .HasForeignKey(e => e.COURSE_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.FIRSTNAME)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.LASTNAME)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.ADDRESS)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.AnimalSolds)
                .WithRequired(e => e.Customer)
                .HasForeignKey(e => e.OWNER_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Courses)
                .WithRequired(e => e.Customer)
                .HasForeignKey(e => e.CUSTOMER_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Message>()
                .Property(e => e.SENDER)
                .IsUnicode(false);

            modelBuilder.Entity<Message>()
                .Property(e => e.RECEIVER)
                .IsUnicode(false);

            modelBuilder.Entity<Message>()
                .Property(e => e.MULTIPLE_RECEIVER)
                .IsUnicode(false);

            modelBuilder.Entity<Message>()
                .Property(e => e.TEXT)
                .IsUnicode(false);

            modelBuilder.Entity<Message>()
                .Property(e => e.MESSAGE_HEAD)
                .IsUnicode(false);
        }*/
    }
}

// https://msdn.microsoft.com/en-us/data/jj591621
// https://arian-celina.com/entity-framework-migrations-and-data-seeding/
// https://msdn.microsoft.com/en-us/magazine/jj883952.aspx