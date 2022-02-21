using Blazor.Template.Data;
using Blazor.Template.Data.Core;
using Blazor.Template.Services;
using Blazor.Template.Services.ContactService;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddDbContextFactory<BlazorContext>(options => options.UseSqlite("Data Source=blazor-template.db"), ServiceLifetime.Singleton);
builder.Services.AddScoped<ContactDbRepository>();

builder.Services.AddScoped<IPageHelper, PageHelper>();
builder.Services.AddScoped<IContactFilters, ContactFilters>();
builder.Services.AddScoped<ContactService>();

var app = builder.Build();

// Initialize the database
var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
using (var scope = scopeFactory.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<BlazorContext>();
    if (db.Database.EnsureCreated())
    {
        var seed = new SeedData();
        await seed.SeedDatabaseWithContactCountOfAsync(db, 100);
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
