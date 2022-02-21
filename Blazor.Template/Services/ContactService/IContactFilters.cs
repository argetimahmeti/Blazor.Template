namespace Blazor.Template.Services.ContactService
{
    public interface IContactFilters
    {

        bool Loading { get; set; }

        string? FilterText { get; set; }

        IPageHelper PageHelper { get; set; }

        bool ShowFirstNameFirst { get; set; }

        bool SortAscending { get; set; }

    }
}
