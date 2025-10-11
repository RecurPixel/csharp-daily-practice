// Simple Calculator

Console.WriteLine("Enter First Num:");
string input = Console.ReadLine();
float num1;

if(!float.TryParse(input, out num1))
{
    Console.WriteLine("Enter Valid number!");
    Environment.Exit(1);
}


Console.WriteLine("Enter Second Num:");

input = Console.ReadLine();
float num2;

if(!float.TryParse(input, out num2))
{
    Console.WriteLine("Enter Valid number!");
    Environment.Exit(1);
}

Console.WriteLine("Enter One Operation [+, -, /, *, %]:");
string op = Console.ReadLine();

float output = 0;

switch (op)
{
    case "+":
        output = num1 + num2;
        break;
    case "-":
        output = num1 - num2;
        break;
    case "/":
        if(num2 == 0)
        {
            Console.WriteLine("Can not divide by 0");
            Environment.Exit(1);
        }
        output = num1 / num2;
        break;
    case "%":
        if(num2 == 0)
        {
            Console.WriteLine("Can not divide by 0");
            Environment.Exit(1);
        }
        output = num1 % num2;
        break;
    case "*":
        output = num1 * num2;
        break;
    default:
        Console.WriteLine("invalid Operator");
        break;

}

Console.WriteLine($"{num1} {op} {num2} = {output}");