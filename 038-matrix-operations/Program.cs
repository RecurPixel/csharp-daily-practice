// **Concepts:** Multidimensional Arrays  
// - Input two 2D arrays.  
// - Perform addition, subtraction, multiplication.  
// 🧩 **Bonus:** Validate dimensions and handle exceptions.


class MatrixOperation
{
    int[,] matrix1;
    int[,] matrix2;
    
    
    public MatrixOperation(int rows, int columns)
    {
        matrix1 = new int[rows, columns];
        matrix2 = new int[rows, columns];
    }

    private void InputMatrix(int rows, int cols)
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write($"\nEnter value for [{i},{j}]: ");
                if (!int.TryParse(Console.ReadLine(), out int input))
                {
                    Console.WriteLine("invalid Input.");
                    return;
                }
                matrix1[i, j] = input;
            }
        }
    }

    private void Addition()
    {
        // Addition, Subtraction, Multiplication
    }

    private void ShowMatrix(int rows, int cols)
    {
        for (int i = 0; i < rows; i++)
        {
            Console.Write("\n|");
            for (int j = 0; j < cols; j++)
            {
                Console.Write($" {matrix1[i, j]}");
            }
            Console.Write(" |");
        }
        Console.WriteLine("\n");
    }
    
    
    public static void Main()
    {
        Console.Write("Enter No. of Rows: ");
        
        if(!int.TryParse(Console.ReadLine(), out int rows))
        {
            Console.WriteLine("invalid Input.");
            return;
        }
        Console.Write("Enter No. of Columns: ");

        if(!int.TryParse(Console.ReadLine(), out int cols))
        {
            Console.WriteLine("invalid Input.");
            return;
        }

        MatrixOperation mo = new MatrixOperation(rows, cols);

        mo.InputMatrix(rows, cols);
        mo.ShowMatrix(rows, cols);

        // Addition: same number of rows and columns in both matrix
        // Multiplication: row of one matrix shoud be same as colum of other matrix
        
    }
}