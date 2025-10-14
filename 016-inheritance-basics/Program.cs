// * Create a base class `Animal` with a method `Speak()`.
// * Create derived classes `Dog` and `Cat` that inherit from `Animal`.
// * Call `Speak()` from each object.

// 📝 *Bonus:* Add shared properties like `Name` or `Age`.


class Animal
{
    protected string Name;
    protected int Age;

    public Animal(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public virtual void Speak()
    {
        Console.WriteLine($"{Name} is making a sound");
    }
}

class Dog : Animal
{
    public Dog(string name, int age) : base(name, age)
    {

    }
    public override void Speak()
    {
        Console.WriteLine($"{Name} is barking: Wuff!");
    }
}

class Cat : Animal
{
    public Cat(string name, int age) : base(name, age)
    {

    }

    public override void Speak()
    {
        Console.WriteLine($"{Name} is saying: Mewwww");
    }
}


class Test
{
    public static void Main(string[] args)
    {
        Dog d = new Dog("Bob", 2);
        d.Speak();
        Cat c = new Cat("Cam", 2);
        c.Speak();
    }
}

// // Note:
// 1. There is beter way to do it using abstract class
// 2. It will prevent us from using Animal class
// 3. It will not require us to define Speak() method in Animal class