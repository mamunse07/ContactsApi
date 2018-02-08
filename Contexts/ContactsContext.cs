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
                @"Data Source=.\\SQLEXPRESS;Initial Catalog=ContactsDB;Integrated Security=True;MultipleActiveResultSets=True;ConnectRetryCount=0");
            base.OnConfiguring(optionsBuilder);
        }
        public ContactsContext(){ }
        public DbSet<Contacts> Contacts { get; set; }
    }
}