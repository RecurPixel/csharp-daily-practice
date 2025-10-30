// ### ✅ **Problem 50: Event Notification System**

// **Concepts:** combining multiple concepts — delegates, events, lambdas, OOP

// * Design a mini **Notification System**:

//   * `Notifier` class — raises an event `OnNotify`.
//   * `EmailService`, `SMSService`, and `PushService` subscribe to it.
//   * When a notification is triggered, all subscribers respond.

// **📝 Bonus:**
// Add filtering so some services only respond to certain message types (e.g., “Alert”, “Info”, “Warning”).


using System.Linq.Expressions;

enum MessageType
{
    Alert,
    Info,
    Warning
}

class NotifyEventArgs : EventArgs
{
    public MessageType Type { get; init; }
    public string Message { get; init; }

    public NotifyEventArgs(MessageType type, string msg)
    {
        Type = type;
        Message = msg;
    }
}

class Notifier
{
    public event EventHandler<NotifyEventArgs>? Notify;

    public void SendNotification(MessageType type, string msg)
    {
        OnNotify(new NotifyEventArgs(type, msg));
    }

    protected virtual void OnNotify(NotifyEventArgs e)
    {
        Notify?.Invoke(this, e);
    }
}

class EmailService
{
    private Notifier _notifier;

    public EmailService(Notifier notifier)
    {
        _notifier = notifier;
        _notifier.Notify += OnEmailNotify;
    }
    public void OnEmailNotify(object sender, NotifyEventArgs e)
    {
        if (e.Type == MessageType.Alert)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[ALERT] Email Sent! Message: {e.Message}");
            Console.ResetColor();
        }
    }
}

class SMSService
{
    private Notifier _notifier;

    public SMSService(Notifier notifier)
    {
        _notifier = notifier;
        _notifier.Notify += OnSmsNotify;
    }
    public void OnSmsNotify(object sender, NotifyEventArgs e)
    {
        if (e.Type == MessageType.Alert || e.Type == MessageType.Warning)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"[SMS - {e.Type}] Sent SMS Notification! Message: {e.Message}");
            Console.ResetColor();
        }
    }
}

class PushService
{
    private Notifier _notifier;

    public PushService(Notifier notifier)
    {
        _notifier = notifier;
        _notifier.Notify += OnPushNotify;
    }
    public void OnPushNotify(object sender, NotifyEventArgs e)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"[Push - {e.Type}] Sent Push Notification! Message: {e.Message}");
        Console.ResetColor();
    }
}

class TestNotificationSystem
{
    public static void Main()
    {
        Notifier notifier = new Notifier();
        EmailService emailService = new EmailService(notifier);
        SMSService sMSService = new SMSService(notifier);
        PushService pushService = new PushService(notifier);

        notifier.SendNotification(MessageType.Alert, "We are about to reach Planet Rcono");
        notifier.SendNotification(MessageType.Info, "Planet Rcono is 3.2 Lights Year away");
        notifier.SendNotification(MessageType.Warning, "Some Turbulance ahead");
    }
}