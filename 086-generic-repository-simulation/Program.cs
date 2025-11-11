// ### ✅ Problem 86: Generic Repository Simulation

// **Concepts:** `Generics`, `Interfaces`, `OOP`

// **Instructions:**
// * Create an interface `IRepository<T>` with methods `Add`, `Remove`, `GetAll`.
// * Implement it for a `User` class using an internal list.

// 📝 **Bonus:** Add persistence by saving and loading data to/from a JSON file.

using System.Text;
using System.Text.Json;
using System.Text.Encodings;

interface IRepository<T>
{
    public bool Add(T item);
    public bool Remove(T item);
    public IEnumerable<T> GetAll();
}


public record User(int ID, string Name, int Age);


class UserRepository : IRepository<User>
{
    private static int _nextUserId = 10001;
    private const string _saveFileName = "user_repo.json";
    private static List<User> _users;

    public UserRepository()
    {
        _users = new List<User>();
        LoadData();
        
    }

    private static void LoadData()
    {
        try
        {
            var jsonString = File.ReadAllText(_saveFileName);
            var userRecords = JsonSerializer.Deserialize<List<User>>(jsonString);

            if (userRecords.Count != 0)
            {
                _users = userRecords;
                var maxId = _users.Max(u => u.ID);
                _nextUserId = maxId != 0 ? maxId + 1 : _nextUserId;
            }


            Console.WriteLine($"Data Loaded from file. `{_saveFileName}`");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"File not found File: `{_saveFileName}`");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Unable to read file Details: {ex.Message}");
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"Json Error. Details: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Something Went Wrong! Details: {ex.Message}");
        }
    }
    
    private static void SaveData()
    {
        try
        {
            var jsonString = JsonSerializer.Serialize(_users, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_saveFileName, jsonString, Encoding.UTF8);

            Console.WriteLine($"Data saved to file. `{_saveFileName}`");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"File not found File: `{_saveFileName}`");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Unable to read file Details: {ex.Message}");
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"Json Error. Details: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Something Went Wrong! Details: {ex.Message}");
        }
    }

    public bool Add(User user)
    {
        if (_users.Contains(user))
        {
            Console.WriteLine($"Record Already Exist. Details: {user}. Skipped.");
            return false;
        }
        _users.Add(user);
        return true;
    }

    public bool Remove(User user)
    {
        if (!_users.Contains(user))
        {
            Console.WriteLine($"Record Does Not Exist. Can not remove. Details: {user}");
            return false;
        }
        _users.Remove(user);
        return true;
    }

    public IEnumerable<User> GetAll()
    {
        return _users;
    }

    public static void Main()
    {
        UserRepository repository = new UserRepository();

        repository.Add(new User(_nextUserId++, "Alex", 26));
        repository.Add(new User(_nextUserId++, "Alen", 22));
        repository.Add(new User(_nextUserId++, "Alena", 16));
        repository.Add(new User(_nextUserId++, "Alex", 26));
        repository.Add(new User(_nextUserId++, "Aren", 29));
        repository.Add(new User(_nextUserId, "Aren", 29));
                

        repository.Remove(new User(1001, "Alex", 26));
        repository.Remove(new User(1001, "Alex", 26));

        foreach (var user in repository.GetAll())
        {
            Console.WriteLine(user);
        }

        SaveData();
    }
}