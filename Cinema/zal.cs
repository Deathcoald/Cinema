using System;

namespace Cinema
{
    class Zal
    {
        public bool[,] small_hall { get; private set; }
        public bool[,] medium_hall { get; private set; }
        public bool[,] large_hall { get; private set; }

        public Zal()
        {
            GenerateMatrices();
        }

        private void GenerateMatrices()
        {
            Random random = new Random();

            small_hall = CreateRandomMatrix(10, 10, random); 

            medium_hall = CreateRandomMatrix(13, 13, random); 

            large_hall = CreateRandomMatrix(20, 20, random); 
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
