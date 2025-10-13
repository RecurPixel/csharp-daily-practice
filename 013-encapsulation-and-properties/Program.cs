// * Create a `BankAccount` class with fields: `accountNumber`, `balance`.
// * Make fields **private** and expose **public properties** with validation (e.g., balance can’t be negative).
// * Add methods `Deposit()` and `Withdraw()`.

// 📝 *Bonus:* Reject invalid withdrawal attempts (e.g., withdrawing more than the balance).

class BankAccount
{
    private int accountNumber;
    private decimal balance;

    public int AccountNumber
    {
        get { return accountNumber; }
    }
    
    public decimal Balance
    {
        get { return balance; }
    }

    public BankAccount()
    {
        accountNumber = (new Random()).Next(1000000, 2000000);;
        balance = 0.0m;
    }

    public bool Deposit(decimal ammount)
    {
        if(ammount < 0.0m)
        {
            Console.WriteLine("Invalid ammount");
            return false;
        }
        balance += ammount;
        return true;
    }

    public bool Withdraw(decimal ammount)
    {
        if(ammount > balance)
        {
            Console.WriteLine("Insufficient Account Balance");
            return false;
        }
        balance -= ammount;
        return true;
    }
    public void Statement()
    {
        Console.WriteLine($"Account No: {accountNumber}");
        Console.WriteLine($"Account Balance: {balance}");
    }
    
    public static void Main(string[] args)
    {
        BankAccount customer1 = new BankAccount();

        customer1.Statement();
        customer1.Withdraw(23.22m);
        customer1.Deposit(99.3m);
        customer1.Deposit(123.4m);
        customer1.Deposit(-123.4m);
        customer1.Statement();

    }


}