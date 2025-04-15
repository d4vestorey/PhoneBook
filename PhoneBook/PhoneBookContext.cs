using Microsoft.EntityFrameworkCore;

namespace PhoneBook
{
    public class PhoneBookContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source=phonebook.db");

        public DbSet<Contact> Contacts { get; set; }
    }
    
}