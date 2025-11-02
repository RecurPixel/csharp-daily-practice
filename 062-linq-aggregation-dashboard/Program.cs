// ### ✅ Problem 62: LINQ Aggregation Dashboard

// **Concepts:** `LINQ`, `Sum`, `Average`, `GroupBy`, `Count`

// **Instructions:**
// * Given a collection of sales records (product name, units sold, revenue), compute:
//   * Total revenue
//   * Average sale per product
//   * Highest-selling item

// 📝 **Bonus:** Handle potential division by zero or empty data using `DefaultIfEmpty()`.


class Product
{
    public string Name { get; init; }
    public int UnitSold { get; init; }
    public double Revenue { get; init; }

    public Product(string name, int unitSold, double revenue)
    {
        Name = name;
        UnitSold = unitSold;
        Revenue = revenue;
    }
}


class LINQAggregationDashboard
{
    public static void Main()
    {
        List<Product> salesRecord = new List<Product>();

        salesRecord.Add(new Product("Apple Iphone", 1, 70000));
        salesRecord.Add(new Product("POLO Shirt", 2, 10000));
        salesRecord.Add(new Product("Samsung S22", 3, 69000));
        salesRecord.Add(new Product("Noodles", 4, 80));
        salesRecord.Add(new Product("Beer", 5, 120));
        salesRecord.Add(new Product("Denim", 6, 1200));
        salesRecord.Add(new Product("Apple Iphone", 1, 70000));
        salesRecord.Add(new Product("POLO Shirt", 2, 10000));
        salesRecord.Add(new Product("Samsung S22", 3, 69000));
        salesRecord.Add(new Product("Noodles", 4, 80));
        salesRecord.Add(new Product("Beer", 5, 120));
        salesRecord.Add(new Product("Denim", 6, 1200));
        salesRecord.Add(new Product("Apple Iphone", 11, 70000));
        salesRecord.Add(new Product("POLO Shirt", 1, 10000));
        salesRecord.Add(new Product("Samsung S22", 6, 69000));
        salesRecord.Add(new Product("Noodles", 9, 80));
        salesRecord.Add(new Product("Beer", 1, 120));
        salesRecord.Add(new Product("Denim", 2, 1200));

        var revenue = salesRecord.Sum(product => product.Revenue);
        Console.WriteLine($"\nTotal Revenue: {revenue,10:C}");


        Console.WriteLine("\n---Average Sales Per Product---\n");
        var averageSalesPerProduct = salesRecord.GroupBy(product => product.Name).Select(g => new { Name = g.Key, AverageSales = g.Average(s => (double?)s.UnitSold) ?? 0.0 });

        Console.WriteLine($"{"Name",-15}{"Average Sales Per Order",15}");
        foreach(var p in averageSalesPerProduct)
        {
            Console.WriteLine($"{p.Name,-15}{p.AverageSales,15:F2}");
        }


        Console.WriteLine("\n---Highest Selling Item Data---\n");
        var highestSelligItem = salesRecord.GroupBy(product => product.Name).Select(g => new { Name = g.Key, TotalUnitSold = g.Sum(s => s.UnitSold), TotalRevenue = g.Sum(s => s.Revenue) }).OrderByDescending(p => p.TotalUnitSold).FirstOrDefault();
        
        if(highestSelligItem != null)
        {
            Console.WriteLine($"Highest Selling Product: {highestSelligItem.Name}");
            Console.WriteLine($"Total Revenue: {highestSelligItem.TotalUnitSold}");
            Console.WriteLine($"Total Revenue: {highestSelligItem.TotalRevenue:C}");
        }
        else
        {
            Console.WriteLine("No sales data available.");
        }

    }
}