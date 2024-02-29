using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using shadowbase.Data;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddRazorPages();
builder.Services.AddDbContext<ShadowbaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ShadowbaseContext") ?? throw new InvalidOperationException("Connection string 'ShadowbaseContext' not found.")));

var app = builder.Build();

// Added Feb 28, refer to Lab 5 for more information
if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}
// End of added Feb 28

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<ShadowbaseContext>();
    context.Database.EnsureCreated();
    DbInitializer.Initialize(context);
}

// Configure the HTTP request pipeline.
// Removed Feb 28, refer to Lab 5 for more information
//if (app.Environment.IsDevelopment())
//{
//    app.UseMigrationsEndPoint();
//}
//else
//{
//    app.UseExceptionHandler("/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}
// End of removed Feb 28

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
