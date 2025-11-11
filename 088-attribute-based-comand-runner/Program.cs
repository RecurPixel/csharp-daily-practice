// ### ✅ Problem 88: Attribute-Based Command Runner

// **Concepts:** `Attributes`, `Reflection`, `Dynamic Invocation`

// **Instructions:**
// * Define a `[Command("name")]` attribute for methods.
// * Build a console app that lists available commands and executes them when user types the command name.

// 📝 **Bonus:** Support command parameters dynamically.



using System.Reflection;

[AttributeUsage(AttributeTargets.Method)]
class CommandAttribute : Attribute
{
    public string Name { get; init; }
    public string Discription { get; set; }

    public CommandAttribute(string name)
    {
        Name = name;
    }

}

[AttributeUsage(AttributeTargets.Parameter)]
public class OptionAttribute : Attribute
{
    public string Name { get; }
    public string Description { get; }
    public bool Required { get; }

    public OptionAttribute(string name, string description, bool required = false)
    {
        Name = name;
        Description = description;
        Required = required;
    }
}


class CommandLineProcessor
{
    [Command("Version", Discription = "Gives version of the application.")]
    public static void Version()
    {
        Console.WriteLine("Version 0.1.1");
    }

    [Command("Add", Discription = "Gives Addition of 2 numbers.")]
    public static void Add([Option("op1", "operand 1.", true)] int op1, [Option("op2", "operand 2.", true)] int op2)
    {
        Console.WriteLine($"{op1} + {op2} = {op1 + op2}");
    }

    [Command("Subtract", Discription = "Gives Subtraction of 2 numbers.")]
    public static void Subtract([Option("op1", "operand 1.", true)] int op1, [Option("op2", "operand 2.", true)] int op2)
    {
        Console.WriteLine($"{op1} - {op2} = {op1 - op2}");
    }

    public static void Main(string[] args)
    {

        if (args.Length == 0)
        {
            Console.WriteLine("Please specify a command.");
            return;
        }

        string methodName = args[0];

        var commandType = typeof(CommandLineProcessor);

        var method = commandType.GetMethods()
                    .FirstOrDefault(m => m.IsDefined(typeof(CommandAttribute), false) &&
                        m.GetCustomAttribute<CommandAttribute>()?.Name.Equals(methodName, StringComparison.OrdinalIgnoreCase) == true);


        if (method != null)
        {
            var parameters = method.GetParameters();
            var methodArgs = new object[parameters.Length];

            for (int i = 0; i < parameters.Length; i++)
            {
                var param = parameters[i];
                var optionAttr = param.GetCustomAttribute<OptionAttribute>();

                if (optionAttr != null)
                {
                    string optionValue = null;
                    // Basic argument parsing (e.g., --name value)
                    for (int j = 1; j < args.Length; j++)
                    {
                        if (args[j].StartsWith($"--{optionAttr.Name}", StringComparison.OrdinalIgnoreCase))
                        {
                            if (j + 1 < args.Length)
                            {
                                optionValue = args[j + 1];
                                break;
                            }
                        }
                    }

                    if (optionAttr.Required && string.IsNullOrEmpty(optionValue))
                    {
                        Console.WriteLine($"Error: Option '--{optionAttr.Name}' is required.");
                        return;
                    }
                    if (!int.TryParse(optionValue, out var methodArgTemp))
                    {
                        Console.WriteLine($"Error: Option '--{optionAttr.Name}' is invalid type.");
                        return;
                    }
                    methodArgs[i] = methodArgTemp;
                }
            }

            method.Invoke(null, methodArgs);
        }
        else
        {
            Console.WriteLine($"Unknown command '{methodName}' .");
        }
    }
}




// Note: This is basic implementaion which took lot of efforst and research.
// Improvements.
// Generic, stadardized parameter passing, Single command parser for multiple Command classes, instance based invocation.
// though current implementaion is enough. Above points need to be practiced. skipping for now.