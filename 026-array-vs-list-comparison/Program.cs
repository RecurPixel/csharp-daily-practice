class ArrayListComparison
{
    public static void Main(string[] args)
    {

        // Create, Change Values, Add, Remove, Access, Aggrigate, 

        // Create an array
        int[] arr1 = new int[5]; // default value array with length 5
        int[] arr2 = { 1, 2, 3, 4, 5 }; // initializer with 5 values
        int[] arr3 = new int[5] { 1, 2, 3, 4, 5 }; // Explicit initalization

        // Add value: Not allowed as array size is fixed.
        // Remove value: Not allowed as array size is fixed.

        // Access Value
        Console.WriteLine("Access using for loop and index");
        for(int i = 0; i < arr1.Length; i++)
        {
            Console.WriteLine("arr1[{0}] = {1}", i, arr1[i]);
        }

        // Access Value

        Console.WriteLine("Access using foreach");
        foreach (int i in arr2)
        {
            Console.WriteLine(i);
        }

        // Changing vlue in array

        arr1[0] = 5;
        arr1[1] = 3;

        for(int i = 0; i < 10; i++)
        {
            try
            {
                arr1[i] = i + i * 2;   
            }catch(IndexOutOfRangeException ex)
            {
                Console.WriteLine("This shows how array are fixed sized and we can not access out of the range");
                break;
            }
        }

        Console.WriteLine("Aggregate");
        Console.WriteLine("Array.Sum(): {0}", arr1.Sum());
        Console.WriteLine("Array.Average(): {0}", arr1.Average());
        Console.WriteLine("Array.Min(): {0}", arr1.Min());
        Console.WriteLine("Array.Max(): {0}", arr1.Max());
        Console.WriteLine("Array.Length: {0}", arr1.Length);
        Console.WriteLine("Array.Rank: {0}", arr1.Rank);

        // There are many Array methods/properties this is not an exhaustive list



        // =================List==========================
        // Create, Change Values, Add, Remove, Access, Aggrigate, 

        // Create an List

        List<int> list1 = new List<int>(); // Empty List
        List<int> list2 = new List<int>(10); // list of size 10
        List<int> list3 = new List<int>() { 1, 2, 3, 4 }; // initializer
        List<int> list4 = new List<int>(arr1); // list out of an array


        // Add value:
        for (int i = 1; i < 10; i++)
        {
            list1.Add(1 * i);
        }

        list2.AddRange(Enumerable.Range(1, 5));
        list3.Insert(3, 8);

        // Access Value
        Console.WriteLine("Access using for loop and index");
        for(int i = 0; i < list1.Count; i++)
        {
            Console.WriteLine("list1[{0}] = {1}", i, list1[i]);
        }

        // Access Value

        Console.WriteLine("Access using foreach");
        foreach (int i in list2)
        {
            Console.WriteLine(i);
        }

        // Changing vlue in array

        list1[0] = 5;
        list1[1] = 3;

        for(int i = 0; i < 10; i++)
        {
            try
            {
                list1[i] = i + i * 2;   
            }catch(ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("List:This shows how array are fixed sized and we can not access out of the range");
            }
        }

        Console.WriteLine("Aggregate");
        Console.WriteLine("list1.Sum(): {0}", list1.Sum());
        Console.WriteLine("list1.Average(): {0}", list1.Average());
        Console.WriteLine("list1.Min(): {0}", list1.Min());
        Console.WriteLine("list1.Max(): {0}", list1.Max());
        Console.WriteLine("list1.Count: {0}", list1.Count);

        // There are many list1 methods/properties this is not an exhaustive list

        // Removing Elements from list

        Console.WriteLine("Before removing from list items coutn: {0}", list1.Count);

        foreach(int i in list1)
        {
            Console.Write(" {0}", i);
        }
        

        list1.Remove(3);
         Console.WriteLine("\nAfter removing list1.Remove(3) from list items coutn: {0}", list1.Count);

        foreach(int i in list1)
        {
            Console.Write(" {0}", i);
        }
        list1.RemoveAt(1);
        Console.WriteLine("\nAfter removing list1.RemoveAt(1); from list items coutn: {0}", list1.Count);

        foreach(int i in list1)
        {
            Console.Write(" {0}", i);
        }
        list1.Remove(300);

        Console.WriteLine("\nAfter removing list1.Remove(300); from list items coutn: {0}", list1.Count);

        foreach (int i in list1)
        {
            Console.Write(" {0}", i);
        }
        
        list1.Clear();

        Console.WriteLine("\nAfter removing list1.Clear(); from list items coutn: {0}", list1.Count);

        foreach(int i in list1)
        {
            Console.Write(" {0}", i);
        }
                                


    }
}
