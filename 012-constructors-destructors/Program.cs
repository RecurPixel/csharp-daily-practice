// * Modify the `Car` class:

//   * Add a **default** and a **parameterized** constructor.
//   * Print a message inside the destructor to show object cleanup.
// * Create multiple car objects using both constructors.

// 📝 *Bonus:* Add an initialization message in the constructor.

class Car
{
    private string brand, model;
    private int year;

    public string Brand
    {
        get { return brand; }
        set { brand = value; }
    }

    public string Model
    {
        get { return model; }
        set { model = value; }
    }

    public int Year
    {
        get { return year; }
        set { year = value; }
    }

    public Car()
    {
        brand = "Unknown";
        model = "Base Model";
        year = 0;
        Console.WriteLine("Default contructor. Object Created.");
    }
    public Car(string carBrand, string carModel, int carYear)
    {
        Console.WriteLine("Parameterized contructor. Object Created.");
        brand = carBrand;
        model = carModel;
        year = carYear;
    }

    ~Car()
    {
        Console.WriteLine("Destructor was call. Memory cleanup done.");
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Brand Name: {brand}");
        Console.WriteLine($"Model No: {model}");
        Console.WriteLine($"Year: {year}");
    }


    public static void Main(String[] args)
    {
        Car c1 = new Car();
        c1.DisplayInfo();
        c1.Brand = "Alpha Cars";
        c1.Model = "Cosmos X";
        c1.Year = 2019;
        c1.DisplayInfo();

        Car c2 = new Car("HondaRonda", "SuperDuper", 1998);
        c2.DisplayInfo();
        c2.Year = 3051;
        c2.DisplayInfo();
    }
}
