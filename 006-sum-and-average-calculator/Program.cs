// See https://aka.ms/new-console-template for more information
Console.WriteLine("--Sum and Average Calculator--!");


// ask user for count of numbers
// get numers from user store in array
// make calculations using methods
// display result

int NumberCount;
int[] Numbers;

Console.WriteLine("How many numbers will you enter?");
while (!int.TryParse(Console.ReadLine(), out NumberCount) || NumberCount <= 0)
{
    Console.WriteLine("Invalid Count!. Please enter valid cound.");
}

Numbers = new int[NumberCount];

for (int i = 0; i < NumberCount; i++)
{
    Console.WriteLine($"Enter Number {i + 1} and enter: ");

    while (!int.TryParse(Console.ReadLine(), out Numbers[i]))
    {
        Console.WriteLine($"Invalid Number!. Enter Number {i + 1} and enter: ");
    }

}


Console.WriteLine($"Sum: {CalculateSum(Numbers)}");
Console.WriteLine($"Average: {CalculateAverage(Numbers)}");
Console.WriteLine($"Min: {CalculateMin(Numbers)}");
Console.WriteLine($"Max: {CalculateMax(Numbers)}");


int CalculateSum(int[] numbers)
{
    int Sum = 0;
    for (int i = 0; i < numbers.Length; i++)
    {
        Sum += numbers[i];
    }
    return Sum;
}

double CalculateAverage(int[] numbers)
{
    return (double) CalculateSum(numbers) / numbers.Length;
}

int CalculateMin(int[] numbers)
{
    int Min = numbers[0];
    for (int i = 0; i < numbers.Length; i++)
    {
        if (numbers[i] < Min) Min = numbers[i];
    }
    return Min;
}

int CalculateMax(int[] numbers)
{
    int Max = numbers[0];
    for (int i = 0; i < numbers.Length; i++)
    {
        if (numbers[i] > Max) Max = numbers[i];
    }
    return Max;
}
