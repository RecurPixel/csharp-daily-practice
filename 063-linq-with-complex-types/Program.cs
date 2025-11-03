// ### ✅ Problem 63: LINQ with Complex Types

// **Concepts:** LINQ with nested objects

// **Instructions:**
// * Create classes `Customer` and `Order`. Each customer has multiple orders.
// * Use LINQ to:
//   * List all customers with total order amounts
//   * Find the top spender
//   * Display orders above a certain amount

// 📝 **Bonus:** Format output in table-like alignment.

using System.Text.RegularExpressions;

class Order
{
    public int OrderId { get; init; }
    public string OrderName { get; init; }
    public double OrderAmount { get; init; }

    public Order(int orderId, string orderName, double orderAmount)
    {
        OrderId = orderId;
        OrderName = orderName;
        OrderAmount = orderAmount;
    }

    public override string ToString()
    {
        return $"Name:{OrderName,-15}Id: {OrderId,15} Amount: {OrderAmount,30:F2}";
    }
}

class Customer
{
    public int CustomerId { get; init; }
    public string CustomerName { get; init; }
    public List<Order> OrderList;

    public Customer(int customerId, string customerName)
    {
        CustomerId = customerId;
        CustomerName = customerName;
        OrderList = new List<Order>();
    }

    public override string ToString()
    {
        return $"\nName:{CustomerName,-15} Id: {CustomerId,15}\n";
    }
}


class AdvanceLINQPractice
{

    private List<Customer> _customerRecords;

    private int _orderId = 1000001;
    private int _customerId = 1001;

    public AdvanceLINQPractice()
    {
        _customerRecords = new List<Customer>();
    }

    public Customer NewCustomer()
    {
        var cID = _customerId++;
        var customer =  new Customer(cID, "Customer_" + cID);
        _customerRecords.Add(customer);
        Console.WriteLine($"New Customer Added CustomerID: {cID}");
        return customer;
    }

    public Order NewOrder(Customer customer)
    {
        var oID = _orderId++;
        Random r = new Random();
        var order = new Order(oID, "Order_" + oID, r.NextDouble() * 100);
        customer.OrderList.Add(order);

        Console.WriteLine($"New Order Added OrderID: {oID}");
        return order;
    }

    public static void Main()
    {
        AdvanceLINQPractice customerManager = new AdvanceLINQPractice();

        Random r = new Random();

        Customer customer;
        for (int i = 0; i < r.Next(20); i++)
        {
            customer = customerManager.NewCustomer();

            for (int j = 0; j < r.Next(20); j++)
            {
                customerManager.NewOrder(customer);
            }

        }

        Console.WriteLine("----Current Records----");
        foreach (Customer c in customerManager._customerRecords)
        {
            Console.WriteLine(c.ToString());
            foreach (Order o in c.OrderList)
            {
                Console.WriteLine(o.ToString());
            }
        }

        var customerWithOrderAmount = customerManager._customerRecords.Select(c => new { CustomerId = c.CustomerId, CustomerName = c.CustomerName, TotalOrderAmount = c.OrderList.Sum(o => o.OrderAmount) });

        Console.WriteLine("\n---Customer Total Order Amount Records\n");
        Console.WriteLine($"\n{"Customer ID",-15}{"Customer Name",15}{"Total Amount",30}");
        foreach (var c in customerWithOrderAmount)
        {
            Console.WriteLine($"{c.CustomerId,-15} {c.CustomerName,15} {c.TotalOrderAmount,30:C}");
        }

        var HighestSpender = customerWithOrderAmount.MaxBy(c => c.TotalOrderAmount);
        Console.WriteLine("\n---Highest Spender\n");
        Console.WriteLine($"{"Customer ID",-15}{"Customer Name",15}{"Total Amount",30}");
        Console.WriteLine($"{HighestSpender.CustomerId,-15} {HighestSpender.CustomerName,15} {HighestSpender.TotalOrderAmount,30:C}");



        var OrderAbouveHundred = customerManager._customerRecords.SelectMany(c => c.OrderList.Where(o => o.OrderAmount > 50));
        Console.WriteLine("\n--Orders Above 50\n");
        Console.WriteLine($"\n{"Order ID",-15}{"Order Name",15}{"Order Amount",30}");
        foreach (var o in OrderAbouveHundred)
        {
            Console.WriteLine($"{o.OrderId,-15} {o.OrderName,15} {o.OrderAmount,30:C}");
        }

    }
}