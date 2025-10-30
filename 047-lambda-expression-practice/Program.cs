// **Concepts:** `lambda expressions`, `Func`, `Action`, `Predicate`

// * Demonstrate all three types of built-in delegates using lambdas:

//   * `Action<string>` → Prints a message.
//   * `Func<int, int, int>` → Returns sum of two integers.
//   * `Predicate<int>` → Checks if a number is even.

// **📝 Bonus:**
// Store multiple lambdas in a list and invoke them sequentially.

class LambdaExpressionPractice
{
    public static void Main()
    {
        Action<string> PrintAMessage = msg => Console.WriteLine(msg);
        Func<int, int, int> SumOfTwoNumbers = (num1, num2) => num1 + num2;
        Predicate<int> IsEven = num => num % 2 == 0;

        PrintAMessage("Calling Action Delegate");
        int n1 = 2, n2 = 3;
        Console.WriteLine($"{n1} + {n2} = {SumOfTwoNumbers(n1, n2)}");
        Console.WriteLine($"IsEven({n1}) = {IsEven(n1)}");

        // Bonus

        List<Action> actions = [() => Console.WriteLine("First Labmda"), () => Console.WriteLine("section Lambda")];

        foreach(Action a in actions)
        {
            a();
        }
    }
}