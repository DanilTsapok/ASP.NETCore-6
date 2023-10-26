namespace WebApplication5.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public User User { get; set; }
        public Product(int id, User user)
        {
            Id = id;
            Description = null;
            Name = null;
            User = user;
        }
        public Product(int id, User user, string description, string name) { 
            Id = id;
            User = user;
            Description = description;
            Name = name;
        }
    }
}
