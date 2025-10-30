// * Write a program that filters even numbers from a list using an anonymous method.
// * Use a delegate `FilterDelegate` that takes an integer and returns a bool.

// **📝 Bonus:**
// Display how many numbers were filtered.


class AnonymousMethodPractice
{
    // public static Predicate<int> FilterDelegate = n => n % 2 == 0;
    public static Func<int, bool> FilterDelegate = delegate (int n) { return n % 2 == 0; };


    public static void Main()
    {

        List<int> numbers = [1, 2, 3, 4, 5, 6, 7, 9];
        int filteredNumbersCount = 0;
        // foreach (int i in numbers.FindAll(AnonymousMethodPractice.FilterDelegate))
        // {
        //     Console.WriteLine(i);
        //     filteredNumbersCount++;
        // }
        // foreach (int i in numbers.Where(delegate(int n) { return n % 2 == 0; }))
        // {
        //     Console.WriteLine(i);
        //     filteredNumbersCount++;
        // }
        foreach (int i in numbers.Where(FilterDelegate))
        {
            Console.WriteLine(i);
            filteredNumbersCount++;
        }

        Console.WriteLine($"Total Numbers in List: {numbers.Count} Even Numbers in List: {filteredNumbersCount}");


    }
}


// Note: This code be solved with Func<int, bool>, or without any and just using anonymous function but I did not do that