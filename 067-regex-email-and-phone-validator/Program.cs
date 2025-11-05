// ### ✅ Problem 67: Regex Email and Phone Validator

// **Concepts:** `Regex`, pattern matching

// **Instructions:**
// * Write a console program that asks the user to input an email and phone number.
// * Use regex to validate both inputs and print whether they are valid.

// 📝 **Bonus:** Ask the user to retry until both inputs are valid using a loop and exception handling.

using System.Text.RegularExpressions;

class RegexValidator
{
    private Regex regex;
    public RegexValidator()
    {
        Console.WriteLine("\n--Regex Email & Phone Validator--");
        regex = new Regex();
    }

    // abc.pqr@mail.com (true)
    // abc.pqr+abc@mail.com (true)
    // abc@mail.co.au (true)
    private bool ValidateEmail(string email)
    {
        string pattern = @"^([\w\.]*)(\+?[\w\.]*)?@[\w\.]*";
        regex.Match(email, pattern);
        return true;
    }


    private bool ValidatePhone()
    {
        string pattern = @"\(?(\d{3})\)?[\s-]?\d{3}[\s-]?\d{4}";
        regex.Match(email, pattern);
        return true;
    }
    
    public static void Main()
    {
        string? email, phone;

        RegexValidator regexValidator = new RegexValidator();

        do
        {
            Console.Write("Enter Email: ");
            email = Console.ReadLine();
            Console.Write("Enter Phone: ");
            phone = Console.ReadLine();

        } while (regexValidator.ValidateEmail(email) && regexValidator.ValidatePhone(phone));
                
    }
}