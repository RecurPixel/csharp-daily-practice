// ### ✅ Problem 82: Custom Attribute and Reflection

// **Concepts:** `Attributes`, `Reflection`, `Metadata`

// **Instructions:**
// * Create a custom attribute `[Developer("name", version)]`.
// * Apply it to multiple classes.
// * Use reflection to list all classes and their developer info.

// 📝 **Bonus:** Filter and display only classes developed by a specific author.

using static System.Attribute;
using System.Reflection;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
class Developer : Attribute
{
    public string Name { get; init; }
    public double Version { get; init; }
    public Developer(string name, double version)
    {
        Name = name;
        Version = version;
    }
}

[Developer("Arthor", 1.0)]
[Developer("Alice", 1.1)] // Example of multiple attributes
class Class1
{
}

[Developer("Alex", 2.0)]
class Class2
{
}

[Developer("Adam", 3.0)]
class Class3
{
}

[Developer("Arthor", 4.0)] // Another class by Arthor
class Class4
{
}


class CustomAttributePractice
{
    public static void Main()
    {
        Assembly currentAssembly = Assembly.GetExecutingAssembly();

        Type[] allTypes = currentAssembly.GetTypes();

        var classesWithDevInfo = allTypes.Where(t =>
                                    t.IsClass &&
                                    !t.IsAbstract &&
                                    Attribute.IsDefined(t, typeof(Developer)));

        string specificAuthor = "Alex";

        var classesBySpecificAuthor = allTypes.Where(t =>
                                    t.IsClass &&
                                    !t.IsAbstract &&
                                    t.GetCustomAttributes(typeof(Developer), false) // 1. Get all Developer attributes
                                    .Cast<Developer>()                             // 2. Cast them to the Developer type
                                    .Any(d => d.Name == specificAuthor));          // 3. Check if any has the specific author's name



        // Note: 
        // Get all types(class/interface/property/method/etc)
        // chekc if it has required attribute using Attribute.IsDefined(t, type(Dev))
        // if you want type with with specific attribute data. simple get all attributes on that type, First caste it as now it is considered of type object. then Run LINQ query or something.
        // the confusion steams from thinking. When you say attribute you internally think of properties/fields but here Attribute is a class that is attached to the specific type and we are get trying to related data from it.
        

        PrintClassAndAttributre(classesWithDevInfo, "All Classes with Developer Attributes");

        PrintClassAndAttributre(classesBySpecificAuthor, $"All clases by specific Author: {specificAuthor}");
    }
    
    private static void PrintClassAndAttributre(IEnumerable<Type> data, string title)
    {
        Console.WriteLine($"\n{title}\n");
        foreach (var type in data)
        {
            Console.WriteLine($"\nClass: {type.Name}");

            var devAttributes = type.GetCustomAttributes(typeof(Developer), false);

            // If there is only single use per class of the Custom Attribute. The we will not need below loop
            // This is actual confusion point as I tried to acces Properties by converting the list directly

            foreach (var attr in devAttributes)
            {
                // Cast the generic Attribute object back to our specific Developer type
                Developer developerInfo = (Developer)attr;
                Console.WriteLine($"  -> Developer: {developerInfo.Name}, Version: {developerInfo.Version:F1}");
            }


        }
    }
}