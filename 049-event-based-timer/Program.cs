// **Concepts:** `event-driven design`, `timer`, `callback`

// * Create a custom `Timer` class that raises an event every second.
// * The subscriber prints elapsed seconds.
// * Stop after 5 ticks.

// **📝 Bonus:**
// Show how to unsubscribe from the event mid-way.

class TimeEventArgs: EventArgs
{
    public int Seconds { get; init; }

    public TimeEventArgs(int timeElipsed)
    {
        Seconds = timeElipsed;
    }
}

class Timer
{
    private int _timeElipsed = 1;
    public event EventHandler<TimeEventArgs> TimeChange;

    public void UpdateTime()
    {
        while (_timeElipsed <= 5)
        {
            Thread.Sleep(1000);
            OnTimeChange(new TimeEventArgs(_timeElipsed));
            _timeElipsed++;
        }
    }

    protected virtual void OnTimeChange(TimeEventArgs e)
    {
        TimeChange?.Invoke(this, e);
    }

}

class TimeTracker
{
    private static Timer _timer;

    public static void Manager_TimeChanged(object sender, TimeEventArgs e)
    {
        if(e.Seconds == 5)
        {
            _timer.TimeChange -= Manager_TimeChanged;
        }
        Console.WriteLine($"Time Elapsed {e.Seconds} Seconds");
    }
    
    public static void Main()
    {
        _timer = new Timer();

        // Subscribe
        _timer.TimeChange += Manager_TimeChanged;

        _timer.UpdateTime();
    }
}