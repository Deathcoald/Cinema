using System;
using System.Collections.Generic;
using System.IO;

namespace Cinema
{
    public class Zal
    {
        public bool[,] medium_hall { get; private set; }
        public int rows { get; set; }
        public int cols { get; set; }
        private string filterTime; 

        public Zal(int Rows, int Cols, string filePath, string Time)
        {
            rows = Rows;
            cols = Cols;
            filterTime = Time;  
            GenerateMatrices(filePath);
        }

        private void GenerateMatrices(string filePath)
        {
            medium_hall = new bool[rows, cols];
            FillMatrixFromFile(filePath);
        }

        private void FillMatrixFromFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Файл не найден.");
                return;
            }

            var lines = File.ReadAllLines(filePath);
            string currentTime = string.Empty;

            foreach (var line in lines)
            {
                if (line.StartsWith("Time:"))
                {
                    currentTime = line;

                    if (currentTime != $"Time: {filterTime}")
                    {
                        currentTime = string.Empty; 
                    }
                }
                else if (line.StartsWith("FIO:") && currentTime == $"Time: {filterTime}")
                {
                    var parts = line.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    string fio = parts[1];
                    int row = int.Parse(parts[3]) - 1;
                    int col = int.Parse(parts[5]) - 1;

                    if (row >= 0 && row < rows && col >= 0 && col < cols)
                    {
                        medium_hall[row, col] = true;  
                    }
                }
            }
        }
    }
}
