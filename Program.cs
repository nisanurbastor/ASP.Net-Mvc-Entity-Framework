using WebApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using System.Configuration;
using WebApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddMvc();

builder.Services.AddMvc(options => options.EnableEndpointRouting = false);

//IServiceCollection serviceCollection = builder.Services.AddTransient<IProductRepository, ProductRepository>();

IServiceCollection serviceCollection = builder.Services.AddTransient<IProductRepository, ProductRepository>();


//var configuration = new ConfigurationBuilder()
//                .SetBasePath(Directory.GetCurrentDirectory())
//                .AddJsonFile("appsettings1.json")
//                .Build();

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetSection(key: "ConnectionStrings:DefaultConnection").Value));

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

  SeedData.Seed(app);



app.UseHttpsRedirection();
app.UseStaticFiles();

//app.UseStaticFiles(new StaticFileOptions
//{
//    FileProvider = new PhysicalFileProvider(
//        Path.Combine(builder.Environment.ContentRootPath, "node_modules")),
//    RequestPath = "/modules"
//});

app.UseStatusCodePages();

app.UseRouting();

app.UseAuthorization();




app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.UseSession();

app.MapRazorPages();
app.MapDefaultControllerRoute();
app.Run();
