using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolLibrary.Core.Contracts;
using SchoolLibrary.Core.Models.Statistics;
using SchoolLibrary.Core.Services;
using SchoolLibrary.Infrastructure.Common;
using SchoolLibrary.Infrastructure.Data;
using SchoolLibrary.Infrastructure.Data.Models;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<SchoolLibraryDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IStatisticService, StatisticService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITakeService, TakeService>();


builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
{
    options.SignIn.RequireConfirmedPhoneNumber = false;
    options.Password.RequireNonAlphanumeric = false;
})
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<SchoolLibraryDbContext>();
builder.Services.AddControllersWithViews(options => 
{
    options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>(); 
});

builder.Services.AddMemoryCache();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error/500");
    app.UseStatusCodePagesWithReExecute("/Home/Error","?statusCode={0}");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "Book Details",
        pattern: "/Book/Details/{id}/{information}",
        defaults: new { Controller = "Book", Action = "Details"}
        );
    endpoints.MapControllerRoute(
           name: "areas",
           pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
    endpoints.MapDefaultControllerRoute();
    endpoints.MapRazorPages();
});

await app.CreateAdminRoleAsync();

await app.RunAsync();
