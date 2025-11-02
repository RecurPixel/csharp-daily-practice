// **Concepts:** `Nullable<T>`, `HasValue`, `??`, `?.`

// **Instructions:**
// * Write a program that reads a product name and an optional discount percentage.
// * If the discount is null, assign it a default value using `??`.
// * Show the final price and demonstrate safe operations with nullables.

// 📝 **Bonus:** Combine with exception handling from Level 3 – handle invalid numeric input gracefully.



class Product
{
    public string ProductName { get; init; }
    public double ProductPrice { get; init; }
    public double? DiscountPercent { get; init; }

    public Product(string? name, double productPrice, double? discountPercent)
    {
        ProductName = name;
        ProductPrice = productPrice;
        DiscountPercent = discountPercent ?? 7.5;
    }

    public override string ToString()
    {
        double finalPrice = ProductPrice * (1 - (DiscountPercent.Value / 100.0));
    
        return $"Product Name: {ProductName}\nProduct Price: {ProductPrice:C}\nDiscount Percent: {DiscountPercent:F2}%\nFinal Discounted Price: {finalPrice:C}";
    }
}

class NullablePractice
{
    private List<Product> _productList;

    public NullablePractice()
    {
        _productList = new List<Product>();
    }

    private Product GetInput()
    {
        string pName;
        double pPrice;
        double? pDiscount;

        Console.Write("\nEnter Product Name: ");

        while (String.IsNullOrWhiteSpace(pName = Console.ReadLine()))
        {
            Console.Write("\nInvalid Input! Enter Product Name: ");
        }

        Console.Write("\nEnter Product Price: ");

        while (!double.TryParse(Console.ReadLine(), out pPrice) || pPrice < 0)
        {
            Console.Write("\nInvalid Input! Enter Product Price: ");
        }

        Console.Write("\nEnter Product Discount: ");
        pDiscount = double.TryParse(Console.ReadLine(), out double inputD) ? inputD : (double?)null;

        if (pDiscount.HasValue)
        {
            Console.WriteLine($"Discount provided! ({pDiscount.Value}%)");
        }
        else
        {
            Console.WriteLine("No discount entered. Default will be applied.");
        }

        return new Product(pName, pPrice, pDiscount);
    }
    
    private void ShowProducts()
    {
        Console.WriteLine("\nProducts Info: ");
        foreach(Product p in _productList){
            Console.WriteLine(p.ToString());
        }
    }

    public static void Main()
    {

        NullablePractice nullablePractice = new NullablePractice();

        Product p = nullablePractice.GetInput();

        nullablePractice._productList.Add(p);

        nullablePractice.ShowProducts();

    }
}