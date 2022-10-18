using Microsoft.EntityFrameworkCore;
using ProjektApp.Core;
using ProjektApp.Areas.Identity.Data;
using ProjektApp.Core.Interfaces;
using ProjektApp.Persistence;
using Microsoft.AspNetCore.Identity;
using ProjektApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IAuctionPersistence, AuctionSqlPersistence>();   
builder.Services.AddScoped<IAuctionService, AuctionService>();

// db, with dependency injection
builder.Services.AddDbContext<AuctionDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AuctionDbConnection")));
builder.Services.AddDbContext<ProjektAppIdentityContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ProjektAppIdentityContextConnection")));
builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ProjektAppIdentityContext>();

// add auto mapper scanning (requires AutoMapper package)
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();
app.Run();
