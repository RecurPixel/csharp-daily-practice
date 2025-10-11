// See https://aka.ms/new-console-template for more information
Console.WriteLine("--Palindrome Checker!--");



while (true)
{
    string input;

    Console.Write("Enter a string: ");


    while(true)
    {
        input = Console.ReadLine();

        if (input.Length != 0) { break;  }
        Console.WriteLine("Empty string not allowed. Enter Valid String");
        
    }

    if (IsPalindrome(input))
    {
        Console.WriteLine($"String {input} is a Palindrome.");
    }
    else
    {
        Console.WriteLine($"String {input} is not Palindrome.");
    }

    Console.Write("Type 'exit' to quit, or press Enter to check another word: ");

    string Exit = Console.ReadLine();

    if(Exit.Length != 0 && Exit.Trim().ToLower() == "exit")
    {
        Console.Write("Good bye!");
        break;
    }
}




bool IsPalindrome(String input)
{
    input = input.Trim().Replace(" ","");

    for(int i = 0; i < input.Length / 2; i++)
    {
        if(input[i] != input[input.Length - 1- i])
        {
            return false;
        }
    }

    return true;
}