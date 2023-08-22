using Microsoft.EntityFrameworkCore;
using Project_20.Models;

namespace Project_20.Data
{
    public class ContactContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        public ContactContext(){}
        public ContactContext(DbContextOptions<ContactContext> options)
            : base(options){}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
