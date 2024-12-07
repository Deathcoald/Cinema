using System;
using System.Windows.Forms;

namespace Cinema
{
    public class Zal
    {
        public bool[,] medium_hall { get; private set; }
        public int rows { get; set; }
        public int cols { get; set; }

        public Zal(int Rows, int Cols)
        {
            rows = Rows;
            cols = Cols;

            GenerateMatrices();
        }

        private void GenerateMatrices()
        {
            Random random = new Random();

            medium_hall = CreateRandomMatrix(rows, cols, random); 

        }

        private bool[,] CreateRandomMatrix(int rows, int cols, Random random)
        {
            bool[,] matrix = new bool[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = random.Next(2) == 1;
                }
            }

            return matrix;
        }

    }
}
