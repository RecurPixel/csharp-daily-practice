// * Read a text file and print its contents.
// * Handle file-related exceptions gracefully.

// **📝 Bonus:**
// Allow the user to input the file path and **retry** if the file is not found.

using System.IO;

class FileExceptionTest
{

    private static bool TryReadFile(string path)
    {
        try
        {

            var fileContent = File.ReadAllText(path);
            Console.WriteLine(fileContent);
            return true;
        }
        catch (FileNotFoundException ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("{0} \n File Path Given: {1}", ex.Message, ex.FileName);
        }
        catch (IOException ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("File Exception: {0}", ex.Message);
        }
        return false;
    }

    public static void Main(string[] args)
    {

        bool isFileRead = false;
        do
        {
            string filePath;

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Enter File Path: ");
            filePath = Console.ReadLine();

            isFileRead = TryReadFile(filePath);

        } while (!isFileRead);
    }
}