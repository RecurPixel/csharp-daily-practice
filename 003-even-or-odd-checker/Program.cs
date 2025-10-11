// See https://aka.ms/new-console-template for more information
Console.WriteLine("--Even or Odd Checker!--");

// Get integer from user as input
// check of Even or Odd using (%) operator
// Display the result

int input;
bool isValidNumber = false;

do
{
    Console.Write("Enter the number: ");
    isValidNumber = int.TryParse(Console.ReadLine(), out input);
} while (!isValidNumber);


if (input % 2 == 0)
{
    Console.WriteLine("The number is Even");
}
else
{
    Console.WriteLine("The numberis Odd");
}