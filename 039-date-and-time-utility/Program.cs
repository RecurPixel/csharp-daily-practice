// **Concepts:** `DateTime`, `TimeSpan`, Formatting  
// - Ask user for their birth date.  
// - Calculate and display age in years, months, and days.  
// 🧩 **Bonus:** Show days until next birthday.


using System.Globalization;


class BirthdayUtility
{

    public int Years { get; private set; }
    public int Months { get; private set; }
    public int Days { get; private set; }

    public DateTime DateOfBirth { get; private set; }

    public BirthdayUtility(DateTime startDate, DateTime endDate)
    {
        DateOfBirth = startDate;
        // Ensure startDate is always before endDate for consistent calculation
        if (startDate > endDate)
        {
            DateTime temp = startDate;
            startDate = endDate;
            endDate = temp;
        }

        Years = endDate.Year - startDate.Year;
        Months = endDate.Month - startDate.Month;
        Days = endDate.Day - startDate.Day;

        if (Days < 0)
        {
            Months--;
            Days += DateTime.DaysInMonth(startDate.Year, startDate.Month);
        }

        if (Months < 0)
        {
            Years--;
            Months += 12;
        }
    }

    public override string ToString()
    {
        string daysTillNextBirthDay = DaysTillNextBirthDay();
        return $"{Years} years, {Months} months, {Days} days \n {daysTillNextBirthDay}";
    }
    public string DaysTillNextBirthDay()
    {

        DateTime birthDayThisYear = new DateTime(DateTime.Now.Year, DateOfBirth.Month, DateOfBirth.Day);

        if (birthDayThisYear < DateTime.Now)
        {
            var dt = birthDayThisYear.AddYears(1);
            return $"Days till next birthday: {dt.Subtract(DateTime.Now).Days}";
        }

        return $"Days till next birthday: {birthDayThisYear.Subtract(DateTime.Now).Days}";

    }
    public static void Main()
    {
        DateTime dt = DateTime.Now;
        Console.WriteLine("Input birth date(dd-mm-YYYY): ");
        DateTime dateOfBirth;

        while (!DateTime.TryParse(
    Console.ReadLine(),
    CultureInfo.GetCultureInfo("en-GB"),
    out dateOfBirth
))
        {
            Console.WriteLine("Invalid Format!. Try Again.");
            Console.WriteLine("Input birth date(dd-mm-YYYY): ");
        }

        BirthdayUtility bdu = new BirthdayUtility(dateOfBirth, DateTime.Now);

        Console.WriteLine(bdu.ToString());

    }
}