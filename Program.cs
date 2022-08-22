using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Vehicl_Project.Areas.Identity.Data;
using Vehicl_Project.DataAccess;
using Vehicl_Project.ProjectServices;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Vehicle_ProjectDbContextConnection") ?? throw new InvalidOperationException("Connection string 'Vehicle_ProjectDbContextConnection' not found.");

builder.Services.AddDbContext<Vehicle_ProjectDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<Vehicle_ProjectUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<Vehicle_ProjectDbContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<IBusRepository, BusRepository>();
builder.Services.AddScoped<IBusService, BusService>();
builder.Services.AddScoped<IBoatRepository, BoatRepository>();
builder.Services.AddScoped<IBoatService, BoatService>();
builder.Services.AddScoped<IColorRepository, ColorRepository>();
builder.Services.AddScoped<IColorService, ColorService>();

AddAuthrozitionPolitics();

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
app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

void AddAuthrozitionPolitics()
{
    builder.Services.AddAuthorization(ops =>
    ops.AddPolicy("Vendor", policy =>
    policy.RequireRole("Vendor")));

    builder.Services.AddAuthorization(ops =>
        ops.AddPolicy("Customer", policy =>
        policy.RequireRole("Customer")));

    builder.Services.AddAuthorization(ops =>
        ops.AddPolicy("Admin", policy =>
        policy.RequireRole("Admin")));
}
