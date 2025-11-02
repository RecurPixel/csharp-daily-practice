// ### ✅ Problem 56: Extension Method Playground

// **Concepts:** `Extension Methods`, `this` keyword, `String` manipulation

// **Instructions:**
// * Write an extension method `ToTitleCase(this string str)` that capitalizes the first letter of each word.
// * Demonstrate by applying it to a list of names entered by the user.

// 📝 **Bonus:** Chain multiple extension methods (like `ToTitleCase()` + `TrimAll()`) for practice.


public static class ExtendString
{
    public static string ToTitleCase(this string str)
    {
        if (string.IsNullOrWhiteSpace(str)) return str;

        string[] strArr = str.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        
        return String.Join(" ", strArr.Select(s => char.ToUpper(s[0]) + s.Substring(1).ToLower()));
    }
    
    public static string TrimAll(this string str)
    {
        string[] strArr = str.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        return String.Join(null, strArr);
    }
}

class ExtensionPlayground
{

    public static void Main()
    {
        Console.WriteLine("Enter a list of names/words (e.g., john doe alice smith):");
        string input = Console.ReadLine();
        
        // Demonstrate Chaining and Title Casing
        Console.WriteLine($"Original: '{input}'");
        Console.WriteLine($"Title Cased: '{input.ToTitleCase()}'");
        Console.WriteLine($"Title Cased & Trimmed: '{input.ToTitleCase().TrimAll()}'");
        
    }
}

