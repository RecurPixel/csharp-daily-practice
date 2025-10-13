// * Create a class `Person` with different members using various access modifiers.
// * Try to access them from another class to observe visibility differences.

// 📝 *Bonus:* Demonstrate how `protected` works via inheritance (preview for next set).


class Person
{
    public int PublicVariable = 1;
    internal int InternalVariable = 2;
    protected int _protectedVariable = 3;
    private int _privateVariable = 4;

    public Person()
    {
        Console.WriteLine("Person constructor");
    }

    public void PublicMethod()
    {
        Console.WriteLine("Person Public Method");
        Console.WriteLine($"Person Public field: {PublicVariable}");
        Console.WriteLine($"Person internal field: {InternalVariable}");
        Console.WriteLine($"Person protected field: {_protectedVariable}");
        Console.WriteLine($"Person private field: {_privateVariable}");
                                        
    }
    protected void ProtectedMethod()
    {
        Console.WriteLine("Person Protected Method");
        Console.WriteLine($"Person Public field: {PublicVariable}");
        Console.WriteLine($"Person internal field: {InternalVariable}");
        Console.WriteLine($"Person protected field: {_protectedVariable}");
        Console.WriteLine($"Person private field: {_privateVariable}");
    }
    internal void InternalMethod()
    {
        Console.WriteLine("Person Internal Method");
        Console.WriteLine($"Person Public field: {PublicVariable}");
        Console.WriteLine($"Person internal field: {InternalVariable}");
        Console.WriteLine($"Person protected field: {_protectedVariable}");
        Console.WriteLine($"Person private field: {_privateVariable}");
    }
    private void PrivateMethod()
    {
        Console.WriteLine("Person Private Method");
        Console.WriteLine($"Person Public field: {PublicVariable}");
        Console.WriteLine($"Person internal field: {InternalVariable}");
        Console.WriteLine($"Person protected field: {_protectedVariable}");
        Console.WriteLine($"Person private field: {_privateVariable}");
    }
}

class GoodPerson : Person
{
    public static void Main(string[] args)
    {
        GoodPerson gp = new GoodPerson();

        gp.PublicMethod();
        gp.InternalMethod();
        gp.ProtectedMethod();
        // gp.PrivateMethod(); inaccessable

        Console.WriteLine(gp.PublicVariable);
        Console.WriteLine(gp.InternalVariable);
        Console.WriteLine(gp._protectedVariable);
        // Console.WriteLine(gp._privateVariable); inaccessable
    }
}


// // Note:
// public -> accessable everywhare
// internal -> accessable everywhare inside same assembly
// protected -> accessable inside the class and any chield class
// private -> accessable only inside the main class
// private protected -> private(outside the assembly) protected(inside the assembly)
// protected internal -> protected(outside the assembly) internal(inside the assembly)