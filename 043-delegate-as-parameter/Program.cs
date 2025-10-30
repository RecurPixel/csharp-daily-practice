// **Concepts:** passing delegates, flexible callbacks

// * Create a function `ProcessNumbers(List<int> numbers, Delegate operation)` that applies an operation to each number.
// * Pass different delegate methods for operations like doubling, squaring, or negating.

// **📝 Bonus:**
// Show how to use anonymous methods instead of named methods.


class DelegateAsParameter
{
    public delegate void Operation(int number);

    public static void ProcessNumbers(List<int> numbers, Operation operation)
    {
        foreach (int i in numbers)
        {
            operation.Invoke(i);
        }
    }

    public static void Main()
    {
        List<int> numbers = [1, 2, 3, 4];

        Console.WriteLine("Doubling Operation: ");
        // DelegateAsParameter.ProcessNumbers(numbers, delegate (int number)
        // {
        //     Console.WriteLine($"Doubled Number {number} is {number * 2}");
        // });

        DelegateAsParameter.ProcessNumbers(numbers, number =>
        {
            Console.WriteLine($"Doubled Number {number} is {number * 2}");
        });

        Console.WriteLine("Squaring Operation: ");
        // DelegateAsParameter.ProcessNumbers(numbers, delegate (int number)
        // {
        //     Console.WriteLine($"Squared Number {number} is {number * number}");
        // });

        DelegateAsParameter.ProcessNumbers(numbers, number =>
        {
            Console.WriteLine($"Squared Number {number} is {number * number}");
        });

        Console.WriteLine("Negating Operation: ");
        // DelegateAsParameter.ProcessNumbers(numbers, delegate (int number)
        // {
        //     Console.WriteLine($"Negated Number {number} is {-number}");
        // });
        DelegateAsParameter.ProcessNumbers(numbers, number =>
        {
            Console.WriteLine($"Negated Number {number} is {-number}");
        });

    }
}