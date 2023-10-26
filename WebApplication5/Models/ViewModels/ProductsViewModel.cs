namespace WebApplication5.Models.ViewModels
{
    public class ProductsViewModel
    {
        public ProductsViewModel() { }
        public ProductsViewModel(IEnumerable<Product> products) { 
            Products= products;
        }
        public IEnumerable<Product> Products { get; set; }
        public int Id { get; set; }
    }
}
