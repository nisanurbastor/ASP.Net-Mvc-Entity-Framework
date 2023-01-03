namespace WebApp.Models
{
	public interface IProductRepository
	{

		IQueryable<Product> Products { get;}

		void CreateProduct(Product product);   // for using add data to the db 

		//Product GetById(string id);

		void UpdateProduct(Product product);  // for updating data

		void DeleteProduct(Product id);

	}
}
