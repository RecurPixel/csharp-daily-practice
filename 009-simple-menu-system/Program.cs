// See https://aka.ms/new-console-template for more information
Console.WriteLine("--Simple Menu System!--");


while (true)
{
    Console.WriteLine("Choose from option 1 to 5");
    Console.WriteLine("1. Add");
    Console.WriteLine("2. Subtract");
    Console.WriteLine("3. Multiply");
    Console.WriteLine("4. Divide");
    Console.WriteLine("5. Exit");
    Console.WriteLine("=========");
     

    int choice;

    if (int.TryParse(Console.ReadLine(), out choice))
    {
        if(choice == 5)
        {
            Console.WriteLine("Good bye!");
            break;
        }
        int[] inputs = input();
        
        switch (choice)
        {
            case 1:
                Console.WriteLine($"Output => {inputs[0]} + {inputs[1]} = {Add(inputs[0], inputs[1])}");
                break;
            case 2:
                Console.WriteLine($"Output => {inputs[0]} - {inputs[1]} = {Subtract(inputs[0], inputs[1])}");
                break;
            case 3:
                Console.WriteLine($"Output => {inputs[0]} x {inputs[1]} = {Multiply(inputs[0], inputs[1])}");
                break;
            case 4:
                if(inputs[1] == 0)
                {
                    Console.WriteLine("Output => Divide By 0 not allowed.");
                    break;
                }
                Console.WriteLine($"Output => {inputs[0]} / {inputs[1]} = {Divide(inputs[0], inputs[1])}");
                break;
            default:
                Console.WriteLine("Invalid Input!. Please Try again.");
                break;
        }

    }
}

int[] input()
{
    int[] inputs = new int[2];

    Console.Write("Enter first Number: ");
    while (!int.TryParse(Console.ReadLine(), out inputs[0]))
    {
        Console.Write("Invalid Number! Try again: ");
    }
    Console.Write("Enter second Number: ");
    while(!int.TryParse(Console.ReadLine(), out inputs[1]))
    {
        Console.Write("Invalid Number! Try again: ");
    }
    return inputs;
}

int Add(int a, int b)
{
    return a + b;
}

int Subtract(int a, int b)
{
    return a - b;
}
int Multiply(int a, int b)
{
    return a * b;
}

double Divide(int a, int b)
{
    return (double)a / b;
}
