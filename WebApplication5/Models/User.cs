namespace WebApplication5.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Password {  get; set; }

        public int numOfProducts {  get; set; }

        public User() { }
        public User(int id, string name, int age, string password, int numOfProducts)
        {
            Id = id;
            Name = name;
            Age = age;
            Password = password;
            numOfProducts = numOfProducts;
        }
    }
}
