using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using EmployeeManagementLogin.Data;
using Microsoft.AspNetCore.Identity;
using EmployeeManagementLogin.Models;
using EmployeeManagementLogin.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<EmployeeManagementDbContext>(options =>
    options.UseSqlServer("Server=DESKTOP-TIC5DM4;Database=EmployeeManagement;Trusted_Connection=True;MultipleActiveResultSets=true")); // Replace with your connection string

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<EmployeeManagementDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Login}/{id?}");

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<EmployeeManagementDbContext>();
    context.Database.Migrate(); // Ensure the database is created and migrated
}

app.Run();