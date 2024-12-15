using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Cinema
{
    public partial class Form3 : Form
    {
        private Zal zal;

        private DateTime Time;
        private string selectedMovie;

        public void create_seat_button(int row, int col, int point_x, int point_y, bool isOccupied)
        {
            Button seatButton = new Button
            {
                Size = new Size(25, 25),
                Location = new Point(point_x, point_y),
                Font = new Font("Times New Roman", 12),
                ForeColor = isOccupied ? Color.White : Color.Black,
                BackColor = isOccupied ? Color.Red : Color.LightGreen,
                TextAlign = ContentAlignment.MiddleCenter,
                Tag = (row, col)
            };

            seatButton.Click += (sender, e) =>
            {
                Button clickedButton = sender as Button;
                var (seatRow, seatCol) = ((int, int))clickedButton.Tag;

                if (isOccupied)
                {
                    MessageBox.Show($"Место занято!");
                }
                else
                {
                    Form4 form4 = new Form4(selectedMovie, Time, seatRow, seatCol, zal, seatButton);  
                    form4.Show();
                }
            };

            this.Controls.Add(seatButton);
        }

        public void create_scene(List<Ticket> tickets)
        {
            int start_x = 20;
            int start_y = 150;
            int padding = 30;
            
            zal.UpdateOccupiedSeats(tickets);

            for (int row = 0; row < Zal.Rows; row++)
            {
                for (int col = 0; col < Zal.Cols; col++)
                {
                    bool isOccupied = zal.IsSeatOccupied(row, col);
                    create_seat_button(row, col, start_x, start_y, isOccupied);
                    start_x += padding;
                }

                start_y += padding;
                start_x = 20;
            }
        }

        private void AddScreenLabel()
        {
            Label screenLabel = new Label
            {
                Text = "Экран",
                Size = new Size(200, 30), 
                Location = new Point(115, 10), 
                BackColor = Color.Gray,
                ForeColor = Color.White,
                Font = new Font("Arial", 14, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter
            };

            this.Controls.Add(screenLabel);
        }
        private Button GetSeatButton(int row, int col)
        {

            foreach (Control control in this.Controls)
            {
                if (control is Button seatButton)
                {
                    var (seatRow, seatCol) = ((int, int))seatButton.Tag;
                    if (seatRow == row && seatCol == col)
                    {
                        return seatButton;
                    }
                }
            }
            return null;  
        }
        public Form3(DateTime Time, string selectedMovie)
        {
            this.selectedMovie = selectedMovie;
            this.Time = Time;
            zal = new Zal();

            var seansList = Seans.LoadSeansFromFile();

            Seans seans = Seans.FindSeans(seansList, Time, selectedMovie);

            List<Ticket> tickets = seans != null ? seans.Tickets : new List<Ticket>();

            InitializeComponent();
            create_scene(tickets);
            AddScreenLabel();
            BaseFunc.create_close_button(this, 350, 550);
        }

    }
}
