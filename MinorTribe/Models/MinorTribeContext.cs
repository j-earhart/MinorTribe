using Microsoft.EntityFrameworkCore;
using MinorTribe.Models;

namespace MinorTribe.Models
{
    public class MinorTribeContext : DbContext
    {
        public MinorTribeContext(DbContextOptions<MinorTribeContext> options) :
           base(options)
        { }

        //Begin Defining your models that will be generated into tables
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Bio> Bios { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        //public DbSet<Shop> Shops { get; set; }

    }
}
