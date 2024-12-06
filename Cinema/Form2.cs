using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Cinema
{
    public partial class Form2 : Form
    {
        private string selectedMovie;

        

        static string[] ReadFile(string filePath)
        {
            try
            {
                return File.ReadAllLines(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при чтении файла: " + ex.Message);
                return new string[] { };
            }
        }

        public void create_seans_button(string time, ref int point_x, ref int point_y)
        {
            Button seansButton = new Button
            {
                Text = time,
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


        private void OnSeansButtonClick(object sender, EventArgs e, string time)
        {
            Form3 form3 = new Form3();

            form3.Show();
        }


        private void LoadSeansTimes()
        {
            string[] seans_time = ReadFile("timetable.txt");

            int point_x = 930;
            int point_y = 100;

            bool isMovieSection = false;

            foreach (string s in seans_time)
            {

                if (string.IsNullOrWhiteSpace(s))
                {
                    isMovieSection = false;
                }

                if (s.StartsWith(selectedMovie))
                {
                    isMovieSection = true;

                    Label cinema_name1 = new Label
                    {
                        Text = s,
                        Size = new System.Drawing.Size(300, 80),
                        Location = new System.Drawing.Point(870, 0),
                        Font = new System.Drawing.Font("Times New Roman", 25),
                        ForeColor = System.Drawing.Color.White,

                        TextAlign = ContentAlignment.MiddleCenter,
                    };
                    this.Controls.Add(cinema_name1);

                    continue;
                }

                if (isMovieSection)
                {
                    string time = s;
                    create_seans_button(time, ref point_x, ref point_y);
                    isMovieSection = true;
                }
            }
        }

            public Form2(string movieName)
        {
            InitializeComponent();
            selectedMovie = movieName;
            this.Text = $"Сеансы для фильма: {selectedMovie}";
            BaseFunc.create_close_button(this, 1820, 10);
            LoadSeansTimes();
        }
        
        
    }
}
