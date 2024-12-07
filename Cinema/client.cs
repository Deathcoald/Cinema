using System;
using System.IO;

namespace Cinema
{
    class Client
    {
        public string FIO { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }

        public Client(string fio, int row, int col)
        {
            FIO = fio;  
            Row = row;  
            Col = col;  
        }
        public void DisplayInfo()
        {
            Console.WriteLine($"ФИО: {FIO}, Ряд: {Row}, Место: {Col}");
        }
        public void SaveToFile(string filePath)
        {
            try
            {
                
                using (StreamWriter writer = new StreamWriter(filePath, true)) 
                {
                    writer.WriteLine($"ФИО: {FIO}, Ряд: {Row}, Место: {Col}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при записи в файл: {ex.Message}");
            }
        }
    }
}
