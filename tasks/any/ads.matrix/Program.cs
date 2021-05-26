using System;

namespace ads.matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Random rnd = new Random();

            int[,] matrix = new int[5, 5];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = rnd.Next(-3, 4);
                    Console.Write("{0, 3}", matrix[i, j]);
                }
                Console.WriteLine();
            }

            Console.WriteLine("\n");

            int[,] matrix1 = WithoutMarkers(matrix);
            PrintMatrix(matrix1);

            int[,] matrix2 = WithMarkers(matrix);
            PrintMatrix(matrix2);
        }

        static int[,] WithMarkers(int[,] matrix)
        {
            bool[] markers = new bool[matrix.GetLength(0)];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i == j && matrix[i, j] > 0)
                    {
                       markers[i] = true;
                    }
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (markers[i])
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (matrix[i, j] > 0)
                        {
                            matrix[i, j] = 1;
                        }
                        else if (matrix[i, j] < 0)
                        {
                            matrix[i, j] = -1;
                        }
                    }
                }  
            }
            return matrix;

        }
        static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("{0, 3}", matrix[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n");
        }
        static int[,] WithoutMarkers(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i == j && matrix[i, j] > 0)
                    {
                        for (int k = 0; k < matrix.GetLength(1); k++)
                        {
                            if (matrix[i, k] > 0)
                            {
                                matrix[i, k] = 1;
                            }
                            else if (matrix[i, k] < 0)
                            {
                                matrix[i, k] = -1;
                            }
                        }
                    }
                }
            }
            return matrix;
        }
    }
}
