using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Cinema
{
    class Client
    {
        public string FIO { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }
        public string MovieName { get; set; }
        public string Time { get; set; }

        public Client(string time, string fio, int row, int col)
        {
            FIO = fio;
            Row = row;
            Col = col;
            Time = time;
        }

        public void SaveToFile(string filePath)
        {
            List<string> fileLines = new List<string>();

            if (File.Exists(filePath))
            {
                fileLines = File.ReadAllLines(filePath).ToList();
            }
            int timeLineIndex = fileLines.FindIndex(line => line.Contains($"Time: {this.Time}"));

            if (timeLineIndex == -1)
            {
                fileLines.Add($"Time: {this.Time}");
                timeLineIndex = fileLines.Count - 1;
            }
            fileLines.Insert(timeLineIndex + 1, $"FIO: {this.FIO}, row: {this.Row + 1}, col: {this.Col + 1}");

            File.WriteAllLines(filePath, fileLines);
        }
    }
}
