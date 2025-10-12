// See https://aka.ms/new-console-template for more information
Console.WriteLine("--Student Grades Summary!--");

// 1. Ask how many students there are.
// 2. For each student, enter their marks.
// 3. Store all marks in an array.
// 4. Write methods:

//    * `GetHighest(int[] marks)`
//    * `GetLowest(int[] marks)`
//    * `GetAverage(int[] marks)`
// 5. Display the overall class summary.

// 📝 **Bonus:**
// Add a method to **assign grades** (A/B/C/D/F) based on the average score.

int studentCount;
int[] studentMarks;

Console.Write("Enter No. of students: ");

while (!int.TryParse(Console.ReadLine(), out studentCount))
{
    Console.WriteLine("Invalid Count. try again.");
}

studentMarks = new int[studentCount];

Console.Write("Enter valid markes (0-100) per line");
    
for(int i = 0; i < studentCount; i++)
{
    Console.Write("=> ");

    while(!int.TryParse(Console.ReadLine(), out studentMarks[i]) || studentMarks[i] < 0 || studentMarks[i] > 100)
    {
        Console.WriteLine("Invalid Marks! Try again");
        Console.Write("=> ");
    }
}


Console.WriteLine($"Highest Score: {GetHighest(studentMarks)}, Highest Grade: {AssignScore(GetHighest(studentMarks))}");
Console.WriteLine($"Lowest Score: {GetLowest(studentMarks)}, Lowest Grade: {AssignScore(GetLowest(studentMarks))}");
Console.WriteLine($"Average Score: {GetAverage(studentMarks)}, Average Grade: {AssignScore((int)GetAverage(studentMarks))}");


int GetHighest(int[] markes)
{
    // return markes.Max();
    int Highest = markes[0];
    for (int i = 0; i < markes.Length; i++)
    {
        if (markes[i] > Highest)
        {
            Highest = markes[i];
        }
    }
    return Highest;
}

int GetLowest(int[] markes)
{
    // return markes.Min();
    int Lowest = markes[0];
    for (int i = 0; i < markes.Length; i++)
    {
        if (markes[i] < Lowest)
        {
            Lowest = markes[i];
        }
    }
    return Lowest;
}

double GetAverage(int[] markes)
{
    // return markes.Average();

    int Sum = 0;
    for (int i = 0; i < markes.Length; i++)
    {
        Sum += markes[i];
    }
    return (double)Sum / markes.Length;
}

char AssignScore(int score)
{
    char grade;
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

    return grade;
}