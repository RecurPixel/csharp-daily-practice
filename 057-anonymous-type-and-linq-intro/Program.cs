// ### ✅ Problem 57: Anonymous Type and LINQ Intro

// **Concepts:** `Anonymous Types`, `var`, `LINQ Select`, `Where`

// **Instructions:**
// * Create a list of products and use LINQ to project anonymous types that only include `Name` and `Price`.
// * Filter out products below a certain price threshold.

// 📝 **Bonus:** Format and print the results neatly with alignment.


class Product
{
    public int ID { get; }
    public string Name { get; }
    public double Price { get; }

    public Product(int id, string name, double price)
    {
        ID = id;
        Name = name;
        Price = price;
    }
}
class AnonymousTypePractice
{
    public static void Main()
    {
        List<Product> products = new List<Product>();
        products.Add(new Product(1, "Apple", 1.2));
        products.Add(new Product(2, "Banana", 2.2));
        products.Add(new Product(3, "Cherry", 3.2));
        products.Add(new Product(4, "Durian", 4.2));
        products.Add(new Product(5, "Elderberry", 5.2));

        var filteredProducts = products.Where(p => p.Price < 3.0).Select(p => new { Name = p.Name, Price = p.Price });

        Console.WriteLine("\n=== Filtered Product List ===\n");
        Console.WriteLine($"{"Name",-15}{"Price",10}"); // Header with padding
        Console.WriteLine("------------------------------");

        foreach (var p in filteredProducts)
        {
            // {0,-15}: Pad the Name to 15 characters, left-aligned (-)
            // {1,10:C}: Pad the Price to 10 characters, right-aligned, and format as currency (C)
            Console.WriteLine($"{p.Name,-15}{p.Price,10:C}"); 
        }
        Console.WriteLine("\n==============================");
                
    }
}