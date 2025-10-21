// **Concepts:** Structs, Methods, Static Methods  
// - Create a `Temperature` struct that holds Celsius/Fahrenheit.  
// - Implement conversion methods: `ToFahrenheit()`, `ToCelsius()`.  
// 🧩 **Bonus:** Overload operators `==`, `!=` to compare two temperatures.


struct Temperature
{
    public double Celsius { get; init; }

    public Temperature(Double temprature)
    {
        Celsius = Math.Round(temprature, 4);
    }

    public static Temperature FromFahrenheit(double fahrenheit)
    {
        double celsiusValue = (fahrenheit - 32) / 1.8;
        return new Temperature(celsiusValue);
    }

    public double ToFahrenheit()
    {
        return Math.Round((Celsius * 1.8) + 32, 4);
    }

    public double ToCelsius()
    {
        return Celsius;
    }

    public static bool operator ==(Temperature temperature1, Temperature temperature2)
    {
        return temperature1.Celsius == temperature2.Celsius;
    }

    public static bool operator !=(Temperature temperature1, Temperature temperature2)
    {
        return temperature1.Celsius != temperature2.Celsius;
    }

    // 4. IMPORTANT: Override Equals and GetHashCode when overloading == and !=
    public override bool Equals(object? obj)
    {
        // Check if the object is null or not a Temperature struct
        if (obj is not Temperature other)
        {
            return false;
        }
        // Use the defined equality logic
        return this.Celsius == other.Celsius;
    }

    public override int GetHashCode()
    {
        return Celsius.GetHashCode();
    }
}

class TemperatureConverter
{
    public static void Main(string[] args)
    {
        double tempC1 = 50.0;
        double tempC2 = 32.0;
        Temperature t1 = new Temperature(tempC1);
        Temperature t2 = new Temperature(tempC2);

        double tempF1 = t1.ToFahrenheit();
        double tempF2 = t2.ToFahrenheit();

        Console.WriteLine($" Temprature Compare: {tempF1}F/({tempC1}C) == {tempF2}F/({tempC2}C) is {t1 == t2}");
        Console.WriteLine($" Temprature Compare: {tempF1}F/({tempC1}C) != {tempF2}F/({tempC2}C) is {t1 != t2}");
    }
}