namespace Blazor.Template.Services.ContactService
{
    public class ContactFilters : IContactFilters
    {
        public IPageHelper PageHelper { get; set; }

        public ContactFilters(IPageHelper pageHelper)
        {
            PageHelper = pageHelper;
        }

        public bool Loading { get; set; }

        public bool ShowFirstNameFirst { get; set; }

        public bool SortAscending { get; set; } = true;

        public string? FilterText { get; set; }
    }
}
