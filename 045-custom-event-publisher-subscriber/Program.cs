// **Concepts:** `custom event`, `event keyword`, `EventArgs`

// * Build a simple event system for a “Stock Price Tracker.”
// * `Stock` class raises an event when the price changes.
// * `Investor` class subscribes and prints a message when notified.

// **📝 Bonus:**
// Include old and new price values in the event arguments.


class PriceEventArgs: EventArgs
{
    public double CurrentPrice { get; init; }
    public double OldPrice { get; init; }

    public PriceEventArgs(double oldPrice ,double newPrice)
    {
        OldPrice = oldPrice;
        CurrentPrice = newPrice;

    }
}

class Stock
{
    private double _price;
    public event EventHandler<PriceEventArgs> PriceChange;

    public void UpdatePrice(double newPrice)
    {
        double oldPrice = _price;
         _price = newPrice;
        OnPriceChange(new PriceEventArgs(oldPrice, newPrice));

    }
    
    protected virtual void OnPriceChange(PriceEventArgs e)
    {
        PriceChange?.Invoke(this, e);
    }

}

class Investor
{
    public static void Manager_PriceChanged(object sender, PriceEventArgs e)
    {
        Console.WriteLine($"Price Changed\nOld Price: {e.OldPrice.ToString("F4")} | New Price: {e.CurrentPrice.ToString("F4")}");
    }

    public static void Main()
    {
        Stock stock = new Stock();

        stock.PriceChange += Manager_PriceChanged;

        Random random = new Random();
        for (int i = 0; i < 10; i++)
        {
            stock.UpdatePrice(random.NextDouble() * 10);
            Thread.Sleep(i * 100);
        }

    }
    
}