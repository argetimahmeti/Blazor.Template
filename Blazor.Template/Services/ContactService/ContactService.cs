using Blazor.Template.Data.Model;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Blazor.Template.Services.ContactService
{
    public class ContactService
    {
        private readonly IContactFilters _filters;

        public ContactService(IContactFilters filters)
        {
            _filters = filters;
        }

        public async Task<ICollection<Contact>> FetchAsync(IQueryable<Contact> query)
        {
            await CountAsync(query);
            var collection = await FetchPageQuery(query)
                .ToListAsync();
            _filters.PageHelper.PageItems = collection.Count;
            return collection;
        }

        public async Task CountAsync(IQueryable<Contact> query)
        {
            _filters.PageHelper.TotalItemCount = await query.CountAsync();
        }

        public IQueryable<Contact> FetchPageQuery(IQueryable<Contact> query)
        {
            return query
                .Skip(_filters.PageHelper.Skip)
                .Take(_filters.PageHelper.PageSize)
                .AsNoTracking();
        }

    }
}
