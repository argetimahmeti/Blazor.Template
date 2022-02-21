using Blazor.Template.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Blazor.Template.Data
{
    public class BlazorContext : DbContext
    {
        public BlazorContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}
