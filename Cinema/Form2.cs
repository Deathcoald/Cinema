using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Cinema
{
    public partial class Form2 : Form
    {
        private string selectedMovie;

<<<<<<< Updated upstream
        public Form2(string movieName)
        {
            InitializeComponent();
            selectedMovie = movieName;
            this.Text = $"Сеансы для фильма: {selectedMovie}";

            LoadSeansTimes();
        }

=======
>>>>>>> Stashed changes
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

        void create_seans_button(string time, ref int point_x, ref int point_y)
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
                Tag = time  
            };
<<<<<<< Updated upstream

=======
>>>>>>> Stashed changes
            
            seansButton.Click += (sender, e) => OnSeansButtonClick(sender, e, time);

            this.Controls.Add(seansButton);
            point_y += 60; 
        }

<<<<<<< Updated upstream
        
=======
>>>>>>> Stashed changes
        private void OnSeansButtonClick(object sender, EventArgs e, string time)
        {
            Form3 form3 = new Form3(time, selectedMovie);
            form3.Show();
        }

<<<<<<< Updated upstream
        
=======
>>>>>>> Stashed changes
        private void LoadSeansTimes()
        {
            string[] seans_time = ReadFile("timetable.txt");

            int point_x = 930;
            int point_y = 100;

            bool isMovieSection = false; 

            foreach (string s in seans_time)
            {
<<<<<<< Updated upstream
                
=======
>>>>>>> Stashed changes
                if (string.IsNullOrWhiteSpace(s))
                {
                    isMovieSection = false; 
                }

                if (s.StartsWith(selectedMovie))
                {
                    isMovieSection = true;
                    
                    Label cinema_name1 = new Label
                    {
<<<<<<< Updated upstream
                            Text = s,
                            Size = new System.Drawing.Size(300, 80),
                            Location = new System.Drawing.Point(870, 0),
                            Font = new System.Drawing.Font("Times New Roman", 25),
                            ForeColor = System.Drawing.Color.White,

                            TextAlign = ContentAlignment.MiddleCenter,
=======
                        Text = s,
                        Size = new System.Drawing.Size(300, 80),
                        Location = new System.Drawing.Point(870, point_y),  
                        Font = new System.Drawing.Font("Times New Roman", 25),
                        ForeColor = System.Drawing.Color.White,
                        TextAlign = ContentAlignment.MiddleCenter,
>>>>>>> Stashed changes
                    };
                    this.Controls.Add(cinema_name1);

                    point_y += 80; 

                    continue;
                }
                
                if (isMovieSection)
                {
                    string time = s;
                    create_seans_button(time, ref point_x, ref point_y);
<<<<<<< Updated upstream
                    isMovieSection = true; 
                }
            }
        }
=======
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
>>>>>>> Stashed changes
    }
}
