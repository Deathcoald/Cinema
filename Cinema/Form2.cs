using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Cinema
{
    public partial class Form2 : Form
    {
        private string selectedMovie;
        private DateTime Time;

        public void create_seans_button(DateTime time, ref int point_x, ref int point_y)
        {
            Button seansButton = new Button
            {
                Text = time.ToString("HH:mm"),
                Size = new System.Drawing.Size(200, 50),
                Location = new System.Drawing.Point(point_x, point_y),
                Font = new System.Drawing.Font("Times New Roman", 18),
                ForeColor = System.Drawing.Color.Black,
                BackColor = System.Drawing.Color.White,

                TextAlign = ContentAlignment.MiddleCenter,
            };


            seansButton.Click += (sender, e) => OnSeansButtonClick(sender, e, time);

            this.Controls.Add(seansButton);
            point_y += 60;
        }


        private void OnSeansButtonClick(object sender, EventArgs e, DateTime time)
        {
            Time = time;

            Form3 form3 = new Form3(Time, selectedMovie);

            form3.Show();
        }


        private void LoadSeansTimes()
        {
            int point_x = 50;
            int point_y = 150;
            DateTime? lastDate = null;

            BaseFunc.createText(this, selectedMovie, 200, 50, 930, 50, 18);

            var sortedTimes = File.ReadLines($"{selectedMovie}_timetable.txt")
                                   .Where(line => !string.IsNullOrWhiteSpace(line)) 
                                   .Select(line => DateTime.ParseExact(line.Trim(), "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture))  
                                   .OrderBy(time => time) 
                                   .ToList();  

            foreach (DateTime time in sortedTimes)
            {
                if (!lastDate.HasValue || lastDate.Value.ToString("yyyy-MM-dd") != time.ToString("yyyy-MM-dd"))
                {
                    lastDate = time;
                    point_x += 200;  
                    point_y = 150; 
                    BaseFunc.createText(this, time.ToString("yyyy-MM-dd"), 200, 50, point_x, 100, 18);
                }

                create_seans_button(time, ref point_x, ref point_y);
            }
        }




        public Form2(string movieName)
        {
            selectedMovie = movieName;

            InitializeComponent();         
            this.Text = $"Сеансы для фильма: {selectedMovie}";
            BaseFunc.create_close_button(this, 1820, 10);
            LoadSeansTimes();
        }
        
        
    }
}
