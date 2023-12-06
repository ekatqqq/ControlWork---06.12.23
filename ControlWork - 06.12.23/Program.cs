//2 вариант

namespace controlworkmatrix
{
    class Matrix
    {
        static void Main(string[] args)
        {
            Shift matrixShift = new Shift();
            string file = "File.txt";

            matrixShift.ReadMatrix(file);
            Console.WriteLine("Исходная матрица:");
            matrixShift.PrintMatrix();

            matrixShift.ShiftRows();
            Console.WriteLine("Матрица после сдвига:");
            matrixShift.PrintMatrix();

            Console.ReadLine();
        }
    }
    class ReadMatrixFromFile
    {
        private int height;
        private int width;
        private int[,] matrix;

        public void ReadMatrix(string file)
        {
            string[] lines = File.ReadAllLines(file);

            string[] size = lines[0].Split(' ');
            height = int.Parse(size[0]);
            width = int.Parse(size[1]);
            matrix = new int[height, width];

            for (int i = 0; i < height; i++)
            {
                string[] row = lines[i + 1].Split(' ');
                for (int j = 0; j < width; j++)
                {
                    matrix[i, j] = int.Parse(row[j]);
                }
            }
        }
    }
    class Shift
    {
        private int height;
        private int width;
        private int[,] matrix;
        public void ShiftRows()
        {
            for (int i = 0; i < height; i++)
            {
                int[] shiftedRow = new int[width];
                for (int j = 0; j < width; j++)
                {
                    shiftedRow[(j + i + 1) % width] = matrix[i, j];
                }

                for (int j = 0; j < width; j++)
                {
                    matrix[i, j] = shiftedRow[j];
                }
            }
        }
        public void PrintMatrix()
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        internal void ReadMatrix(string file)
        {
            throw new NotImplementedException();
        }
    }
}
