// * Create a console-based address book.
// * Key = person’s name
// * Value = list of phone numbers
// * Allow:

//   * Add contact
//   * Remove contact
//   * Search contact
// * Use exception handling for invalid or empty inputs.

// **📝 Bonus:**
// Use `try-catch-finally` to manage errors and always print a summary after each operation.


using System.Text.RegularExpressions;

class AddressBook
{
    private Dictionary<string, List<string>> _addressBook;

    public AddressBook()
    {
        _addressBook = new Dictionary<string, List<string>>();
    }

    static bool IsValidContact(string contact)
    {
        string pattern = @"^[+]{1}(?:[0-9\\-\\(\\)\\/" +
                          "\\.]\\s?){6,15}[0-9]{1}$";
        if (String.IsNullOrWhiteSpace(contact))
        {
            return false;
        }

        if (Regex.IsMatch(contact, pattern))
        {
            return true;
        }
        return false;

    }

    public static (string, string) InputContact()
    {
        string name;
        string contact;

        Console.Write("\nEnter Name: ");
        while (String.IsNullOrWhiteSpace(name = Console.ReadLine()))
        {
            Console.Write("Invalid Name. Try Agrain: ");
        }

        Console.Write("\nEnter Contact (+00 000000000): ");
        while (!AddressBook.IsValidContact(contact = Console.ReadLine()))
        {
            Console.Write("Invalid Contact. Try Agrain (+00 000000000): ");
        }

        return (name, contact);
    }

    private void AddContact()
    {
        try
        {
            (string name, string contact) = AddressBook.InputContact();

            if (_addressBook.ContainsKey(name))
            {
                _addressBook[name].Add(contact);
            }
            else
            {
                _addressBook.Add(name, new List<string>() { contact });
            }
        }catch(Exception ex)
        {
            Console.WriteLine($"\nError: Something Went Wrong! Details: {ex.Message}");
        }
        
    }

    private void RemoveContact()
    {
        try
        {
            Console.WriteLine("\nEnter Removal Details:");
            (string name, string contact) = AddressBook.InputContact();

            if (_addressBook.ContainsKey(name) && _addressBook[name].Remove(contact))
            {
                Console.WriteLine($"\nSuccess: Removed Contact: {contact} for Name: {name}.");
                return;
            }
            else
            {
                Console.WriteLine($"\nError: Invalid Name: {name}. Try Again.");
                return;
            }
        }catch(Exception ex)
        {
            Console.WriteLine($"\nError: Something Went Wrong! Details: {ex.Message}");
        }
    }

    private void RemoveEntry()
    {
        try
        {
            Console.WriteLine("\nEnter Removal Details:");

            string name;
            Console.Write("\nEnter Name: ");
            while (String.IsNullOrWhiteSpace(name = Console.ReadLine()))
            {
                Console.Write("Invalid Name. Try Agrain: ");
            }

            if (_addressBook.ContainsKey(name) && _addressBook.Remove(name))
            {
                Console.WriteLine($"\nSuccess: Removed Contact Name: {name} from Address Book.");
                return;
            }
            else
            {
                Console.WriteLine($"\nError: Invalid Name: {name}. Try Again.");
                return;
            }
        }catch(Exception ex)
        {
            Console.WriteLine($"\nError: Something Went Wrong! Details: {ex.Message}");
        }
    }

    private void SearchContact()
    {
        string contact;
        Console.Write("\nEnter Contact (+00 000000000): ");
        while (!AddressBook.IsValidContact(contact = Console.ReadLine()))
        {
            Console.Write("Invalid Contact. Try Agrain (+00 000000000): ");
        }

        foreach (KeyValuePair<string, List<string>> item in this._addressBook)
        {
            if (item.Value.Contains(contact))
            {
                Console.WriteLine($"\nContact Found: Name {item.Key}");
                foreach (string c in item.Value)
                {
                    Console.WriteLine($" > Contact: {c}");
                }
                return;
            }
        }
        Console.WriteLine($"No Contact Found. Try Again.");
    }

    private void ShowContacts()
    {
        Console.WriteLine("\n---Contact Book---");

        foreach (KeyValuePair<string, List<string>> item in _addressBook)
        {
            Console.WriteLine($"\n{item.Key}");
            foreach (string contact in item.Value)
            {
                Console.WriteLine($" > Contact: {contact}");
            }
            Console.WriteLine("\n----");
        }
    }
    public static void Main()
    {

        AddressBook addressBook = new AddressBook();

        bool keepAlive = true;

        while (keepAlive)
        {

            try
            {
                Console.WriteLine("\n---Address Book---\n");
                Console.WriteLine(" > Add Contact: 1");
                Console.WriteLine(" > Remove contact: 2");
                Console.WriteLine(" > Remove Address Entry: 3");
                Console.WriteLine(" > Search Contact: 4");
                Console.WriteLine(" > Exit: 0");

                if(!int.TryParse(Console.ReadLine(), out var input))
                {
                    Console.WriteLine("Invalid Input! Try Again.");
                    continue;
                }
                switch(input)
                {
                    case 1: 
                        addressBook.AddContact();
                        break;
                    case 2: 
                        addressBook.RemoveContact();
                        break;
                    case 3: 
                        addressBook.RemoveEntry();
                        break;
                    case 4: 
                        addressBook.SearchContact();
                        break;
                    case 0:
                        keepAlive = false;
                        break;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: Something Went Wrong. Details: {ex.Message}");
            }
            finally
            {
                addressBook.ShowContacts();
            }

        }
    }
}