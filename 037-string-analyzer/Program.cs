// **Concepts:** String Functions, Char Arrays  
// - Ask user for input string.  
// - Display: total characters, words, vowels, consonants, spaces.  
// 🧩 **Bonus:** Reverse string manually without built-in functions.


class StringAnalyzer
{

    private string GetInput()
    {
        Console.Write("Provide Input: ");
        return Console.ReadLine();
    }

        private string ReverseString(string inputString)
        {
            char[] charArray = inputString.ToCharArray();
            int length = charArray.Length;

            for (int i = 0; i < length / 2; i++)
            {
                char temp = charArray[i];
                charArray[i] = charArray[length - 1 - i];
                charArray[length - 1 - i] = temp;
            }

            return new string(charArray);
        }

    private void DisplayStringInfo(string inputString)
    {
        Console.WriteLine("\n-----String Details------");

        int totalVowelCount = 0;
        int totalConsonantCount = 0;
        int totalSpaceCount = 0;
        int totalLetterCount = 0;

        char[] vowels = { 'a', 'e', 'i', 'o', 'u' };

        string lowerInput = inputString.ToLower();

        foreach (char c in lowerInput)
        {
            if (Char.IsLetter(c))
            {
                totalLetterCount++;
                if (vowels.Contains(c))
                {
                    totalVowelCount++;
                }
                else
                {
                    totalConsonantCount++;
                }
            }
            else if (Char.IsWhiteSpace(c))
            {
                totalSpaceCount++;
            }
        }

        int totalWordCount = inputString.Split(
           (char[])null, // Null means split by whitespace
           StringSplitOptions.RemoveEmptyEntries // Ignores extra spaces
       ).Length;

        Console.WriteLine($"Total Characters (including all symbols/spaces): {inputString.Length}");
        Console.WriteLine($"Total Words: {totalWordCount}");
        Console.WriteLine($"Total Letters: {totalLetterCount}");
        Console.WriteLine($"Total Vowels: {totalVowelCount}");
        Console.WriteLine($"Total Consonants: {totalConsonantCount}");
        Console.WriteLine($"Total Spaces: {totalSpaceCount}");

        string reversed = ReverseString(inputString);
        Console.WriteLine($"\nReversed String: {reversed}");
        
    }
    public static void Main()
    {
        StringAnalyzer analyzer = new StringAnalyzer();
        string s = analyzer.GetInput();
        analyzer.DisplayStringInfo(s);
    }
}