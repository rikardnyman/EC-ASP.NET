using Data.Contexts;
using Data.Entities;
using Data.Repositories;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"),
                         b => b.MigrationsAssembly("EC-ASP.NET")));

builder.Services.AddIdentity<UserEntity, IdentityRole>(x =>
{
    x.User.RequireUniqueEmail = true;
    x.Password.RequiredLength = 8;

})
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(x =>
{
    x.LoginPath = "/auth/signin";
    x.AccessDeniedPath = "/auth/denied";
    x.Cookie.HttpOnly = true;
    x.Cookie.IsEssential = true;
    x.Cookie.Expiration = TimeSpan.FromHours(1);
    x.SlidingExpiration = true;

});
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();



var app = builder.Build();
app.UseHsts();
app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Admin}/{action=Members}/{id?}")
    .WithStaticAssets();


app.Run();
