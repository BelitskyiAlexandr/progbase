using System;

namespace ads.matrix
{
    class Node
    {
        public int value;
        public int priority;
    }
    class Queue
    {
        public Node[] queue;
        public int size;

        public Queue()
        {
            queue = new Node[10];
            size = 3;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // Random rnd = new Random();

            // int[,] matrix = new int[5, 5];
            // for (int i = 0; i < matrix.GetLength(0); i++)
            // {
            //     for (int j = 0; j < matrix.GetLength(1); j++)
            //     {
            //         matrix[i, j] = rnd.Next(-3, 4);
            //         Console.Write("{0, 3}", matrix[i, j]);
            //     }
            //     Console.WriteLine();
            // }

            // Console.WriteLine("\n");

            // int[,] matrix1 = WithoutMarkers(matrix);
            // PrintMatrix(matrix1);

            // int[,] matrix2 = WithMarkers(matrix);
            // PrintMatrix(matrix2);
        
            Node node1 = new Node(){
                value = 3,
                priority = 1,
            };
            Node node2 = new Node(){
                value = 5,
                priority = 2,
            };
            Node node3 = new Node(){
                value = 7,
                priority = 3,
            };

            var queue = new Queue();
            queue.queue[0] = node2;
            queue.queue[1] = node3;
            queue.queue[2] = node1;
            
            
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
