using Blazor.Template.Data.Model;

namespace Blazor.Template.Data.Core
{
    public class ContactDbRepository : BlazorRepository<Contact, BlazorContext>
    {
        private BlazorContext _context;
        public ContactDbRepository(BlazorContext context) : base(context)
        {
            _context = context;
        }
    }
}
