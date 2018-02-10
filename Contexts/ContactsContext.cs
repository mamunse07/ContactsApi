using ContactsApi.Models;
using Microsoft.EntityFrameworkCore;
 
namespace ContactsApi.Contexts
{
    public class ContactsContext : DbContext
    {
        public ContactsContext(DbContextOptions<ContactsContext> options)
            :base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Data Source=localhost;Initial Catalog=ContactsContext;User ID=SA;Password=Mamun420");
            base.OnConfiguring(optionsBuilder);
        }
        public ContactsContext(){ }
        public DbSet<Contacts> Contacts { get; set; }
        public DbSet<TodoItem> TodoItems { get; set; }
    }
}