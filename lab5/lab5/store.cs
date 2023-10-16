using System;
using System.Collections.Generic;
using System.Linq;


class Product
{
    public string Name { get; set; }
    public double Price { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public double Rating { get; set; }
}


class User
{
    public string Username { get; set; }
    public string Password { get; set; }
    public List<Order> PurchaseHistory { get; set; }

    public User(string username, string password)
    {
        Username = username;
        Password = password;
        PurchaseHistory = new List<Order>();
    }
}


class Order
{
    public List<Product> Products { get; set; }
    public int Quantity { get; set; }
    public double TotalPrice { get; set; }
    public string Status { get; set; }
}


interface ISearchable
{
    List<Product> SearchByCriteria(double minPrice, double maxPrice, string category, double minRating);
}


class Store : ISearchable
{
    private List<Product> Products;
    private List<User> Users;

    public Store()
    {
        Products = new List<Product>
        {
            new Product { Name = "Product1", Price = 50, Description = "Very useful product", Category = "Food", Rating = 4.5 },
            new Product { Name = "Product2", Price = 30, Description = "Delicious product", Category = "Food", Rating = 4.0 },
            new Product { Name = "Book1", Price = 100, Description = "Interesting book", Category = "Books", Rating = 4.8 },
            new Product { Name = "Book2", Price = 80, Description = "Highly engaging book", Category = "Books", Rating = 4.2 },
        };

        Users = new List<User>
        {
            new User("user1", "password1"),
            new User("user2", "password2")
        };
    }

    public List<Product> SearchByCriteria(double minPrice, double maxPrice, string category, double minRating)
    {
        var results = from product in Products
                      where product.Price >= minPrice
                      && product.Price <= maxPrice
                      && product.Category == category
                      && product.Rating >= minRating
                      select product;

        return results.ToList();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Store store = new Store();
        double minPrice = 40;
        double maxPrice = 90;
        string category = "Food";
        double minRating = 4.0;

        List<Product> searchResults = store.SearchByCriteria(minPrice, maxPrice, category, minRating);

        Console.WriteLine($"Search results based on criteria: Price from {minPrice} to {maxPrice}, Category: {category}, Minimum Rating: {minRating}");
        foreach (var product in searchResults)
        {
            Console.WriteLine($"Name: {product.Name}, Price: {product.Price}, Rating: {product.Rating}");
        }
    }
}
