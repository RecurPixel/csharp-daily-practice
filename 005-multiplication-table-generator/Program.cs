// See https://aka.ms/new-console-template for more information
Console.WriteLine("--Multiplication Table Generator!--");


// ask user to input number to generate table of
// ask user range upto which they want to generate table
// show output

int number, range;

while (true)
{
    Console.Write("Please Enter Valid number: ");
    if (int.TryParse(Console.ReadLine(), out number))
    {
        break;
    }
    Console.WriteLine("Invalid Number!. Please Enter Valid number.");
}

while (true)
{
    Console.Write("Please Enter a range(1-100): ");
    
    if (int.TryParse(Console.ReadLine(), out range) && (range > 0 && range <= 100))
    {
        break;
    }
    Console.WriteLine("Invalid Range!. Please Enter Valid range.");
}

for (int i = 1; i <= range; i++)
{
    Console.WriteLine($"{number} x {i} = {number * i}");
}

