using LibrarySystem.Application.DependencyInjection;
using LibrarySystem.Application.Mapping;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

builder.Services.AddControllersWithViews();

builder.Services.AddAutoMapper(typeof(BookProfile).Assembly);

builder.Services.AddDependencyInjection(configuration);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
