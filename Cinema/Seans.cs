using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;

namespace Cinema
{
    public class Seans
    {
        public Seans() { }  

        public Seans(string name, DateTime datetime)
        {
            Name = name;
            SeansDate = datetime;
            Tickets = new List<Ticket>();
        }

        public string Name { get; set; }  
        public DateTime SeansDate { get; set; }  
        public List<Ticket> Tickets { get; set; } = new List<Ticket>();

        public void AddTicket(Ticket ticket, List<Seans> seansList)
        {
            Tickets.Add(ticket);
            Cinema.SaveSeansToFile(seansList);
        }

        public static Seans FindSeans(List<Seans> seansList, DateTime seansDate, string name)
        {
            return seansList.FirstOrDefault(seans => seans.SeansDate == seansDate && seans.Name == name);
        }

        public static List<Seans> LoadSeansFromFile()
        {
            if (!File.Exists("seans.json"))
                return new List<Seans>();

            using (StreamReader reader = new StreamReader("seans.json"))
            {
                string json = reader.ReadToEnd();
                return JsonSerializer.Deserialize<List<Seans>>(json) ?? new List<Seans>();
            }
        }
    }
}
