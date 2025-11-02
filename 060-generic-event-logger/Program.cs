// ### ✅ Problem 60: Generic Event Logger

// **Concepts:** `Generic Delegate`, `Event`, `Type Safety`

// **Instructions:**
// * Create a generic event-based logger:
//   * Declare a generic delegate `Logger<T>(T message)`
//   * Raise events of different types (`string`, `int`, `DateTime`)
//   * Handle events using lambda expressions

// 📝 **Bonus:** Integrate nullables and pattern matching for advanced event filtering.


class DateTimeEventArgs : EventArgs
{
    public DateTime Message { get; init; }
    public DateTimeEventArgs(DateTime dt)
    {
        Message = dt;
    }
}

class StringEventArgs : EventArgs
{
    public string Message { get; init; }

    public StringEventArgs(string s)
    {
        Message = s;
    }
}

class IntEventArgs : EventArgs
{
    public int? Message { get; init; }
    
    public IntEventArgs(int? i) 
    {
        Message = i;
    }
}

class GenericDelegate<T>
{
    public event EventHandler<T> Logger;

    public void UpdateLog(T e)
    {
        Thread.Sleep(1000); // Simulate Wait
        OnLogger(e);
    }

    public virtual void OnLogger(T e)
    {
        Logger?.Invoke(this, e);
    }
}

class TestGenericDelegate
{
    public static void Main()
    {
        GenericDelegate<IntEventArgs> gDInt = new GenericDelegate<IntEventArgs>();
        GenericDelegate<StringEventArgs> gDStr = new GenericDelegate<StringEventArgs>();
        GenericDelegate<DateTimeEventArgs> gDDT = new GenericDelegate<DateTimeEventArgs>();

        gDInt.Logger += (object sender, IntEventArgs e) =>
            {
                if (e.Message is int num and > 50) 
                {
                    // This branch executes if the number is present and large
                    Console.WriteLine($"[INT LOG - FILTERED]: Value {num} logged. (Value > 50)");
                }
                else if (e.Message is null) 
                {
                    // This branch executes if the message is explicitly null
                    Console.WriteLine("[INT LOG - NULL]: Null message received. (Defaulted to 0)");
                }
                else
                {
                    // This branch executes if the number is present but <= 50
                    Console.WriteLine($"[INT LOG - UNFILTERED]: Value {e.Message.Value} logged. (Value <= 50)");
                }
            };
        gDStr.Logger += (object sender, StringEventArgs e) => Console.WriteLine($"{e.Message}");
        gDDT.Logger += (object sender, DateTimeEventArgs e) => Console.WriteLine($"{e.Message}");


        gDInt.UpdateLog(new IntEventArgs(null));
        gDInt.UpdateLog(new IntEventArgs(10));
        gDInt.UpdateLog(new IntEventArgs(123));
        
        gDStr.UpdateLog(new StringEventArgs("OneTwoThree"));
        gDDT.UpdateLog(new DateTimeEventArgs(DateTime.Now));

    }
}