using WebApp.Data;

namespace WebApp.Models
{
    public class Product
    {
        public string ProductID { get; set; }
        public string? Color { get; set; }
        public string? Brand { get; set; }
        public string? Shape { get; set; }
        public string? Price { get; set; }
        public string? PictureURl { get; set; }

        public int? CategoryID { get; set; }
    }
}
