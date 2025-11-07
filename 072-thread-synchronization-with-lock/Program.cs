// ### ✅ Problem 72: Thread Synchronization with Lock

// **Concepts:** `lock`, shared resource

// **Instructions:**
// * Simulate a bank account accessed by two threads performing deposits and withdrawals.
// * Use `lock` to prevent data corruption.

// 📝 **Bonus:** Show what happens when the lock is removed.


class ThreadSynchronizationPractice
{
    private static int _bankBalance = 1000;

    private static readonly object BalanceLock = new object();

    private static Random random = new Random();

    public static void Main()
    {

        Thread th1 = new Thread(Deposit);
        Thread th2 = new Thread(Withdraw);

        th1.Start();
        th2.Start();

        th1.Join();
        th2.Join();

        Console.WriteLine("Final Balance: " + _bankBalance);
    }

    private static void Deposit()
    {

        for(int i = 0; i < 10; i++)
        {
            lock (BalanceLock)
            {

                int currentBalance = _bankBalance;

                // 2. Simulate complex processing/time lag (forced context switch)
                Thread.Sleep(1);

                int amount = random.Next();
                // 3. Calculate new balance
                int newBalance = currentBalance + amount;

                // 4. Write new balance
                _bankBalance = newBalance; // THIS is where the corruption happens

                Console.WriteLine($"Current Balance: {currentBalance} + Deposit: {amount} = {currentBalance + amount}. Updated Balance: {_bankBalance}");
            }
        }

        
    }
    
    private static void Withdraw()
    {
        for(int i = 0; i < 10; i++)
        {
            lock (BalanceLock)
            {

                int currentBalance = _bankBalance;

                // 2. Simulate complex processing/time lag (forced context switch)
                Thread.Sleep(1);

                int amount = random.Next();
                // 3. Calculate new balance
                int newBalance = currentBalance - amount;

                // 4. Write new balance
                _bankBalance = newBalance; // THIS is where the corruption happens

                Console.WriteLine($"Current Balance: {currentBalance} - Withdrawal: {amount}  = {currentBalance - amount}. Updated Balance: {_bankBalance}");
            }
        }
       
    }

}