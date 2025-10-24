// **Concepts:** Multidimensional Arrays  
// - Input two 2D arrays.  
// - Perform addition, subtraction, multiplication.  
// 🧩 **Bonus:** Validate dimensions and handle exceptions.


class MatrixOperation
{
    int[,] matrix1;
    int[,] matrix2;

    private readonly int rows;
    private readonly int cols;
    
    
    public MatrixOperation(int inputRows, int inputCols)
    {
        rows = inputRows;
        cols = inputCols;
        matrix1 = new int[rows, cols];
        matrix2 = new int[rows, cols];
    }

    private void FillMatrix(int[,] matrix, string name)
    {
        int matrixRows = matrix.GetLength(0);
        int matrixCols = matrix.GetLength(1);

        Console.WriteLine($"\n----- Input {name} ({matrixRows}x{matrixCols}) -----");

        for (int i = 0; i < matrixRows; i++)
        {
            for (int j = 0; j < matrixCols; j++)
            {
                int input;
                bool validInput = false;

                // Input loop to ensure valid integer is entered
                do
                {
                    Console.Write($"Enter value for [{i},{j}]: ");
                    if (int.TryParse(Console.ReadLine(), out input))
                    {
                        matrix[i, j] = input;
                        validInput = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter an integer.");
                    }
                } while (!validInput);
            }
        }
    }
    
    private void InputMatrix(int rows, int cols)
    {
        FillMatrix(matrix1, "Matrix 1");
        FillMatrix(matrix2, "Matrix 2");
    }

    private void Multiplication()
    {
        
        int r1 = matrix1.GetLength(0); // Rows of M1
        int c1 = matrix1.GetLength(1); // Columns of M1 (Inner dimension)
        int r2 = matrix2.GetLength(0); // Rows of M2 (Inner dimension)
        int c2 = matrix2.GetLength(1); // Columns of M2

        // CRITICAL VALIDATION: Columns of M1 must equal Rows of M2
        if (c1 != r2)
        {
            Console.WriteLine($"ERROR: Cannot perform Multiplication. M1 columns ({c1}) must equal M2 rows ({r2}).");
            return;
        }

        int[,] resultMatrix = new int[r1, c2];

        for (int i = 0; i < r1; i++)
        {
            // j: Iterates over the resulting columns (M2 columns)
            for (int j = 0; j < c2; j++)
            {
                // k: Iterates over the inner, shared dimension (c1 or r2)
                for (int k = 0; k < c1; k++) 
                {
                    resultMatrix[i, j] += matrix1[i, k] * matrix2[k, j];
                }
            }
        }

        ShowMatrix(resultMatrix, "\n-----Showing Mulitplication-----");
        
    }

    private void Addition()
    {

        if (matrix1.GetLength(0) != matrix2.GetLength(0) || matrix1.GetLength(1) != matrix2.GetLength(1))
        {
            Console.WriteLine("ERROR: Cannot perform Addition. Matrices must have identical dimensions.");
            return;
        }

        int[,] resultMatrix = new int[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                resultMatrix[i, j] = matrix1[i, j] + matrix2[i, j];
            }
        }

        ShowMatrix(resultMatrix, "\n-----Showing Addition-----");
    }

    private void Subtraction()
    {

        if (matrix1.GetLength(0) != matrix2.GetLength(0) || matrix1.GetLength(1) != matrix2.GetLength(1))
        {
            Console.WriteLine("ERROR: Cannot perform Subtraction. Matrices must have identical dimensions.");
            return;
        }

        int[,] resultMatrix = new int[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                resultMatrix[i, j] = matrix1[i, j] - matrix2[i, j];
            }
        }
        
        ShowMatrix(resultMatrix, "\n-----Showing Subtraction-----");
    }


    private void ShowMatrix(int[,] matrix, string name)
    {

        Console.WriteLine(name);
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            Console.Write("\n|");
            for (int j = 0; j < cols; j++)
            {
                Console.Write($" {matrix[i, j]}");
            }
            Console.Write(" |");
        }
        Console.WriteLine("\n");
    }


    public static void Main()
    {
        try
        {
            Console.WriteLine("--- Matrix Calculator Setup ---");

            if (!GetDimension("Rows", out int rows) || !GetDimension("Columns", out int cols))
            {
                Console.WriteLine("Matrix dimensions must be positive integers.");
                return;
            }

            MatrixOperation mo = new MatrixOperation(rows, cols);

            mo.InputMatrix(rows, cols);

            mo.Addition();
            mo.Subtraction();
            mo.Multiplication();
        }
        catch (OutOfMemoryException)
        {
            Console.WriteLine("\nFATAL ERROR: Matrices are too large to allocate memory.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nAN UNEXPECTED ERROR OCCURRED: {ex.Message}");
        }

    }
    
    private static bool GetDimension(string dimName, out int dimension)
    {
        Console.Write($"Enter No. of {dimName}: ");
        if (!int.TryParse(Console.ReadLine(), out dimension) || dimension <= 0)
        {
            dimension = 0;
            return false;
        }
        return true;
    }
}