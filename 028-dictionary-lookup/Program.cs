// **Concepts:** `Dictionary<TKey, TValue>`, `KeyNotFoundException`

// * Build a dictionary of countries and capitals.
// * Allow the user to enter a country and display its capital.
// * Handle invalid keys.

// **📝 Bonus:**
// Allow adding new key-value pairs dynamically.

class CountryCapitalLookup
{

        private static int GetValidIntInput()
        {
            int input;
            while (!int.TryParse(Console.ReadLine(), out input) || input < 0 || input > 4)
            {
                Console.WriteLine("Enter Valid Input: ");
            }
            return input;

        }
    public static void Main(string[] args)
    {
        Dictionary<string, string> Lookup = new Dictionary<string, string>() {
            { "Afghanistan", "Kabul" },
            { "Åland Islands", "Mariehamn" },
            { "Albania", "Tirana" },
            { "Algeria", "Algiers" },
            { "American Samoa", "Pago Pago" },
            { "Andorra", "Andorra la Vella" },
            { "Angola", "Luanda" },
            { "Anguilla", "The Valley" },
            { "Antarctica", "Antarctica" },
            { "Antigua and Barbuda", "St. John's" },
            { "Argentina", "Buenos Aires" },
            { "Armenia", "Yerevan" },
            { "Aruba", "Oranjestad" },
            { "Australia", "Canberra" },
            { "Austria", "Vienna" },
            { "Azerbaijan", "Baku" } };


        bool stop = true;
        int choice;
        do
        {
            Console.WriteLine("\nLookup Options: ");
            Console.WriteLine("Show all: 1");
            Console.WriteLine("Add Entry: 2");
            Console.WriteLine("Remove Entry: 3");
            Console.WriteLine("Look Country: 4");
            Console.WriteLine("Exit: 0");

            choice = GetValidIntInput();
            
            if(choice == 1)
            {
                Console.WriteLine("Country      | Capital");
                foreach (KeyValuePair<string, string> pair in Lookup)
                {
                    Console.WriteLine("{0} | {1}", pair.Key, pair.Value);
                }
                
            } else if(choice == 2)
            {
                string country; 
                string capital;
                Console.WriteLine("Enter County: ");
                country = Console.ReadLine();
                Console.WriteLine("Enter Capital: ");
                capital = Console.ReadLine();
                if(country.Trim().Length == 0 || capital.Trim().Length == 0)
                {
                    Console.WriteLine("Country or Capital empty");
                }
                else
                {
                Lookup[country] = capital;
                Console.WriteLine("Lookup: {0} => {1}", country, capital);
                }


            } else if(choice == 3)
            {
                string country;
                Console.WriteLine("Enter County to remove: ");
                country = Console.ReadLine();
                bool wasRemoved = Lookup.Remove(country);
                if (wasRemoved)
                {
                    Console.WriteLine($"{country} removed successfully.");
                }
                else
                {
                    Console.WriteLine($"{country} was not found in the dictionary.");
                }

            } else if(choice == 4)
            {
                string country;
                    Console.WriteLine("Enter County to look: ");
                    country = Console.ReadLine(); 

                if (Lookup.TryGetValue(country, out string capital))
                {
                    // Success: 'capital' now holds the value
                    Console.WriteLine($"The capital of {country} is {capital}.");
                }
                else
                {
                    // Failure: Key was not found
                    Console.WriteLine($"{country} not found. Please try again or add the entry (Option 2).");
                }
                
            } else
            {
                stop = false;
                Console.WriteLine("Good Bye!");
            }
                                                            

        } while (stop);

    }
}