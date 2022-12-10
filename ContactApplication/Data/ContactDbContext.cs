using ContactApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactApplication.Data
{
    public class ContactAPIDbContext : DbContext
    {
        public ContactAPIDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Contact> Contacts { get; set; }
    }
}
