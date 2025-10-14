class Vehicle
{
    protected string LicensePlate;
    protected int Wheels;

    public Vehicle(string licensePlate, int wheels)
    {
        LicensePlate = licensePlate;
        Wheels = wheels;

        Console.WriteLine("Vehicle created.");
    }
}

class Car: Vehicle
{
    protected bool HasTrunk;

    public Car(string licensePlate, int wheels, bool hasTrunk) : base(licensePlate, wheels)
    {
        HasTrunk = hasTrunk;
        Console.WriteLine("Car created.");
    }

    public void GetDescription()
    {
        Console.WriteLine("Licence Plate: " + LicensePlate);
        Console.WriteLine($"Wheels: {Wheels}");
        Console.WriteLine("Trunk: " + (HasTrunk ? "Yes" : "No"));
    }
    
    public static void Main(string[] args)
    {
        Car c = new Car("US12BPX", 4, true);
        c.GetDescription();
    }
}