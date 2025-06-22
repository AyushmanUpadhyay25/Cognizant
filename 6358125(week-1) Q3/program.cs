using System;
using System.Collections.Generic;

public class Product
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public string Category { get; set; }

    public Product(int id, string name, string category)
    {
        ProductId = id;
        ProductName = name;
        Category = category;
    }

    public override string ToString()
    {
        return $"ID: {ProductId}, Name: {ProductName}, Category: {Category}";
    }
}

class Program
{
    
    public static Product LinearSearch(List<Product> products, string name)
    {
        foreach (var product in products)
        {
            if (product.ProductName.Equals(name, StringComparison.OrdinalIgnoreCase))
                return product;
        }
        return null;
    }

    
    public static Product BinarySearch(List<Product> products, string name)
    {
        int left = 0, right = products.Count - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            int comparison = string.Compare(products[mid].ProductName, name, StringComparison.OrdinalIgnoreCase);

            if (comparison == 0)
                return products[mid];
            else if (comparison < 0)
                left = mid + 1;
            else
                right = mid - 1;
        }

        return null;
    }

    static void Main()
    {
        List<Product> products = new List<Product>()
        {
            new Product(1, "Laptop", "Electronics"),
            new Product(2, "Shoes", "Fashion"),
            new Product(3, "Watch", "Accessories"),
            new Product(4, "Phone", "Electronics"),
            new Product(5, "Book", "Education")
        };

        Console.WriteLine("=== Linear Search ===");
        var resultLinear = LinearSearch(products, "Book");
        Console.WriteLine(resultLinear != null ? resultLinear.ToString() : "Product not found");

        Console.WriteLine("\n=== Binary Search ===");
        products.Sort((p1, p2) => string.Compare(p1.ProductName, p2.ProductName, StringComparison.OrdinalIgnoreCase));
        var resultBinary = BinarySearch(products, "Book");
        Console.WriteLine(resultBinary != null ? resultBinary.ToString() : "Product not found");
    }
}

