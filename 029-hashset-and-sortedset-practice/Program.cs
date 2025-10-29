// **Concepts:** `HashSet<T>`, `SortedSet<T>`

// * Create two sets of favorite numbers.
// * Demonstrate:

//   * Union
//   * Intersection
//   * Difference
// * Then show sorted results using `SortedSet`.

// **📝 Bonus:**
// Show how `HashSet` automatically prevents duplicates.


class TestSet
{

    public static void PrintItemInSet(IEnumerable<int> hShet, string title)
    {
        Console.WriteLine($"\n {title}");
        foreach (int i in hShet)
        {
            Console.Write($" {i}");
        }
    }
    public static void Main()
    {
        HashSet<int> favNum1 = new HashSet<int>();
        HashSet<int> favNum2 = new HashSet<int>();
        HashSet<int> favOutput = new HashSet<int>();

        favNum1.Add(11);
        favNum1.Add(1);
        favNum1.Add(3);
        favNum1.Add(5);
        favNum1.Add(7);
        favNum1.Add(9);
        
        favNum2.Add(3);
        favNum2.Add(6);
        favNum2.Add(9);
        favNum2.Add(12);
        favNum2.Add(15);

        favNum1.Remove(1);
        favNum2.Remove(1);

        favNum1.RemoveWhere(n => n == 5);

        TestSet.PrintItemInSet(favNum1, "Numbers in Faverote set 1");
        TestSet.PrintItemInSet(favNum2, "Numbers in Faverote set 2");

        favOutput = new HashSet<int>(favNum1);
        favOutput.UnionWith(favNum2);
        TestSet.PrintItemInSet(favOutput, "Fav1 = Fav1 Union Fav2");

        favOutput = new HashSet<int>(favNum1);
        favOutput.IntersectWith(favNum2);
        TestSet.PrintItemInSet(favOutput, "Fav1 = Fav 1 Intersect Fav2");

        favNum1.Add(17);

        favOutput = new HashSet<int>(favNum1);
        favOutput.ExceptWith(favNum2);
        TestSet.PrintItemInSet(favOutput, "Fav1 = Fav 1 minus Fav2");

        var sortedFav1 = new SortedSet<int>(favNum1);
        TestSet.PrintItemInSet(sortedFav1, "Sorted fav1 using sorted set");

        // Trying to add duplicate items


        if (!favNum1.Add(17))
        {
            Console.WriteLine("\nTried to add duplicate item in favNum1 17");
        }
        
        TestSet.PrintItemInSet(favNum1, "Numbers in Faverote set 1 after adding duplicate items");
        
                
                                        
    }
}