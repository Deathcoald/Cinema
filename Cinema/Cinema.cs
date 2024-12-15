using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Cinema
{
    public class Cinema
    {
        public static List<Seans> SeansList = new List<Seans>();

        public static List<Seans> LoadSeansFromFile()
        {
            if (!File.Exists("seans.json"))
                return new List<Seans>();

            using (StreamReader reader = new StreamReader("seans.json"))
            {
                string json = reader.ReadToEnd();
                return JsonSerializer.Deserialize<List<Seans>>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true 
                }) ?? new List<Seans>();
            }
        }


        public static void SaveSeansToFile(List<Seans> seansList)
        {
            string json = JsonSerializer.Serialize(seansList, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("seans.json", json);
        }

        public static void AddTicketToSeans(Ticket ticket, DateTime seansDate, string Name)
        {
            if (SeansList.Count == 0)
            {
                LoadSeansFromFile();
            }
            Seans seans = Seans.FindSeans(SeansList, seansDate, Name);

            if (seans == null)
            {
                seans = new Seans(Name, seansDate);
                SeansList.Add(seans);
            }
            seans.AddTicket(ticket, SeansList);
        }
    }
}
