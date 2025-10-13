class Car
{
    string brand, model, year;

    public Car(string carBrand, string carModel, string carYear)
    {
        brand = carBrand;
        model = carModel;
        year = carYear;
    }
    public void DisplayInfo()
    {
        Console.WriteLine("Brand Name: " + brand);
        Console.WriteLine("Model No: " + model);
        Console.WriteLine("Year: " + year);
    }

    public void ChangeYear(String _year)
    {
        year = _year;
    }
    
    public static void Main(String[] args)
    {
        Car c1 = new Car("HondaRonda", "SuperDuper", "2921");
        c1.DisplayInfo();
        c1.ChangeYear("2524");
        c1.DisplayInfo();
    }
}
