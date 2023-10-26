using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication5.Models;
using WebApplication5.Models.ViewModels;

namespace WebApplication5.Controllers
{
    public class HomeController : Controller
    {

        static int userId = 1;
        static int productId = 1;
        static readonly List<Product> _products = new List<Product>();
        static readonly List<User> _users = new List<User>();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            IndexViewModel users = new IndexViewModel(_users);
            return View(users);
        }
        public IActionResult Registration()
        {
            return View();
        }
        public IActionResult AddUser(User user)
        {
            if (ModelState.IsValid && user.Age > 16)
            {
                user.Id = userId;
                _users.Add(user);
                for (int i=0; i<user.numOfProducts; i++)
                {
                    _products.Add(new Product(productId, user));
                    productId++;
                }
                userId++;
                return View("Users", new IndexViewModel(_users));
            }
            return View("Age");
        }

        public IActionResult ShowUserProducts(User user)
        {
            ProductsViewModel products = new ProductsViewModel(
                _products.Where(p=> p.User.Id == user.Id).ToList()
                );
            return View(products);

        }
        public IActionResult ChangeProducts(IFormCollection form)
        {
            string newId = form["Id"];
            string newName = form["Name"];
            string newDescription = form["Description"];

            Console.WriteLine($"{newId}, {newName}, {newDescription}");
            var newProduct = _products.FirstOrDefault(p => p.Id == int.Parse(newId));
            newProduct.Name = newName;
            newProduct.Description = newDescription;

            return View("Users", new IndexViewModel(_users));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}