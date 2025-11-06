// ### ✅ Problem 67: Regex Email and Phone Validator

// **Concepts:** `Regex`, pattern matching

// **Instructions:**
// * Write a console program that asks the user to input an email and phone number.
// * Use regex to validate both inputs and print whether they are valid.

// 📝 **Bonus:** Ask the user to retry until both inputs are valid using a loop and exception handling.

using System.Text.RegularExpressions;


class InvalidEmailException : ArgumentException
{
    public string AttemptedEmail { get; }
    public InvalidEmailException() 
        : base("Email validation failed. Provide a valid Email.")
    {
    }
    public InvalidEmailException(string message, Exception inner) 
        : base(message, inner)
    {
    }
    
    public InvalidEmailException(string AttemptedEmail) 
        : base($"Email validation failed. The entered Email ({AttemptedEmail}) is Invalid.")
    {
        this.AttemptedEmail = AttemptedEmail;
    }
}

class InvalidPhoneException: ArgumentException
{
    public string AttemptedPhone { get; }
    public InvalidPhoneException()
        : base("Phone validation failed. Provide a valid Phone.")
    {
    }
    
    public InvalidPhoneException(string message, Exception inner) 
        : base(message, inner)
    {
    }
    
    public InvalidPhoneException(string AttemptedPhone) 
        : base($"Phone validation failed. The entered Phone ({AttemptedPhone}) is Invalid.")
    {
        this.AttemptedPhone = AttemptedPhone;
    }
}

class RegexValidator
{
    public RegexValidator()
    {
        Console.WriteLine("\n--Regex Email & Phone Validator--");
    }

    // abc.pqr@mail.com (true)
    // abc.pqr+abc@mail.com (true)
    // abc@mail.co.au (true)
    private bool ValidateEmail(string email)
    {
        string pattern = @"^\w+(\.\w+)*(\+[\w]*)?@\w+\.\w+(\.\w+)*?$";
        return Regex.IsMatch(email, pattern);
    }


    private bool ValidatePhone(string phone)
    {
        string pattern = @"\(?(\d{3})\)?[\s-]?\d{3}[\s-]?\d{4}";
        return Regex.IsMatch(phone, pattern);
    }

    public static void Main()
    {
        string? email, phone;
        bool keepChecking = true;
        RegexValidator regexValidator = new RegexValidator();

        while (keepChecking)
        {
            Console.Write("Enter Email: ");
            email = Console.ReadLine();
            Console.Write("Enter Phone: ");
            phone = Console.ReadLine();

            try
            {
                if (!regexValidator.ValidateEmail(email)) throw new InvalidEmailException(email);
                if (!regexValidator.ValidatePhone(phone)) throw new InvalidPhoneException(phone);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Valid Email: {email}");
                Console.WriteLine($"Valid Phone: {phone}");
                Console.ResetColor();

                keepChecking = false;
            }
            catch (InvalidEmailException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
            catch (InvalidPhoneException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
        }

    }
}