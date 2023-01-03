using WebApp.Data;
using WebApp.Models;

namespace WebApp.Models
{
    public class ProductRepository:IProductRepository
    {
        //ıproduct ta girilenler buranın interface i olacak
        private AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<Product> Products => _context.Products;

        public void CreateProduct(Product product)
        {
            _context.Products.Add(product);  // sign product
            _context.SaveChanges();  // real registering
        }

        public void UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }

        public void DeleteProduct(Product product)
        {
            // Find the product with the matching id
            var product_ = _context.Products.Where(i=>i.ProductID == product.ProductID).FirstOrDefault();

            // Remove the product from the database
            _context.Products.Remove(product_);
            _context.SaveChanges();
        }

	}
}
