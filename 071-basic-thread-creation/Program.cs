// ### ✅ Problem 71: Basic Thread Creation

// **Concepts:** `Thread`, `ThreadStart`

// **Instructions:**
// * Write a program that creates two threads – one prints numbers 1–10, another prints letters A–J.
// * Run both simultaneously and observe the interleaved output.

// 📝 **Bonus:** Use `Thread.Sleep()` to control pacing and demonstrate scheduling differences.

class ThreadPractice
{
    public static void Main()
    {
        Thread th1 = new Thread(PrintNumbers);
        Thread th2 = new Thread(PrintLetters);

        th1.IsBackground = true;

        th1.Start();
        th2.Start();

        // th1.Join();
        // th2.Join();

        // Note: Because th2 is not background task and th1 is. The execution will only wait for th2 to complete after that it will not concern with th1

        // The code is intentionally look mismatch to show what method does what
    }

    private static void PrintNumbers()
    {
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine(i);
            Thread.Sleep(2000);
        }
    }
    private static void PrintLetters()
    {
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine(Convert.ToChar(65 + i));
            Thread.Sleep(1000);
        }
    }
}