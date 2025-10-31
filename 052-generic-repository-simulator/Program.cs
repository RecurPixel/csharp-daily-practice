// **Concepts:** `Generic Class`, `List<T>`, `where T : class`

// **Instructions:**
// * Simulate a simple data repository using a generic class `Repository<T>` that supports:
//   * `Add`, `Remove`, `GetAll` methods
//   * Generic type constraint: only accepts class types

// 📝 **Bonus:** Add basic error handling for null references and print all repository contents neatly.


class TestDataType
{
    public int ID { get; init; }
    public string Name {get; init;}

    public TestDataType(int id, string name)
    {
        ID = id;
        Name = name;
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        TestDataType other = (TestDataType)obj;
        return ID == other.ID && Name == other.Name;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(ID, Name);
    }

    public override string ToString()
    {
        return $"Item ID: {ID}, Item Name: {Name}";
    }
}

class Repository<T> where T : class
{
    private List<T> _repositoryItems;

    public Repository()
    {
        _repositoryItems = new List<T>();
    }

    public void Add(T data)
    {
        if (data == null)
    {
        // Bonus: Basic error handling printout
        Console.WriteLine("[Repository Error] Attempted to add a null object. Item skipped.");
        return; 
    }
    _repositoryItems.Add(data);
    }

    public void Remove(T data)
    {
        _repositoryItems.Remove(data);
    }

    public List<T> GetAll()
    {
        return _repositoryItems;
    }

}

class TestGenericClass
{
    public static void Main()
    {
        Repository<TestDataType> records = new Repository<TestDataType>();
        TestDataType? nullObject = null;

        records.Add(new TestDataType(1, "one"));
        records.Add(new TestDataType(2, "two"));
        records.Add(new TestDataType(3, "three"));
        records.Add(new TestDataType(4, "four"));
        records.Add(new TestDataType(5, "five"));
        records.Add(nullObject);
        records.Add(new TestDataType(6, "six"));

        records.Remove(new TestDataType(3, "three"));

        Console.WriteLine("All Records Details\n");
        foreach (TestDataType t in records.GetAll())
        {
            Console.WriteLine($"Record Info: {t.ToString()}");
        }


    }
}