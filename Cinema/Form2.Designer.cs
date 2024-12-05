using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Cinema
{
    public partial class Form2 : Form
    {
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

        void create_button_text(string line, ref int point_x, ref int point_y)
        {
            Label seansLabel = new Label();

            seansLabel.Text = line;
            seansLabel.Size = new System.Drawing.Size(400, 30);
            seansLabel.Location = new System.Drawing.Point(point_x, point_y);
            seansLabel.Font = new System.Drawing.Font("Times New Roman", 20);
            seansLabel.ForeColor = System.Drawing.Color.White;
            

            this.Controls.Add(seansLabel);

            point_y += 40;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();

            string[] seans_time = ReadFile("timetable.txt");

            int point_x = 500;
            int point_y = 100;

            foreach (string s in seans_time)
            {
                if (string.IsNullOrWhiteSpace(s))
                {
                    point_x += 400;
                    point_y = 100;
                }
                else
                {
                    this.create_button_text(s, ref point_x, ref point_y);
                }
            }

            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1920, 1000);
            this.Name = "Form2";
            this.Text = "Сеансы";

            this.ResumeLayout(false);
        }
    }
}
