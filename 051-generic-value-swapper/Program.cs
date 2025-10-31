// **Concepts:** `Generic Method`, `Type Parameter`, `Constraints`

// **Instructions:**
// * Create a generic method `Swap<T>(ref T a, ref T b)` that swaps two variables of any type.
// * Demonstrate its use with integers, strings, and custom objects.

// 📝 **Bonus:** Add type constraints (e.g., `where T : struct`) and handle nullables gracefully using `?.` and `??`.



class CustomClass
{
    public string CustomProp { get; }

    public CustomClass(string str)
    {
        CustomProp = str;
    }
}

class GenericValueSwapper
{
    public static void Swap<T>(ref T a, ref T b) where T : struct
    {
        T temp;
        temp = a;
        a = b;
        b = temp;
    }
    
    public static void SwapStruct<T> (ref T a, ref T b)
    {
        // The standard swap logic works perfectly here
        T temp;
        temp = a;
        a = b;
        b = temp;
    }

    public static void Main()
    {
        int intA = 5;
        int intB = 3;

        Console.WriteLine($"\nBefore Swap {intA} , {intB}");
        
        Swap<int>(ref intA, ref intB);

        Console.WriteLine($"After Swap {intA} , {intB}");


        int? intANullable = 5;
        int? intBNullable = 3;

        Console.WriteLine($"\nBefore Swap Nullable int {intANullable} , {intBNullable}");
        
        SwapStruct<int?>(ref intANullable, ref intBNullable);

        Console.WriteLine($"After Swap Nullable int {intANullable} , {intBNullable}");
        

        char charA = 'a';
        char charB = 'b';

        Console.WriteLine($"\nBefore Swap {charA} , {charB}");

        Swap<char>(ref charA, ref charB);

        Console.WriteLine($"After Swap {charA} , {charB}");

        string stringA = "Hello" ?? "Default Value A";;
        string stringB = "World" ?? "Default Value B";;

        Console.WriteLine($"\nBefore Swap {stringA} , {stringB}");

        SwapStruct<string>(ref stringA, ref stringB);

        Console.WriteLine($"After Swap {stringA} , {stringB}");

        CustomClass customClassObjectA = new CustomClass("Object A");
        CustomClass customClassObjectB = new CustomClass("Object B");

        Console.WriteLine($"\nBefore Swap {customClassObjectA.CustomProp} , {customClassObjectB.CustomProp}");

        SwapStruct<CustomClass>(ref customClassObjectA, ref customClassObjectB);

        Console.WriteLine($"After Swap {customClassObjectA.CustomProp} , {customClassObjectB.CustomProp}");
    }
}