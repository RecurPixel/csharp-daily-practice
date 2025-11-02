// ### ✅ Problem 61: Filtering and Sorting Products with LINQ

// **Concepts:** `LINQ`, `Where`, `OrderBy`, `Select`

// **Instructions:**
// * Create a list of products (name, category, price).
// * Use LINQ to:
//   * Filter products above a certain price
//   * Sort them by category, then by price

// 📝 **Bonus:** Group products by category and print summaries.


enum Categories
{
    Fashion,
    Electronic,
    Essentials
}

class Product
{
    public string Name { get; init; }
    public Categories Category { get; init; }
    public double Price { get; init; }

    public Product(string name, Categories category, double price)
    {
        Name = name;
        Category = category;
        Price = price;
    }

    public override string ToString()
    {
        return $"{Name,-15}{Price,15:C}";
    }
}

class PracticeLINQ
{
    public static void Main()
    {
        List<Product> products = new List<Product>();

        products.Add(new Product("Apple Iphone", Categories.Electronic, 70000));
        products.Add(new Product("POLO Shirt", Categories.Fashion, 10000));
        products.Add(new Product("Samsung S22", Categories.Electronic, 69000));
        products.Add(new Product("Noodles", Categories.Essentials, 80));
        products.Add(new Product("Beer", Categories.Essentials, 120));
        products.Add(new Product("Denim", Categories.Fashion, 1200));


        var filteredProducts = products.Where(product => product.Price > 10000).OrderBy(product => product.Category).ThenBy(product => product.Price);

        Console.WriteLine("\n----Products Obove 10,000. Ordered By Category---\n");
        Console.WriteLine($"{"Name",-15}{"Price",15}");
        foreach (Product p in filteredProducts)
        {
            Console.WriteLine(p.ToString());
        }


        var groupedProducts = products.GroupBy(product => product.Category);

        Console.WriteLine("\n----Products Grouped By Category---\n");
        Console.WriteLine($"{"Name",-15}{"Price",15}");
        
        foreach (var group in groupedProducts)
        {
            Console.WriteLine($"Category: {group.Key}");
            foreach (var product in group)
            {
                Console.WriteLine(product.ToString());
            }
            Console.WriteLine();
        }
    }
}