// ### ✅ Problem 66: JSON CRUD Operations

// **Concepts:** Read/Write JSON, File Handling, LINQ Updates

// **Instructions:**
// * Create a small menu-based program that allows:
//   * Adding a record
//   * Updating a record
//   * Deleting a record
//   * Saving data back to JSON

// 📝 **Bonus:** Use `try-finally` to ensure file closure and show user-friendly messages.


using System.Text.Json;
using System.Text;
using System.Text.Json.Serialization;

class Donation
{
    public int DonorId { get; init; }
    public string? FullName { get; set; }
    public string? Email { get; set; }
    public double Amount { get; init; }

    [JsonConstructor]
    public Donation(int donorId, string? fullName, string? email, double amount)
    {
        this.DonorId = donorId;
        this.FullName = fullName ?? "Anonymous";
        this.Email = email ?? "anon@email.com";
        this.Amount = amount;
    }

    public override string ToString()
    {
        return $"{DonorId,-15}{FullName,15}{Email,30}{Amount,45:C}";
    }
}


class JSONCRUD
{
    public const string FileName = "Donation_Records.json";
    public static int _latestDonationID = 10001;

    private List<Donation> _donationRecords;
    public JSONCRUD()
    {
        _donationRecords = new List<Donation>();
    }

    private void LoadRecords()
    {
        if (!File.Exists(FileName))
        {
            try 
            {
                File.WriteAllText(FileName, "[]");
                Console.WriteLine($"\nNOTE: Created new empty records file: {FileName}");
            }
            catch (Exception ex)
            {
                 Console.WriteLine($"\nERROR: Could not create file. {ex.Message}");
            }
            return;
        }

        try
        {

            string jsonStringFromFile = File.ReadAllText(FileName);

            List<Donation>? loadedRecords = null;

            try
            {
                loadedRecords = JsonSerializer.Deserialize<List<Donation>>(jsonStringFromFile);
            }
            catch (JsonException)
            {
                Console.WriteLine($"Loaded file is empty. Starting with a blank list.");
            }

            if (loadedRecords != null)
            {
                _donationRecords = loadedRecords;
                _latestDonationID = _donationRecords.Any() ? _donationRecords.Max(t => t.DonorId) + 1 : 1001;
                Console.WriteLine($"Loaded {_donationRecords.Count} records from {FileName}. Next ID: {_latestDonationID}");
            }
            return;

        }
        catch (IOException ex)
        {
            Console.WriteLine($"\nERROR loading file: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nERROR loading file: {ex.Message}");
        }
        return;
    }

    private void Add()
    {
        Console.Write("Enter Donor Full Name: ");
        string? name = Console.ReadLine();
        
        Console.Write("Enter Donor Email: ");
        string? email = Console.ReadLine();

        Console.Write("Enter Donation Amount: ");
        if (!double.TryParse(Console.ReadLine(), out double amount) || amount <= 0)
        {
            Console.WriteLine("❌ Invalid amount. Record not added.");
            return;
        }

        _donationRecords.Add(new Donation(_latestDonationID++, name, email, amount));
        Console.WriteLine($"\n✅ Added new record with ID: {_latestDonationID - 1}");
    }

    private void Remove()
    {
        Console.Write("Enter Donor ID to Remove: ");
        if (!int.TryParse(Console.ReadLine(), out int idToRemove))
        {
            Console.WriteLine("❌ Invalid ID format.");
            return;
        }

        int recordsRemoved = _donationRecords.RemoveAll(d => d.DonorId == idToRemove);

        if (recordsRemoved > 0)
        {
            Console.WriteLine($"\n✅ Successfully removed {recordsRemoved} record(s) with ID: {idToRemove}");
        }
        else
        {
            Console.WriteLine($"\nℹ️ No record found with ID: {idToRemove}");
        }
    }

    private void Update()
    {
        Console.Write("Enter Donor ID to Update: ");
        if (!int.TryParse(Console.ReadLine(), out int idToUpdate))
        {
            Console.WriteLine("❌ Invalid ID format.");
            return;
        }

        Donation? recordToUpdate = _donationRecords.FirstOrDefault(d => d.DonorId == idToUpdate);

        if (recordToUpdate == null)
        {
            Console.WriteLine($"\nℹ️ No record found with ID: {idToUpdate}");
            return;
        }

        Console.WriteLine($"\nRecord Found: {recordToUpdate.FullName} ({recordToUpdate.Email})");
        Console.WriteLine("Enter new details (leave blank to keep current value):");

        Console.Write($"New Full Name (Current: {recordToUpdate.FullName}): ");
        string? newName = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(newName))
        {
            recordToUpdate.FullName = newName;
        }

        Console.Write($"New Email (Current: {recordToUpdate.Email}): ");
        string? newEmail = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(newEmail))
        {
            recordToUpdate.Email = newEmail;
        }

        Console.WriteLine($"\n✅ Record ID {idToUpdate} updated successfully.");
    }

    private void Save()
    {
        try
        {
            string donationString = JsonSerializer.Serialize(_donationRecords, new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText(FileName, donationString, Encoding.UTF8);

            Console.WriteLine($"File `{FileName}` is Saved latest Data.");
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine($"\nFile `{FileName}` Not Found. Continuing Opesation without loading. Details: {ex.Message} ");
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"\nError: Invalid Json. Discription: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Something Went Wrong. Details: {ex.Message}");
        }
    }

    private void Show()
    {
        Console.WriteLine("\n---Updated Records---");
        Console.WriteLine($"{"Donation Id",-15}{"Donor Name",15}{"Donor Email",30}{"Donation Amount",45}");
        foreach (var d in _donationRecords)
        {
            Console.WriteLine(d);
        }
        return;
    }


    public static void Main()
    {
        JSONCRUD handler = new JSONCRUD();
        handler.LoadRecords();

        bool keepAlive = true;

        while (keepAlive)
        {

            try
            {
                Console.WriteLine("\n---Donation Menu---\n");
                Console.WriteLine(" > Add: 1");
                Console.WriteLine(" > Remove: 2");
                Console.WriteLine(" > Update: 3");
                Console.WriteLine(" > Show: 4");
                Console.WriteLine(" > Save and Exit: 0");

                if (!int.TryParse(Console.ReadLine(), out var input))
                {
                    Console.WriteLine("Invalid Input! Try Again.");
                    continue;
                }
                switch (input)
                {
                    case 1:
                        handler.Add();
                        break;
                    case 2:
                        handler.Remove();
                        break;
                    case 3:
                        handler.Update();
                        break;
                    case 4:
                        handler.Show();
                        break;
                    case 0:
                        handler.Save();
                        keepAlive = false;
                        break;
                    default:
                        Console.WriteLine("❌ Invalid choice! Please select 0, 1, 2, 3 or 4.");
                        break;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: Something Went Wrong. Details: {ex.Message}");
            }
            finally
            {
                handler.Show();
            }

        }
    }
}