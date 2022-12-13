using CustomerContacts.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerContacts.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }
}
