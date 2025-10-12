// See https://aka.ms/new-console-template for more information
Console.WriteLine("--Word Counter!--");

// 1. Ask the user to input a sentence.
// 2. Create a method `CountWords(string sentence)` that splits the string using spaces and counts the number of words.
// 3. Display the total word count.

// 📝 **Bonus:** Count **unique words** (hint: use `ToLower()` and basic array comparisons).


string sentence;

Console.WriteLine("Write a sentence.");

sentence = Console.ReadLine() ?? "";

Console.WriteLine("No. of words is " + CountWords(sentence));
Console.WriteLine("No. of unique words is " + CountUniqueWords(sentence));


int CountWords(string sentence)
{
    return sentence.Split(" ", StringSplitOptions.RemoveEmptyEntries).Length;
}

int CountUniqueWords(string sentence)
{
    string[] words = sentence.ToLower().Split(" ", StringSplitOptions.RemoveEmptyEntries);
    int uniqueWordsCount = 0;

    for (int i = 0; i < words.Length; i++)
    {
        bool isDuplicate = false;

        for (int j = 0; j < i; j++)
        {
            if (words[i] == words[j])
            {
                isDuplicate = true;
                break;
            }
        }

        if (!isDuplicate)
        {
            uniqueWordsCount++;
        }
    }

    return uniqueWordsCount;
}