// **Concepts:** FileStream, Byte Operations  
// - Copy contents from one file to another using `FileStream`.  
// 🧩 **Bonus:** Allow copying of `.txt` and `.csv` files.


class CopyTextFile
{
    public const string SourceFile = "input.csv";
    public const string DestFile = "output.csv";

    public static void Main()
    {

        if (!File.Exists(SourceFile))
        {
            Console.WriteLine($"\nNOTE: Creating sample source file: {SourceFile}");
            try
            {
                File.WriteAllLines(SourceFile, new string[] {
                    "This is the first line of the source file.",
                    "The FileStream will copy this data byte by byte.",
                    "We are using an 8KB buffer for maximum efficiency."
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: Could not create test file. {ex.Message}");
                return;
            }
        }

        try
        {
            using (FileStream readStream = new FileStream(SourceFile, FileMode.Open))
            {
                using (FileStream writeStream = new FileStream(DestFile, FileMode.Create))
                {
                    // int i;
                    // while((i = readStream.ReadByte()) != -1)
                    // {
                    //     writeStream.WriteByte((byte)i);
                    // }  

                    byte[] buffer = new byte[8192];
                    int bytesRead;

                    while ((bytesRead = readStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        writeStream.Write(buffer, 0, bytesRead);
                    }
                }
            }
            
            Console.WriteLine("\nSUCCESS: File copy complete!");
            Console.WriteLine($"Contents of '{SourceFile}' copied to '{DestFile}'.");
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine("Unable to Open File. Error: " + ex.Message);
        }
        catch (IOException ex)
        {
            Console.WriteLine("Something Went Wrong with File Read/Write. Error: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Something Went Wrong. Error: " + ex.Message);
        }
    }
}