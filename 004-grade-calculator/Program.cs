// See https://aka.ms/new-console-template for more information
Console.WriteLine("--Grade Calculator!--");


// Ask user for score 0-100 (only allow valid score)
// Convert score to grade
// Display grade

int score;
char grade;

while (true)
{
    Console.Write("Enter score (0-100): ");
    if (int.TryParse(Console.ReadLine(), out score) && (score >= 0 && score <= 100))
    {
        break;
    }
    Console.WriteLine("Invalid input. Please enter a whole number between 0 and 100.");
}

if (score >= 90 && score <= 100)
{
    grade = 'A';
}
else if (score >= 80 && score <= 89)
{
    grade = 'B';
}
else if (score >= 70 && score <= 79)
{
    grade = 'C';
}
else if (score >= 60 && score <= 69)
{
    grade = 'D';
}
else
{
    grade = 'F';
}

Console.WriteLine($"Your Grade is: {grade}");