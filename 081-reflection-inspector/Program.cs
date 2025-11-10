// ### ✅ Problem 81: Reflection Inspector

// **Concepts:** `Reflection`, `System.Type`, `Assembly`

// **Instructions:**
// * Create a program that accepts a class name as input and prints all its methods, properties, and fields using reflection.
// * Test with your previous classes.

// 📝 **Bonus:** Print custom attribute details if any are found.

using System.Reflection;
using System.Text.RegularExpressions;
using StudentRecords;


class ReflectionPractice
{
    public static void Main()
    {

        BindingFlags flags = BindingFlags.Public |
                     BindingFlags.Instance |
                     BindingFlags.DeclaredOnly;


        Console.Write("\nEnter Class Name: ");
        var classNameToFind = Console.ReadLine()?.Trim();

        if (String.IsNullOrEmpty(classNameToFind) || !Regex.IsMatch(classNameToFind, @"^[a-zA-Z_][a-zA-Z0-9_]*$"))
        {
            Console.WriteLine("Invalid Class Name. Try Again.");
            return;

        }


        // Begin: AI generated code for reference and understanding

        Type foundType = null;
        List<Assembly> loadedAssemblies = new List<Assembly>();

        const string SearchRootPath = @"..\";
        const string StandardBinPathSegment = @"bin\Debug";
        const string TargetFrameworkFolder = @"net9.0";
        const string DllFilter = @"*.dll";

        string rootDir = Path.GetFullPath(SearchRootPath);

        Console.WriteLine($"\nSearching for '{classNameToFind}' in all projects under: {rootDir}\n");

        const string RelativeDllPath = @"bin\Debug\net9.0";

        string[] projectDirectories = Directory.GetDirectories(rootDir);


        List<string> assemblyFiles = new List<string>(); // Use a List to dynamically collect paths

        string assemblyPath = Assembly.GetExecutingAssembly().Location;
        string currentAssemblyFolder = Path.GetDirectoryName(assemblyPath);

        // 1. Iterate through each discovered project folder
        foreach (string projectDir in projectDirectories)
        {
            // Skip the current project's folder to avoid unnecessary checking (optional but recommended)
            if (Path.GetFileName(projectDir).Equals(currentAssemblyFolder, StringComparison.OrdinalIgnoreCase))
                continue;

            // 2. Construct the absolute, specific directory path to the DLL location
            // Example: C:\...\csharp-daily-practice\proj1\bin\Debug\net9.0
            string finalSearchPath = Path.Combine(projectDir, RelativeDllPath);

            // 3. Check if the target build directory exists before searching
            if (Directory.Exists(finalSearchPath))
            {
                try
                {
                    // 4. Perform a simple, non-recursive file search using ONLY the file wildcard
                    string[] foundDlls = Directory.GetFiles(
                        path: finalSearchPath,
                        searchPattern: DllFilter, // e.g., "*.dll"
                        searchOption: SearchOption.TopDirectoryOnly
                    );

                    // Add all found DLLs to the collection list
                    assemblyFiles.AddRange(foundDlls);
                }
                catch (Exception ex)
                {
                    // Handle access issues for a specific folder gracefully
                    Console.WriteLine($"⚠️ Error searching {finalSearchPath}: {ex.Message}");
                }
            }
        }

        // Convert the List back to an array if you need the final result as a string[]
        string[] finalAssemblyFiles = assemblyFiles.ToArray();


        foreach (string file in finalAssemblyFiles)
        {
            // Skip the current project's own DLL, if it happens to be in the list
            // if (Path.GetFileNameWithoutExtension(file) == Assembly.GetExecutingAssembly().GetName().Name)
            //     continue;

            try
            {
                // Load the external assembly
                Assembly assembly = Assembly.LoadFrom(file);
                loadedAssemblies.Add(assembly);

                // 2. Search for the Type within the loaded Assembly
                // Iterate through all types to handle cases where there is no explicit namespace
                foundType = assembly.GetTypes()
                                    .FirstOrDefault(t => t.Name.Equals(classNameToFind, StringComparison.Ordinal));

                if (foundType != null)
                {
                    Console.WriteLine($"\n✅ **FOUND** '{classNameToFind}' in Assembly: {assembly.GetName().Name}");
                    Console.WriteLine($"   - Full Type Name: {foundType.FullName}");

                    break; // Stop searching once the class is found
                }
            }
            catch (BadImageFormatException)
            {
                // Ignore files that aren't valid .NET assemblies (e.g., unmanaged DLLs)
            }
            catch (Exception ex)
            {
                // Handle other loading errors
                Console.WriteLine($"⚠️ Could not load {Path.GetFileName(file)}: {ex.Message}");
            }
        }
        if (foundType == null)
        {
            Console.WriteLine($"\n❌ **NOT FOUND**: Class '{classNameToFind}' was not found in any sibling project assembly.");
        }

        // End: AI generated code for reference and understanding

        Type info = foundType;

        Console.WriteLine("Properties:");
        foreach (var prop in info.GetProperties(flags))
        {
            Console.WriteLine(prop.Name);
        }

        Console.WriteLine("Constructor:");
        foreach (var prop in info.GetConstructors(flags))
        {
            Console.WriteLine($"Public: {prop.IsPublic} Private: {prop.IsPrivate}");
        }

        Console.WriteLine("Methods:");
        foreach (var prop in info.GetMethods(flags))
        {
            Console.WriteLine($"    >Method Name: {prop.Name}");
            foreach (var param in prop.GetParameters())
            {
                Console.WriteLine($"        >Parameter Name: {param.Name}");
            }
        }

        Console.WriteLine("Fields:");
        foreach (var prop in info.GetFields())
        {
            Console.WriteLine($"    >Method Name: {prop.Name}, Field Type: {prop.FieldType.Name}");
        }

        Console.WriteLine("Custom Attributes:");
        foreach (Object attributes in info.GetCustomAttributes(true))
        {
            TestInfo ti = attributes as TestInfo;

            if (null != ti)
            {
                Console.WriteLine("Test Id: {0}", ti.TestInfoId);
                Console.WriteLine("Test Name: {0}", ti.TestInfoName);
                Console.WriteLine("Test Valid: {0}", ti.IsTestValid);
                Console.WriteLine("\n----\n");
            }
        }

    }
}




// Note: The code is getting very complex. It is not worth spending more thime on it.
// There are many thing we can do with it. Like, instead of just finding only one Calss we can find all of them.
// We can Seperate concerns and make code more moduler.
// We can improve readiblity of code
// Make is more robust. and we can go on. 
// As this is just practice we will stop here.