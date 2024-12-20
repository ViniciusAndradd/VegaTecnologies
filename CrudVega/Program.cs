using Microsoft.EntityFrameworkCore;
using CrudVega.Context;
using CrudVega.Repositories;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString,
        new MySqlServerVersion(new Version(8, 0, 40))));

builder.Services.AddScoped<ISupplierRepository,SupplierRepository>();
builder.Services.AddScoped<IMaterialRepository, MaterialRepository>();

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

app.UseAuthorization();
app.MapControllers();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllerRoute(
//        name: "default",
//        pattern: "{controller=Home}/{action=Index}/{id?}");

//    endpoints.MapControllerRoute(
//        name: "DeleteSupplier",
//        pattern: "{controller=Supplier}/{action=Delete}/{id}");

//    endpoints.MapControllerRoute(
//        name: "DeleteMaterial",
//        pattern: "{controller=Material}/{action=Delete}/{id}");
//});


app.Run();
