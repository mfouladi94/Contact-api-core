using Microsoft.EntityFrameworkCore;
using test_web_api_core.Models;

namespace test_web_api_core.Data
{
    public class contactsApiDbcontext : DbContext
    {
        public contactsApiDbcontext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}
