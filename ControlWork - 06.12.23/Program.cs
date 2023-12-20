//2 вариант

using System;
using System.IO;

class Matrix
{
    static void Main()
    {
        string filePath = "C:/Users/user/source/repos/ControlWork - 06.12.23/ControlWork - 06.12.23/File.txt";
        int height;
        int width;
        int[,] matrix;

        using (StreamReader sr = new StreamReader(filePath))
        {
            string[] dimensions = sr.ReadLine().Split();
            height = int.Parse(dimensions[0]);
            width = int.Parse(dimensions[1]);

            matrix = new int[height, width];

            for (int i = 0; i < height; i++)
            {
                string[] row = sr.ReadLine().Split();
                for (int j = 0; j < width; j++)
                {
                    matrix[i, j] = int.Parse(row[j]);
                }
            }
        }

        ShiftMatrix(matrix);

        Console.WriteLine("матрица после сдвига: ");
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    static void ShiftMatrix(int[,] matrix)
    {
        int height = matrix.GetLength(0);
        int width = matrix.GetLength(1);

        for (int i = 0; i < height; i++)
        {
            int[] rowNew = new int[width];
            for (int j = 0; j < width; j++)
            {
                rowNew[j] = matrix[i, j];
            }

            for (int j = 0; j < width; j++)
            {
                matrix[i, (j + (i + 2)) % width] = rowNew[j];
            }
        }
    }
}
