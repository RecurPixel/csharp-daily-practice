class LogWriter
{

    public const string LogFilePath = "log.txt";
    public static void WriteLog(string logEntry)
    {
        try
        {

            using (FileStream fs = new FileStream(LogFilePath, FileMode.Append))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine(logEntry);
                }
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine("\nError: Could Not Write on File. Details:  " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("\nAn Unexpected Error Occoured: " + ex.Message);
        }
    }
    public static void Main(string[] args)
    {

        Console.Write("Write Your Log Message: ");
        string? userInput = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(userInput))
        {
            Console.WriteLine("Message cannot be empty. Exiting.");
            return;
        }

        string dateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        string log = $"[{dateTime}] {userInput}";


        WriteLog(log);

        Console.WriteLine($"\nSUCCESS: Message saved to '{LogFilePath}'.");
        Console.WriteLine($"Entry: {log}");

    }
}