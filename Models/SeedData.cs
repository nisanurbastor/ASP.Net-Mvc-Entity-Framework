using Microsoft.EntityFrameworkCore;
using WebApp.Data;


namespace WebApp.Models
{
	public class SeedData
    {
        public static void Seed(IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            AppDbContext con = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            con.Database.Migrate();
            if (!con.Products.Any())
            {
                con.Products.AddRange(new List<Product>()
                {
                    new Product() {
                        ProductID = "HUM30",
                        Brand = "Fender",
                        Price = "999",
                        Color = "Sunburst",
                        Shape="C"
                    },
                    new Product() {
                        ProductID = "HUM41",
                        Brand = "Fender",
                        Price = "999",
                        Color = "Vintage White",
                        Shape = "C"
                    },
                    new Product() {
                        ProductID = "JS32",
                        Brand = "Jackson",
                        Price = "999",
                        Color = "Black",
                        Shape = "V"
                    },
                    new Product() {
                        ProductID = "JS32T",
                        Brand = "Jackson",
                        Price = "999",
                        Color = "Red",
                        Shape = "V"
                    },
                    new Product() {
                        ProductID = "KVXMG",
                        Brand = "Jackson",
                        Price = "999",
                        Color = "White",
                        Shape = "V"
                    }
                });
                con.SaveChanges();
            }
        }
    }
}
