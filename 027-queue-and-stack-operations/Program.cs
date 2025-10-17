// * Create a menu-driven console app that:

//   * Adds elements
//   * Removes elements
//   * Views elements
// * Demonstrate FIFO vs LIFO behavior.

// **📝 Bonus:**
// Handle invalid removal attempts with try-catch.

// Note: This code be improved further but that is not our goal right now. We are focussing on learning.


class QueueAndStack
{

    private static int GetValidIntInput()
    {
        int input;
        while (!int.TryParse(Console.ReadLine(), out input))
        {
            Console.WriteLine("Enter Valid Input: ");
        }
        return input;

    }

    protected static void QueueOperatoin()
    {
        Queue<int> intQueue = new Queue<int>();

        int choice;
        bool continueOperation = true;

        do
        {
            Console.WriteLine("Queue Operation");
            Console.WriteLine("Add: 1");
            Console.WriteLine("Remove: 2");
            Console.WriteLine("Peek: 3");
            Console.WriteLine("Print and Exit: Any Key");

            choice = GetValidIntInput();
            if (choice == 1)
            {
                Console.Write("Enter a number: ");
                choice = GetValidIntInput();
                intQueue.Enqueue(choice);

                Console.WriteLine("Updated Queue: ");
                foreach (int i in intQueue)
                {
                    Console.Write("{0} ", i);
                }
            }
            else if (choice == 2)
            {
                try
                {
                    Console.WriteLine("\n Removed {0}", intQueue.Dequeue());
                    Console.WriteLine("Updated Queue: ");
                    foreach (int i in intQueue)
                    {
                        Console.Write("{0} ", i);
                    }
                }
                catch (InvalidOperationException)
                {
                    Console.WriteLine("Nothing to Remove Empty Queue");
                }
            }
            else if (choice == 3)
            {
                Console.WriteLine("\n Top item {0}", intQueue.Peek());
            }
            else
            {
                Console.Write("Queue Items: ");
                foreach (int i in intQueue)
                {
                    Console.Write("{0} ", i);
                }
                Console.WriteLine("");
                continueOperation = false;
            }
        } while (continueOperation);

    }

    protected static void StackOperatoin()
    {
        Stack<int> intStack = new Stack<int>();

        int choice;
        bool continueOperation = true;

        do
        {
            Console.WriteLine("Stack Operation");
            Console.WriteLine("Push: 1");
            Console.WriteLine("Pop: 2");
            Console.WriteLine("Peek: 3");
            Console.WriteLine("Print and Exit: Any Key");
            choice = GetValidIntInput();

            if (choice == 1)
            {
                Console.Write("Enter a number: ");
                choice = GetValidIntInput();

                intStack.Push(choice);

                Console.Write("Updated Stack Items: ");
                foreach (int i in intStack)
                {
                    Console.Write(" {0}", i);
                }
                Console.WriteLine("");
            }
            else if (choice == 2)
            {
                try
                {
                    Console.WriteLine("\n Pop {0}", intStack.Pop());
                    Console.Write("Updated Stack Items: ");
                    foreach (int i in intStack)
                    {
                        Console.Write("{0} ", i);
                    }
                }
                catch (InvalidOperationException)
                {
                    Console.Write("\nNothing to remove Empty Stack");
                }
            }
            else if (choice == 3)
            {
                Console.WriteLine("\n Top item {0}", intStack.Peek());
            }
            else
            {
                Console.Write("\nStack Items: ");
                foreach (int i in intStack)
                {
                    Console.Write("{0} ", i);
                }
                continueOperation = false;
            }
        } while (continueOperation);


    }

    public static void Main(string[] args)
    {
        int choice;
        bool exitLoop = true;

        do
        {
            Console.WriteLine("\nSelect Data Structure to Test");
            Console.WriteLine("Queue: 1");
            Console.WriteLine("Stack: 2");
            Console.WriteLine("Quit: Any Key");
            choice = GetValidIntInput();

            if (choice == 1)
            {
                QueueOperatoin();
            }
            else if (choice == 2)
            {
                StackOperatoin();
            }
            else
            {
                Console.WriteLine("Good Bye!");
                exitLoop = false;
            }
        } while (exitLoop);
    }
}