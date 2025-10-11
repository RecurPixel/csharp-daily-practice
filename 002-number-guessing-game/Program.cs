// See https://aka.ms/new-console-template for more information
Console.WriteLine("Number Guessing Game!");


// generate a random number between 1 and 100
// ask user to input a number
// check if number matches, is close to match, is far from match
// repeat for 10 number of attempts
// if matches before that congratulate else after attempt exhaust end the game

int secretNumber;
int attemps = 10;

Random rand = new Random();

secretNumber = rand.Next(1, 101);

while (attemps > 0)
{
    Console.Write($"Enter your guess {attemps} attempts remainging: ");
    int inputNumber = int.Parse(Console.ReadLine() ?? "");

    if (inputNumber == secretNumber)
    {
        Console.WriteLine($"Congratulations you have gussed the number {inputNumber}!");
        Environment.Exit(0);
    }
    else if (inputNumber / 10 == secretNumber / 10)
    {
        Console.WriteLine($"Opps you were so close try again {inputNumber}");
    }
    else
    {
        Console.WriteLine($"Too far from it try again {inputNumber}");
    }
    attemps--;
}

Console.WriteLine($"You failed to guess the number. Secret Number ({secretNumber})");